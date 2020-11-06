using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SerializableObjects;

namespace MemoryGame
{  
    public partial class GameForm : Form
    {   /////***************************** Attriuts ******************************////// 
   
        AnimalsGrid animalsGate;
        GameSettings gameSettings;
        public static List<Player> playersList; 
        Data data;
        Boolean JokerOneFound = false;
        Boolean JokerTwoFound = false;
        Boolean JokerThreeFound = false;
        bool isFirstShown = false;
        bool isSecondShown = false;
        string myFirstAnimal;
        string mySecondAnimal;
        List<PictureBox> pictureBoxList;
        
        public delegate void SendDataEventHandler(Data data);
        private delegate void timeDelegate(GameSettings.Time time);
        private delegate void ReceiveDataDelegate(Data data);
        private delegate void WinnerDelegate(Player player);
        
        public EventHandler pbClickEventDelegate;
        public static event SendDataEventHandler sendDataEvent;
        /////***************************** Constructors ******************************////// 
        public GameForm()
        {
            InitializeComponent();
            Initialize();
            
        }
        /////*************************** Methods ****************************************//////

        // quit program with x button
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            btn_Stop.PerformClick();
            const string message = "Are you sure that you would like to Quit the game?";
            const string caption = "Choose Level";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
            gameSettings.Stop();

        }
        private void Play()
        {

            gamePanel.Enabled = true;
            btn_Play.Enabled = false;
            btn_Stop.Enabled = true;
            gameSettings.Play();

        }
        private void Stop()
        {
            gamePanel.Enabled = false;
            btn_Stop.Enabled = false;
            btn_Play.Enabled = true;
            gameSettings.Stop();


        }

        // delay with parameter seconds 
        private void delay(int seconds)
        {
            DateTime dt1 = DateTime.Now;
            int diff = 0;

            while (diff < seconds)
            {
                DateTime dt2 = DateTime.Now;
                TimeSpan ts = dt2.Subtract(dt1);
                diff = (int)ts.TotalSeconds;

            }
        }
        //// notifications methods
        private void ViewTime(GameSettings.Time time)
        {
            labelSeconds.Text = time.seconds.ToString();
            labelMinutes.Text = time.minutes.ToString();
            labelHours.Text = time.hours.ToString();
        }
        // second méthode to avoid crossed thread 
        private void ViewTimeInvoke(GameSettings.Time time)
        {
            this.Invoke(new timeDelegate(ViewTime), time);
        }
        private void ViewDataInvoke(Data data)
        {
            this.Invoke(new ReceiveDataDelegate(ViewData), data);
        }
        private void ViewWinnerInvoke(Player player) {
            this.Invoke(new WinnerDelegate(ViewWinner));
        }
        private void ViewWinner(Player player) {
            MessageBox.Show("the winner is:" + player.EndPoint.ToString());
        }
        private void ViewData(Data data)
        {
            if (data.Message == "Connect")
            {
                delay(1);
    
                textBoxMessage.Text = "Client connect";
            }
            if (data.Message == "Finish")
            {
                btn_Inisialize.PerformClick();
            
            }

        }
        private void ViewMovesValue(int value)
        {   textBox_NumberOfMoves.Text = value.ToString();
        }
        private void ViewScoreValue(int value)
        {
            textBoxScore.Text = value.ToString();
        }
        // initialize Game
        private void Initialize()
        {   animalsGate = new AnimalsGrid();
            pictureBoxList = new List<PictureBox>();
            // creat a delegate to pb_click method  
            pbClickEventDelegate = new System.EventHandler(pb_Click);
            gameSettings = new GameSettings();
            //gameSettings.Gate = animalsGate.NameGate();
            data = new Data();
            data.Gate = animalsGate.NameGate();
            data.Message = "Inisialize";
            TCPServer.myData = data;
            // abonnate to event with anonymous methods 
            TCPServer.DataEventHandler del = ViewDataInvoke;

            TCPServer.dataRecEvent += new TCPServer.DataEventHandler(ViewDataInvoke);
            TCPServer.winnerEvent += new TCPServer.WinnerEventHandler(ViewWinnerInvoke);
            gameSettings.CounterChangeEvent += new GameSettings.CounterEventHandler(ViewTimeInvoke);
            gameSettings.MovesChangeEvent += new GameSettings.CounterMovesEventHandler(ViewMovesValue);
            gameSettings.ScoreChangeEvent += new GameSettings.CounterScoreEventHandler(ViewScoreValue);
           
            for (int i = 0; i < 49; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Tag = i;
                pb.Image = MemoryGame.Properties.Resources.defaultPicture;
                pb.Name = "defaultPicture";
                pb.Size = pb.Image.Size;
                pb.BorderStyle = BorderStyle.FixedSingle;
                gamePanel.Controls.Add(pb);
                // add pbClickEventDelegate which is the delagte of pb_click to each pb click event
                pb.Click += pbClickEventDelegate;
                pictureBoxList.Add(pb);

            }
            gamePanel.Enabled = false;

            // lambda expression 
            pictureBoxList.ForEach(Item =>
            {
                Item.Image = MemoryGame.Properties.Resources.defaultPicture;
                Item.BorderStyle = BorderStyle.FixedSingle;
            });
            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList.ElementAt(i).Name = animalsGate.ElementAt(i).Name;

            }

