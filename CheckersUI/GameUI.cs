using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckersUI
{
	public class GameUI
	{
		public GameUI()
		{
			Start();
		}

		public void Start()
		{
			Application.EnableVisualStyles();
			FormGameSettings gameSettings = new FormGameSettings();
			gameSettings.ShowDialog();
			new FormGame().ShowDialog();
		}
	}
}
