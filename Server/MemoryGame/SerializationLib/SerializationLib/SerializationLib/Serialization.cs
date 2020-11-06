using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace SerializationLib
{
    static public class Serialization
    {
        // Convert an object to a byte array
        static public byte[] Serialize(Object o)
        {
            // on utlise un formateur de flux de donnée binary

            BinaryFormatter binFormat = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            // serialize a object in a stream data 
            binFormat.Serialize(memStream, o);
            return memStream.GetBuffer();

        }


        static public object Deserialize(byte[] buffer)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            memStream.Write(buffer, 0, buffer.Length);
            memStream.Seek(0, 0);
            return binFormat.Deserialize(memStream);

        }
    }
}

