using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Prehistoric
{
    public class FileDownload
    {
        public void Download(string address, string fileName)
        {
            WebClient client = new WebClient();

            client.DownloadFile(address, fileName);
        }
    }
}
