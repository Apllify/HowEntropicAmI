using System.Diagnostics;

namespace HowEntropicAmI
{
	public partial class MainForm : Form
	{

		public MainForm()
		{
			InitializeComponent();

			//we become the error handler
			Shown += (_, _) =>
			{
				Error.ErrorEvent += OnError;
				//check if error happened before us ?
				if (Error.CurrentErr != "")
				{
					OnError(Error.CurrentErrType, Error.CurrentErr);
				}
			};

			Closing += (_, _) =>
			{
				Error.ErrorEvent -= OnError;
			};

			//run freq dict computation for CBF
			BruteForce.BuildFreqDict(@"D:\Programmation\C#\HowEntropicAmI\HowEntropicAmI\rawdata\100k-most-used-passwords-NCSC.txt");
			DictionaryAttack.BuildImpersonalTokens(@"D:\Programmation\C#\HowEntropicAmI\HowEntropicAmI\rawdata\common-words.txt");


		}



		/// <summary>
		/// Creates the end user message for an entropy amount
		/// </summary>
		/// <param name="entropy"></param>
		/// <returns></returns>
		private string entropyMessage(double entropy)
		{
			return $"{entropy:0.00} bit(s) of entropy";
		}

		private void ShowWarning(string message)
		{
			errorLabel.Text = $"Warning : {message}.";
			errorLabel.ForeColor = Color.Goldenrod;
		}

		private void ShowError(string message)
		{
			errorLabel.Text = $"Error : {message} !";
			errorLabel.ForeColor = Color.DarkRed;
		}

		private void OnError(Error.ErrorType type, string message)
		{
			if (type == Error.ErrorType.Error)
			{
				ShowError(message);
			}
			else if (type == Error.ErrorType.Warning)
			{
				ShowWarning(message);
			}
		}

		private void passwordConfirmButton_Click(object sender, EventArgs e)
		{
			string pword = passwordInput.Text;

			//restrict our alphabet to match
			Config.RestrictAlphabet(pword);

			//check for illegal characters
			bool pwordValid = Config.IsPwordValid(pword);
			if (!pwordValid)
			{
				Error.EmitError(Error.ErrorType.Error,
								"password contains illegal characters");
				return;
			}

			//run all the computation here
			double bfEntropy = BruteForce.BFEntropy(pword);
			double cbfEntropy = BruteForce.WeightedBFEntropy(pword);
			double daEntropy = DictionaryAttack.ImpersonalEntropy(pword);
			double idaEntropy = DictionaryAttack.PersonalEntropy(pword);

			//show results to the user
			bfEntropyLabel.Text = entropyMessage(bfEntropy);
			cbfEntropyLabel.Text = entropyMessage(cbfEntropy);
			daEntropyLabel.Text = entropyMessage(daEntropy);
			idaEntropyLabel.Text = entropyMessage(idaEntropy);

			//display the worst case
			double worstEntropy = new double[] { bfEntropy, cbfEntropy, daEntropy, idaEntropy }.Min();
			worstCaseCountLabel.Text = entropyMessage(worstEntropy);

		}
	}
}