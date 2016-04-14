using RemoteControlExample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RemoteControlExample.Controllers
{
    public class ActionController : ApiController
    {
        public object Post(ActionRequest actionRequest) {

            if (actionRequest.ActionName == "start")
            {
                Process.Start(@"C:\Program Files (x86)\CCH ProSystem\Deploy\ClientFrameWork.exe");
            }
            else
            {
                string uri = "net.pipe://localhost/central";
                var a = new EndpointAddress(uri);
                var b = new NetNamedPipeBinding();
                var c = ChannelFactory<IActionManager>.CreateChannel(b, a);
                try
                {
                    c.SendMessage(actionRequest.ActionName);
                }
                catch (Exception){}
                
            }
            
            return Ok();
        }

    }
}
