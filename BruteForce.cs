using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowEntropicAmI
{
	public static class BruteForce
	{
		public static Dictionary<char, int> FreqDict;

		/// <summary>
		/// Computes the entropy of a password 
		/// for a pure brute force method
		/// (i.e. try everything)
		/// </summary>
		public static double BFEntropy(string pword)
		{
			double posCount = Math.Pow(Config.Alphabet.Length, pword.Length);

			return Math.Log2(posCount);
		}


		private static void BuildFreqDict(string filename)
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


			//write to public freq dict
			FreqDict = freqDict;


		}

		/// <summary>
		/// Computes the entropy of a password 
		/// for a weighted brute force method
		/// (i.e. every char has a different prob frequency)
		/// </summary>
		public static double WeightedBFEntropy(string pword)
		{
			return 0;
		}
	}
}
