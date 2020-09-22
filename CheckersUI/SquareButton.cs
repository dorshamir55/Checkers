using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
	}
}
