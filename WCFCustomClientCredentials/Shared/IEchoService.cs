namespace Shared
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IEchoService
    {
        [OperationContract]
        string Echo(int value);
    }
}