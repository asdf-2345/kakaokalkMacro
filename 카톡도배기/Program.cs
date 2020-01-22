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
		string answer = "";
			Console.WriteLine("도배하시려는 말을 입력해주세요");
			string str = Console.ReadLine();
			Console.WriteLine("얼마나 반복하실겁니까?");
			int number = 0;
		a:
			try{
				number = int.Parse(Console.ReadLine());
			}
			catch{
				Console.WriteLine("다시 입력해주세요.");
				goto a;
			}
			Console.WriteLine("원하시는 채팅방 이름을 입력해주세요");
			string ChatRoomName = Console.ReadLine();
		b:
			macro(number, str, ChatRoomName);
			
			Console.WriteLine("다시하시겠습니까?(예 - 0, 아니오 - 0이 아닌수)");
			answer = Console.ReadLine();
			if(answer != "0"){
				Environment.Exit(0);
			}
			
			Console.WriteLine("이 설정 그대로 - 0 \n처음부터 다시 - 1 \n채팅방 이름만 바꾸기 - 2 \n도배할 말만 바꾸기 - 3 \n반복 횟수만 바꾸기 - 4");
			answer = Console.ReadLine();
		c:
			if(answer == "0"){
				goto b;
			}
			else if(answer == "1"){
				goto first;
			}
			else if(answer == "2"){
				Console.WriteLine("원하시는 채팅방 이름을 입력해주세요");
				ChatRoomName = Console.ReadLine();
				goto b;
			}
			else if(answer == "3"){
				Console.WriteLine("도배하시려는 말을 입력해주세요");
				str = Console.ReadLine();
				goto b;
			}
			else if(answer == "4"){
				Console.WriteLine("얼마나 반복 하시겠습니까?");
			d:
				try{
					number = int.Parse(Console.ReadLine());
				}
				catch{
					Console.WriteLine("다시입력해주세요");
					goto d;
				}
				goto b;
			}
			else{
				Console.WriteLine("다시입력해주세요");
				goto c;
			}
		}
		
		public static void macro(int num, string str, string ChatRoomName){
			int i = FindWindow(null, ChatRoomName);
			int a = FindWindowEx(i, 0, "RichEdit20W", null);
			for(int c = 0; c < num; c++){
				Console.WriteLine((c + 1) + "번 반복");
				SendMessage(a, 0x000c, 0, str);
    			PostMessage(a, 0x0100, 0xD, 0x1C001);
    			Thread.Sleep(200);
			}
		}
	}
}
