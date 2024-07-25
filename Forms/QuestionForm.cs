using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HowEntropicAmI.Forms
{
	public partial class QuestionForm : Form
	{
		const string savefileName = "persistent.dat";

		public readonly static (string, string)[] inputs =
		{
			("questionInput1", "text"),
			("questionInput2", "text"),
			("questionInput3", "date"),
			("questionInput4", "text"),
			("questionInput5", "email"),
			("questionInput6", "text"),
			("questionInput7", "text"),
			("questionInput8", "text"),
			("questionInput9", "text"),
		};


		public static string[] inputValues;

		static QuestionForm()
		{
			inputValues = new string[inputs.Length];
			LoadData();
		}

		public QuestionForm()
		{
			InitializeComponent();

			//load the input values into their fields + set listeners
			for (int i = 0; i < inputs.Length; i++)
			{
				string inputName = inputs[i].Item1;

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
			TextBox input = (TextBox)Controls.Find(inputs[inputId].Item1, true)[0];
			inputValues[inputId] = input.Text;
		}

		/// <summary>
		/// Generate and serialize our data in dict form
		/// </summary>
		public static void SaveData()
		{
			// generate the data dictionary
			Dictionary<string, string> saveData = new Dictionary<string, string>(inputs.Length);	
			for (int i = 0; i < inputs.Length; i++)
			{
				saveData[inputs[i].Item1] = inputValues[i];
 			}

			// now serialize it 
			string serialized = JsonSerializer.Serialize<Dictionary<string, string>>(saveData);

			using (StreamWriter stream = new StreamWriter(savefileName))
			{
				stream.Write(serialized);
			}

		}

		public static void LoadData()
		{
			// load the serialized data
			string serialized = null;
			try
			{
				using (StreamReader stream = new StreamReader(savefileName))
				{
					serialized = stream.ReadToEnd();
				}
			}
			catch(FileNotFoundException)
			{
				//file likely does not exist
				return;
			}
			catch
			{
				Error.EmitError(Error.ErrorType.Warning, $"Failed to load {savefileName}");
			}


			//convert to a dictionary
			if (serialized == null)
			{
				return;
			}
			Dictionary<string, string> saveData = JsonSerializer.Deserialize<Dictionary<string, string>>(serialized);


			//now store this info if the input name matches up
			foreach (string inputName in saveData.Keys)
			{
				(string, string) inputMatch = inputs.Where((inputTuple) => inputTuple.Item1 == inputName).FirstOrDefault();
				if (!inputMatch.Equals(default))
				{
					int inputId = Array.IndexOf(inputs, inputMatch);
					inputValues[inputId] = saveData[inputName];
				}
			}
		}


	}
}
