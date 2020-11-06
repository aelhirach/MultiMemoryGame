using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MemoryGame
{using System.Net;
using System.Net.Sockets;
    public class Player
    {
        private Socket playerSoc;
        private int score;
        private int numberOfMoves;
        private int seconds;
        private bool isWinner=false;
        private IPEndPoint endPoint;
        private bool isChecked = false;
        public Player(){}
        public  Player (Socket socket)
        {
            this.playerSoc = socket;
        }
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }
        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        public bool IsWinner
        {
            get { return isWinner; }
            set { isWinner = value; }
        }
        public IPEndPoint EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }
        public Socket PlayerSoc
        {
            get { return playerSoc; }
            set { playerSoc = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public int NumberOfMoves
        {
            get { return numberOfMoves; }
            set { numberOfMoves = value; }
        }
        public int Points 
        {
            get { return (this.Score * 1000 - this.NumberOfMoves * 200 - this.Seconds); }
        }
    }
}
