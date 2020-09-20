using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
	public class Move
	{
        private Square m_From;
        private Square m_To;
        private Square m_Eaten;
        private bool m_IsSkipMove;

        public Move()
        {
        }

        public Move(Square i_From, Square i_To)
        {
            m_From = i_From;
            m_To = i_To;
        }

        public Move(Square i_From, Square i_To, Square i_Eaten)
        {
            m_From = i_From;
            m_To = i_To;
            m_Eaten = i_Eaten;
        }

        public Square From
        {
            get
            {
                return m_From;
            }

            set
            {
                m_From = value;
            }
        }

        public Square To
        {
            get
            {
                return m_To;
            }

            set
            {
                m_To = value;
            }
        }

        public Square Eaten
        {
            get
            {
                return m_Eaten;
            }

            set
            {
                m_Eaten = value;
            }
        }

        public bool IsSkipMove
        {
            get
            {
                return m_IsSkipMove;
            }

            set
            {
                m_IsSkipMove = value;
            }
        }

        public enum eKindOfMoves
        {
            Regular,
            Skip
        }

        public static Move Parse(string i_StringMove, Board i_GameBoard)
        {
            int fromCol, fromRow, toCol, toRow;
            Square from, to;

            fromCol = i_StringMove[0] - 'A';
            fromRow = i_StringMove[1] - 'a';
            toCol = i_StringMove[3] - 'A';
            toRow = i_StringMove[4] - 'a';
            from = i_GameBoard[fromCol, fromRow];
            to = i_GameBoard[toCol, toRow];
/*            if (from.IsRewardKing(to, (int)i_GameBoard.Size))
            {
                from.SquareValue = from.MyKingSign;
                from.IsKing = true;
            }*/

            return new Move(from, to);
        }

        public static bool operator ==(Move i_MoveA, Move i_MoveB)
        {
            return i_MoveA.From.Col == i_MoveB.From.Col && i_MoveA.From.Row == i_MoveB.From.Row
                     && i_MoveA.To.Col == i_MoveB.To.Col && i_MoveA.To.Row == i_MoveB.To.Row;
        }

        public static bool operator !=(Move i_MoveA, Move i_MoveB)
        {
            return !(i_MoveA == i_MoveB);
        }

        public override string ToString()
        {
            return string.Format(
"{0}{1}>{2}{3}",
                (char)(m_From.Col + 'A'),
                (char)(m_From.Row + 'a'),
                (char)(m_To.Col + 'A'),
                (char)(m_To.Row + 'a'));
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}