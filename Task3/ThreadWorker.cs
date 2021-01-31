using System;
using System.Threading;

namespace Task3
{
    public class ThreadWorker
    {
        private int  _successCounter = 0, _failCounter = 0;
        private LoginClient _loginer = new LoginClient();

        public void TryLogin(object loginPassword)
        {
            Credentials loginPasswordPair = loginPassword as Credentials;
            string result = _loginer.Login(loginPasswordPair.Login, loginPasswordPair.Password);
            if (String.IsNullOrEmpty(result))
                Interlocked.Increment(ref _failCounter);
            else
                Interlocked.Increment(ref _successCounter); 
        }
        public JsonResultModel GetCounters() => new JsonResultModel(_successCounter, _failCounter);
    }
}
