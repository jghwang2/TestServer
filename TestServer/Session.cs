using SuperSocket.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    class Session : AppSession
    {
        int heartbeatCount { get; set; }

        public Session()
        {
        }

        public void AddHeartbeatCount(int addCount = 1)
        {
            if (heartbeatCount + addCount > int.MaxValue)
                heartbeatCount = 0;

            heartbeatCount += addCount;
        }

        public int GetHeartbeatCount() {  return heartbeatCount; }
    }
}
