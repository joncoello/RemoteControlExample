using RemoteControlExample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RemoteControlExample.Controllers
{
    public class ActionController : ApiController
    {
        public object Post(ActionRequest actionRequest) {
            Process.Start(@"C:\Program Files (x86)\CCH ProSystem\Deploy\ClientFrameWork.exe");
            return Ok();
        }

    }
}
