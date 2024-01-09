using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    enum ErrorCode : int
    {
        NoError = 0,
        Error = 1,
    }
}

namespace Protocol
{
    public enum PacketType : int
    {
        CG_HEARTBEAT_SYNC_REQ = 1,
        CG_HEARTBEAT_SYNC_RES,
        CG_HEARTBEAT_ASYNC_REQ,
        CG_HEARTBEAT_ASYNC_RES,
    }
}