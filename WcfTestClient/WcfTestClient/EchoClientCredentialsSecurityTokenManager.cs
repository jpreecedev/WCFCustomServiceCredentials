namespace WcfTestClient
{
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.ServiceModel;
    using System.ServiceModel.Security.Tokens;
    using Shared;

    public class EchoClientCredentialsSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        private readonly EchoClientCredentials _credentials;

        public EchoClientCredentialsSecurityTokenManager(EchoClientCredentials connectClientCredentials)
            : base(connectClientCredentials)
        {
            _credentials = connectClientCredentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            if (tokenRequirement.TokenType == EchoConstants.EchoTokenType)
            {
                // Handle this token for Custom.
                return new EchoTokenProvider(_credentials);
            }
            if (tokenRequirement is InitiatorServiceModelSecurityTokenRequirement)
            {
                // Return server certificate.
                if (tokenRequirement.TokenType == SecurityTokenTypes.X509Certificate)
                {
                    return new X509SecurityTokenProvider(_credentials.ServiceCertificate.DefaultCertificate);
                }
            }
            return base.CreateSecurityTokenProvider(tokenRequirement);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            return new EchoSecurityTokenSerializer(version);
        }
    }
}