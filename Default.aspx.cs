using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WarMegaChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        List<Card> cards = new List<Card>();
        Player p1 = new Player("Player1");
        Player p2 = new Player("Player2");
        Card c = new Card();
        Game g = new Game();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Play.createShuffledDeck(cards);
            p1.dealHand(cards, p1, p2);

            while (g.GameOver != true)
            {
                resultLabel.Text += p1.playersTurn(p1, p2);
                g.War = g.DetermineWinnerWar(p1.MyCard.Value, p2.MyCard.Value, g);
                
                while (g.War == true)
                {
                    resultLabel.Text += "<br/><h2>This is War</h2><br/><br/>";
                    g.WarBoolTrue(p1, p2, g);
                    resultLabel.Text += p1.showWarHand(p1.WarHand, p2.WarHand, c);
                    resultLabel.Text += p1.playersTurn(p1, p2);
                   g.War = g.DetermineWinnerWar(p1.MyCard.Value, p2.MyCard.Value, g);
                }
                resultLabel.Text += String.Format("<br/>{0} <br/>", g.AssignWin(p1, p2, g));
                resultLabel.Text += g.roundResults(p1, p2, c);
                resultLabel.Text += String.Format("<br/>{0} <br/>", g.determineGameOver(p1.Score, p2.Score, g));
                
            }
            }
        }


    }




