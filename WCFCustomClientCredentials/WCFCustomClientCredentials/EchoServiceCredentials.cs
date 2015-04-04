namespace WCFCustomClientCredentials
{
    using System.IdentityModel.Selectors;
    using System.ServiceModel.Description;

    public class EchoServiceCredentials : ServiceCredentials
    {
        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new EchoServiceCredentialsSecurityTokenManager(this);
        }

        protected override ServiceCredentials CloneCore()
        {
            return new EchoServiceCredentials();
        }
    }
}