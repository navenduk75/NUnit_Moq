using NUnit.Framework;
using System.Collections.Generic;
using System;
using Moq;

namespace NUnit_Moq
{
    [TestFixture]
    public class TokenRepositoryUnitTest
    {
        private Mock<IStore> mockStore;

        [SetUp]
        public void Setup()
        {
            mockStore = new Mock<IStore>();
        }

        [Test]
        public void SaveAccessToken_ValueGetSaved()
        {
            TokenRepository repo = new TokenRepository(mockStore.Object);
            repo.SaveAccessToken(new AccessToken());
            mockStore.Verify(m => m.SaveToken(It.IsAny<IToken>()), Times.Once);
        }

        [Test]
        public void SaveRefeshToken_ValueGetSaved()
        {
            TokenRepository repo = new TokenRepository(mockStore.Object);
            repo.SaveRefreshToken(new RefreshToken());
            mockStore.Verify(m => m.SaveToken(It.IsAny<IToken>()), Times.Once);
        }

        [Test]
        public void GetAccessToken_ValueReturned()
        {
            string client_id = "123";
            AccessToken accessToken = new AccessToken { Id = 1, Client_Id = client_id};
            mockStore.Setup(m => m.GetToken(TokenType.AccessToken, client_id)).Returns(accessToken);

            TokenRepository repo = new TokenRepository(mockStore.Object);
            var actualValue = repo.GetAccessToken(client_id);
            Assert.AreEqual(actualValue, accessToken);
        }

        [Test]
        public void GetRefreshToken_ValueReturned()
        {
            string client_id = "123";
            RefreshToken refreshToken = new RefreshToken { Id = 1, Client_Id = client_id };
            mockStore.Setup(m => m.GetToken(TokenType.RefreshToken, client_id)).Returns(refreshToken);

            TokenRepository repo = new TokenRepository(mockStore.Object);
            var actualValue = repo.GetRefreshToken(client_id);
            Assert.AreEqual(actualValue, refreshToken);
        }

        [TearDown]
        public void CleanUp()
        {
            // Any cleanup code comes here
        }
    }
}
