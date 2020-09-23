namespace CheckersUI
{
	public class MatrixButtons<T>
	{
		private T[,] m_TButtonsMatrix;

		public MatrixButtons(int i_Width, int i_Height)
		{
			m_TButtonsMatrix = new T[i_Width, i_Height];
		}

		public T this[int row, int col]
		{
			get
			{
				return m_TButtonsMatrix[row, col];
			}

			set
			{
				m_TButtonsMatrix[row, col] = value;
			}
		}
	}
}