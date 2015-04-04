namespace WCFCustomClientCredentials
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;

    public class EchoTokenAuthorizationPolicy : IAuthorizationPolicy
    {
        private readonly string _id;
        private readonly IEnumerable<ClaimSet> _issuedClaimSets;
        private readonly ClaimSet _issuer;

        public EchoTokenAuthorizationPolicy(ClaimSet issuedClaims)
        {
            if (issuedClaims == null)
            {
                throw new ArgumentNullException("issuedClaims");
            }

            _issuer = issuedClaims.Issuer;
            _issuedClaimSets = new[] { issuedClaims };
            _id = Guid.NewGuid().ToString();
        }

        public ClaimSet Issuer
        {
            get { return _issuer; }
        }

        public string Id
        {
            get { return _id; }
        }

        public bool Evaluate(EvaluationContext context, ref object state)
        {
            foreach (ClaimSet issuance in _issuedClaimSets)
            {
                context.AddClaimSet(this, issuance);
            }

            return true;
        }
    }
}