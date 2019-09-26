using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FirebaseTest
{
    class Program
    {
        static void PrintUser(User user)
        {
            if (user != null)
            {
                Console.WriteLine($"User: {user.TelegramID}; {user.Name}; {user.IsB2C}; {user.Login1C}; {user.Password1C}");
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }
        
        private static async Task Run()
        {
            //TODO: Authentication

            #region fill user repository
            var repository = new List<User>
            {
                new User
                {
                    TelegramID = 2353,
                    IsB2C = true,
                    Name = "Petya",
                    Login1C = "02351",
                    Password1C = "12345"
                },
                new User
                {
                    TelegramID = 4356,
                    IsB2C = false,
                    Name = "Sasha",
                    Login1C = "88765",
                    Password1C = "88776"
                },
                new User
                {
                    TelegramID = 8790,
                    IsB2C = true,
                    Name = "Misha",
                    Login1C = "33445",
                    Password1C = "5656"
                },
                new User
                {
                    TelegramID = 1111,
                    IsB2C = true,
                    Name = "Terminator",
                    Login1C = "777",
                    Password1C = "0000"
                },
                new User
                {
                    TelegramID = 4356,
                    IsB2C = true,
                    Name = "Grisha",
                    Login1C = "88765",
                    Password1C = "88776"
                }
            };
            #endregion

            // add / update user
            foreach (var item in repository)
            {
                await FirebaseHelper.AddUser(item.TelegramID.ToString(), JsonConvert.SerializeObject(item));
            }
            Console.WriteLine("Added users to Firebase done!");

            // get all users
            var users = await FirebaseHelper.GetAllUsers();
            foreach (var item in users) PrintUser(item);
            Console.WriteLine(new string('-', 20));

            // get user by TelegramID => "Misha"
            var userMisha = await FirebaseHelper.GetUser(8790);
            PrintUser(userMisha);
            // get user by TelegramID => "<None>"
            var userNone = await FirebaseHelper.GetUser(0);
            PrintUser(userNone);
            Console.WriteLine();

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        static void Main(string[] args) => Run().Wait();
    }
}
