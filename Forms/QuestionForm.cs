using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HowEntropicAmI.Forms
{
	public partial class QuestionForm : Form
	{
		public readonly static string[] inputNames =
		{
			"questionInput1",
			"questionInput2",
			"questionInput3",
			"questionInput4",
			"questionInput5",
			"questionInput6",
			"questionInput7",
			"questionInput8",
			"questionInput9",
		};


		public static string[] inputValues;

		static QuestionForm()
		{
			//todo : load previously stored values here
			inputValues = new string[inputNames.Length];
		}

		public QuestionForm()
		{
			InitializeComponent();

			//load the input values into their fields + set listeners
			for (int i = 0; i < inputNames.Length; i++)
			{
				string inputName = inputNames[i];

				//put the values of the inputs that we remember
				try
				{
					TextBox input = (TextBox)Controls.Find(inputName, true)[0];
					input.Text = inputValues[i];


					{
						int inputId = i;
						input.TextChanged += ((object e, EventArgs ee) => onInputChanged(inputId));

					}


				}
				catch
				{
					Error.EmitError(Error.ErrorType.Warning, "One of the input names is invalid in QuestionForm.cs");
				}


			}
		}

		private void onInputChanged(int inputId)
		{
			TextBox input = (TextBox)Controls.Find(inputNames[inputId], true)[0];
			inputValues[inputId] = input.Text;
		}


	}
}
