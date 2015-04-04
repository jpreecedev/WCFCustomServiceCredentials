namespace WCFCustomClientCredentials
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using Properties;
    using Shared;

    public class EchoServiceHost : ServiceHost
    {
        public EchoServiceHost(params Uri[] addresses)
            : base(typeof(EchoService), addresses)
        {
        }

        protected override void InitializeRuntime()
        {
            var baseUri = new Uri("http://echo.local");
            var serviceUri = new Uri(baseUri, "EchoService.svc");

            Description.Behaviors.Remove((typeof(ServiceCredentials)));

            var serviceCredential = new EchoServiceCredentials();
            serviceCredential.ServiceCertificate.Certificate = new X509Certificate2(Resources.echo, string.Empty, X509KeyStorageFlags.MachineKeySet);
            Description.Behaviors.Add(serviceCredential);

            var behaviour = new ServiceMetadataBehavior { HttpGetEnabled = true, HttpsGetEnabled = false };
            Description.Behaviors.Add(behaviour);

            Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            Description.Behaviors.Find<ServiceDebugBehavior>().HttpHelpPageUrl = serviceUri;

            AddServiceEndpoint(typeof(IEchoService), new BindingHelper().CreateHttpBinding(), string.Empty);

            base.InitializeRuntime();
        }
    }
}