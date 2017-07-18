using System;
using System.IO;

namespace ChatStrip
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Stripping chat messages from serverlog.log into ChatMessages.txt");
			var lines = File.ReadAllLines("serverlog.log");
			foreach (var line in lines)
				if (line.Contains("ChatWindow"))
					using (StreamWriter w = File.AppendText("ChatMessages.txt"))
					{
						string tmpStr = line.Replace("ChatWindow: Character ", string.Empty);
						string tmpA = tmpStr.Remove(25, 5);
						string tmpB = tmpA.Remove(20, 4);
						w.WriteLine(tmpB);
					}
			Console.WriteLine("\n\nPress any key to quit ...");
			Console.ReadKey(true);
		}
	}
}
