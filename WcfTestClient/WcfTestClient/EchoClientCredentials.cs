namespace WcfTestClient
{
    using System.IdentityModel.Selectors;
    using System.ServiceModel.Description;

    public class EchoClientCredentials : ClientCredentials
    {
        public string LicenseKey { get; private set; }
        public string UniqueCode { get; private set; }
        public string ClientUserName { get; private set; }

        public EchoClientCredentials(string licenseKey, string uniqueCode, string userName)
        {
            LicenseKey = licenseKey;
            UniqueCode = uniqueCode;
            ClientUserName = userName;
        }

        protected override ClientCredentials CloneCore()
        {
            return new EchoClientCredentials(LicenseKey, UniqueCode, ClientUserName);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            return new EchoClientCredentialsSecurityTokenManager(this);
        }
    }
}