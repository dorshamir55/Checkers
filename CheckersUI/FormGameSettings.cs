using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckersUI
{
	public partial class FormGameSettings : Form
	{
		private int m_BoardSize;
		private string m_NamePlayer1;
		private string m_NamePlayer2;
		private bool m_IsComputer = true;

		public FormGameSettings()
		{
			InitializeComponent();

			this.radioButton1.CheckedChanged += radioButton_CheckedChanged;
			this.radioButton2.CheckedChanged += radioButton_CheckedChanged;
			this.radioButton3.CheckedChanged += radioButton_CheckedChanged;
			this.textBoxPlayer1.KeyPress += TextBoxPlayer_KeyPress;
			this.textBoxPlayer2.KeyPress += TextBoxPlayer_KeyPress;
			this.checkBoxPlayer2.CheckedChanged += CheckBoxPlayer2_CheckedChanged;
			this.buttonDone.Click += ButtonDone_Click;
		}

		public int BoardSize
		{
			get
			{
				return m_BoardSize;
			}

			private set
			{
				m_BoardSize = value;
			}
		}

		public string NamePlayer1
		{
			get
			{
				return m_NamePlayer1;
			}

			private set
			{
				m_NamePlayer1 = value;
			}
		}

		public string NamePlayer2
		{
			get
			{
				return m_NamePlayer2;
			}

			private set
			{
				m_NamePlayer2 = value;
			}
		}

		public bool IsComputer
		{
			get
			{
				return m_IsComputer;
			}

			private set
			{
				m_IsComputer = value;
			}
		}

		private void TextBoxPlayer_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ' ' || (sender as TextBox).TextLength == 12 && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		private void ButtonDone_Click(object sender, EventArgs e)
		{
			if (textBoxPlayer1.Text.Equals("") || textBoxPlayer2.Text.Equals(""))
			{
				MessageBox.Show("Player name can't be blank");
			}
			else if (m_BoardSize == 0)
			{
				MessageBox.Show("Please choose size board");
			}
			else
			{
				NamePlayer1 = textBoxPlayer1.Text;
				NamePlayer2 = textBoxPlayer2.Text;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPlayer2.Checked == true)
			{
				IsComputer = false;
				textBoxPlayer2.Enabled = true;
				textBoxPlayer2.Text = "";
			}
			else
			{
				IsComputer = true;
				textBoxPlayer2.Enabled = false;
				textBoxPlayer2.Text = "PC";
			}
		}

		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButtonChecked = sender as RadioButton;

			if (radioButtonChecked.Checked)
			{
				string size = radioButtonChecked.Text.Substring(0, radioButtonChecked.Text.IndexOf(' '));

				BoardSize = int.Parse(size);
			}
		}
	}
}
