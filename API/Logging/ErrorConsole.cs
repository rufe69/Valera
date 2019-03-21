using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
	public static class ErrorConsole
	{
		public static void WriteLine(string text)
		{
			Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
			Console.WriteLine($"Error: {text}");
			Console.ResetColor();
		}
	}
}