            label_First_Joker.Text = animalsGate.JokerList.ElementAt(0).Name;
            label_Second_Joker.Text = animalsGate.JokerList.ElementAt(1).Name;
            label_Third_Joker.Text = animalsGate.JokerList.ElementAt(2).Name;

        }
        ////*************************** Les Handlers ****************************************//////
        // PitureBoxs Click Handler 
        private void pb_Click(object sender, EventArgs e)
        {   // sender is the object that rise event in this case it is one of the pb 
            PictureBox pb = sender as PictureBox;
            gameSettings.CountNumberOfMoves();
            if (!isFirstShown)
            {
                for (int i = 0; i < pictureBoxList.Count(); i++)
                {
                    myFirstAnimal = pb.Name;

                    if (pb.Equals(pictureBoxList.ElementAt(i)))
                    {
                        pb.Image = animalsGate.ElementAt(i).Picture;

                        isFirstShown = true;
                        animalsGate.FirstAnimalPosition = i;
                        pictureBoxList.ElementAt(i).Enabled = false;

                    }
                }
            }
            

            else if (!isSecondShown)
            {
                for (int j = 0; j < pictureBoxList.Count(); j++)
                {
                    mySecondAnimal = pb.Name;
                    if (pb.Equals(pictureBoxList.ElementAt(j)))
                    {
                        pb.Image = animalsGate.ElementAt(j).Picture;
                        isSecondShown = true;
                        animalsGate.SecondAnimalPosition = j;
                        pictureBoxList.ElementAt(j).Enabled = false;

                    }
                }
            }


            if (isFirstShown && isSecondShown)
            {
                if (myFirstAnimal.Equals(mySecondAnimal))
                {
                    textBoxNotification.Text = " Good job";
                    gameSettings.CountScore(2);
                }
                else
                {
                    delay(1);
                    textBoxNotification.Text = " Images don't match";
                    pictureBoxList.ElementAt(animalsGate.FirstAnimalPosition).Image = MemoryGame.Properties.Resources.defaultPicture;
                    pictureBoxList.ElementAt(animalsGate.SecondAnimalPosition).Image = MemoryGame.Properties.Resources.defaultPicture;
                    pictureBoxList.ElementAt(animalsGate.FirstAnimalPosition).Enabled = true;
                    pictureBoxList.ElementAt(animalsGate.SecondAnimalPosition).Enabled = true;

                }
                isFirstShown = false;
                isSecondShown = false;
            }

        }
        // all display button handler for test 
        private void btn_Display_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList.ElementAt(i).Image = animalsGate.ElementAt(i).Picture;
            }
        }
        // display button handler for test
        private void btn_Hide_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList.ElementAt(i).Image = MemoryGame.Properties.Resources.defaultPicture;
            }
        }
        // play button handler for test
        private void btn_Play_Click(object sender, EventArgs e)
        {  
            Play();
            data.Stop = true;
            data.Message = "Start";
            if (sendDataEvent != null)
            sendDataEvent(data);


        }
        // stop button handler for test
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            Stop();
            data.Stop = true;
            data.Message = "Stop";
            if (sendDataEvent != null) 
            sendDataEvent(data);
            
        }
        // answer joker button handler for test
        private void btn_Answer_Click(object sender, EventArgs e)
        {

            if (textBoxJokers.Text == "") MessageBox.Show("Tape the name in the text area before answer", "Answer Incorrect",
                                   MessageBoxButtons.OK, MessageBoxIcon.Question);

            else
            {
                for (int i = 0; i < animalsGate.JokerList.Count(); i++)
                {
                    if (textBoxJokers.Text == animalsGate.JokerList.ElementAt(i).Name)
                    {
                        if (!JokerOneFound) { gameSettings.CountScore(20); JokerOneFound = true; MessageBox.Show("You found the first jocker", "Correct answer", MessageBoxButtons.OK); }
                        else if (!JokerTwoFound) { gameSettings.CountScore(15); JokerTwoFound = true; MessageBox.Show("You found the second jocker", "Correct answer", MessageBoxButtons.OK); }
                        else if (!JokerThreeFound) { gameSettings.CountScore(10); JokerThreeFound = true; MessageBox.Show("You found the second jocker", "Correct answer", MessageBoxButtons.OK); }
                        for (int j = 0; j < pictureBoxList.Count(); j++)
                        {
                            if (animalsGate.JokerList.ElementAt(i).Name == pictureBoxList.ElementAt(j).Name)
                            {
                                pictureBoxList.ElementAt(j).Image = animalsGate.JokerList.ElementAt(i).Picture;
                                pictureBoxList.ElementAt(j).Enabled = false;
                                pictureBoxList.ElementAt(j).BorderStyle = BorderStyle.FixedSingle;
                                pictureBoxList.ElementAt(j).BackColor = Color.Red;
                                break;
                            }
                        }
                        break;
                    }

                    else { if (i == animalsGate.JokerList.Count() - 1) gameSettings.CountScore(-5);}
                }
            }

        }
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (TCPServer.StartTCPServer())
                btn_Connect.Enabled = false;
                btn_Disconnect.Enabled = true;
            
        }
        private void btn_Inisialize_Click(object sender, EventArgs e)
        {
            Stop();
            animalsGate.Clear();
            gameSettings=null;
            JokerOneFound = false;
            JokerTwoFound = false;
            JokerThreeFound = false;
            isFirstShown = false;
            isSecondShown = false;
            myFirstAnimal="";
            mySecondAnimal="";
            pictureBoxList.Clear();
            gamePanel.Controls.Clear();
            data=null;
          
            Initialize();
            ViewTimeInvoke(new GameSettings.Time());
            data.Message = "Inisialize";
            if (sendDataEvent != null)
                sendDataEvent(data);
            
        }
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            TCPServer.listenSocket.Close();
            btn_Connect.Enabled = true;
            btn_Disconnect.Enabled = false;
        }

    }
}
