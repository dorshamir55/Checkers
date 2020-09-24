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
			this.labelPlayer1Score = new System.Windows.Forms.Label();
			this.labelPlayer2Score = new System.Windows.Forms.Label();
			this.panelBoard = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// labelPlayer1Score
			// 
			this.labelPlayer1Score.AutoSize = true;
			this.labelPlayer1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.labelPlayer1Score.Location = new System.Drawing.Point(60, 9);
			this.labelPlayer1Score.Name = "labelPlayer1Score";
			this.labelPlayer1Score.Size = new System.Drawing.Size(93, 17);
			this.labelPlayer1Score.TabIndex = 0;
			this.labelPlayer1Score.Text = "Player1Score";
			// 
			// labelPlayer2Score
			// 
			this.labelPlayer2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPlayer2Score.AutoSize = true;
			this.labelPlayer2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
			this.labelPlayer2Score.Location = new System.Drawing.Point(229, 9);
			this.labelPlayer2Score.Name = "labelPlayer2Score";
			this.labelPlayer2Score.Size = new System.Drawing.Size(93, 17);
			this.labelPlayer2Score.TabIndex = 0;
			this.labelPlayer2Score.Text = "Player2Score";
			// 
			// panelBoard
			// 
			this.panelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelBoard.BackColor = System.Drawing.SystemColors.Control;
			this.panelBoard.Location = new System.Drawing.Point(15, 42);
			this.panelBoard.Margin = new System.Windows.Forms.Padding(0);
			this.panelBoard.Name = "panelBoard";
			this.panelBoard.Size = new System.Drawing.Size(304, 304);
			this.panelBoard.TabIndex = 1;
			// 
			// FormGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 361);
			this.Controls.Add(this.panelBoard);
			this.Controls.Add(this.labelPlayer2Score);
			this.Controls.Add(this.labelPlayer1Score);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "FormGame";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Checkers";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelPlayer1Score;
		private System.Windows.Forms.Label labelPlayer2Score;
		private System.Windows.Forms.Panel panelBoard;
	}
}