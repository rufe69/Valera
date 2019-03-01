using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
	public class WarningConsole
	{
		public static void WriteLine(string text)
		{
			Console.ForegroundColor = ConsoleColor.Cyan; // устанавливаем цвет
			Console.WriteLine(text);
			Console.ResetColor();
		}
	}
}
