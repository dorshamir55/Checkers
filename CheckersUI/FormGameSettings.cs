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
		private string m_BoardSize;
		private string m_NamePlayer1;
		private string m_NamePlayer2;

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

		public string BoardSize
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
			else if (m_BoardSize is null)
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
				textBoxPlayer2.Enabled = true;
				textBoxPlayer2.Text = "";
			}
			else
			{
				textBoxPlayer2.Enabled = false;
				textBoxPlayer2.Text = "PC";
			}
		}

		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButtonChecked = sender as RadioButton;

			if (radioButtonChecked.Checked)
			{
				BoardSize = radioButtonChecked.Text.Substring(0, radioButtonChecked.Text.IndexOf(' '));
			}
		}
	}
}
