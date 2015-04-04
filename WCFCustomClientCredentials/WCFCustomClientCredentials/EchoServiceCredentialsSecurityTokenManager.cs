namespace WCFCustomClientCredentials
{
    using System.IdentityModel.Selectors;
    using System.ServiceModel.Description;
    using System.ServiceModel.Security;

    public class EchoServiceCredentialsSecurityTokenManager : ServiceCredentialsSecurityTokenManager
    {
        public EchoServiceCredentialsSecurityTokenManager(ServiceCredentials parent)
            : base(parent)
        {
        }

        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            if (tokenRequirement.TokenType == EchoConstants.EchoTokenType)
            {
                outOfBandTokenResolver = null;
                return new EchoSecurityTokenAuthenticator();
            }
            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            return new EchoSecurityTokenSerializer(version);
        }
    }
}