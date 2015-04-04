namespace Shared
{
    public class EchoConstants
    {
        public const string EchoNamespace = "https://echo/";

        public const string EchoLicenseKeyClaim = EchoNamespace + "Claims/LicenseKey";
        public const string EchoUniqueCodeClaim = EchoNamespace + "Claims/UniqueCode";
        public const string EchoUserNameClaim = EchoNamespace + "Claims/UserName";
        public const string EchoTokenType = EchoNamespace + "Tokens/EchoToken";

        public const string EchoTokenPrefix = "ct";
        public const string EchoUrlPrefix = "url";
        public const string EchoTokenName = "EchoToken";
        public const string Id = "Id";
        public const string WsUtilityPrefix = "wsu";
        public const string WsUtilityNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";

        public const string EchoLicenseKeyElementName = "LicenseKey";
        public const string EchoUniqueCodeElementName = "UniqueCodeKey";
        public const string EchoUserNameElementName = "UserNameKey";
    }
}