using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarMegaChallenge
{

    public class Game
    {
        public bool Player1Winner { get; set; }
        public bool Player2Winner { get; set; }
        public bool War { get; set; }
        public bool GameOver { get; set; }

        public Game()
        {
            Player1Winner = false;
            Player2Winner = false;
            War = false;
            GameOver = false;            
        }

        public bool DetermineWinnerWar(int score1, int score2, Game g)
        {
            if (score1 > score2)
            {
                g.Player1Winner = true;
                g.Player2Winner = false;
                g.War = false;
            }
            else if (score2 > score1)
            {
                g.Player1Winner = false;
                g.Player2Winner = true;
                g.War = false;
            }
            else g.War = true;

            return g.War;
        }
        public string AssignWin(Player p1, Player p2, Game g)
        {
            string message = "";
           
            if (g.Player1Winner == true)
            {
                p1.MyHand.Add(p1.MyCard);
                p1.MyHand.Add(p2.MyCard);
                if (p1.WarHand != null)addWarHand(p1, p2);
                p1.updateScores(p1.MyHand, p1);
                p2.updateScores(p2.MyHand, p2);
                message = "<h2>Player 1 Wins this Round!</h2>";
               
            }
            else
            {
                p2.MyHand.Add(p1.MyCard);
                p2.MyHand.Add(p2.MyCard);
                if (p2.WarHand != null)addWarHand(p2, p1);
                p1.updateScores(p1.MyHand, p1);
                p2.updateScores(p2.MyHand, p2);
                message = "<h2>Player 2 Wins this Round</h2>";
               
            }
            g.War = false;
            g.removeWarHand(p1, p2);
            return message;
        }

        public void WarBoolTrue(Player p1, Player p2, Game g)
        {
            g.goToWar(p1, p2);
            p1.WarHand.Add(p1.MyCard);
            p2.WarHand.Add(p2.MyCard);
           
            p1.MyHand.TrimExcess();
            p2.MyHand.TrimExcess();

        }


        public void goToWar(Player p1, Player p2)
        {
            for (int i = 0; i < 3; i++)
            {               
                p1.WarHand.Add(p1.MyHand.ElementAt(i));
                p2.WarHand.Add(p2.MyHand.ElementAt(i));
            }

            for (int i = 0; i < 3; i++)
            {
                p1.MyHand.Remove(p1.MyHand.ElementAt(i));
                p2.MyHand.Remove(p2.MyHand.ElementAt(i));
            }
            p1.MyHand.TrimExcess();
            p2.MyHand.TrimExcess();
            
        }

        public void addWarHand(Player winner, Player loser)
        {
            if (winner.WarHand != null)
            {
                for (int i = 0; i < winner.WarHand.Count; i++)
                {
                    winner.MyHand.Add(winner.WarHand.ElementAt(i));
                }
            }
            if (loser.WarHand != null)
            {
                for (int i = 0; i < loser.WarHand.Count; i++)
                {
                    winner.MyHand.Add(loser.WarHand.ElementAt(i));
                }

            }
        }

        public void removeWarHand(Player p1, Player p2)
        {
            p1.WarHand.Clear();
            p2.WarHand.Clear();
        }

        public string roundResults(Player p1, Player p2, Card c)
        {
            string message = "";
            message += "</br><h4>---- Player 1 ----  ----Player 2 ----</h4>";
            message += String.Format("<br/><h4>|      {0}     |       {1}       |</h4>", c.displayCard(p1.MyCard), c.displayCard(p2.MyCard));
            message += String.Format("<br/><h4>|Score:{0}     | Score:{1}      |</h4>", p1.Score, p2.Score);
            message += String.Format("<br/><h4>|Num:  {0}     | Num:  {1}      |</h4>", p1.NumberofCards, p2.NumberofCards);
            message += "____________________________________________________";

            return message;
        }

        public string determineGameOver(int p1Score, int p2Score, Game g)
        {
            int winningScore = 240;
            string message = "";
            if (p1Score > winningScore)
            {
                g.GameOver = true;
                message = String.Format("<br/><h2>Player 1 Wins the Game! </h2><br/> Player 1 Score: {0} <br/> Player 2 Score: {1}",
                    p1Score, p2Score);
            }
            else if (p2Score > winningScore)
            {
                g.GameOver = true;
                message = String.Format("<br/><h2>Player 2 Wins the Game!</h2> <br/> Player 2 Score: {0} <br/> Player 1 Score: {1}",
                    p2Score, p1Score);
            }

            else
            {
                g.GameOver = false;
                message += "";

            }
            return message;
        }
    }
}
