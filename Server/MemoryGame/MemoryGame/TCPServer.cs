using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using SerializableObjects;


namespace MemoryGame
{
    class TCPServer
    {   
        public delegate void DataEventHandler(Data data);
        public static event DataEventHandler dataRecEvent;
        public delegate void WinnerEventHandler(Player player);
        public static event WinnerEventHandler winnerEvent;
        public static Data myData;
        public static Socket listenSocket;
        
        // an argment wheather client or server 
        public static bool StartTCPServer()
        {
            try
            {
                int port = 1234;
                IPAddress localIP = IPAddress.Parse("127.0.0.1");
                listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint localEndPoint = new IPEndPoint(localIP, port);
                listenSocket.Bind(localEndPoint);
                listenSocket.Listen(10); //maximum number of connections queu
                GameForm.playersList = new List<Player>();
                AcceptClient(listenSocket);
                GameForm.sendDataEvent += new GameForm.SendDataEventHandler(SendToClientList);
                return true;

            }
            catch
            {   MessageBox.Show("Error to bind adress");
                return false;
            }
        }
        private static void AcceptClient(Socket listener)
        {
            Console.WriteLine("Waiting for a connection...");
            listener.BeginAccept(new AsyncCallback(AcceptClientCallback), listener);

        }
        private static void AcceptClientCallback(IAsyncResult ar)
        {
            try
            {
                Socket listener = (Socket)ar.AsyncState;
                Socket client = listener.EndAccept(ar);
                Player player = new Player(client);
                IPEndPoint clientIpEndPoint = client.RemoteEndPoint as IPEndPoint;
                player.EndPoint = clientIpEndPoint;
                GameForm.playersList.Add(player);
                //listen for other connections
                AcceptClient(listener);
                Receive(client);
            }
            catch { }
            
        } 
        // Receive Message
        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {   
               
            }
        }
        public static void ReceiveCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the client socket 
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;
            try
            {

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.

                    for (int i = 0; i < bytesRead; i++)
                        state.TransmissionBuffer.Add(state.buffer[i]);

                    //  Get the rest of the data.
                    if (client.Available > 0)
                    {
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                    else
                    {
                        ReceiveDone(state);
                        Receive(client);
                        
                    }   
                    
                }
                else
                {
                    ReceiveDone(state);
                    Receive(client);
                }
                //Test test= new Test();
                //test.Message = "test";
                
                //settings.Message = "Okkkkkkkkkk";
                
            }
            catch 
            {
                client.Close();
                foreach (Player player in GameForm.playersList)
                    if (client.Equals(player.PlayerSoc))
                    {
                        GameForm.playersList.Remove(player);
                        break;
                    }
                
            }
        }
        private static void ReceiveDone(StateObject state)
        {
            try
            {
                Data data = Data.Deserialize(state.TransmissionBuffer.ToArray());
                if (data.Message == "Connect")
                {
                    myData.Message = "Gate";
                    Send(state.workSocket, myData);
                    dataRecEvent(data);
                }
                else if (data.Message == "Finish")
                {
                    foreach (Player player in GameForm.playersList)
                        //if (state.workSocket.Equals(player.PlayerSoc))
                        {   myData.Message = "isFinish";
                            Send(player.PlayerSoc, myData);
                        }
                }
                
                else if (data.Message == "Config") {
                    
                    foreach (Player player in GameForm.playersList)
                        if (state.workSocket.Equals(player.PlayerSoc))
                        {
                            player.Seconds = data.Seconds;
                            player.Score = data.Score;
                            player.NumberOfMoves = data.NumberOfMoves;
                            player.IsChecked = true;
                        }

                    if (checkList())
                    {   ///error here
                        GameForm.playersList = GameForm.playersList.OrderByDescending(o => o.Points).ToList();
                        GameForm.playersList.First().IsWinner = true;

                        foreach (Player player in GameForm.playersList)
                            if (player.IsWinner)
                            {
                                myData.Message = "Winner";
                                Send(player.PlayerSoc, myData);
                                //winnerEvent(player);
                            }
                            else {
                                myData.Message = "Loser";
                                Send(player.PlayerSoc, myData);
                            }
                        
                    }
                    
                }
            }
            catch (Exception e) { 
                MessageBox.Show(e.Message + "d");
            
            }
        }
        public static bool checkList(){
            bool value=true;
            foreach (Player player in GameForm.playersList)
                if (player.IsChecked == false)
                {
                    value = false;
                    break;
                }
            return value;
            
        }
        // Send Data 
        private static void SendToClientList(Data data) {
            StateObject state = new StateObject();
            byte[] byteData = data.Serialize();
            //int i = 0;
            if (data != null )
            foreach (Player player in GameForm.playersList)   
            {
                player.PlayerSoc.BeginSend(byteData, 0, byteData.Length, 
                                                      SocketFlags.None, new AsyncCallback(SendCallback), player.PlayerSoc);}

        }
        private static void Send(Socket client, Data data)
        {
            // Convert the string data to byte data using ASCII encoding.
            StateObject state = new StateObject();
            byte[] byteData = data.Serialize();

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None,
                new AsyncCallback(SendCallback), client);
        }
        private static void SendCallback(IAsyncResult ar)
        {

            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Receive(client);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "a");
            }
        }
       

    }
}
