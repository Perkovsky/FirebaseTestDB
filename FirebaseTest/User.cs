using System.Text;
using Newtonsoft.Json;

namespace FirebaseTest
{
    public class User
    {
        public int TelegramID { get; set; }
        public string Login1C { get; set; } // code of client in 1C
        public string Password1C { get; set; }
        [JsonIgnore]
        public LoginState? State { get; set; }
        public string Name { get; set; }
        public bool IsB2C { get; set; }
        [JsonIgnore]
        public bool IsAuthorized => State == LoginState.Authorized;

        public void Clear()
        {
            Login1C = null;
            Password1C = null;
            State = null;
            Name = null;
            IsB2C = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TelegramID: {TelegramID}");
            sb.AppendLine($"Login1C: {Login1C}");
            sb.AppendLine($"Password1C: {Password1C}");
            sb.AppendLine($"State: {State}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"IsB2C: {IsB2C}");

            return sb.ToString();
        }
    }
}
