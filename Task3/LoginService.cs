using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace Task3
{
    public static class LoginService
    {
        private static readonly string _path = "login.csv";

        public static async Task GenerateLoginsAsync(int count)
        {
            string[] logins = new string[count];

            for (int i = 0; i < count; i++)
            {
                logins[i] = "login" + i.ToString() + ";" + "password" + i.ToString();
            }

            await File.WriteAllLinesAsync(_path, logins);
        }
        public static async Task<ConcurrentQueue<Credentials>> GetLoginsAsync()
        {
            ConcurrentQueue<Credentials> queue = new ConcurrentQueue<Credentials>();
            string[] logins = await File.ReadAllLinesAsync(_path);

            for (int i = 0; i < logins.Length; i++) 
            {
                string[] temp = logins[i].Split(";");
                queue.Enqueue(new Credentials { Login = temp[0], Password = temp[1] });
            }

            return queue;
        }
    }
}
