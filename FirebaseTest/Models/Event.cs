using System;

namespace FirebaseTest.Models
{
	public class Event
	{
		public string Id { get; private set; }
		public string Message { get; set; }

		public Event() => Id = Guid.NewGuid().ToString();
	}
}
