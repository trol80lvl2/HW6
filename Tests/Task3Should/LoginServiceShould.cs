using System;
using System.IO;
using System.Threading.Tasks;
using Task3;
using Xunit;

namespace Tests.Task3Should
{
    public class LoginServiceShould
    {
        Random rnd = new Random();
        [Fact]
        public async Task CorrectCountOfCredentialsAreCreated()
        {
            int countCredentials = rnd.Next(100, 1000);
            await LoginService.GenerateLoginsAsync(countCredentials);
            int countInFile = File.ReadAllLines("login.csv").Length;
            Assert.Equal(countCredentials, countInFile);
        }
        [Fact]
        public async Task CorrectCountOfCredentialsAreReturned()
        {
            int countCredentials = rnd.Next(100, 1000);
            await LoginService.GenerateLoginsAsync(countCredentials);
            var returned = await LoginService.GetLoginsAsync();
            Assert.Equal(countCredentials, returned.Count);
        }
    }
}
