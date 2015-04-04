namespace WcfTestClient
{
    using System;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using Shared;

    public class EchoTokenProvider : SecurityTokenProvider
    {
        private readonly EchoClientCredentials _credentials;

        public EchoTokenProvider(EchoClientCredentials credentials)
        {
            if (credentials == null) throw new ArgumentNullException("credentials");

            _credentials = credentials;
        }

        protected override SecurityToken GetTokenCore(TimeSpan timeout)
        {
            return new EchoToken(_credentials.LicenseKey, _credentials.UniqueCode, _credentials.ClientUserName);
        }
    }
}