using HowEntropicAmI.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HowEntropicAmI
{
	public static class DictionaryAttack
	{
		public static HashSet<string> ImpersonalTokens = new();


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
					for (int j = 0; j < Config.AllAlphabets[i].Length; j++)
					{
						alphabetTokens.Add(Config.AllAlphabets[i][j].ToString());
					}
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
		private static List<string> tokenize(string word, HashSet<string> tokens)
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


		/// <summary>
		/// Returns common variations of the input word
		/// </summary>
		private static HashSet<string> wordVariants(string word)
		{
			
			string baseWord = word.ToLower();
			HashSet<string> variants = new(3);   
			
			//capitalization variants here
			variants.Add(baseWord);
			variants.Add(baseWord.ToUpper());
			variants.Add(new CultureInfo("en-US").TextInfo.ToTitleCase(baseWord));

			return variants;
		}


		/// <summary>
		/// Returns useful keyword variants from an email
		/// </summary>
		private static HashSet<string> emailVariants(string email)
		{
			//test if truly an email 
			MailAddress typedEmail;
			try
			{
				typedEmail = new MailAddress(email);
			}
			catch (FormatException e)
			{
				return new HashSet<string>();
			}


			//if so, return variants of the email username
			return wordVariants(typedEmail.User);
		}

		/// <summary>
		/// Returns useful keyword variants from a date
		/// </summary>
		private static HashSet<string> dateVariants(string date)
		{
			//test if truly a date 
			DateTime typedDate;
			try
			{
				typedDate = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
			}
			catch (FormatException e)
			{
				return new HashSet<string>();
			}

			
			HashSet<string> variants = new HashSet<string>();


			//get variants on month NAME
			variants.UnionWith(wordVariants(typedDate.ToString("MMM")));
			variants.UnionWith(wordVariants(typedDate.ToString("MMMM")));

			//get invididual components of the date
			variants.Add(typedDate.ToString("dd"));
			variants.Add(typedDate.ToString("MM"));
			variants.Add(typedDate.ToString("yyyy"));

			//get full date in us and european format
			variants.Add(typedDate.ToString("dd/MM/yyyy"));
			variants.Add(typedDate.ToString("MM/dd/yyyy"));

			return variants;


		}

		/// <summary>
		/// Retrieves the impersonal tokens list from a file.
		/// 1 line = 1 token.
		/// </summary>
		public static void BuildImpersonalTokens(string filename)
		{
			ImpersonalTokens.Clear();

			//read all words from file 
			try
			{
				FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				using (StreamReader reader = new StreamReader(fs))
				{
					while (!reader.EndOfStream)
					{
						string newWord = reader.ReadLine();
						if (newWord != "")
						{
							ImpersonalTokens.UnionWith(wordVariants(newWord));
						}
					}
				}
			}
			catch
			{
				Error.EmitError(Error.ErrorType.Error, "could not load impersonal tokens");
			}
		}

		public static double ImpersonalEntropy(string password)
		{
			HashSet<string> tokens = new HashSet<string>(ImpersonalTokens.Count +
														 Config.AlphabetSize);
			tokens.UnionWith(ImpersonalTokens);
			tokens.UnionWith(getAlphabetTokens()); 
			


			List<string> lexedPassword = tokenize(password, tokens);
			
			double posCount = Math.Pow(tokens.Count, lexedPassword.Count);

			return Math.Log2(posCount);
		}


		public static double PersonalEntropy(string password)
		{
			// add the boilerplate tokens
			HashSet<string> tokens = new HashSet<string>(ImpersonalTokens.Count + 
														 Config.AlphabetSize);
			tokens.UnionWith(ImpersonalTokens);
			tokens.UnionWith(getAlphabetTokens());

			// add the personal tokens wrt their types
			for (int i = 0; i < QuestionForm.inputs.Length; i++) 
			{
				string inputType = QuestionForm.inputs[i].Item2;
				string inputValue = QuestionForm.inputValues[i];

				if (inputValue == null || inputValue == "")
				{
					continue;
				}

				foreach (string personalWord in inputValue.Split(" "))
				{
					if (inputType == "text")
						tokens.UnionWith(wordVariants(personalWord));
					else if (inputType == "email")
						tokens.UnionWith(emailVariants(personalWord));
					else if (inputType == "date")
						tokens.UnionWith(dateVariants(personalWord));
				}

			}


			List<string> lexedPassword = tokenize(password, tokens);

			double posCount = Math.Pow(tokens.Count, lexedPassword.Count);

			return Math.Log2(posCount);
		}
	}
}
