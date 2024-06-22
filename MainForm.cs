using System.Diagnostics;

namespace HowEntropicAmI
{
	public partial class MainForm : Form
	{

		public MainForm()
		{
			InitializeComponent();

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

		private void passwordConfirmButton_Click(object sender, EventArgs e)
		{
			string pword = passwordInput.Text;

			//check password validity
			bool pwordValid = Config.IsPwordValid(pword);
			if (!pwordValid)
			{
				ShowError("password is not in specified character set");
				return;
			}

			//run all the computation here
			double bfEntropy = BruteForce.BFEntropy(pword);

			//show results to the user
			bfEntropyLabel.Text = entropyMessage(bfEntropy);

		}
	}
}