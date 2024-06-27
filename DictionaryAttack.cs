using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HowEntropicAmI
{
	public static class DictionaryAttack
	{
		public static HashSet<string> impersonalTokens = new();
		public static HashSet<string> personalTokens = new();


		/// <summary>
		/// Builds the token hashset from the current 
		/// alphabet
		/// </summary>
		private static HashSet<string> getAlphabetTokens()
		{
			//append every current alphabet char
			HashSet<string> alphabetTokens = new(Config.AlphabetSize);
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
						token.Length > bestLen)
					{
						bestLen = token.Length;
						bestToken = token;
					}
				}
			}

			return (bestLen, bestToken);
		}



		/// <summary>
		/// Tokenize the input string with longest match selection
		/// </summary>
		private static List<string> parseString(string word, HashSet<string> tokens)
		{
			List<string> parsed = new();
			int curIndex = 0;

			while (curIndex < word.Length)
			{
				//get current match
				(int matchLen, string match) = consumeToken(word.Substring(curIndex), tokens); 

				//handle case where token list is does not span all possible words
				if (matchLen == -1)
				{
					Error.EmitError(Error.ErrorType.Error, "could not tokenize password");
					return new List<string>();
				}

				//add our match and move on
				parsed.Add(match);
				curIndex += matchLen;

			}

			return parsed;

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
