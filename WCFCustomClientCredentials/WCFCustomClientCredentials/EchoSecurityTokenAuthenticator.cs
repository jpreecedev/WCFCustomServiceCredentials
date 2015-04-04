namespace WCFCustomClientCredentials
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;

    public class EchoSecurityTokenAuthenticator : SecurityTokenAuthenticator
    {
        protected override bool CanValidateTokenCore(SecurityToken token)
        {
            return (token is EchoToken);
        }

        protected override ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token)
        {
            var echoToken = token as EchoToken;

            if (echoToken == null)
            {
                throw new ArgumentNullException("token");
            }

            var authorizationException = IsAuthorized(echoToken.LicenseKey, echoToken.UniqueCode, echoToken.UserName);
            if (authorizationException != null)
            {
                throw authorizationException;
            }

            var policies = new List<IAuthorizationPolicy>(3)
            {
                CreateAuthorizationPolicy(EchoConstants.EchoLicenseKeyClaim, echoToken.LicenseKey, Rights.PossessProperty),
                CreateAuthorizationPolicy(EchoConstants.EchoUniqueCodeClaim, echoToken.UniqueCode, Rights.PossessProperty),
                CreateAuthorizationPolicy(EchoConstants.EchoUserNameClaim, echoToken.UserName, Rights.PossessProperty),
            };

            return policies.AsReadOnly();
        }

        private static Exception IsAuthorized(string licenseKey, string uniqueCode, string userName)
        {
            Exception result = null;

            //Check if user is authorized.  If not you must return a FaultException

            return result;
        }

        private static EchoTokenAuthorizationPolicy CreateAuthorizationPolicy<T>(string claimType, T resource, string rights)
        {
            return new EchoTokenAuthorizationPolicy(new DefaultClaimSet(new Claim(claimType, resource, rights)));
        }
    }
}