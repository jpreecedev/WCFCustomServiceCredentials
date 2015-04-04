namespace Shared
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IdentityModel.Tokens;

    public class EchoToken : SecurityToken
    {
        private readonly DateTime _effectiveTime = DateTime.UtcNow;
        private readonly string _id;
        private readonly ReadOnlyCollection<SecurityKey> _securityKeys;

        public string LicenseKey { get; set; }
        public string UniqueCode { get; set; }
        public string UserName { get; set; }

        public EchoToken(string licenseKey, string uniqueCode, string userName, string id = null)
        {
            LicenseKey = licenseKey;
            UniqueCode = uniqueCode;
            UserName = userName;

            _id = id ?? Guid.NewGuid().ToString();
            _securityKeys = new ReadOnlyCollection<SecurityKey>(new List<SecurityKey>());
        }

        public override string Id
        {
            get { return _id; }
        }

        public override ReadOnlyCollection<SecurityKey> SecurityKeys
        {
            get { return _securityKeys; }
        }

        public override DateTime ValidFrom
        {
            get { return _effectiveTime; }
        }

        public override DateTime ValidTo
        {
            get { return DateTime.MaxValue; }
        }
    }
}