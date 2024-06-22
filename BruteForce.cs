using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowEntropicAmI
{
	public static class BruteForce
	{

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
