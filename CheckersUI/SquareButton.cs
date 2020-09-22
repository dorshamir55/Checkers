using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex02;

namespace CheckersUI
{
	public class SquareButton : Button
	{
		private Point m_Point;

		public SquareButton(Point i_point)
		{
			m_Point = i_point;
		}

		public Point Point
		{
			get
			{
				return m_Point;
			}
		}

		public int Row
		{
			get
			{
				return m_Point.X;
			}

			set
			{
				m_Point.X = value;
			}
		}

		public int Col
		{
			get
			{
				return m_Point.Y;
			}

			set
			{
				m_Point.Y = value;
			}
		}

		public void initializeSquareButtonDetails(int i_Row, int i_Col, int i_BoardSize)
		{
			if (i_Row % 2 == 0 && i_Col % 2 == 0 || i_Row % 2 != 0 && i_Col % 2 != 0)
			{
				this.BackColor = Color.DarkGray;
				this.Enabled = false;
			}
			else
			{
				this.BackColor = Color.Beige;
				this.Enabled = true;
				if (i_Col < (i_BoardSize / 2) - 1)
				{
					this.Text = ((char)Square.ePlayerColor.White).ToString();// "O";
				}
				else if (i_Col > i_BoardSize / 2)
				{
					this.Text = ((char)Square.ePlayerColor.Black).ToString();// "X";
				}
			}

			this.Margin = Padding.Empty;
			this.Font = new Font(this.Font, FontStyle.Bold);
			this.Location = new Point(this.Width * i_Row, this.Height * i_Col);
		}
	}
}
