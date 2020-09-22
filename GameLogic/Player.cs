using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Player
    {
        private string m_Name;
        private List<Move> m_PlayerRegularMoves;
        private List<Move> m_PlayerSkippingMoves;
        private ePlayerType m_PlayerType;
        private Square.ePlayerColor m_PlayerColor;
        private int m_Score = 0;
        private List<Square> m_PlayerSquares;

        public enum ePlayerType
        {
            Computer,
            Human
        }

        public Player(ePlayerType i_PlayerType, Square.ePlayerColor i_PlayerColor, string i_Name) : this(i_PlayerType, i_PlayerColor, i_Name, 0)
        {
        }

        public Player(ePlayerType i_PlayerType, Square.ePlayerColor i_PlayerColor, string i_Name, int i_Score)
        {
            m_PlayerType = i_PlayerType;
            m_PlayerColor = i_PlayerColor;
            m_Name = i_Name;
            m_Score = i_Score;
            m_PlayerSquares = new List<Square>();
            m_PlayerRegularMoves = new List<Move>();
            m_PlayerSkippingMoves = new List<Move>();
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public ePlayerType PlayerType
        {
            get
            {
                return m_PlayerType;
            }

            set
            {
                m_PlayerType = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public List<Square> PlayerSquares
        {
            get
            {
                return m_PlayerSquares;
            }

            set
            {
                m_PlayerSquares = value;
            }
        }

        public Square.ePlayerColor PlayerColor
        {
            get
            {
                return m_PlayerColor;
            }

            set
            {
                m_PlayerColor = value;
            }
        }

        public List<Move> PlayerRegularMoves
        {
            get
            {
                return m_PlayerRegularMoves;
            }

            set
            {
                m_PlayerRegularMoves = value;
            }
        }

        public List<Move> PlayerSkippingMoves
        {
            get
            {
                return m_PlayerSkippingMoves;
            }

            set
            {
                m_PlayerSkippingMoves = value;
            }
        }

        public List<Move> CreateRegularArray(Board i_GameBoard)
        {
            List<Move> result = new List<Move>();

            foreach (Square square in m_PlayerSquares)
            {
                square.AddRegularMoves(i_GameBoard, result);
            }

            return result;
        }

        public List<Move> CreateSkipsArray(Board i_GameBoard)
        {
            List<Move> result = new List<Move>();

            foreach (Square square in m_PlayerSquares)
            {
                square.AddSkipMoves(i_GameBoard, result);
            }

            return result;
        }

        public List<Move> CreateMovesSkippingTwiceLists(Board i_GameBoard, Square i_Square)
        {
            List<Move> result = new List<Move>();
             
            i_Square.AddSkipMoves(i_GameBoard, result);

            return result;
        }

        public void UpdatePlayerSquaresList(ref Move i_CurrentMove)
        {
            removeSquareFromList(i_CurrentMove.From);
            i_CurrentMove.To.SquareValue = i_CurrentMove.From.SquareValue;
            i_CurrentMove.To.IsKing = i_CurrentMove.From.IsKing;
            i_CurrentMove.To.MyKingSign = i_CurrentMove.From.MyKingSign;
            m_PlayerSquares.Add(i_CurrentMove.To);
        }

        private void removeSquareFromList(Square i_CurrentSquareToDelete)
        {
            foreach (Square square in m_PlayerSquares)
            {
                if (square == i_CurrentSquareToDelete)
                {
                    m_PlayerSquares.Remove(square);
                    break;
                }
            }
        }

        public void UpdateEatenPlayerSquaresList(Move i_CurrentMove)
        {
            removeSquareFromList(i_CurrentMove.Eaten);
        }

        public bool IsComputer()
        {
            return ePlayerType.Computer == m_PlayerType;
        }

        public Move GetPCMove(int i_Size)
        {
            Move pcMove = new Move();
            Random random = new Random();
            int randomIndex;

            if (m_PlayerSkippingMoves.Count != 0)
            {
                randomIndex = random.Next(m_PlayerSkippingMoves.Count);
                pcMove = m_PlayerSkippingMoves[randomIndex];
                pcMove.IsSkipMove = true;
/*                if (pcMove.From.IsRewardKing(pcMove.To, i_Size))
                {
                    pcMove.From.SquareValue = pcMove.From.MyKingSign;
                    pcMove.From.IsKing = true;
                }*/
            }
            else if (m_PlayerRegularMoves.Count != 0)
            {
                randomIndex = random.Next(m_PlayerRegularMoves.Count);
                pcMove = m_PlayerRegularMoves[randomIndex];
                pcMove.IsSkipMove = false;
/*                if (pcMove.From.IsRewardKing(pcMove.To, i_Size))
                {
                    pcMove.From.SquareValue = pcMove.From.MyKingSign;
                    pcMove.From.IsKing = true;
                }*/
            }

            return pcMove;
        }

        public int CalculateScore()
        {
            int sumScore = 0;

            foreach (Square square in m_PlayerSquares)
            {
                if (square.IsKing)
                {
                    sumScore += (int)Square.eValue.King;
                }
                else
                {
                    sumScore += (int)Square.eValue.Regular;
                }
            }

            return sumScore;
        }
    }
}
