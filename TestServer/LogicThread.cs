using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    internal class LogicThread
    {
        Thread thread;

        public LogicThread()
        {
            thread = new Thread(() => Run());
        }

        public void Run()
        {
            while (true)
            {
            }
        }

        public void Start()
        {
            thread.Start();
        }

        public Task<common.ErrorCode> ProcessPacket(byte[] msg)
        {
            /*
            switch(msg.packetType)
            {
                case Protocol.PacketType.CG_HEARTBEAT_ASYNC_REQ:
                {
                    var packet = msg as Protocol.CG_HEARTBEAT_ASYNC_REQ;
                    if (null == packet)
                        break;
                }
                    break;
                case Protocol.PacketType.CG_HEARTBEAT_SYNC_REQ:
                {
                    var packet = msg as Protocol.CG_HEARTBEAT_SYNC_REQ;
                    if (null == packet)
                        break;
                }
                    break;
            }
            */
            return Task.FromResult(common.ErrorCode.NoError);
        }
    }
}
