using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
namespace 카톡1
{
	class Program
	{
		[DllImport("user32.dll")]
		public static extern int FindWindow(string lpClassName, string lpWindowName);
		
		[DllImport("user32.dll")]
		public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);
		
		[DllImport("user32.dll")]
		public static extern int SendMessage(int hwnd, int wMsg, int wParam, string lParam);
		
		[DllImport("user32.dll")]
		public static extern uint PostMessage(int hwnd, int wMsg, int wParam, int lParam);

		public static void Main()
		{
		first: Console.Clear();
		Console.WriteLine("※맨앞에 있는 카톡창에 보내집니다 주의하세요");
			string answer = "";
			Console.WriteLine("도배하시려는 말을 입력해주세요");
			string str = Console.ReadLine();
			int number = getInput();
		b:
			macro(number, str);
			
			Console.WriteLine("다시하시겠습니까?(예 - 0, 아니오 - 0이 아닌수)");
			answer = Console.ReadLine();
			if(answer != "0"){
				Environment.Exit(0);
			}
			
			Console.WriteLine("이 설정 그대로 - 0 \n처음부터 다시 - 1 \n도배할 말만 바꾸기 - 2 \n반복 횟수만 바꾸기 - 3");
			answer = Console.ReadLine();
		c:
			if(answer == "0"){
				goto b;
			}
			else if(answer == "1"){
				goto first;
			}
			else if(answer == "2"){
				Console.WriteLine("도배하시려는 말을 입력해주세요");
				str = Console.ReadLine();
				goto b;
			}
			else if(answer == "3"){
				number = getInput();
				goto b;
			}
			else{
				Console.WriteLine("다시입력해주세요");
				goto c;
			}
		}
		public static int getInput(){
			Console.WriteLine("얼마나 반복하실겁니까?");
			a:
			int input = 0;
			try{
				input = int.Parse(Console.ReadLine());
			}
			catch{
				Console.WriteLine("다시 입력해주세요.");
				goto a;
			}
			return input;
		}
		public static void macro(int num, string str){
			for(int c = 0; c < num; c++){
				Console.WriteLine((c + 1) + "번 반복");
				int i = FindWindow("#32770", null);
				int a = FindWindowEx(i, 0, "RichEdit20W", null);
				SendMessage(a, 0x000c, 0, str);
    			PostMessage(a, 0x0100, 0xD, 0x1C001);
    			Thread.Sleep(200);
			}
		}
	}
}
