using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SerializableObjects;


namespace MemoryGame
{

    public class GameSettings: Data
    {
        public struct Time
        {
            public int seconds;
            public int minutes;
            public int hours;
        }

        ////***************************** Delegats & Events************************/////////
        public delegate void CounterEventHandler(Time time);
        public event CounterEventHandler CounterChangeEvent;

        public delegate void CounterMovesEventHandler(int value);
        public event CounterMovesEventHandler MovesChangeEvent;

        public delegate void CounterScoreEventHandler(int value);
        public event CounterScoreEventHandler ScoreChangeEvent;
        Time time;

        public GameSettings() {
            time.seconds = 0;
            time.minutes = 0;
            time.hours = 0;
        }

        ////********************************** Proprietes***************************////

        // CounterEvent Triger
        // MovesEvent Triger
        public void CountNumberOfMoves()
        {
            numberOfMoves++;
            if (MovesChangeEvent != null)
                MovesChangeEvent(numberOfMoves);
        }

        // ScoreEvent Triger
        public void CountScore(int value)
        {
            score += value;
            if (ScoreChangeEvent != null)
                ScoreChangeEvent(score);
        }
        public void Count()
        {   
            while (!stop)
            {
                time.seconds++;
                if (time.seconds == 60) { time.seconds = 0; time.minutes++; }
                if (time.minutes == 60) { time.seconds = 0; time.minutes = 0; time.hours++; }
                if (CounterChangeEvent != null)
                {
                    
                   CounterChangeEvent(time);
                }
                Thread.Sleep(1000);
            }
        }
        // Play Method
        public void Play()
        {
            Thread t = new Thread(Count);
            stop = false;
            t.Start();
            
            
        }

        // Stop Method
        public void Stop()
        {
            stop = true;
        }

    }



}
