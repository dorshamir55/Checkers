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
		private FormGameSettings m_gameSettings = new FormGameSettings();
		private FormGame m_FormGame;
		private GameLogic m_Game;

		public GameUI()
		{
			Run();
		}

		public FormGameSettings GameSettings
		{
			get
			{
				return m_gameSettings;
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
				return m_Game;
			}
		}

		public void Run()
		{
			bool ifFirstGame = true;
			bool isStillPlaying = true;

			GameSettings.ShowDialog();
			startGame(ifFirstGame);
			//TODO
		}

		private void startGame(bool i_IsFirstGame)
		{
			createGameInfo();
			m_FormGame = new FormGame(GameSettings.BoardSize, GameLogic.CurrentPlayer, GameLogic.WaitingPlayer);
			FormGame.ShowDialog();

			/*while (!gameOver())
			{
				if (GameLogic.LastMove != null)
				{
					Console.WriteLine(string.Format("{0}'s move was ({1}): {2}", GameLogic.LastPlayerName, (char)GameLogic.LastSignPlayerPlayed, GameLogic.LastMove));
				}

				Console.WriteLine(string.Format("It's {0}'s Turn ({1})", GameLogic.CurrentPlayer.Name, (char)GameLogic.CurrentPlayer.PlayerColor));
				//Game.LastMove = getAndRunAMove();
				if (GameLogic.LastMove == "Q")//TODO quir from game
				{
					GameLogic.IsQuit = true;
				}
				else
				{
					//Change Board
					GameLogic.SwitchPlayersAndCreateNewMoves();
				}
			}*/
		}

		private void createGameInfo()
		{
			Player player1, player2;
			Board board;
			Player.ePlayerType player2Type = Player.ePlayerType.Human;

			//TODO check for another game
			if (GameSettings.IsComputer)
			{
				player2Type = Player.ePlayerType.Computer;
			}

			player1 = new Player(Player.ePlayerType.Human, Square.ePlayerColor.White, GameSettings.NamePlayer1);
			player2 = new Player(player2Type, Square.ePlayerColor.Black, GameSettings.NamePlayer2);
			board = new Board((Board.eBoradSize)GameSettings.BoardSize);
			m_Game = new GameLogic(board, player1, player2);
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
