using Common.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JwtUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private ServiceProvider _serviceProvider;

        private AuthenticationTokenResponse authenticationTokenResponse;
        [TestInitialize] // run before each test
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddJWTAuthentication(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build());
            _serviceProvider = services.BuildServiceProvider();
            authenticationTokenResponse = _serviceProvider.GetService<AuthenticationTokenResponse>();

        }

        [TestCleanup]
        public void Cleanup()
        {
            if (_serviceProvider != null)
            {
                _serviceProvider.Dispose();
            }
        }


        [TestMethod]
        public void TestJwtResponse()
        {            
            Assert.IsNotNull(authenticationTokenResponse, "AuthenticationTokenResponse should not be null");
            var token = authenticationTokenResponse.GetResponseToken(1, "testusername", null, null);
           
            Assert.IsNotNull(token, "Token  should not be null");
            Assert.IsTrue(token.AccessToken.Length > 0, "Token should have value");
          
        }
        [TestMethod]
        public void TestJwtResponseWithRoles()
        {
            Assert.IsNotNull(authenticationTokenResponse, "AuthenticationTokenResponse should not be null");
            var token = authenticationTokenResponse.GetResponseToken(1, "testusername", new List<string>()
            {
                "Admin",
            });

            Assert.IsNotNull(token, "Token  should not be null");
            Assert.IsTrue(token.AccessToken.Length > 0, "Token should have value");

        }

    }
}