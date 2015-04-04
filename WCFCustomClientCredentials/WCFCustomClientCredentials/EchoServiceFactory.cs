namespace WCFCustomClientCredentials
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    public class EchoServiceFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new EchoServiceHost(new[]
            {
                new Uri("http://echo.local/")
            });
        }
    }
}