using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializableObjects
{
    [Serializable]
    public class Settings
    {
       


        public byte[] Serialize()
        {
            return SerializationManager.Serialize(this);
        }

        public static Settings Deserialize(byte[] buffer)
        {
            return (Settings)SerializationManager.Deserialize(buffer);
        }


        
        

    }
}
