using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;


namespace ThreadFun
{
	class Program
	{


		static void Print(object lineNumber)
		{

			ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));


			while (true)
			{
				foreach (var color in colors)
				{
					if (color == ConsoleColor.Black)
						continue;

					Console.ForegroundColor = color;
					lock (locker)  // курсор то разделяемый ресурс
					{
						Console.SetCursorPosition(0, (int)lineNumber);
						for (int i = 0; i <= 10; i++)
						{

							Console.Write('.');
							Thread.Sleep(1);
						}
						Console.Write('|');
						Console.SetCursorPosition(0, (int)lineNumber);
					}
				}
			}
		}

		static object locker = new object();
		static void Main(string[] args)
		{
			Console.CursorVisible = false;


			for (int i = 0; i < 10; i++)
			{
				Thread thread = new Thread(new ParameterizedThreadStart(Print));
				thread.Start(i);
			}
			
		}
	}
}
