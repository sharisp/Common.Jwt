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
        [TestInitialize] // ÿ�����Է�������ǰִ��
        public void Setup()
        {
            // 1. ���� DI ����
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
            // 2. ��ȡ AuthenticationTokenResponse ʵ��

            Assert.IsNotNull(authenticationTokenResponse, "AuthenticationTokenResponse should not be null");
            var token = authenticationTokenResponse.GetResponseToken(1, "testusername", null, null);
            // 3. ��֤Ĭ��ֵ
            Assert.IsNotNull(token, "Token  should not be null");
            Assert.IsTrue(token.AccessToken.Length > 0, "Token should have value");
          
        }
    }
}