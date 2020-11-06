using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net.Sockets;



namespace MemoryGame
{
    class StateObject
    {

        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        public List<byte> TransmissionBuffer = new List<byte>();
        // Received data string.

    }


}
