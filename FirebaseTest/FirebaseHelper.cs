using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace FirebaseTest
{
    static class FirebaseHelper
    {
        static readonly string BASE_URL = "https://testdb-32619.firebaseio.com/";
        static readonly string AUTH = "TJVs7OWpIsiKOFmmhEYhyd5cz1qPvPqz99xuf2CS";
        static readonly string ROOT_KEY_USERS = "users";

        private static FirebaseClient GetFirebaseClient()
        {
            return new FirebaseClient(BASE_URL, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(AUTH)
            });
        }

        public static async Task AddUser(string childKey, string data)
        {
            FirebaseClient client = GetFirebaseClient();
            await client.Child(ROOT_KEY_USERS)
                        .Child(childKey)
                        .PutAsync(data);
        }

        public static async Task<IEnumerable<User>> GetAllUsers()
        {
            FirebaseClient client = GetFirebaseClient();
            var users = await client.Child(ROOT_KEY_USERS)
                                    .OnceAsync<User>();

            return users.Select(u => u.Object);
        }

        public static async Task<User> GetUser(int telegramID)
        {
            FirebaseClient client = GetFirebaseClient();
            var users = await client.Child(ROOT_KEY_USERS)
                                    .OnceAsync<User>();

            return users.Where(u => u.Key == telegramID.ToString()).FirstOrDefault()?.Object;
        }
    }
}
