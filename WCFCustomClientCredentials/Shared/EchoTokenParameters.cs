namespace Shared
{
    using System;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.ServiceModel.Security.Tokens;

    public class EchoTokenParameters : SecurityTokenParameters
    {
        public EchoTokenParameters()
        {
        }

        protected EchoTokenParameters(EchoTokenParameters other)
            : base(other)
        {
        }

        protected override bool HasAsymmetricKey
        {
            get { return false; }
        }

        protected override bool SupportsClientAuthentication
        {
            get { return false; }
        }

        protected override bool SupportsClientWindowsIdentity
        {
            get { return false; }
        }

        protected override bool SupportsServerAuthentication
        {
            get { return false; }
        }

        protected override SecurityTokenParameters CloneCore()
        {
            return new EchoTokenParameters(this);
        }

        protected override void InitializeSecurityTokenRequirement(SecurityTokenRequirement requirement)
        {
            requirement.TokenType = EchoConstants.EchoTokenType;
        }

        protected override SecurityKeyIdentifierClause CreateKeyIdentifierClause(SecurityToken token, SecurityTokenReferenceStyle referenceStyle)
        {
            if (referenceStyle == SecurityTokenReferenceStyle.Internal)
            {
                return token.CreateKeyIdentifierClause<LocalIdKeyIdentifierClause>();
            }
            throw new NotSupportedException("External references are not supported for echo tokens");
        }
    }
}