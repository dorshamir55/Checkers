using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex02;

namespace CheckersUI
{
	public partial class FormGame : Form
	{
		//private const int k_SquareSize = 40;
		private SquareButton[,] m_buttonsMatrix;

		public FormGame(int i_BoardSize, Player i_Player1, Player i_Player2)
		{
			InitializeComponent();

			initializeBoard(i_BoardSize);
			initializeNameAndScores(i_Player1, i_Player2);
		}

		private void initializeNameAndScores(Player i_Player1, Player i_Player2)
		{
			labelPlayer1Score.Text = string.Format("{0}: {1}",
			i_Player1.Name,
			i_Player1.Score);
			labelPlayer2Score.Text = string.Format("{0}: {1}",
			i_Player2.Name,
			i_Player2.Score);
		}

		private void initializeBoard(int i_BoardSize)
		{
			m_buttonsMatrix = new SquareButton[i_BoardSize, i_BoardSize];

			for (int row = 0; row < i_BoardSize; row++)
			{
				for (int col = 0; col < i_BoardSize; col++)
				{
					SquareButton squareButton = createSquare(row, col, i_BoardSize);
					m_buttonsMatrix[row, col] = squareButton;
					panelBoard.Controls.Add(squareButton);
				}
			}

			//this.Size = new Size(i_BoardSize * k_SquareSize, i_BoardSize * k_SquareSize + 5 * labelPlayer1Score.Bottom);
			//this.FormBorderStyle = FormBorderStyle.FixedDialog;
		}

		private SquareButton createSquare(int i_Row, int i_Col, int i_BoardSize)
		{
			Point point = new Point(i_Row, i_Col);
			SquareButton squareButton = new SquareButton(point);
			squareButton.Margin = Padding.Empty;
			squareButton.Size = new Size(panelBoard.Width/i_BoardSize, panelBoard.Height / i_BoardSize);
			squareButton.Location = new Point(squareButton.Width * i_Row, squareButton.Height * i_Col);
			squareButton.BackColor = getBackColor(i_Row, i_Col);
			squareButton.Enabled = isEnabledSquareButton(i_Row, i_Col);
			squareButton.Text = getSquareSign(i_Row, i_Col, i_BoardSize);
			squareButton.Font = new Font(squareButton.Font, FontStyle.Bold);
			return squareButton;
		}

		private bool isEnabledSquareButton(int i_Row, int i_Col)
		{
			bool enabled = true;

			if (i_Row % 2 == 0 && i_Col % 2 == 0 || i_Row % 2 != 0 && i_Col % 2 != 0)
			{
				enabled = false;
			}

			return enabled;
		}

		private string getSquareSign(int i_Row, int i_Col, int i_BoardSize)
		{
			string sign = string.Empty;

			if ((i_Row % 2 == 0 && i_Col % 2 != 0) || (i_Row % 2 != 0 && i_Col % 2 == 0))
			{
				if (i_Col < (i_BoardSize / 2) - 1)
				{
					sign = "O";
				}
				else if (i_Col > i_BoardSize / 2)
				{
					sign = "X";
				}
			}

			return sign;
		}

		private Color getBackColor(int i_Row, int i_Col)
		{
			Color squareColor = new Color();

			if (i_Row % 2 == 0 && i_Col % 2 == 0 || i_Row % 2 != 0 && i_Col % 2 != 0)
			{
				squareColor = Color.DarkGray;
			}
			else
			{
				squareColor = Color.Beige;
			}

			return squareColor;
		}
	}
}
