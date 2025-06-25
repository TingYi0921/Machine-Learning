using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	internal class NumberGuessingGame
	{
		private string _answer; //正確答案

		///<summary>
		///開一個新遊戲，重設答案
		///</summary>
		public void NewGame()
		{
			var random = new Random();
			// todo 如何取得四個不重複的數字?
			var hs = new HashSet<int>(); // 創建一個HashSet方法叫hs
			do
			{
				int number = random.Next(0, 10); // 亂數從0-9取一個數字
				hs.Add(number); // 把取得的數字放進hs
			}while (hs.Count < 4); // 取到第4個就停止迴圈

			_answer = string.Empty; // 開啟新遊戲時把答案清空
			foreach (int n in hs) // 用foreach迴圈把數字轉成字串後放進_answer
			{
				_answer += n.ToString();
			}
		}

		///<summary>
		///回傳輸入值是否為合理的值
		///</summary>
		///<param name="value"></param>
		///<returns></returns>
		public ValidationResult Validate(string value) // 驗證輸入值，是否合理
		{
			// 判斷是不是空值is null or empty
			if (string.IsNullOrEmpty(value)) return ValidationResult.Fail("輸入值不可為空值");

			// length = 4,長度必須是4
			if (value.Length != 4) return ValidationResult.Fail("輸入長度必須是4");

			// 必須是四個數字
			if (int.TryParse(value, out int number) == false) return ValidationResult.Fail("輸入值必須是數字");

			// 每個值都不相同
			HashSet<char> chars = new HashSet<char>();
			foreach (char c in value) 
			{
				chars.Add(c);
			}
			if (chars.Count != 4) return ValidationResult.Fail("必須每個值都不同");

			return ValidationResult.Success();
		} 
		public GameResult CompareGuess(string value) 
		{
			GameResult result = new GameResult { CountA = 0, CountB = 0};

			for (int index = 0; index < _answer.Length; index++) 
			{
				if (value[index] == _answer[index])
				{
					result.CountA++;
				}
				else 
				{
					if (_answer.Contains(value[index]))
					{
						result.CountB++;
					}
				}
			}
			return result;
		}

		public string GetAnswer()
		{
			return _answer;
		}
	}

	public class GameResult
	{
		public int CountA { get; set; }
		public int CountB { get; set; }
	}
	public class ValidationResult
	{
		public bool IsSuccess {  get; private set; }
		public string ErrorMessage {  get; private set; }
		public static ValidationResult Success()=>new ValidationResult { IsSuccess = true };
		public static ValidationResult Fail(string errorMessage)
		{
			return new ValidationResult { IsSuccess = false, ErrorMessage = errorMessage };
		}
	}
}
