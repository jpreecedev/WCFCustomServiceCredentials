namespace WCFCustomClientCredentials
{
    using System.ServiceModel;
    using Shared;

    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class EchoService : IEchoService
    {
        public string Echo(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}