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
        Queue<Protocol.Protocol> msgQueue;

        public LogicThread()
        {
            thread = new Thread(() => Run());
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1);
                if (msgQueue != null)
                {
                    var msg = msgQueue.Dequeue();
                    ProcessPacket(msg);
                }
            }
        }

        public void Start()
        {
            thread.Start();
        }

        public Task<common.ErrorCode> ProcessPacket(Protocol.Protocol msg)
        {
            switch(msg.packetType)
            {
                case Protocol.PacketType.CG_HEARTBEAT_ASYNC_REQ:
                {
                    var packet = (Protocol.CG_HEARTBEAT_ASYNC_REQ)msg;
                    break;
                }
                case Protocol.PacketType.CG_HEARTBEAT_SYNC_REQ:
                {
                    var packet = (Protocol.CG_HEARTBEAT_SYNC_REQ)msg;
                    break;
                }
            }

            return Task.FromResult(common.ErrorCode.NoError);
        }
    }
}
