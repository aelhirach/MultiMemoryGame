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
        AnimalsGate animalsGate;
        GameSettings gameSettings;
        Boolean JokerOneFound = false;
        Boolean JokerTwoFound = false;
        private Data myData;
        Boolean JokerThreeFound = false;
        bool isFirstShown = false;
        bool isSecondShown = false;
        int numberOfFoundedPairs=0; 
        string myFirstAnimal;
        string mySecondAnimal;
        List<PictureBox> pictureBoxList;
        EventHandler pbClickEventDelegate;
        private delegate void ViewTimeDelegate(GameSettings.Time time);
        public delegate void SendDataEventHandler(Data data);
        public static event SendDataEventHandler sendDataEvent;
        private delegate void ViewDataDelegate(Data data);
        public Data MyData 
        {
            get { return myData; }
            set { myData = value; }
        }
        /////***************************** Constructors ******************************////// 
        public GameForm()
        {
            TCPClient.viewEvent += new TCPClient.ViewEventHandler(ViewActionInvoke);
            myData = new Data();
            InitializeComponent();
            //Initialize(data);
        }
        /////*************************** Methods ****************************************//////

        // quit program with x button
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            const string message = "Are you sure that you would like to Quit the game?";
            const string caption = "Choose Level";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
            if (gameSettings!= null) gameSettings.Stop();

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
        public int getSeconds(GameSettings.Time time)
        {
            return (time.seconds + time.minutes * 60 + time.hours * 3600);
        }
        private void ClearSetting()
        {
            
                gameSettings.Stop();
                gamePanel.Enabled = false;
                animalsGate.Clear();
                gameSettings = null;
                JokerOneFound = false;
                animalsListBox.Items.Clear();
                JokerTwoFound = false;
                JokerThreeFound = false;
                isFirstShown = false;
                isSecondShown = false;
                myFirstAnimal = "";
                mySecondAnimal = "";
                pictureBoxList.Clear();
                numberOfFoundedPairs = 0;
                gamePanel.Controls.Clear();
            

        }
        // abonate events methods 
        private void MovesValueChange(int value)
        {   textBox_NumberOfMoves.Text = value.ToString();
        }
        private void ScoreValueChange(int value)
        {
            textBoxScore.Text = value.ToString();
        }
        private void ViewActionInvoke(Data data)
        {
            if (data.Message == "Gate" || data.Message == "Inisialize")
                this.Invoke(new ViewDataDelegate(ViewInitialize), data);
            if (data.Message == "Stop")
                this.Invoke(new ViewDataDelegate(ViewStop), data);
            if (data.Message == "Start")
                this.Invoke(new ViewDataDelegate(ViewPlay), data);
            if (data.Message == "isFinish")
                this.Invoke(new ViewDataDelegate(SendConfig),data);
            if (data.Message == "Winner")
                this.Invoke(new ViewDataDelegate(ViewWinner), data);
            if (data.Message == "Loser")
                this.Invoke(new ViewDataDelegate(ViewLoser), data);


        }
        private void ViewTimeInvoke(GameSettings.Time time)
        {
               this.Invoke(new ViewTimeDelegate(ViewTime), time);
           
              
            
        }

        ////***************************  delegate methods to avoid crossed thread ****************************************//////
        private void ViewTime(GameSettings.Time time)
        {
            labelSeconds.Text = time.seconds.ToString();
            labelMinutes.Text = time.minutes.ToString();
            labelHours.Text = time.hours.ToString();
        }
        private void ViewInitialize(Data data)
        {
            this.MyData = data;
            if (data.Message == "Inisialize")
            {
                ClearSetting();
                ViewTimeInvoke(new GameSettings.Time());
            }
            animalsGate = new AnimalsGate(data.Gate);
            foreach (Animal animal in animalsGate.tempList())
            {
                animalsListBox.Items.Add(animal.Name);
            }
            pictureBoxList = new List<PictureBox>();
            // creat a delegate to pb_click method  
            pbClickEventDelegate = new System.EventHandler(pb_Click);
            gameSettings = new GameSettings();
            //gameSettings.Gate = animalsGate.NameGate();
            data.Gate = animalsGate.NameGate();
            // abonnate to event with anonymous methods 
            //TCPServer.DataRecEvent += new TCPServer.DataEventHandler(Display);
            gameSettings.CounterChangeEvent += new GameSettings.CounterEventHandler(ViewTimeInvoke);
            gameSettings.MovesChangeEvent += new GameSettings.CounterMovesEventHandler(MovesValueChange);
            gameSettings.ScoreChangeEvent += new GameSettings.CounterScoreEventHandler(ScoreValueChange);


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


            gamePanel.Enabled = true;
            btn_Answer.Enabled = true;
            textBoxJokers.Enabled = true;


            for (int i = 0; i < pictureBoxList.Count; i++)
            {
                pictureBoxList.ElementAt(i).Name = animalsGate.ElementAt(i).Name;


            }
            if (data.Message == "Gate") gameSettings.Play();
            else
            {

                gamePanel.Enabled = false;

                btn_Answer.Enabled = false;
            }


        }
        private void ViewPlay(Data data)
        {

            gamePanel.Enabled = true;
            gameSettings.Play();
            btn_Answer.Enabled = true;


        }
        private void ViewStop(Data data)
        {
            gamePanel.Enabled = false;
            gameSettings.Stop();
            btn_Answer.Enabled = false;


        }
        private void SendConfig(Data data)
        {  
            gameSettings.Stop();
            gamePanel.Enabled = false;
            myData.Message = "Config";
            myData.NumberOfMoves = gameSettings.NumberOfMoves;
            myData.Score = gameSettings.Score;
            myData.Seconds = getSeconds(gameSettings.time);
            sendDataEvent(myData);
        }
        private void ViewWinner(Data data){
            MessageBox.Show("You win");
        }
        private void ViewLoser(Data data) { 
        MessageBox.Show("You lose");
        }

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
                    numberOfFoundedPairs++;
                    if (numberOfFoundedPairs == 23)
                    {
                        gameSettings.Stop();
                        gamePanel.Enabled = false;
                        myData.Message = "Finish";
                        
                        //myData.MyTime = gameSettings.MyTime;
                        sendDataEvent(myData);
                        /// send me whether i won or not 
                        
                    }
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
        // stop button handler for test        
      
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
                        if (!JokerOneFound) { gameSettings.CountScore(20); JokerOneFound = true; MessageBox.Show("You found the first joker", "Correct answer", MessageBoxButtons.OK); }
                        else if (!JokerTwoFound) { gameSettings.CountScore(15); JokerTwoFound = true; MessageBox.Show("You found the second joker", "Correct answer", MessageBoxButtons.OK); }
                        else if (!JokerThreeFound) { gameSettings.CountScore(10); JokerThreeFound = true; MessageBox.Show("You found the second joker", "Correct answer", MessageBoxButtons.OK); }
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
            if (TCPClient.StartTCPClient())
            {
                btn_Connect.Enabled = false;
                btn_Disconnect.Enabled = true;
                btn_Answer.Enabled = true;
                
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            ClearSetting();
            TCPClient.serverSoc.Close();
            btn_Connect.Enabled = true;
            btn_Disconnect.Enabled = false;
            btn_Answer.Enabled = false;
            ViewTimeInvoke(new GameSettings.Time());

            
        }

       

        


       

      
       
 
    }
}
