using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Square
    {
        private readonly int m_Col;
        private readonly int m_Row;
        private ePlayerColor m_SquareValue;
        private bool m_IsKing;
        private ePlayerColor m_MyKingSign;

        public Square(int i_BoardCol, int i_BoardRow, ePlayerColor i_PlayerColor)
        {
            m_Col = i_BoardCol;
            m_Row = i_BoardRow;
            m_SquareValue = i_PlayerColor;
            m_MyKingSign = m_SquareValue == ePlayerColor.White || m_SquareValue == ePlayerColor.WhiteKing ? ePlayerColor.WhiteKing : ePlayerColor.BlackKing;
        }

        public enum eValue
        {
            King = 4,
            Regular = 1,
        }

        public int Col
        {
            get
            {
                return m_Col;
            }
        }

        public int Row
        {
            get
            {
                return m_Row;
            }
        }

        public bool IsKing
        {
            get
            {
                return m_IsKing;
            }

            set
            {
                m_IsKing = value;
            }
        }

        public ePlayerColor MyKingSign
        {
            get
            {
                return m_MyKingSign;
            }

            set
            {
                m_MyKingSign = value;
            }
        }

        public ePlayerColor SquareValue
        {
            get
            {
                return m_SquareValue;
            }

            set
            {
                m_SquareValue = value;
            }
        }

        public enum ePlayerColor
        {
            White = 'O',
            Black = 'X',
            WhiteKing = 'U',
            BlackKing = 'K',
            Blank = ' '
        }

        public enum eDirection
        {
            Down = 1,
            Up = -1,
            Left = -1,
            Right = 1,
        }

        public static bool operator ==(Square i_SquareA, Square i_SquareB)
        {
            return i_SquareA.Col == i_SquareB.Col && i_SquareA.Row == i_SquareB.Row;
        }

        public static bool operator !=(Square i_SquareA, Square i_SquareB)
        {
            return !(i_SquareA == i_SquareB);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void AddRegularMoves(Board i_GameBoard, List<Move> i_List)
        {
            int directionMove = getDirectionMove();

            insertRegularMovesByDirection(i_GameBoard, directionMove, i_List);
            if (IsKing)
            {
                directionMove *= -1;
                insertRegularMovesByDirection(i_GameBoard, directionMove, i_List);
            }
        }

        public void AddSkipMoves(Board i_GameBoard, List<Move> o_Result)
        {
            int directionMove;

            directionMove = getDirectionMove();
            insertSkipMovesByDirection(i_GameBoard, directionMove, o_Result);
            if (IsKing)
            {
                directionMove *= -1;
                insertSkipMovesByDirection(i_GameBoard, directionMove, o_Result);
            }
        }

        private void insertRegularMovesByDirection(Board i_GameBoard, int directionMove, List<Move> i_List)
        {
            Square nextPointCheck = new Square(m_Col + (int)eDirection.Left, m_Row + directionMove, m_SquareValue);

            if (CanMove(i_GameBoard, nextPointCheck))
            {
                addMoveToRegularList(nextPointCheck, i_List);
            }

            nextPointCheck = new Square(m_Col + (int)eDirection.Right, m_Row + directionMove, m_SquareValue);
            if (CanMove(i_GameBoard, nextPointCheck))
            {
                addMoveToRegularList(nextPointCheck, i_List);
            }
        }

        private void insertSkipMovesByDirection(Board i_GameBoard, int i_directionMove, List<Move> o_List)
        {
            Square nextSquareCheck;
            Square eatenSquare;

            nextSquareCheck = new Square(m_Col + (int)eDirection.Left, m_Row + i_directionMove, m_SquareValue);
            if (isOpponent(i_GameBoard, nextSquareCheck))
            {
                eatenSquare = new Square(m_Col + (int)eDirection.Left, m_Row + i_directionMove, m_SquareValue);
                nextSquareCheck = new Square(m_Col + ((int)eDirection.Left * 2), m_Row + (i_directionMove * 2), m_SquareValue);
                if (CanMove(i_GameBoard, nextSquareCheck))
                {
                    addMoveToSkipList(nextSquareCheck, o_List, eatenSquare);
                }
            }

            nextSquareCheck = new Square(m_Col + (int)eDirection.Right, m_Row + i_directionMove, m_SquareValue);

            if (isOpponent(i_GameBoard, nextSquareCheck))
            {
                eatenSquare = new Square(m_Col + (int)eDirection.Right, m_Row + i_directionMove, m_SquareValue);
                nextSquareCheck = new Square(m_Col + ((int)eDirection.Right * 2), m_Row + (i_directionMove * 2), m_SquareValue);

                if (CanMove(i_GameBoard, nextSquareCheck))
                {
                    addMoveToSkipList(nextSquareCheck, o_List, eatenSquare);
                }
            }
        }

        private void addMoveToRegularList(Square i_nextSquareCheck, List<Move> o_List)
        {
            Move move = new Move();

            move.From = this;
            move.To = i_nextSquareCheck;
            if (move.From.IsKing)
            {
                move.To.SquareValue = move.From.MyKingSign;
            }

            o_List.Add(move);
        }

        private void addMoveToSkipList(Square i_NextLocation, List<Move> o_List, Square i_EatenSquare)
        {
            Move move = new Move();

            move.From = this;
            move.To = i_NextLocation;
            if (move.From.IsKing)
            {
                move.To.SquareValue = move.From.MyKingSign;
            }

            move.Eaten = i_EatenSquare;
            move.IsSkipMove = true;
            o_List.Add(move);
        }

        private int getDirectionMove()
        {
            return (m_SquareValue == ePlayerColor.White || m_SquareValue == ePlayerColor.WhiteKing) ? (int)eDirection.Down : (int)eDirection.Up;
        }

        public bool CanMove(Board i_GameBoard, Square i_NextMove)
        {
            int nextMoveCol = i_NextMove.Col, nextMoveRow = i_NextMove.Row;

            return !checkIfOutOfBounds(i_GameBoard.Size, i_NextMove.Col, i_NextMove.Row) && i_GameBoard[nextMoveCol, nextMoveRow].SquareValue == ePlayerColor.Blank;
        }

        private bool checkIfOutOfBounds(Board.eBoradSize i_GameBoardSize, int i_Col, int i_Row)
        {
            bool checkRow = (i_Row >= (int)i_GameBoardSize) || (i_Row < 0);
            bool checkCol = (i_Col >= (int)i_GameBoardSize) || (i_Col < 0);

            return checkRow || checkCol;
        }

        private bool isOpponent(Board i_GameBoard, Square i_SquarePlayer)
        {
            bool result = false;
            int col = i_SquarePlayer.Col;
            int row = i_SquarePlayer.Row;

            if (!checkIfOutOfBounds(i_GameBoard.Size, col, row))
            {
                ePlayerColor opponentSign = i_GameBoard[col, row].SquareValue;
                ePlayerColor myColor = SquareValue == ePlayerColor.White || SquareValue == ePlayerColor.WhiteKing ? ePlayerColor.White : ePlayerColor.Black;
                if ((char)opponentSign != (char)MyKingSign && (char)opponentSign != (char)myColor && (char)opponentSign != (char)ePlayerColor.Blank)
                {
                    result = true;
                }
            }

            return result;
        }

        public bool IsRewardKing(Square i_SquareToKing, int i_BoardSize)
        {
            return !IsKing && ((m_SquareValue == Square.ePlayerColor.Black && i_SquareToKing.Row == 0)
                || (m_SquareValue == Square.ePlayerColor.White && i_SquareToKing.Row == (int)i_BoardSize-1));
        }
    }
}