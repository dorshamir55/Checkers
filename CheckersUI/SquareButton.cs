﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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

		public static bool operator ==(SquareButton i_SquareButtonA, SquareButton i_SquareButtonB)
		{
			return i_SquareButtonA.Col == i_SquareButtonB.Col && i_SquareButtonA.Row == i_SquareButtonB.Row;
		}

		public static bool operator !=(SquareButton i_SquareButtonA, SquareButton i_SquareButtonB)
		{
			return !(i_SquareButtonA == i_SquareButtonB);
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public void initializeSquareButtonDetails(int i_Row, int i_Col, int i_BoardSize)
		{
			if ((i_Row % 2 == 0 && i_Col % 2 == 0) || (i_Row % 2 != 0 && i_Col % 2 != 0))
			{
				this.BackColor = Color.Black;
				this.Enabled = false;
			}
			else
			{
				this.BackColor = Color.Beige;
				if (i_Col < (i_BoardSize / 2) - 1)
				{
					this.Enabled = false;
					changeSquareToWhite();
				}
				else if (i_Col > i_BoardSize / 2)
				{
					this.Enabled = false;
					changeSquareToBlack();
				}
				else
				{
					this.Enabled = true;
				}
			}

			this.Margin = Padding.Empty;
			this.Font = new Font(this.Font, FontStyle.Bold);
			this.Location = new Point(this.Width * i_Row, this.Height * i_Col);
		}

		public bool IsPressed(SquareButton i_LastSquareButton)
		{
			return this == i_LastSquareButton && this.BackColor == Color.LightBlue;
		}

		public bool CanMoveTo(List<SquareButton> i_SquareButtonsMovesList)
		{
			bool canMove = false;

			foreach (SquareButton squareButtonTo in i_SquareButtonsMovesList)
			{
				if (this.Row == squareButtonTo.Row && this.Col == squareButtonTo.Col)
				{
					canMove = true;
					break;
				}
			}

			return canMove;
		}

		public void changeSquareToWhite()
		{
			this.BackgroundImage = CheckersUI.Properties.Resources.white;
			this.BackgroundImageLayout = ImageLayout.Center;
		}

		public void changeSquareToBlack()
		{
			this.BackgroundImage = CheckersUI.Properties.Resources.black;
			this.BackgroundImageLayout = ImageLayout.Center;
		}
	}
}
