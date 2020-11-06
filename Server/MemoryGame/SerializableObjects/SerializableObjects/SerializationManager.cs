using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SerializableObjects
{
    static class SerializationManager
    {
        public static byte[] Serialize(object o)
        {
            BinaryFormatter bin = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            bin.Serialize(mem, o);
            return mem.GetBuffer();
        }

        public static object Deserialize(byte[] buffer)
        {
            BinaryFormatter bin = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();

            mem.Write(buffer, 0, buffer.Length);
            mem.Seek(0, 0);
            return bin.Deserialize(mem);
        }
    }
}
