using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowEntropicAmI
{
	public static class BruteForce
	{
		public static bool FreqDictDone = false;
		public static Dictionary<char, int> FreqDict;

		/// <summary>
		/// Computes the entropy of a password 
		/// for a pure brute force method
		/// (i.e. try everything)
		/// </summary>
		public static double BFEntropy(string pword)
		{
			//sum of geometric sequence with initial = 1, ratio = size alphabet
			double posCount = (1.0 - Math.Pow(Config.AlphabetSize, pword.Length+1)) /
							  (1.0 - Config.AlphabetSize);

			//remove u_0 = 1
			posCount--;

			return Math.Log2(posCount);
		}


		public static void BuildFreqDict(string filename)
		{
			//initialize dict with all 0s
			Dictionary<char, int> freqDict = new Dictionary<char, int>(200);

			for (int i = 0; i <  Config.AllAlphabets.Length; i++)
			{
				for (int j = 0; j < Config.AllAlphabets[i].Length; j++)
				{
					freqDict[Config.AllAlphabets[i][j]] = 0;
				}
			}

			//read all chars from file 
			try
			{
				FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				using (StreamReader reader = new StreamReader(fs))
				{
					while (!reader.EndOfStream)
					{
						char newchar = (char)reader.Read();
						if (freqDict.ContainsKey(newchar))
						{
							freqDict[newchar]++;
						}
					}
				}
			}
			catch
			{
				Error.EmitError(Error.ErrorType.Error, "could not build password freq dict");
			}

			//write to public freq dict
			FreqDict = freqDict;
			FreqDictDone = true;
		}

		/// <summary>
		/// Computes the entropy of a password 
		/// for a weighted brute force method
		/// (i.e. every char has a different prob frequency)
		/// </summary>
		public static double WeightedBFEntropy(string pword)
		{
			//check that the freq dict is already computed
			if (!FreqDictDone)
			{
				Thread.Sleep(3000);
				if (!FreqDictDone)
				{
					Error.EmitError(Error.ErrorType.Error, "freq dict not available");
				} 
			}
			//compute the total weight relevant to our alphabet 
			string curAlphabet = Config.Alphabet;
			double curAlphabetWeight = 0;

			foreach(char c in curAlphabet)
			{
				curAlphabetWeight += FreqDict[c];
			}


			//compute the probability of our current password char by char
			double prob = 1;
			foreach(char c in pword)
			{
				prob *= FreqDict[c] / curAlphabetWeight;
			}

			//convert to entropy bits
			return (Math.Log2(1.0 / prob));

		}
	}
}
