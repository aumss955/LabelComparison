using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TraceabilityNew
{
    class WebAPI
    {

        public static bool CheckForInternetConnection(string url)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://localhost:8000/"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
