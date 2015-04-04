namespace WCFCustomClientCredentials
{
    using System;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.ServiceModel.Security;
    using System.Xml;

    public class EchoSecurityTokenSerializer : WSSecurityTokenSerializer
    {
        private readonly SecurityTokenVersion _version;

        public EchoSecurityTokenSerializer(SecurityTokenVersion version)
        {
            _version = version;
        }

        protected override bool CanReadTokenCore(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.IsStartElement(EchoConstants.EchoTokenName, EchoConstants.EchoNamespace))
            {
                return true;
            }
            return base.CanReadTokenCore(reader);
        }

        protected override SecurityToken ReadTokenCore(XmlReader reader, SecurityTokenResolver tokenResolver)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.IsStartElement(EchoConstants.EchoTokenName, EchoConstants.EchoNamespace))
            {
                string id = reader.GetAttribute(EchoConstants.Id, EchoConstants.WsUtilityNamespace);

                reader.ReadStartElement();

                string licenseKey = reader.ReadElementString(EchoConstants.EchoLicenseKeyElementName, EchoConstants.EchoNamespace);
                string companyKey = reader.ReadElementString(EchoConstants.EchoUniqueCodeElementName, EchoConstants.EchoNamespace);
                string machineKey = reader.ReadElementString(EchoConstants.EchoUserNameElementName, EchoConstants.EchoNamespace);

                reader.ReadEndElement();

                return new EchoToken(licenseKey, companyKey, machineKey, id);
            }
            return DefaultInstance.ReadToken(reader, tokenResolver);
        }

        protected override bool CanWriteTokenCore(SecurityToken token)
        {
            if (token is EchoToken)
            {
                return true;
            }
            return base.CanWriteTokenCore(token);
        }

        protected override void WriteTokenCore(XmlWriter writer, SecurityToken token)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            var EchoToken = token as EchoToken;
            if (EchoToken != null)
            {
                writer.WriteStartElement(EchoConstants.EchoTokenPrefix, EchoConstants.EchoTokenName, EchoConstants.EchoNamespace);
                writer.WriteAttributeString(EchoConstants.WsUtilityPrefix, EchoConstants.Id, EchoConstants.WsUtilityNamespace, token.Id);
                writer.WriteElementString(EchoConstants.EchoLicenseKeyElementName, EchoConstants.EchoNamespace, EchoToken.LicenseKey);
                writer.WriteElementString(EchoConstants.EchoUniqueCodeElementName, EchoConstants.EchoNamespace, EchoToken.UniqueCode);
                writer.WriteElementString(EchoConstants.EchoUserNameElementName, EchoConstants.EchoNamespace, EchoToken.UserName);
                writer.WriteEndElement();
                writer.Flush();
            }
            else
            {
                base.WriteTokenCore(writer, token);
            }
        }
    }
}