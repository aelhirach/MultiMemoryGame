using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializationLib
{
    [Serializable]
    public class SerializableObject
    {
        string message;
        int x, y;

        public SerializableObject(string message)
        {
            this.message = message;
            x = 10;
            y = 20;

        }

        public string GetMessage()
        {
            return message;
        }
    }
}
