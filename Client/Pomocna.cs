using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace Client
{
    public class Pomocna
    {
        static IPozoriste proxy = null;
        static ChannelFactory<IPozoriste> channel = new ChannelFactory<IPozoriste>(
            new BasicHttpBinding(),
            new EndpointAddress("http://localhost:8000"));

        public static IPozoriste Proxy
        {
            get
            {
                if(proxy == null || channel.State != CommunicationState.Opened)
                {
                    proxy = channel.CreateChannel();
                }
                return proxy;
            }
        }
    }
}
