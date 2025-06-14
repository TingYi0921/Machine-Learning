using System.Threading.Channels;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入姓名: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("姓名不可為空白或空值。");
            }

            Console.Write("請輸入身高(cm): ");
            string heightInput = Console.ReadLine();

            int height = int.Parse(heightInput);

            Console.Write("請輸入性別(1: 男, 0: 女): ");
            string genderInput = Console.ReadLine();
            string gender = string.Empty;

            if (genderInput == "1")
            {
                gender = "先生";
            }
            else if (genderInput == "0")
            {
                gender = "女士";
            }
            else
            {
                Console.WriteLine("輸入錯誤，請輸入 1 或 0");
                return;
            }

            Console.WriteLine($"您好, {name} {gender}\r\n您的身高是 {height} 公分");
        }
    }
}