namespace HowEntropicAmI
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			titleLabel = new Label();
			passwordInput = new TextBox();
			passwordConfirmButton = new Button();
			bfTitleLabel = new Label();
			bfEntropyLabel = new Label();
			errorLabel = new Label();
			SuspendLayout();
			// 
			// titleLabel
			// 
			titleLabel.Anchor = AnchorStyles.Top;
			titleLabel.AutoSize = true;
			titleLabel.BackColor = SystemColors.Control;
			titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
			titleLabel.Location = new Point(230, 32);
			titleLabel.Name = "titleLabel";
			titleLabel.Size = new Size(341, 46);
			titleLabel.TabIndex = 0;
			titleLabel.Text = "Enter your password :";
			// 
			// passwordInput
			// 
			passwordInput.Anchor = AnchorStyles.Top;
			passwordInput.Location = new Point(230, 100);
			passwordInput.Name = "passwordInput";
			passwordInput.Size = new Size(285, 27);
			passwordInput.TabIndex = 1;
			// 
			// passwordConfirmButton
			// 
			passwordConfirmButton.Anchor = AnchorStyles.Top;
			passwordConfirmButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			passwordConfirmButton.Location = new Point(539, 100);
			passwordConfirmButton.Name = "passwordConfirmButton";
			passwordConfirmButton.Size = new Size(46, 26);
			passwordConfirmButton.TabIndex = 2;
			passwordConfirmButton.Text = "Run";
			passwordConfirmButton.UseVisualStyleBackColor = true;
			passwordConfirmButton.Click += passwordConfirmButton_Click;
			// 
			// bfTitleLabel
			// 
			bfTitleLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			bfTitleLabel.AutoSize = true;
			bfTitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			bfTitleLabel.Location = new Point(82, 233);
			bfTitleLabel.Name = "bfTitleLabel";
			bfTitleLabel.Size = new Size(160, 35);
			bfTitleLabel.TabIndex = 3;
			bfTitleLabel.Text = "Brute Force : ";
			// 
			// bfEntropyLabel
			// 
			bfEntropyLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			bfEntropyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			bfEntropyLabel.ForeColor = SystemColors.GrayText;
			bfEntropyLabel.Location = new Point(65, 279);
			bfEntropyLabel.Name = "bfEntropyLabel";
			bfEntropyLabel.Size = new Size(177, 71);
			bfEntropyLabel.TabIndex = 4;
			bfEntropyLabel.Text = "---";
			bfEntropyLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// errorLabel
			// 
			errorLabel.Anchor = AnchorStyles.Top;
			errorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			errorLabel.ForeColor = Color.Goldenrod;
			errorLabel.Location = new Point(230, 140);
			errorLabel.Name = "errorLabel";
			errorLabel.Size = new Size(355, 59);
			errorLabel.TabIndex = 5;
			errorLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 505);
			Controls.Add(errorLabel);
			Controls.Add(bfEntropyLabel);
			Controls.Add(bfTitleLabel);
			Controls.Add(passwordConfirmButton);
			Controls.Add(passwordInput);
			Controls.Add(titleLabel);
			Name = "MainForm";
			Text = "How Entropic Am I ?";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label titleLabel;
		private TextBox passwordInput;
		private Button passwordConfirmButton;
		private Label bfTitleLabel;
		private Label bfEntropyLabel;
		private Label errorLabel;
	}
}