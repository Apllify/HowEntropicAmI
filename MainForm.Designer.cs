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
			components = new System.ComponentModel.Container();
			titleLabel = new Label();
			passwordInput = new TextBox();
			passwordConfirmButton = new Button();
			bfTitleLabel = new Label();
			bfEntropyLabel = new Label();
			errorLabel = new Label();
			cbfTitleLabel = new Label();
			cbfEntropyLabel = new Label();
			toolTip = new ToolTip(components);
			daTitleLabel = new Label();
			daEntropyLabel = new Label();
			idaTitleLabel = new Label();
			idaEntropyLabel = new Label();
			idaCustomizeButton = new Button();
			worstCaseTitleLabel = new Label();
			worstCaseCountLabel = new Label();
			SuspendLayout();
			// 
			// titleLabel
			// 
			titleLabel.Anchor = AnchorStyles.Top;
			titleLabel.BackColor = SystemColors.Control;
			titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
			titleLabel.Location = new Point(338, 32);
			titleLabel.Name = "titleLabel";
			titleLabel.Size = new Size(355, 46);
			titleLabel.TabIndex = 0;
			titleLabel.Text = "Enter your password :";
			titleLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// passwordInput
			// 
			passwordInput.Anchor = AnchorStyles.Top;
			passwordInput.Location = new Point(338, 100);
			passwordInput.Name = "passwordInput";
			passwordInput.Size = new Size(285, 27);
			passwordInput.TabIndex = 1;
			// 
			// passwordConfirmButton
			// 
			passwordConfirmButton.Anchor = AnchorStyles.Top;
			passwordConfirmButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
			passwordConfirmButton.Location = new Point(647, 100);
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
			bfTitleLabel.Location = new Point(27, 291);
			bfTitleLabel.Name = "bfTitleLabel";
			bfTitleLabel.Size = new Size(160, 35);
			bfTitleLabel.TabIndex = 3;
			bfTitleLabel.Text = "Brute Force : ";
			bfTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// bfEntropyLabel
			// 
			bfEntropyLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			bfEntropyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			bfEntropyLabel.ForeColor = SystemColors.GrayText;
			bfEntropyLabel.Location = new Point(27, 344);
			bfEntropyLabel.Name = "bfEntropyLabel";
			bfEntropyLabel.Size = new Size(160, 71);
			bfEntropyLabel.TabIndex = 4;
			bfEntropyLabel.Text = "---";
			bfEntropyLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// errorLabel
			// 
			errorLabel.Anchor = AnchorStyles.Top;
			errorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			errorLabel.ForeColor = Color.Goldenrod;
			errorLabel.Location = new Point(338, 140);
			errorLabel.Name = "errorLabel";
			errorLabel.Size = new Size(355, 94);
			errorLabel.TabIndex = 5;
			errorLabel.TextAlign = ContentAlignment.TopCenter;
			// 
			// cbfTitleLabel
			// 
			cbfTitleLabel.Anchor = AnchorStyles.Bottom;
			cbfTitleLabel.AutoSize = true;
			cbfTitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			cbfTitleLabel.Location = new Point(227, 291);
			cbfTitleLabel.Name = "cbfTitleLabel";
			cbfTitleLabel.Size = new Size(228, 35);
			cbfTitleLabel.TabIndex = 6;
			cbfTitleLabel.Text = "Clever Brute Force :";
			cbfTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// cbfEntropyLabel
			// 
			cbfEntropyLabel.Anchor = AnchorStyles.Bottom;
			cbfEntropyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			cbfEntropyLabel.ForeColor = SystemColors.GrayText;
			cbfEntropyLabel.Location = new Point(227, 344);
			cbfEntropyLabel.Name = "cbfEntropyLabel";
			cbfEntropyLabel.Size = new Size(228, 71);
			cbfEntropyLabel.TabIndex = 7;
			cbfEntropyLabel.Text = "---";
			cbfEntropyLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// daTitleLabel
			// 
			daTitleLabel.Anchor = AnchorStyles.Bottom;
			daTitleLabel.AutoSize = true;
			daTitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			daTitleLabel.Location = new Point(487, 291);
			daTitleLabel.Name = "daTitleLabel";
			daTitleLabel.Size = new Size(216, 35);
			daTitleLabel.TabIndex = 8;
			daTitleLabel.Text = "Dictionary Attack :";
			daTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// daEntropyLabel
			// 
			daEntropyLabel.Anchor = AnchorStyles.Bottom;
			daEntropyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			daEntropyLabel.ForeColor = SystemColors.GrayText;
			daEntropyLabel.Location = new Point(487, 344);
			daEntropyLabel.Name = "daEntropyLabel";
			daEntropyLabel.Size = new Size(206, 71);
			daEntropyLabel.TabIndex = 9;
			daEntropyLabel.Text = "---";
			daEntropyLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// idaTitleLabel
			// 
			idaTitleLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			idaTitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			idaTitleLabel.Location = new Point(749, 254);
			idaTitleLabel.Name = "idaTitleLabel";
			idaTitleLabel.Size = new Size(227, 108);
			idaTitleLabel.TabIndex = 10;
			idaTitleLabel.Text = "Personalized Dictionary Attack :";
			idaTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// idaEntropyLabel
			// 
			idaEntropyLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			idaEntropyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			idaEntropyLabel.ForeColor = SystemColors.GrayText;
			idaEntropyLabel.Location = new Point(749, 344);
			idaEntropyLabel.Name = "idaEntropyLabel";
			idaEntropyLabel.Size = new Size(227, 71);
			idaEntropyLabel.TabIndex = 11;
			idaEntropyLabel.Text = "---";
			idaEntropyLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// idaCustomizeButton
			// 
			idaCustomizeButton.Location = new Point(791, 235);
			idaCustomizeButton.Name = "idaCustomizeButton";
			idaCustomizeButton.Size = new Size(136, 29);
			idaCustomizeButton.TabIndex = 12;
			idaCustomizeButton.Text = "Customize";
			idaCustomizeButton.UseVisualStyleBackColor = true;
			// 
			// worstCaseTitleLabel
			// 
			worstCaseTitleLabel.Anchor = AnchorStyles.Bottom;
			worstCaseTitleLabel.AutoSize = true;
			worstCaseTitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			worstCaseTitleLabel.Location = new Point(207, 466);
			worstCaseTitleLabel.Name = "worstCaseTitleLabel";
			worstCaseTitleLabel.Size = new Size(301, 35);
			worstCaseTitleLabel.TabIndex = 13;
			worstCaseTitleLabel.Text = "Your worst case entropy : ";
			worstCaseTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// worstCaseCountLabel
			// 
			worstCaseCountLabel.Anchor = AnchorStyles.Bottom;
			worstCaseCountLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			worstCaseCountLabel.ForeColor = Color.Red;
			worstCaseCountLabel.Location = new Point(532, 450);
			worstCaseCountLabel.Name = "worstCaseCountLabel";
			worstCaseCountLabel.Size = new Size(206, 71);
			worstCaseCountLabel.TabIndex = 14;
			worstCaseCountLabel.Text = "---";
			worstCaseCountLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1017, 570);
			Controls.Add(worstCaseCountLabel);
			Controls.Add(worstCaseTitleLabel);
			Controls.Add(idaCustomizeButton);
			Controls.Add(idaEntropyLabel);
			Controls.Add(idaTitleLabel);
			Controls.Add(daEntropyLabel);
			Controls.Add(daTitleLabel);
			Controls.Add(cbfEntropyLabel);
			Controls.Add(cbfTitleLabel);
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
		private Label cbfTitleLabel;
		private Label cbfEntropyLabel;
		private ToolTip toolTip;
		private Label daTitleLabel;
		private Label daEntropyLabel;
		private Label idaTitleLabel;
		private Label idaEntropyLabel;
		private Button idaCustomizeButton;
		private Label worstCaseTitleLabel;
		private Label worstCaseCountLabel;
	}
}