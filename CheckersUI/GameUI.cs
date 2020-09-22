using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex02;

namespace CheckersUI
{
	public class GameUI
	{
		private FormGameSettings m_GameSettings = new FormGameSettings();
		private FormGame m_FormGame;
		private GameLogic m_GameLogic;

		public GameUI()
		{
			Run();
		}

		public FormGameSettings GameSettings
		{
			get
			{
				return m_GameSettings;
			}
		}

		public FormGame FormGame
		{
			get
			{
				return m_FormGame;
			}
		}

		public GameLogic GameLogic
		{
			get
			{
				return m_GameLogic;
			}
		}

		public void Run()
		{
			bool ifFirstGame = true;
			bool isStillPlaying = true;

			m_GameSettings.ShowDialog();
			startGame(ifFirstGame);
			//TODO
		}

		private void startGame(bool i_IsFirstGame)
		{
			createGameInfo();
			m_FormGame = new FormGame(m_GameLogic);
			//m_FormGame.PlayGame(m_GameLogic, m_GameSettings);
			m_GameLogic.CalculatePlayerMoves();
			//changeSquareButtonVisibility();
			m_FormGame.ShowDialog();

			while (!gameOver())
			{
				//change visibility of squareButtons
				//Game.LastMove = getAndRunAMove();
				if (m_GameLogic.LastMove == "Q")//TODO quit from game
				{
					m_GameLogic.IsQuit = true;
				}
				else
				{
					//Change Board
					m_GameLogic.SwitchPlayersAndCreateNewMoves();
				}
			}
		}

		private void changeSquareButtonVisibility()
		{
			foreach (Square square in m_GameLogic.CurrentPlayer.PlayerSquares)
			{
				m_FormGame.ButtonMatrix[square.Col, square.Row].Enabled = true;
			}

			foreach (Square square in m_GameLogic.WaitingPlayer.PlayerSquares)
			{
				m_FormGame.ButtonMatrix[square.Col, square.Row].Enabled = false;
			}
		}

		private void createGameInfo()
		{
			Player player1, player2;
			Board board;
			Player.ePlayerType player2Type = Player.ePlayerType.Human;

			//TODO check for another game
			if (m_GameSettings.IsComputer)
			{
				player2Type = Player.ePlayerType.Computer;
			}

			player1 = new Player(Player.ePlayerType.Human, Square.ePlayerColor.White, m_GameSettings.NamePlayer1);
			player2 = new Player(player2Type, Square.ePlayerColor.Black, m_GameSettings.NamePlayer2);
			board = new Board((Board.eBoradSize)m_GameSettings.BoardSize);
			m_GameLogic = new GameLogic(board, player1, player2);
		}

		/*private string getAndRunAMove()
		{
			string errorMessage = string.Empty;
			string move;

			if (GameLogic.IsPcTurn())
			{
				move = GameLogic.GetAndRunPcMove();
			}
			else
			{
				//Get chosen square location

				while (!GameLogic.IsValidMove(move, out errorMessage))
				{
					if (move == "Q")//If quit the game
					{
						break;
					}

					Console.WriteLine(string.Format(
@"Invalid Move, please enter a valid move 
{0}",
errorMessage));
					move = Console.ReadLine();
				}
			}

			if (move != "Q")
			{
				GameLogic.CheckRewardKing();
				GameLogic.RunMove(GameLogic.CurrentMove);
			}

			return move;
		}*/

		private bool gameOver()
		{
			return false;
		}
	}
}
