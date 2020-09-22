using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
		//private SquareButton[,] m_ButtonsMatrix;
		private MatrixButtons<SquareButton> m_ButtonsMatrix;
		private GameLogic m_GameLogic;
		private SquareButton m_FromSquareButton;

		public MatrixButtons<SquareButton> ButtonMatrix
		{
			get
			{
				return m_ButtonsMatrix;
			}
		}

		public FormGame(GameLogic i_GameLogic)
		{
			InitializeComponent();

			m_GameLogic = i_GameLogic;
			initializeBoard((int)i_GameLogic.GameBoard.Size);
			initializeNameAndScores(i_GameLogic.CurrentPlayer, i_GameLogic.WaitingPlayer);
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
			m_ButtonsMatrix = new MatrixButtons<SquareButton>(i_BoardSize, i_BoardSize);

			for (int row = 0; row < i_BoardSize; row++)
			{
				for (int col = 0; col < i_BoardSize; col++)
				{
					SquareButton squareButton = createSquareButton(row, col, i_BoardSize);
					m_ButtonsMatrix[row, col] = squareButton;
					squareButton.Click += SquareButton_Click;
					panelBoard.Controls.Add(squareButton);
				}
			}

			m_FromSquareButton = m_ButtonsMatrix[0, 0];
		}

		private void SquareButton_Click(object sender, EventArgs e)
		{
			SquareButton squareButtonChosen = sender as SquareButton;
			string mySign, myKingSign;

			mySign = ((char)m_GameLogic.CurrentPlayer.PlayerColor).ToString();
			myKingSign = mySign == ((char)Square.ePlayerColor.White).ToString() ?
				((char)Square.ePlayerColor.WhiteKing).ToString() : ((char)Square.ePlayerColor.BlackKing).ToString();

			if (squareButtonChosen.Text.Equals("") ||
				!squareButtonChosen.Text.Equals(mySign) && !squareButtonChosen.Text.Equals(myKingSign))
			{
				MessageBox.Show("Please choose your squares!");
			}
			else
			{
				if (squareButtonChosen.BackColor == Color.LightBlue)
				{
					squareButtonChosen.BackColor = Color.White;
				}
				else 
				{
					m_FromSquareButton.BackColor = Color.White;
					m_FromSquareButton = squareButtonChosen;
					m_FromSquareButton.BackColor = Color.LightBlue;
					//TODO: Check moves
				}
			}
		}

		private SquareButton createSquareButton(int i_Row, int i_Col, int i_BoardSize)
		{
			Point point = new Point(i_Row, i_Col);
			SquareButton squareButton = new SquareButton(point);
			squareButton.Size = new Size(panelBoard.Width/i_BoardSize, panelBoard.Height / i_BoardSize);
			squareButton.initializeSquareButtonDetails(i_Row, i_Col, i_BoardSize);
			
			return squareButton;
		}
	}
}
