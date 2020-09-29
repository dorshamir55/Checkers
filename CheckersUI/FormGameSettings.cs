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
		private const int k_MaxNameSize = 10;
		private int m_BoardSize;

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
				return textBoxPlayer1.Text;
			}
		}

		public string NamePlayer2
		{
			get
			{
				return textBoxPlayer2.Text;
			}
		}

		public bool IsComputer
		{
			get
			{
				return !textBoxPlayer2.Enabled;
			}
		}

		public int MaxNameSize
		{
			get
			{
				return k_MaxNameSize;
			}
		}

		private void TextBoxPlayer_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ' ' || ((sender as TextBox).TextLength == MaxNameSize && e.KeyChar != (char)Keys.Back))
			{
				e.Handled = true;
			}
		}

		private void ButtonDone_Click(object sender, EventArgs e)
		{
			if (textBoxPlayer1.Text.Equals(string.Empty) || textBoxPlayer2.Text.Equals(string.Empty))
			{
				MessageBox.Show("Player name can't be blank", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (m_BoardSize == 0)
			{
				MessageBox.Show("Please choose size board", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPlayer2.Checked == true)
			{
				textBoxPlayer2.Enabled = true;
				textBoxPlayer2.Text = string.Empty;
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
				string size = radioButtonChecked.Text.Substring(0, radioButtonChecked.Text.IndexOf(' '));

				BoardSize = int.Parse(size);
			}
		}
	}
}
