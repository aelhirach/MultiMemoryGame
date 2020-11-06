namespace MemoryGame
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Infolabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diplayJockersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Inisialize = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.btn_Display = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_Answer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Second_Joker = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Hide = new System.Windows.Forms.Button();
            this.textBoxScore = new System.Windows.Forms.TextBox();
            this.label_Third_Joker = new System.Windows.Forms.Label();
            this.textBoxJokers = new System.Windows.Forms.TextBox();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.label_First_Joker = new System.Windows.Forms.Label();
            this.label_NumberOfMovesText = new System.Windows.Forms.Label();
            this.textBoxNotification = new System.Windows.Forms.TextBox();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.labelHours = new System.Windows.Forms.Label();
            this.textBox_NumberOfMoves = new System.Windows.Forms.TextBox();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Infolabel
            // 
            this.Infolabel.AutoSize = true;
            this.Infolabel.Location = new System.Drawing.Point(31, 15);
            this.Infolabel.Name = "Infolabel";
            this.Infolabel.Size = new System.Drawing.Size(544, 13);
            this.Infolabel.TabIndex = 33;
            this.Infolabel.Text = "Train your brain! Play this game every day. Keep your brain in shape! Find pairs " +
                "of images under the following tiles: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.eToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 24);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializeToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // initializeToolStripMenuItem
            // 
            this.initializeToolStripMenuItem.Name = "initializeToolStripMenuItem";
            this.initializeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.initializeToolStripMenuItem.Text = "initialize";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayAllToolStripMenuItem,
            this.hideAllToolStripMenuItem,
            this.diplayJockersToolStripMenuItem});
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.eToolStripMenuItem.Text = "Tools";
            // 
            // displayAllToolStripMenuItem
            // 
            this.displayAllToolStripMenuItem.Name = "displayAllToolStripMenuItem";
            this.displayAllToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.displayAllToolStripMenuItem.Text = "Display all";
            // 
            // hideAllToolStripMenuItem
            // 
            this.hideAllToolStripMenuItem.Name = "hideAllToolStripMenuItem";
            this.hideAllToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.hideAllToolStripMenuItem.Text = "Hide all";
            // 
            // diplayJockersToolStripMenuItem
            // 
            this.diplayJockersToolStripMenuItem.Name = "diplayJockersToolStripMenuItem";
            this.diplayJockersToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.diplayJockersToolStripMenuItem.Text = "Display Jockers";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameRulesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gameRulesToolStripMenuItem
            // 
            this.gameRulesToolStripMenuItem.Name = "gameRulesToolStripMenuItem";
            this.gameRulesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.gameRulesToolStripMenuItem.Text = "Game rules";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(3, 31);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(670, 624);
            this.gamePanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Infolabel);
            this.panel1.Controls.Add(this.gamePanel);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 658);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Disconnect);
            this.groupBox1.Controls.Add(this.btn_Inisialize);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.textBoxMessage);
            this.groupBox1.Controls.Add(this.btn_Display);
            this.groupBox1.Controls.Add(this.btn_Play);
            this.groupBox1.Controls.Add(this.btn_Answer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_Second_Joker);
            this.groupBox1.Controls.Add(this.btn_Stop);
            this.groupBox1.Controls.Add(this.btn_Hide);
            this.groupBox1.Controls.Add(this.textBoxScore);
            this.groupBox1.Controls.Add(this.label_Third_Joker);
            this.groupBox1.Controls.Add(this.textBoxJokers);
            this.groupBox1.Controls.Add(this.labelSeconds);
            this.groupBox1.Controls.Add(this.label_First_Joker);
            this.groupBox1.Controls.Add(this.label_NumberOfMovesText);
            this.groupBox1.Controls.Add(this.textBoxNotification);
            this.groupBox1.Controls.Add(this.labelMinutes);
            this.groupBox1.Controls.Add(this.labelHours);
            this.groupBox1.Controls.Add(this.textBox_NumberOfMoves);
            this.groupBox1.Location = new System.Drawing.Point(679, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 624);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Panel";
            // 
            // btn_Inisialize
            // 
            this.btn_Inisialize.Location = new System.Drawing.Point(94, 141);
            this.btn_Inisialize.Name = "btn_Inisialize";
            this.btn_Inisialize.Size = new System.Drawing.Size(75, 23);
            this.btn_Inisialize.TabIndex = 40;
            this.btn_Inisialize.Text = "Inisialize";
            this.btn_Inisialize.UseVisualStyleBackColor = true;
            this.btn_Inisialize.Click += new System.EventHandler(this.btn_Inisialize_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(16, 312);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 38;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Enabled = false;
            this.textBoxMessage.Location = new System.Drawing.Point(37, 353);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(119, 20);
            this.textBoxMessage.TabIndex = 37;
            // 
            // btn_Display
            // 
            this.btn_Display.Location = new System.Drawing.Point(13, 55);
            this.btn_Display.Name = "btn_Display";
            this.btn_Display.Size = new System.Drawing.Size(78, 23);
            this.btn_Display.TabIndex = 25;
            this.btn_Display.Text = "Display";
            this.btn_Display.UseVisualStyleBackColor = true;
            this.btn_Display.Click += new System.EventHandler(this.btn_Display_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(13, 84);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(78, 25);
            this.btn_Play.TabIndex = 18;
            this.btn_Play.Text = "Play";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_Answer
            // 
            this.btn_Answer.Location = new System.Drawing.Point(13, 141);
            this.btn_Answer.Name = "btn_Answer";
            this.btn_Answer.Size = new System.Drawing.Size(75, 23);
            this.btn_Answer.TabIndex = 27;
            this.btn_Answer.Text = "Answer";
            this.btn_Answer.UseVisualStyleBackColor = true;
            this.btn_Answer.Click += new System.EventHandler(this.btn_Answer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Score :";
            // 
            // label_Second_Joker
            // 
            this.label_Second_Joker.AutoSize = true;
            this.label_Second_Joker.Location = new System.Drawing.Point(111, 167);
            this.label_Second_Joker.Name = "label_Second_Joker";
            this.label_Second_Joker.Size = new System.Drawing.Size(73, 13);
            this.label_Second_Joker.TabIndex = 28;
            this.label_Second_Joker.Text = "Second Joker";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(97, 84);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(78, 25);
            this.btn_Stop.TabIndex = 19;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Hide
            // 
            this.btn_Hide.Location = new System.Drawing.Point(97, 55);
            this.btn_Hide.Name = "btn_Hide";
            this.btn_Hide.Size = new System.Drawing.Size(76, 23);
            this.btn_Hide.TabIndex = 26;
            this.btn_Hide.Text = "Hide";
            this.btn_Hide.UseVisualStyleBackColor = true;
            this.btn_Hide.Click += new System.EventHandler(this.btn_Hide_Click);
            // 
            // textBoxScore
            // 
            this.textBoxScore.Enabled = false;
            this.textBoxScore.Location = new System.Drawing.Point(135, 242);
            this.textBoxScore.Name = "textBoxScore";
            this.textBoxScore.Size = new System.Drawing.Size(44, 20);
            this.textBoxScore.TabIndex = 35;
            // 
            // label_Third_Joker
            // 
            this.label_Third_Joker.AutoSize = true;
            this.label_Third_Joker.Location = new System.Drawing.Point(73, 189);
            this.label_Third_Joker.Name = "label_Third_Joker";
            this.label_Third_Joker.Size = new System.Drawing.Size(60, 13);
            this.label_Third_Joker.TabIndex = 29;
            this.label_Third_Joker.Text = "Third Joker";
            // 
            // textBoxJokers
            // 
            this.textBoxJokers.Location = new System.Drawing.Point(37, 115);
            this.textBoxJokers.Name = "textBoxJokers";
            this.textBoxJokers.Size = new System.Drawing.Size(127, 20);
            this.textBoxJokers.TabIndex = 20;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(120, 26);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(19, 13);
            this.labelSeconds.TabIndex = 24;
            this.labelSeconds.Text = "00";
            // 
            // label_First_Joker
            // 
            this.label_First_Joker.AutoSize = true;
            this.label_First_Joker.Location = new System.Drawing.Point(20, 167);
            this.label_First_Joker.Name = "label_First_Joker";
            this.label_First_Joker.Size = new System.Drawing.Size(55, 13);
            this.label_First_Joker.TabIndex = 21;
            this.label_First_Joker.Text = "First Joker";
            // 
            // label_NumberOfMovesText
            // 
            this.label_NumberOfMovesText.AutoSize = true;
            this.label_NumberOfMovesText.Location = new System.Drawing.Point(34, 219);
            this.label_NumberOfMovesText.Name = "label_NumberOfMovesText";
            this.label_NumberOfMovesText.Size = new System.Drawing.Size(99, 13);
            this.label_NumberOfMovesText.TabIndex = 30;
            this.label_NumberOfMovesText.Text = "Number Of Moves :";
            // 
            // textBoxNotification
            // 
            this.textBoxNotification.Enabled = false;
            this.textBoxNotification.Location = new System.Drawing.Point(4, 277);
            this.textBoxNotification.Name = "textBoxNotification";
            this.textBoxNotification.Size = new System.Drawing.Size(176, 20);
            this.textBoxNotification.TabIndex = 32;
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Location = new System.Drawing.Point(78, 26);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(19, 13);
            this.labelMinutes.TabIndex = 23;
            this.labelMinutes.Text = "00";
            this.labelMinutes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.Location = new System.Drawing.Point(42, 26);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(19, 13);
            this.labelHours.TabIndex = 22;
            this.labelHours.Text = "00";
            // 
            // textBox_NumberOfMoves
            // 
            this.textBox_NumberOfMoves.Enabled = false;
            this.textBox_NumberOfMoves.Location = new System.Drawing.Point(135, 216);
            this.textBox_NumberOfMoves.Name = "textBox_NumberOfMoves";
            this.textBox_NumberOfMoves.Size = new System.Drawing.Size(45, 20);
            this.textBox_NumberOfMoves.TabIndex = 31;
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Enabled = false;
            this.btn_Disconnect.Location = new System.Drawing.Point(100, 312);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_Disconnect.TabIndex = 41;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 687);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Infolabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diplayJockersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameRulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel gamePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TextBox textBoxJokers;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.Button btn_Display;
        private System.Windows.Forms.Button btn_Hide;
        private System.Windows.Forms.Button btn_Answer;
        private System.Windows.Forms.Label label_NumberOfMovesText;
        private System.Windows.Forms.TextBox textBox_NumberOfMoves;
        private System.Windows.Forms.TextBox textBoxScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Second_Joker;
        private System.Windows.Forms.Label label_Third_Joker;
        private System.Windows.Forms.Label label_First_Joker;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TextBox textBoxNotification;
        private System.Windows.Forms.Button btn_Inisialize;
        private System.Windows.Forms.Button btn_Disconnect;
    }
}

