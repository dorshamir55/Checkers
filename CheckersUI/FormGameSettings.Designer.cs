namespace CheckersUI
{
	partial class FormGameSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelBoardSize = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.labelPlayers = new System.Windows.Forms.Label();
			this.labelPlayer1 = new System.Windows.Forms.Label();
			this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
			this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
			this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
			this.buttonDone = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelBoardSize
			// 
			this.labelBoardSize.AutoSize = true;
			this.labelBoardSize.Location = new System.Drawing.Point(13, 13);
			this.labelBoardSize.Name = "labelBoardSize";
			this.labelBoardSize.Size = new System.Drawing.Size(59, 13);
			this.labelBoardSize.TabIndex = 0;
			this.labelBoardSize.Text = "Board size:";
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(24, 29);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(48, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "6 x 6";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(78, 29);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(48, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "8 x 8";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(132, 29);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(60, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "10 x 10";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// labelPlayers
			// 
			this.labelPlayers.AutoSize = true;
			this.labelPlayers.Location = new System.Drawing.Point(13, 49);
			this.labelPlayers.Name = "labelPlayers";
			this.labelPlayers.Size = new System.Drawing.Size(44, 13);
			this.labelPlayers.TabIndex = 0;
			this.labelPlayers.Text = "Players:";
			// 
			// labelPlayer1
			// 
			this.labelPlayer1.AutoSize = true;
			this.labelPlayer1.Location = new System.Drawing.Point(21, 71);
			this.labelPlayer1.Name = "labelPlayer1";
			this.labelPlayer1.Size = new System.Drawing.Size(48, 13);
			this.labelPlayer1.TabIndex = 0;
			this.labelPlayer1.Text = "Player 1:";
			// 
			// checkBoxPlayer2
			// 
			this.checkBoxPlayer2.AutoSize = true;
			this.checkBoxPlayer2.Location = new System.Drawing.Point(24, 96);
			this.checkBoxPlayer2.Name = "checkBoxPlayer2";
			this.checkBoxPlayer2.Size = new System.Drawing.Size(67, 17);
			this.checkBoxPlayer2.TabIndex = 4;
			this.checkBoxPlayer2.Text = "Player 2:";
			this.checkBoxPlayer2.UseVisualStyleBackColor = true;
			// 
			// textBoxPlayer1
			// 
			this.textBoxPlayer1.Location = new System.Drawing.Point(100, 68);
			this.textBoxPlayer1.Name = "textBoxPlayer1";
			this.textBoxPlayer1.Size = new System.Drawing.Size(92, 20);
			this.textBoxPlayer1.TabIndex = 3;
			// 
			// textBoxPlayer2
			// 
			this.textBoxPlayer2.Enabled = false;
			this.textBoxPlayer2.Location = new System.Drawing.Point(100, 94);
			this.textBoxPlayer2.Name = "textBoxPlayer2";
			this.textBoxPlayer2.Size = new System.Drawing.Size(92, 20);
			this.textBoxPlayer2.TabIndex = 5;
			this.textBoxPlayer2.Text = "[PC]";
			// 
			// buttonDone
			// 
			this.buttonDone.Location = new System.Drawing.Point(115, 125);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size(77, 23);
			this.buttonDone.TabIndex = 6;
			this.buttonDone.Text = "Done";
			this.buttonDone.UseVisualStyleBackColor = true;
			// 
			// formGameSettings
			// 
			this.AcceptButton = this.buttonDone;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(204, 161);
			this.Controls.Add(this.buttonDone);
			this.Controls.Add(this.textBoxPlayer2);
			this.Controls.Add(this.textBoxPlayer1);
			this.Controls.Add(this.checkBoxPlayer2);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.labelPlayer1);
			this.Controls.Add(this.labelPlayers);
			this.Controls.Add(this.labelBoardSize);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(220, 200);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(220, 200);
			this.Name = "formGameSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game settigns";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelBoardSize;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label labelPlayers;
		private System.Windows.Forms.Label labelPlayer1;
		private System.Windows.Forms.CheckBox checkBoxPlayer2;
		private System.Windows.Forms.TextBox textBoxPlayer1;
		private System.Windows.Forms.TextBox textBoxPlayer2;
		private System.Windows.Forms.Button buttonDone;
	}
}

