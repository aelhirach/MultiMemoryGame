using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializableObjects
{

    [Serializable]
    public class Data
    {
        //Attributs 
        protected bool stop = true;
        protected int numberOfMoves = 0;
        protected int score = 0;
        protected int seconds = 0;
        private List<string> gate;
        public byte[] Serialize()
        {
            return SerializationManager.Serialize(this);
        }

        public static Data Deserialize(byte[] buffer)
        {
            return (Data)SerializationManager.Deserialize(buffer);
        }

        ////********************************** Proprietes***************************////
        public string Message { get; set; }
        public bool Stop
        {
            get { return stop; }
            set { stop = value; }
        }
        public int NumberOfMoves
        {
            get { return numberOfMoves; }
            set { numberOfMoves = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        public List<string> Gate
        {
            get { return gate; }
            set { gate = value; }
        }


    }



}
