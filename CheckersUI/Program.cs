﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckersUI
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			new GameUI();
			/*Application.EnableVisualStyles();
			FormGameSettings gameSettings = new FormGameSettings();
			gameSettings.ShowDialog();
			new FormGame().ShowDialog();*/
		}
	}
}