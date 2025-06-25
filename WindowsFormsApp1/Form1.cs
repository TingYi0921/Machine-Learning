using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		NumberGuessingGame _game;
		public Form1()
		{
			InitializeComponent();

			_game = new NumberGuessingGame();
			_game.NewGame();

			this.AcceptButton = this.btnGuess;
		}

		private void btnNewGame_Click(object sender, EventArgs e)
		{
			_game.NewGame();

			txtGuess.Text = txtHistory.Text = "";

			txtGuess.Focus();
		}

		private void btnGetAnswer_Click(object sender, EventArgs e)
		{
			string answer = _game.GetAnswer();
			MessageBox.Show(answer);
		}

		private void btnGuess_Click(object sender, EventArgs e)
		{
			string input = txtGuess.Text;

			var result = _game.Validate(input);
			if (result.IsSuccess == false)
			{
				MessageBox.Show("輸入值驗證失敗，原因: " + result.ErrorMessage);
				return;
			}

			GameResult gameResult = _game.CompareGuess(input);
			if (gameResult.CountA == 4)
			{
				MessageBox.Show("恭喜，答對了");
				txtGuess.Text = "";
				txtHistory.Text = "";

				_game.NewGame();
				return;
			}

			string message = $"{input}: {gameResult.CountA} A {gameResult.CountB} B\r\n";
			txtHistory.Text += message;

			txtGuess.Text = "";
			txtGuess.Focus();
		}
	}
}
