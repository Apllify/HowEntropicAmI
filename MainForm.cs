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
			};

			Closing += (_, _) =>
			{
				Error.ErrorEvent -= OnError;
			};

			//run freq dict computation for CBF
			BruteForce.BuildFreqDict(@"D:\Programmation\C#\HowEntropicAmI\HowEntropicAmI\rawdata\100k-most-used-passwords-NCSC.txt");
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

			//check password validity
			bool pwordValid = Config.IsPwordValid(pword);
			if (!pwordValid)
			{
				Error.EmitError(Error.ErrorType.Error,
								"password is not in specified character set");
				return;
			}

			//run all the computation here
			double bfEntropy = BruteForce.BFEntropy(pword);
			double cbfEntropy = BruteForce.WeightedBFEntropy(pword);

			//show results to the user
			bfEntropyLabel.Text = entropyMessage(bfEntropy);
			cbfEntropyLabel.Text = entropyMessage(cbfEntropy);

		}
	}
}