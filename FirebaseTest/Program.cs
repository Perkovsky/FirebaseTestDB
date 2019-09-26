using System;
using Newtonsoft.Json;
using FirebaseTest.Models;
using FirebaseTest.Services;

namespace FirebaseTest
{
    class Program
    {
		static void Main(string[] args)
		{
			using (var firebaseService = new FirebaseService())
			{
				while (true)
				{
					Console.Write("Enter your message: ");
					string msg = Console.ReadLine();
					if (msg.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
						break;

					int left = msg.Length + 20;
					Console.SetCursorPosition(left, Console.CursorTop - 1);
					Console.WriteLine(" -> sended.");

					var @event = new Event { Message = msg };
					firebaseService.AddEvent(JsonConvert.SerializeObject(@event)).Wait();
				}
			}
		}
	}
}
