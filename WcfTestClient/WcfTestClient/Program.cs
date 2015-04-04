namespace WcfTestClient
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using Properties;
    using Shared;

    internal class Program
    {
        private static void Main()
        {
            var serviceAddress = new EndpointAddress("http://echo.local/EchoService.svc");

            var channelFactory = new ChannelFactory<IEchoService>(new BindingHelper().CreateHttpBinding(), serviceAddress);

            var credentials = new EchoClientCredentials("license key", "unique code", "user name");
            var certificate = new X509Certificate2(Resources.echo);
            credentials.ServiceCertificate.DefaultCertificate = certificate;

            channelFactory.Endpoint.Behaviors.Remove(typeof(ClientCredentials));
            channelFactory.Endpoint.Behaviors.Add(credentials);

            var service = channelFactory.CreateChannel();
            Console.WriteLine(service.Echo(10));

            Console.ReadLine();
        }
    }
}