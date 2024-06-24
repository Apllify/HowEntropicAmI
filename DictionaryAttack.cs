using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HowEntropicAmI
{
	public static class DictionaryAttack
	{
		private static HashSet<string> impersonalTokens = new();
		private static HashSet<string> personalTokens = new();


		/// <summary>
		/// Builds the token hashset from the current 
		/// alphabet
		/// </summary>
		private static HashSet<string> getAlphabetTokens()
		{
			//append every current alphabet 
			HashSet<string> alphabetTokens = new();
			for (int i = 0; i < Config.AllAlphabets.Length; i++)
			{
				if (Config.ActiveAlphabets[i]) 
				{
					alphabetTokens.Append(Config.AllAlphabets[i]);
				}
			}

			return alphabetTokens;
		}


		/// <summary>
		/// Finds the largest valid token that can be 
		/// taken in the input word using the token list.
		/// </summary>
		/// <returns>(-1, "") if no token found </returns>
		private static (int, string) consumeToken(string word, HashSet<string> tokens)
		{
			//TODO : use TRIE approach here
			//check everything and keep longest match
			int bestLen = -1;
			string bestToken = "";
			foreach(string token in tokens)
			{
				if (word.StartsWith(token))
				{
					if (bestLen == -1 ||
						token.Length < bestLen)
					{
						bestLen = token.Length;
						bestToken = token;
					}
				}
			}

			return (bestLen, bestToken);
		}

		public static double ImpersonalEntropy(string password)
		{
			HashSet<string> tokens = new(getAlphabetTokens().Union(impersonalTokens));

			return 0;
		}

		public static double PersonalEntropy(string password)
		{
			HashSet<string> tokens = new(getAlphabetTokens().Union(personalTokens));

			return 0;
		}
	}
}
