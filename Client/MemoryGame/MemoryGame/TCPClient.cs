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
    class TCPClient
    {   
          
        public delegate void ViewEventHandler(Data data);
        public static event ViewEventHandler viewEvent;
        private static TcpClient server;
        public static Socket serverSoc;
        
        public static bool StartTCPClient()
        {
            server = new TcpClient();
            Socket serverSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint hostEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            //Connect(hostEndPoint, server.Client);
            Connect(hostEndPoint, serverSoc);
            Data data = new Data();
            data.Message = "Connect";
            try
            {
                Send(serverSoc, data);
                GameForm.sendDataEvent += new GameForm.SendDataEventHandler(SendMydata);
                return true;
            }
            catch {
                MessageBox.Show("Error to connect to server"); 
                return false;
            }
            
     
        }
        private static void SendMydata(Data data)
        {
            // Convert the string data to byte data using ASCII encoding.
            StateObject state = new StateObject();
            byte[] byteData = data.Serialize();

            // Begin sending the data to the remote device.
            serverSoc.BeginSend(byteData, 0, byteData.Length, SocketFlags.None,
                new AsyncCallback(SendCallback), serverSoc);

        }
        /// Client
        private static void Connect(EndPoint remoteEP, Socket server)
        {
            server.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), server);
            
        }
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket server = (Socket)ar.AsyncState;
                serverSoc = server;
                // Complete the connection.
                server.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    server.RemoteEndPoint.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        // send message 
        private static void Send(Socket server, Data data)
        {
            // Convert the string data to byte data using ASCII encoding.
            StateObject state = new StateObject();
            byte[] byteData = data.Serialize();
            // Begin sending the data to the remote device.

                server.BeginSend(byteData, 0, byteData.Length, SocketFlags.None,
                new AsyncCallback(SendCallback), server);
                
            
        }
        private static void SendCallback(IAsyncResult ar)
        {

            try
            {
                // Retrieve the socket from the state object.
                Socket server = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = server.EndSend(ar);
                Receive(server);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        // receive Data 
        private static void Receive(Socket server)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = server;

                // Begin receiving the data from the remote device.
                server.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private static void ReceiveCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the client socket 
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket server = state.workSocket;
            try
            {

                // Read data from the remote device.
                int bytesRead = server.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.

                    for (int i = 0; i < bytesRead; i++)
                        state.TransmissionBuffer.Add(state.buffer[i]);

                    //  Get the rest of the data.
                    if (server.Available > 0)
                    {
                        server.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                    else
                    {
                        ReceiveDone(state);
                        Receive(server);
                    }
                }
                else
                {
                    ReceiveDone(state);
                    Receive(server);
                }
            }
            catch (Exception e)
            {
                server.Close();
                //Console.WriteLine(e.ToString());
            }
        }
        private static void ReceiveDone(StateObject state)
        {
            try
            {
                Data data = Data.Deserialize(state.TransmissionBuffer.ToArray());
  
                    viewEvent(data);
                
            }
            catch { };
        }

    }
}
