namespace CheckersUI
{
	partial class FormGame
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
			this.labelPlayer1Score = new System.Windows.Forms.Label();
			this.labelPlayer2Score = new System.Windows.Forms.Label();
			this.panelBoard = new System.Windows.Forms.Panel();
			this.pictureBoxDicePlayer1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxDicePlayer2 = new System.Windows.Forms.PictureBox();
			this.pictureBoxWhiteSign = new System.Windows.Forms.PictureBox();
			this.pictureBoxBlackSign = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDicePlayer1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDicePlayer2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWhiteSign)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlackSign)).BeginInit();
			this.SuspendLayout();
			// 
			// labelPlayer1Score
			// 
			this.labelPlayer1Score.AutoSize = true;
			this.labelPlayer1Score.BackColor = System.Drawing.Color.LightBlue;
			this.labelPlayer1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.labelPlayer1Score.Location = new System.Drawing.Point(58, 11);
			this.labelPlayer1Score.Name = "labelPlayer1Score";
			this.labelPlayer1Score.Size = new System.Drawing.Size(80, 15);
			this.labelPlayer1Score.TabIndex = 0;
			this.labelPlayer1Score.Text = "Player1Score";
			// 
			// labelPlayer2Score
			// 
			this.labelPlayer2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPlayer2Score.AutoSize = true;
			this.labelPlayer2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.labelPlayer2Score.Location = new System.Drawing.Point(238, 11);
			this.labelPlayer2Score.Name = "labelPlayer2Score";
			this.labelPlayer2Score.Size = new System.Drawing.Size(80, 15);
			this.labelPlayer2Score.TabIndex = 0;
			this.labelPlayer2Score.Text = "Player2Score";
			// 
			// panelBoard
			// 
			this.panelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelBoard.BackColor = System.Drawing.Color.Black;
			this.panelBoard.Location = new System.Drawing.Point(15, 42);
			this.panelBoard.Margin = new System.Windows.Forms.Padding(0);
			this.panelBoard.Name = "panelBoard";
			this.panelBoard.Size = new System.Drawing.Size(304, 304);
			this.panelBoard.TabIndex = 1;
			// 
			// pictureBoxDicePlayer1
			// 
			this.pictureBoxDicePlayer1.BackgroundImage = global::CheckersUI.Properties.Resources.dice_trolling;
			this.pictureBoxDicePlayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxDicePlayer1.Location = new System.Drawing.Point(12, 5);
			this.pictureBoxDicePlayer1.Name = "pictureBoxDicePlayer1";
			this.pictureBoxDicePlayer1.Size = new System.Drawing.Size(26, 26);
			this.pictureBoxDicePlayer1.TabIndex = 2;
			this.pictureBoxDicePlayer1.TabStop = false;
			// 
			// pictureBoxDicePlayer2
			// 
			this.pictureBoxDicePlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxDicePlayer2.BackgroundImage = global::CheckersUI.Properties.Resources.dice_trolling;
			this.pictureBoxDicePlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxDicePlayer2.Location = new System.Drawing.Point(190, 5);
			this.pictureBoxDicePlayer2.Name = "pictureBoxDicePlayer2";
			this.pictureBoxDicePlayer2.Size = new System.Drawing.Size(26, 26);
			this.pictureBoxDicePlayer2.TabIndex = 2;
			this.pictureBoxDicePlayer2.TabStop = false;
			this.pictureBoxDicePlayer2.Visible = false;
			// 
			// pictureBoxWhiteSign
			// 
			this.pictureBoxWhiteSign.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxWhiteSign.BackgroundImage")));
			this.pictureBoxWhiteSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxWhiteSign.Location = new System.Drawing.Point(38, 8);
			this.pictureBoxWhiteSign.Name = "pictureBoxWhiteSign";
			this.pictureBoxWhiteSign.Size = new System.Drawing.Size(20, 20);
			this.pictureBoxWhiteSign.TabIndex = 3;
			this.pictureBoxWhiteSign.TabStop = false;
			// 
			// pictureBoxBlackSign
			// 
			this.pictureBoxBlackSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxBlackSign.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxBlackSign.BackgroundImage")));
			this.pictureBoxBlackSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxBlackSign.Location = new System.Drawing.Point(216, 8);
			this.pictureBoxBlackSign.Name = "pictureBoxBlackSign";
			this.pictureBoxBlackSign.Size = new System.Drawing.Size(20, 20);
			this.pictureBoxBlackSign.TabIndex = 3;
			this.pictureBoxBlackSign.TabStop = false;
			// 
			// FormGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 361);
			this.Controls.Add(this.pictureBoxBlackSign);
			this.Controls.Add(this.pictureBoxWhiteSign);
			this.Controls.Add(this.pictureBoxDicePlayer1);
			this.Controls.Add(this.pictureBoxDicePlayer2);
			this.Controls.Add(this.panelBoard);
			this.Controls.Add(this.labelPlayer2Score);
			this.Controls.Add(this.labelPlayer1Score);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormGame";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Checkers";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDicePlayer1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDicePlayer2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWhiteSign)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlackSign)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelPlayer1Score;
		private System.Windows.Forms.Label labelPlayer2Score;
		private System.Windows.Forms.Panel panelBoard;
		private System.Windows.Forms.PictureBox pictureBoxDicePlayer2;
		private System.Windows.Forms.PictureBox pictureBoxDicePlayer1;
		private System.Windows.Forms.PictureBox pictureBoxWhiteSign;
		private System.Windows.Forms.PictureBox pictureBoxBlackSign;
	}
}