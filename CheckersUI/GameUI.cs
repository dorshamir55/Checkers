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
		private GameLogic m_gameLogic;

		public GameUI()
		{
			Start();
		}

		public FormGameSettings GameSettings
		{
			get
			{
				return m_gameSettings;
			}
		}

		public GameLogic GameLogic
		{
			get
			{
				return m_gameLogic;
			}
		}

		private void Start()
		{
			Application.EnableVisualStyles();
			m_gameSettings.ShowDialog();
			createGameInfo();
			new FormGame().ShowDialog();
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
			m_gameLogic = new GameLogic(board, player1, player2);
		}
	}
}
