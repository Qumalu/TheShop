using System;

namespace TheShop
{
	public class Logger : ILogger
	{
		public void Log(LogMessageType logMessageType, string message)
		{
			if (string.IsNullOrWhiteSpace(message))
				throw new ArgumentNullException("Message can not be empty!");

			Console.WriteLine(logMessageType.ToString() + ": " + message);
		}
	}

}
