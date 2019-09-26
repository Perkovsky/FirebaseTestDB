using System;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace FirebaseTest.Services
{
    public class FirebaseService: IDisposable
    {
        private const string BASE_URL = "https://testdb-32619.firebaseio.com/";
        private const string AUTH = "TJVs7OWpIsiKOFmmhEYhyd5cz1qPvPqz99xuf2CS";
        private const string ROOT_KEY_EVENTS = "events";

		private readonly FirebaseClient _client;

		public FirebaseService()
		{
			_client = new FirebaseClient(BASE_URL, new FirebaseOptions
			{
				AuthTokenAsyncFactory = () => Task.FromResult(AUTH)
			});
		}

        public async Task AddEvent(/*string childKey,*/ string data)
        {
			await _client.Child(ROOT_KEY_EVENTS)
				.Child(Guid.NewGuid().ToString())
                .PutAsync(data);
        }

		public void Dispose()
		{
			_client.Child(ROOT_KEY_EVENTS).Dispose();
		}
	}
}
