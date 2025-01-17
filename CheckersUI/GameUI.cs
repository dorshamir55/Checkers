﻿using System;
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
			if (m_GameSettings.ShowDialog() == DialogResult.OK)
			{
				startGame();
			}
		}

		private void startGame()
		{
			createGameInfo(true);
			m_GameLogic.CalculatePlayerMoves();
			m_FormGame = new FormGame(m_GameLogic);
			while (m_FormGame.ShowDialog() == DialogResult.OK)
			{
				createGameInfo(false);
				m_GameLogic.CalculatePlayerMoves();
				m_FormGame = new FormGame(m_GameLogic);
			}
		}

		private void createGameInfo(bool i_IsFirstGame)
		{
			Player player1, player2;
			Board board;
			Player.ePlayerType player2Type;
			if (i_IsFirstGame)
			{
				player2Type = Player.ePlayerType.Human;
				if (m_GameSettings.IsComputer)
				{
					player2Type = Player.ePlayerType.Computer;
				}

				player1 = new Player(Player.ePlayerType.Human, Square.ePlayerColor.White, m_GameSettings.NamePlayer1);
				player2 = new Player(player2Type, Square.ePlayerColor.Black, m_GameSettings.NamePlayer2);
				board = new Board((Board.eBoradSize)m_GameSettings.BoardSize);
			}
			else
			{
				player1 = new Player(m_GameLogic.WaitingPlayer.PlayerType, m_GameLogic.WaitingPlayer.PlayerColor, m_GameLogic.WaitingPlayer.Name, m_GameLogic.WaitingPlayer.Score);
				player2 = new Player(m_GameLogic.CurrentPlayer.PlayerType, m_GameLogic.CurrentPlayer.PlayerColor, m_GameLogic.CurrentPlayer.Name, m_GameLogic.CurrentPlayer.Score);
				board = new Board(m_GameLogic.GameBoard.Size);
			}

			m_GameLogic = new GameLogic(board, player1, player2);
		}
	}
}
