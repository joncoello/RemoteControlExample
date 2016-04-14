using System.ServiceModel;

namespace RemoteControlExample.Controllers
{
    [ServiceContract]
    internal interface IActionManager
    {
        [OperationContract]
        void SendMessage(string message);
    }
}