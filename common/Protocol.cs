using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public enum PacketType : int
    {
        CG_HEARTBEAT_SYNC_REQ = 1,
        CG_HEARTBEAT_SYNC_RES,
        CG_HEARTBEAT_ASYNC_REQ,
        CG_HEARTBEAT_ASYNC_RES,
    }

    public class Protocol
    {
        public PacketType packetType;
        public DateTime time;
    }

    public class CG_HEARTBEAT_SYNC_REQ : Protocol
    {
    }

    public class CG_HEARTBEAT_SYNC_RES : Protocol
    {
        public bool errorCode;
        public int count;
    }

    public class CG_HEARTBEAT_ASYNC_REQ : Protocol
    {
    }

    public class CG_HEARTBEAT_ASYNC_RES : Protocol
    {
        public bool errorCode;
        public int count;
    }
}
