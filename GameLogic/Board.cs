using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public delegate void BoardChanged<T>(T newSquareValue);

    public class Board
    {
        private readonly eBoradSize m_Size;
        private Square[,] m_BoardSquares;

        public event BoardChanged<char> BoardValueChanged;

        public Board(eBoradSize i_Size)
        {
            m_Size = i_Size;
            m_BoardSquares = new Square[(int)i_Size, (int)i_Size];
            initializeBoard();
        }

        public Square this[int col, int row]
        {
            get
            {
                return m_BoardSquares[col, row];
            }

            set
            {
                m_BoardSquares[col, row] = value;
            }
        }

        public eBoradSize Size
        {
            get
            {
                return m_Size;
            }
        }

        public enum eBoradSize
        {
            Small = 6,
            Medium = 8,
            Large = 10
        }

        private void initializeBoard()
        {
            int boardSize = (int)m_Size;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if ((row % 2 == 0 && col % 2 != 0) || (row % 2 != 0 && col % 2 == 0))
                    {
                        if (row < (boardSize / 2) - 1)
                        {
                            m_BoardSquares[col, row] = new Square(col, row, Square.ePlayerColor.White);
                        }
                        else if (row > boardSize / 2)
                        {
                            m_BoardSquares[col, row] = new Square(col, row, Square.ePlayerColor.Black);
                        }
                        else
                        {
                            m_BoardSquares[col, row] = new Square(col, row, Square.ePlayerColor.Blank);
                        }
                    }
                    else
                    {
                            m_BoardSquares[col, row] = new Square(col, row, Square.ePlayerColor.Blank);
                    }
                }
            }
        }

        public void Update(Move i_LastMove)
        {
            if (i_LastMove.IsSkipMove)
            {
                m_BoardSquares[i_LastMove.Eaten.Col, i_LastMove.Eaten.Row].SquareValue = Square.ePlayerColor.Blank;
                m_BoardSquares[i_LastMove.Eaten.Col, i_LastMove.Eaten.Row].MyKingSign = Square.ePlayerColor.Blank;
                m_BoardSquares[i_LastMove.Eaten.Col, i_LastMove.Eaten.Row].IsKing = false;
            }

            if (i_LastMove.From.IsKing)
            {
                m_BoardSquares[i_LastMove.From.Col, i_LastMove.From.Row].IsKing = false;
                m_BoardSquares[i_LastMove.To.Col, i_LastMove.To.Row].IsKing = true;
            }

            m_BoardSquares[i_LastMove.To.Col, i_LastMove.To.Row].SquareValue = i_LastMove.From.SquareValue;
            m_BoardSquares[i_LastMove.To.Col, i_LastMove.To.Row].MyKingSign = i_LastMove.From.MyKingSign;
            onBoardValueChanged((char)i_LastMove.From.SquareValue);
            m_BoardSquares[i_LastMove.From.Col, i_LastMove.From.Row].SquareValue = Square.ePlayerColor.Blank;
            m_BoardSquares[i_LastMove.From.Col, i_LastMove.From.Row].MyKingSign = Square.ePlayerColor.Blank;
        }

        protected virtual void onBoardValueChanged(char newSquareValue)
        {
            //Console.Clear();
            if (BoardValueChanged != null)
            {
                BoardValueChanged.Invoke(newSquareValue);
            }
        }
    }
}
