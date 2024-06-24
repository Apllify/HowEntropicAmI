using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowEntropicAmI
{
	static class Config
	{
		#region sub-alphabet definitions
		const string Lowercase =
			"abcdefghijklmnopqrstuvwxyz";

		const string Uppercase =
			"ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		const string Digits =
			"0123456789";

		const string Symbols =
			@"!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~";
		#endregion

		public static readonly string[] AllAlphabets =
			 { Lowercase, Uppercase, Digits, Symbols };

		public static bool[] ActiveAlphabets;


		//return a concatenation of active alphabets
		public static string Alphabet
		{
			get
			{
				//use string builder to avoid copies
				StringBuilder alphabet = new StringBuilder();

				for (int i = 0; i < AllAlphabets.Length; i++)
				{
					if (ActiveAlphabets[i])
					{
						alphabet.Append(AllAlphabets[i]);
					}
				}

				//stringify our result
				return alphabet.ToString();
			}
		}

		public static int AlphabetSize
		{
			get
			{
				int size = 0;
				for (int i = 0; i < AllAlphabets.Length; i++)
				{
					if (ActiveAlphabets[i]) size += AllAlphabets[i].Length;
				}

				return size;
			}
		}

		static Config()
		{
			//all alphabets active initially 
			ActiveAlphabets = new bool[AllAlphabets.Length];
			Array.Fill(ActiveAlphabets, true);
		}


		/// <summary>
		/// Checks whether a password is valid given
		/// the currently selected alphabet
		/// </summary>
		public static bool IsPwordValid(string pword)
		{
			string alphabet = Alphabet;

			foreach(char c in pword)
			{
				if (!alphabet.Contains(c)){
					return false;
				}
			}

			return true;
		}

	}
}
