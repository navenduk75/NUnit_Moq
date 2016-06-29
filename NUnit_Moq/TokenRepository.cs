using System;
using System.Collections.Generic;

namespace NUnit_Moq
{
    public enum TokenType
    {
        AccessToken = 1,
        RefreshToken = 2
    }
    public interface IStore
    {
        void SaveToken(IToken token);
        IToken GetToken(TokenType tokenType, string client_id);
    }

    public interface IToken
    {

    }
    
    public class TokenRepository
    {
        private IStore _store;
        public TokenRepository(IStore store)
        {
            this._store = store;
        }

        public AccessToken GetAccessToken(string client_id)
        {
            return _store.GetToken(TokenType.AccessToken, client_id) as AccessToken;
        }

        public RefreshToken GetRefreshToken(string client_id)
        {
            return _store.GetToken(TokenType.RefreshToken, client_id) as RefreshToken;
        }

        public void SaveAccessToken(AccessToken accessToken)
        {
            _store.SaveToken(accessToken);
        }

        public void SaveRefreshToken(RefreshToken refreshToken)
        {
            _store.SaveToken(refreshToken);
        }
    }
}