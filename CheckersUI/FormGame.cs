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
			m_GameLogic.GameBoard.BoardValueChanged += GameBoard_BoardValueChanged;
			initializeNameAndScores(i_GameLogic.CurrentPlayer, i_GameLogic.WaitingPlayer);
			initializeGame();
		}

		private void initializeGame()
		{
			Point point;
			SquareButton squareButtonChosen;
			Move firstPcMove = m_GameLogic.CurrentPlayer.GetPCMove((int)m_GameLogic.GameBoard.Size);

			point = new Point(firstPcMove.To.Col, firstPcMove.To.Row);
			squareButtonChosen = new SquareButton(point);
			switchSquareButtonVisibility(m_GameLogic.CurrentPlayer.IsComputer());
			m_ButtonsMovesList = new List<SquareButton>();
			
			//Check if work:
			if (m_GameLogic.CurrentPlayer.IsComputer())
			{
				runPcTurn(ref squareButtonChosen);
			}
			//
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

			m_FromSquareButton = ButtonMatrix[1, 0];
		}

		private void SquareButton_Click(object sender, EventArgs e)
		{
			SquareButton squareButtonChosen = sender as SquareButton;

			if (squareButtonChosen.Text.Equals(""))
			{
				if (squareButtonChosen.CanMoveTo(m_ButtonsMovesList))
				{
					performMove(ref squareButtonChosen);
				}
				else
				{
					if (m_GameLogic.IsNeededToEat())
					{
						MessageBox.Show("You must eat!");
					}
					else
					{
						MessageBox.Show("Invalid move!");
					}
				}
			}
			else
			{
				if (squareButtonChosen.IsPressed(m_FromSquareButton))
				{
					performWhenSquarePressed(ref squareButtonChosen);
				}
				else
				{
					performWhenSquareUnpressed(ref squareButtonChosen);
				}
			}
		}

		private void performWhenSquareUnpressed(ref SquareButton squareButtonChosen)
		{
			m_FromSquareButton.BackColor = Color.Beige;
			UpdateSelectedSquareButton(ref squareButtonChosen);
		}

		private void performWhenSquarePressed(ref SquareButton squareButtonChosen)
		{
			squareButtonChosen.BackColor = Color.Beige;
			changeButtonsMoveToWhite();
			m_ButtonsMovesList.Clear();
		}

		private void performMove(ref SquareButton squareButtonChosen)
		{
			string blank, move = string.Empty;

			move = getMove(squareButtonChosen);
			if (m_GameLogic.IsValidMove(move, out blank))
			{
				runMove();
				m_GameLogic.SwitchPlayersAndCreateNewMoves();
				if (m_GameLogic.IsNextPlayerTurn)
				{
					if (m_GameLogic.IsPcTurn())
					{
						runPcTurn(ref squareButtonChosen);
					}
					else
					{
						switchSquareButtonVisibility(m_GameLogic.CurrentPlayer.IsComputer());
						/*if (m_GameLogic.IsNeededToEat())
						{
							MessageBox.Show(string.Format("{0}, You must eat!", m_GameLogic.CurrentPlayer.Name));
							//Todo: blue backColor when needed to eat
						}*/
					}
				}
				else
				{
					prepareBoardForNextEat(ref squareButtonChosen);
				}
			}

			checkGameOver();
		}

		private void runPcTurn(ref SquareButton squareButtonChosen)
		{
			if (!m_GameLogic.IDontHaveMoves())
			{
				m_GameLogic.GetAndRunPcMove();
				m_FromSquareButton = ButtonMatrix[m_GameLogic.CurrentMove.From.Col, m_GameLogic.CurrentMove.From.Row];
				runAndUpdatePcMove(ref squareButtonChosen);
				while (m_GameLogic.IsPcTurn())
				{
					m_GameLogic.GetAndRunPcMove();
					m_FromSquareButton = squareButtonChosen;
					runAndUpdatePcMove(ref squareButtonChosen);
				}
			}
		}

		private void runAndUpdatePcMove(ref SquareButton squareButtonChosen)
		{
			squareButtonChosen = ButtonMatrix[m_GameLogic.CurrentMove.To.Col, m_GameLogic.CurrentMove.To.Row];
			squareButtonChosen.Enabled = false;
			m_FromSquareButton.Enabled = true;
			m_GameLogic.CheckRewardKing();
			m_GameLogic.RunMove(m_GameLogic.CurrentMove);
			m_ButtonsMovesList.Clear();
			m_GameLogic.SwitchPlayersAndCreateNewMoves();
		}

		private void checkGameOver()
		{
			string resultOfGame = string.Empty;
			const string question = "Another Round?";

			if (m_GameLogic.IDontHaveMoves())
			{
				m_GameLogic.CalculatePlayersScore();
				if (m_GameLogic.IsDraw())
				{
					resultOfGame = string.Format(@"Tie
{0}",
question);
				}
				else
				{
					resultOfGame = string.Format(@"{0} Won!
{1}",
m_GameLogic.WaitingPlayer.Name,
question);
				}

				askForAnotherGame(resultOfGame);
			}
		}

		private void askForAnotherGame(string i_ResultOfGame)
		{
			DialogResult dialogResult = MessageBox.Show(i_ResultOfGame, "Some Title", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.OK;
			}
			else if (dialogResult == DialogResult.No)
			{
				this.DialogResult = DialogResult.Cancel;
			}

			this.Close();
		}

		private void runMove()
		{
			//MessageBox.Show("Update board");
			m_GameLogic.CheckRewardKing();
			m_GameLogic.RunMove(m_GameLogic.CurrentMove);
			changeButtonsMoveToWhite();
		}

		private string getMove(SquareButton i_SquareButtonChosen)
		{
			return string.Format("{0}{1}>{2}{3}",
						(char)(m_FromSquareButton.Row + 'A'),
						(char)(m_FromSquareButton.Col + 'a'),
						(char)(i_SquareButtonChosen.Row + 'A'),
						(char)(i_SquareButtonChosen.Col + 'a'));
		}

		private void prepareBoardForNextEat(ref SquareButton i_SquareButtonChosen)
		{
			changeButtonsMoveToWhite();
			m_FromSquareButton.BackColor = Color.Beige;
			i_SquareButtonChosen.BackColor = Color.LightBlue;
			m_ButtonsMovesList.Clear();
			createButtonsMovesList(ref i_SquareButtonChosen, m_GameLogic.CurrentPlayer.PlayerSkippingMoves);
			changeButtonsMoveToBlue();
			m_FromSquareButton = i_SquareButtonChosen;
		}

		private void UpdateSelectedSquareButton(ref SquareButton i_SquareButtonChosen)
		{
			changeButtonsMoveToWhite();
			i_SquareButtonChosen.BackColor = Color.LightBlue;
			if (m_GameLogic.IsNeededToEat())
			{
				m_ButtonsMovesList.Clear();
				createButtonsMovesList(ref i_SquareButtonChosen, m_GameLogic.CurrentPlayer.PlayerSkippingMoves);
				changeButtonsMoveToBlue();
			}
			else if (m_GameLogic.ThereIsRegularMoves())
			{
				createButtonsMovesList(ref i_SquareButtonChosen, m_GameLogic.CurrentPlayer.PlayerRegularMoves);
				changeButtonsMoveToBlue();
			}

			m_FromSquareButton = i_SquareButtonChosen;
		}

		private void GameBoard_BoardValueChanged(string i_NewSquareValue)
		{
			if (m_GameLogic.CurrentMove.IsSkipMove)
			{
				ButtonMatrix[m_GameLogic.CurrentMove.Eaten.Col, m_GameLogic.CurrentMove.Eaten.Row].Text = "";
				ButtonMatrix[m_GameLogic.CurrentMove.Eaten.Col, m_GameLogic.CurrentMove.Eaten.Row].Enabled = true;
			}

			m_FromSquareButton.Text = "";
			m_FromSquareButton.BackColor = Color.Beige;
			ButtonMatrix[m_GameLogic.CurrentMove.To.Col, m_GameLogic.CurrentMove.To.Row].Text = i_NewSquareValue;
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

		public void switchSquareButtonVisibility(bool i_IsComputer)
		{
			foreach (Square square in m_GameLogic.CurrentPlayer.PlayerSquares)
			{
				ButtonMatrix[square.Col, square.Row].Enabled = !i_IsComputer;
			}

			foreach (Square square in m_GameLogic.WaitingPlayer.PlayerSquares)
			{
				ButtonMatrix[square.Col, square.Row].Enabled = i_IsComputer;
			}
		}
	}
}