namespace Shared
{
    using System.ServiceModel.Channels;
    using System.ServiceModel.Security.Tokens;

    public class BindingHelper
    {
        public Binding CreateHttpBinding()
        {
            var httpTransport = new HttpTransportBindingElement
            {
                MaxReceivedMessageSize = 10000000
            };

            var messageSecurity = new SymmetricSecurityBindingElement();
			messageSecurity.EndpointSupportingTokenParameters.SignedEncrypted.Add(new EchoTokenParameters());

            var x509ProtectionParameters = new X509SecurityTokenParameters
            {
                InclusionMode = SecurityTokenInclusionMode.Never
            };

            messageSecurity.ProtectionTokenParameters = x509ProtectionParameters;
            return new CustomBinding(messageSecurity, httpTransport);
        }

        public Binding CreateHttpsBinding()
        {
            var httpTransport = new HttpsTransportBindingElement
            {
                MaxReceivedMessageSize = 10000000
            };

            var messageSecurity = new SymmetricSecurityBindingElement();

            var x509ProtectionParameters = new X509SecurityTokenParameters
            {
                InclusionMode = SecurityTokenInclusionMode.Never
            };

            messageSecurity.ProtectionTokenParameters = x509ProtectionParameters;
            return new CustomBinding(messageSecurity, httpTransport);
        }


    }
}