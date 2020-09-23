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
		private const int k_SquareSize = 40;
		private const int k_MarginWidthSpace = 30;
		private const int k_MarginHeightSpace = 15;
		//private SquareButton[,] m_ButtonsMatrix;
		private MatrixButtons<SquareButton> m_ButtonsMatrix;
		private GameLogic m_GameLogic;
		private SquareButton m_FromSquareButton;
		private List<SquareButton> m_ButtonsMovesList;

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
			this.BackColor = Color.SandyBrown;
			initializeBoard((int)i_GameLogic.GameBoard.Size);
			initializeNameAndScores(i_GameLogic.CurrentPlayer, i_GameLogic.WaitingPlayer);
			initializeGame();
		}

		private void initializeGame()
		{
			changeSquareButtonVisibility();
			m_ButtonsMovesList = new List<SquareButton>();
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
			this.ClientSize = new Size(i_BoardSize * k_SquareSize + k_MarginWidthSpace, i_BoardSize * k_SquareSize + panelBoard.Top + k_MarginHeightSpace);

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

			m_FromSquareButton = ButtonMatrix[1,0];
		}

		private void SquareButton_Click(object sender, EventArgs e)
		{
			string blank, move;
			SquareButton squareButtonChosen = sender as SquareButton;

			blank = string.Empty;
			if (squareButtonChosen.Text.Equals(""))
			{
				if (squareButtonChosen.CanMoveHere(m_ButtonsMovesList))
				{
					move = string.Format("{0}{1}>{2}{3}",
						(char)(m_FromSquareButton.Row + 'A'),
						(char)(m_FromSquareButton.Col + 'a'),
						(char)(squareButtonChosen.Row + 'A'),
						(char)(squareButtonChosen.Col + 'a'));

					if (m_GameLogic.IsValidMove(move, out blank))
					{
						MessageBox.Show("Update board");
						m_GameLogic.CheckRewardKing();
						m_GameLogic.GameBoard.SquareButtonValueChanged += GameBoard_SquareButtonValueChanged;
						m_GameLogic.RunMove(m_GameLogic.CurrentMove);
						changeButtonsMoveToWhite();
						//TODO: UpdateBoard...
						m_GameLogic.SwitchPlayersAndCreateNewMoves();
						if (m_GameLogic.IsNextPlayerTurn)
						{
							changeSquareButtonVisibility();
						}
						else
						{
							m_FromSquareButton = squareButtonChosen;
							m_FromSquareButton.BackColor = Color.LightBlue;
						}
						//m_ButtonsMovesList.Clear();
						//m_FromSquareButton = squareButtonChosen;
						//TODO: if eaten, Check for other skippings moves.
						//TODO: check for switch player.
					}
				}
				else
				{
					MessageBox.Show("Invalid move!");
				}
			}
			else
			{
				if (squareButtonChosen.IsPressed(m_FromSquareButton))
				{
					squareButtonChosen.BackColor = Color.Beige;
					changeButtonsMoveToWhite();
					m_ButtonsMovesList.Clear();
				}
				else
				{
					m_FromSquareButton.BackColor = Color.Beige;
					UpdateSelectedSquareButton(ref squareButtonChosen);
				}
			}
		}

		private void UpdateSelectedSquareButton(ref SquareButton squareButtonChosen)
		{
			changeButtonsMoveToWhite();
			squareButtonChosen.BackColor = Color.LightBlue;
			if (m_GameLogic.IsNeededToEat())
			{
				m_ButtonsMovesList.Clear();
				createButtonsMovesList(ref squareButtonChosen, m_GameLogic.CurrentPlayer.PlayerSkippingMoves);
				changeButtonsMoveToBlue();
			}
			else if (m_GameLogic.ThereIsRegularMoves())
			{
				createButtonsMovesList(ref squareButtonChosen, m_GameLogic.CurrentPlayer.PlayerRegularMoves);
				changeButtonsMoveToBlue();
			}

			m_FromSquareButton = squareButtonChosen;
		}

		private void GameBoard_SquareButtonValueChanged(string newSquareValue)
		{
			if (m_GameLogic.CurrentMove.IsSkipMove)
			{
				ButtonMatrix[m_GameLogic.CurrentMove.Eaten.Col, m_GameLogic.CurrentMove.Eaten.Row].Text = "";
				ButtonMatrix[m_GameLogic.CurrentMove.Eaten.Col, m_GameLogic.CurrentMove.Eaten.Row].Enabled = true;
			}

			m_FromSquareButton.Text = "";
			m_FromSquareButton.BackColor = Color.Beige;
			ButtonMatrix[m_GameLogic.CurrentMove.To.Col, m_GameLogic.CurrentMove.To.Row].Text = newSquareValue;
		}

		private void changeButtonsMoveToBlue()
		{
			foreach (SquareButton squareButtonTo in m_ButtonsMovesList)
			{
				squareButtonTo.BackColor = Color.Blue;
			}
		}

		private void changeButtonsMoveToWhite()
		{
			foreach (SquareButton squareButtonTo in m_ButtonsMovesList)
			{
				squareButtonTo.BackColor = Color.White;
			}
		}

		private void createButtonsMovesList(ref SquareButton i_SquareButtonChosen, List<Move> i_playerMoves)
		{
			m_ButtonsMovesList.Clear();
			foreach (Move possibleMove in i_playerMoves)
			{
				if (i_SquareButtonChosen.Row == possibleMove.From.Col &&
					i_SquareButtonChosen.Col == possibleMove.From.Row)
				{
					ButtonMatrix[possibleMove.To.Col, possibleMove.To.Row].BackColor = Color.Blue;
					m_ButtonsMovesList.Add(ButtonMatrix[possibleMove.To.Col, possibleMove.To.Row]);
				}
			}
		}

		private SquareButton createSquareButton(int i_Row, int i_Col, int i_BoardSize)
		{
			Point point = new Point(i_Row, i_Col);
			SquareButton squareButton = new SquareButton(point);
			squareButton.Size = new Size(k_SquareSize, k_SquareSize);
			squareButton.initializeSquareButtonDetails(i_Row, i_Col, i_BoardSize);
			
			return squareButton;
		}

		public void changeSquareButtonVisibility()
		{
			int newCol, boardSize = (int)m_GameLogic.GameBoard.Size;

			foreach (Square square in m_GameLogic.CurrentPlayer.PlayerSquares)
			{
				ButtonMatrix[square.Col, square.Row].Enabled = true;
			}

			foreach (Square square in m_GameLogic.WaitingPlayer.PlayerSquares)
			{
				ButtonMatrix[square.Col, square.Row].Enabled = false;
			}
		}
	}
}
