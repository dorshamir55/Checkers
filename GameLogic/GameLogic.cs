using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class GameLogic
    {
        private Board m_GameBoard;
        private Player m_CurrentPlayer;
        private Player m_WaitingPlayer;
        private Move m_CurrentMove;
        private string m_LastMove = null;
        private bool m_IsNeededToEatAgain = false;
        private bool m_IsQuit = false;
        private string m_LastPlayerName;
        private Square.ePlayerColor m_LastSignPlayerPlayed;
        private bool m_isNeedToStopAfterRewardingKing = false;
        private bool m_IsNextPlayerTurn = true;

        public Board GameBoard
        {
            get
            {
                return m_GameBoard;
            }

            set
            {
                m_GameBoard = value;
            }
        }

        public string LastMove
        {
            get
            {
                return m_LastMove;
            }

            set
            {
                m_LastMove = value;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public Player WaitingPlayer
        {
            get
            {
                return m_WaitingPlayer;
            }

            set
            {
                m_WaitingPlayer = value;
            }
        }

        public Move CurrentMove
        {
            get
            {
                return m_CurrentMove;
            }

            set
            {
                m_CurrentMove = value;
            }
        }

        public bool IsQuit
        {
            get
            {
                return m_IsQuit;
            }

            set
            {
                m_IsQuit = value;
            }
        }

        public string LastPlayerName
        {
            get
            {
                return m_LastPlayerName;
            }

            set
            {
                m_LastPlayerName = value;
            }
        }

        public Square.ePlayerColor LastSignPlayerPlayed
        {
            get
            {
                return m_LastSignPlayerPlayed;
            }

            set
            {
                m_LastSignPlayerPlayed = value;
            }
        }

        public bool IsNeedToStopAfterRewardingKing
        {
            get
            {
                return m_isNeedToStopAfterRewardingKing;
            }

            set
            {
                m_isNeedToStopAfterRewardingKing = value;
            }
        }

        public bool IsNextPlayerTurn
        {
            get
            {
                return m_IsNextPlayerTurn;
            }

            set
            {
                m_IsNextPlayerTurn = value;
            }
        }

        public GameLogic(Board i_GameBoard, Player i_FirstPlayer, Player i_SecondPlayer)
        {
            m_GameBoard = i_GameBoard;
            m_CurrentPlayer = i_FirstPlayer;
            m_WaitingPlayer = i_SecondPlayer;

            m_CurrentPlayer.PlayerSquares = createPlayersSquaresList(m_CurrentPlayer.PlayerColor);
            m_WaitingPlayer.PlayerSquares = createPlayersSquaresList(m_WaitingPlayer.PlayerColor);
        }

        private List<Square> createPlayersSquaresList(Square.ePlayerColor i_PlayerColor)
        {
            List<Square> playersSquares = new List<Square>();
            for (int i = 0; i < (int)m_GameBoard.Size; i++)
            {
                for (int j = 0; j < (int)m_GameBoard.Size; j++)
                {
                    if (m_GameBoard[i, j].SquareValue == i_PlayerColor)
                    {
                        playersSquares.Add(m_GameBoard[i, j]);
                    }
                }
            }

            return playersSquares;
        }

        private bool IsValidBoardSize(string i_BoardSizeStringInput, out int o_BoardSize)
        {
            bool isNumeric = int.TryParse(i_BoardSizeStringInput, out o_BoardSize);

            return isNumeric && (o_BoardSize == (int)Board.eBoradSize.Small || o_BoardSize == (int)Board.eBoradSize.Medium || o_BoardSize == (int)Board.eBoradSize.Large);
        }

        public void CalculatePlayerMoves()
        {
            m_CurrentPlayer.PlayerRegularMoves = m_CurrentPlayer.CreateRegularArray(m_GameBoard);
            m_CurrentPlayer.PlayerSkippingMoves = m_CurrentPlayer.CreateSkipsArray(m_GameBoard);
        }

        public bool IsValidMove(string i_StringMove, out string o_ErrorMessage)
        {
            Move move;
            bool isValidMove = false;
            o_ErrorMessage = string.Empty;

            move = Move.Parse(i_StringMove, m_GameBoard);
            if (IsNeededToEat())
            {
                isValidMove = isSkipMove(move);
                if (!isValidMove)
                {
                    o_ErrorMessage = "You have skipping moves available, choose a legal move";
                }
            }
            else
            {
                isValidMove = isRegularMove(move);
            }

            return isValidMove;
        }

        private bool isRegularMove(Move i_Move)
        {
            bool result = false;

            foreach (Move move in m_CurrentPlayer.PlayerRegularMoves)
            {
                if (move == i_Move)
                {
                    i_Move.IsSkipMove = false;
                    result = true;
                    m_CurrentMove = i_Move;
                    break;
                }
            }

            return result;
        }

        private bool isSkipMove(Move i_Move)
        {
            bool isSkipMove = false;

            foreach (Move move in m_CurrentPlayer.PlayerSkippingMoves)
            {
                if (move == i_Move)
                {
                    i_Move.Eaten = new Square(move.Eaten.Col, move.Eaten.Row, move.Eaten.SquareValue);
                    i_Move.IsSkipMove = true;
                    isSkipMove = true;
                    m_CurrentMove = i_Move;
                    break;
                }
            }

            return isSkipMove;
        }

        public void RunMove(Move i_Move)
        {
            /*            if (i_Move.From.IsRewardKing(i_Move.To, (int)GameBoard.Size))
                        {
                            i_Move.From.SquareValue = i_Move.From.MyKingSign;
                            i_Move.From.IsKing = true;
                        }*/
            m_CurrentPlayer.UpdatePlayerSquaresList(ref i_Move);
            if (i_Move.IsSkipMove)
            {
                m_WaitingPlayer.UpdateEatenPlayerSquaresList(i_Move);
                m_GameBoard.Update(i_Move);
                m_CurrentPlayer.PlayerSkippingMoves = m_CurrentPlayer.CreateMovesSkippingTwiceLists(m_GameBoard, m_CurrentMove.To);
                if (IsNeededToEat())
                {
                    m_IsNeededToEatAgain = true;
                }
                else
                {
                    m_IsNeededToEatAgain = false;
                }
            }
            else
            {
                m_GameBoard.Update(i_Move);
                m_IsNeededToEatAgain = false;
            }
        }

        public bool areMoreSkipMoves()
        {
            return m_IsNeededToEatAgain;
        }

        public bool IsNeededToEat()
        {
            return m_CurrentPlayer.PlayerSkippingMoves.Count > 0;
        }

        public bool ThereIsRegularMoves()
        {
            return m_CurrentPlayer.PlayerRegularMoves.Count > 0;
        }

        public void SwitchPlayersAndCreateNewMoves()
        {
            LastPlayerName = m_CurrentPlayer.Name;
            LastSignPlayerPlayed = m_CurrentPlayer.PlayerColor;
            if (!areMoreSkipMoves() || IsNeedToStopAfterRewardingKing)
            {
                IsNeedToStopAfterRewardingKing = false;
                swap(ref m_CurrentPlayer, ref m_WaitingPlayer);
                CalculatePlayerMoves();
                IsNextPlayerTurn = true;
            }
            else
            {
                IsNextPlayerTurn = false;
            }
        }

        private void swap(ref Player io_PlayerOne, ref Player io_PlayerTwo)
        {
            Player temp;

            temp = io_PlayerOne;
            io_PlayerOne = io_PlayerTwo;
            io_PlayerTwo = temp;
        }

        public bool IsPcTurn()
        {
            return m_CurrentPlayer.IsComputer();
        }

        public string GetAndRunPcMove()
        {
            m_CurrentMove = m_CurrentPlayer.GetPCMove((int)GameBoard.Size);

            return m_CurrentMove.ToString();
        }

        public bool IsDraw()
        {
            swap(ref m_CurrentPlayer, ref m_WaitingPlayer);
            CalculatePlayerMoves();
            swap(ref m_CurrentPlayer, ref m_WaitingPlayer);

            return m_WaitingPlayer.PlayerRegularMoves.Count == 0 && m_WaitingPlayer.PlayerSkippingMoves.Count == 0;
        }

        public void CalculatePlayersScore()
        {
            int currentPlayerScore, waitingPlayerScore;

            currentPlayerScore = m_CurrentPlayer.CalculateScore();
            waitingPlayerScore = m_WaitingPlayer.CalculateScore();
            if (currentPlayerScore > waitingPlayerScore)
            {
                m_CurrentPlayer.Score += currentPlayerScore - waitingPlayerScore;
            }
            else if (waitingPlayerScore > currentPlayerScore)
            {
                m_WaitingPlayer.Score += waitingPlayerScore - currentPlayerScore;
            }
        }

        public void CheckRewardKing()
        {
            if (m_CurrentMove.From.IsRewardKing(m_CurrentMove.To, (int)GameBoard.Size))
            {
                m_CurrentMove.From.SquareValue = m_CurrentMove.From.MyKingSign;
                m_CurrentMove.From.IsKing = true;
                IsNeedToStopAfterRewardingKing = true;
            }
        }

        public bool IDontHaveMoves()
        {
            return !ThereIsRegularMoves() && !IsNeededToEat();
        }
    }
}
