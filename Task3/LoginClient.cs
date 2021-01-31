using System;
using System.Threading;

namespace Task3
{
    public class LoginClient
    {
        Random _random = new Random();
        public string Login(string login, string password)
        {
            Thread.Sleep(_random.Next(0,1000));
            return _random.NextDouble() > 0.49 ? Guid.NewGuid().ToString() : null;
        }
    }
}
