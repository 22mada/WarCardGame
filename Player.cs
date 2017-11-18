using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarMegaChallenge
{  
    public class Player
    {
        public string Name { get; set; }
        public int NumberofCards { get; set; }
        public int Score { get; set; }
        public Card MyCard { get; set; }
        public List<Card> MyHand { get; set; }
        public List<Card> WarHand { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
            NumberofCards = 0;
            MyHand = new List<Card>();
            MyCard = new Card();
            WarHand = new List<Card>();

        }
        public void dealHand(List<Card> cards, Player p1, Player p2)
        {
            foreach (var card in cards)
            {
                if (card.Index % 2 != 0) p1.MyHand.Add(card);
                else p2.MyHand.Add(card);
            }
            
        }
        public void setCard(List<Card> l, Card c)
        {
            l.TrimExcess();
            c = l.First();
            l.Remove(l.First());
            l.TrimExcess();
        }
        public string playersTurn(Player p1, Player p2)
        {
            try
            {
                p1.MyCard = p1.MyHand.First();
                p1.MyHand.Remove(p1.MyHand.First());
                p1.MyHand.TrimExcess();
                p1.updateScores(p1.MyHand, p1);

                p2.MyCard = p2.MyHand.First();
                p2.MyHand.Remove(p2.MyHand.First());
                p2.MyHand.TrimExcess();
                p2.updateScores(p2.MyHand, p2);

                return showCard(p1.MyCard, p2.MyCard);
            }
            catch
            {
                return "Error";
            }

            
        }

        public string showCard(Card p1, Card p2)
        {
            string message = "<b/><h2>---Player 1---   ---Player 2---</h2><b/>";
            message += string.Format("<h2>|     {0}      |      {1}     |</h2>", p1.displayCard(p1), p1.displayCard(p2));
            message += "<b/> ______________________________________________<b/>";
            return message;
        }

        public string showWarHand(List<Card> p1, List<Card> p2, Card c)
        {
            string message = "<b/><h2>---Player 1---   ---Player 2---</h2> <b/>";
            for (int i = 0; i < p1.Count-1; i++)
            {
                message += string.Format("<h2>|     {0}      |      {1}     |</h2>", c.displayCard(p1.ElementAt(i)), c.displayCard(p2.ElementAt(i)));
            }
           
            message += "<b/>______________________________________________</b>";
            return message;
        }
        public string showHand(List<Card> p1, List<Card> p2, Card c)// testing purposes
        {
            int length = 0;
            if (p1.Count > p2.Count) length = p2.Count;
            else length = p1.Count;
            string message = "";
            message += "<b/><h2>---Player 1---   ---Player 2---</h2> <b/>";
            for (int i = 0; i < length; i++)
            {
                message += string.Format("<h2>|     {0}      |      {1}     |</h2><b/>", c.displayCard(p1.ElementAt(i)), c.displayCard(p2.ElementAt(i)));
            }
            if (p1.Count > p2.Count)
            { 
             for (int i = length; i < p1.Count; i++)
                {
                     message += "<h2>| " + c.displayCard(p1.ElementAt(i)) + "</h2><b/>";
                 }
            }
            else if(p1.Count<p2.Count)
            {
                for (int i = length; i < p2.Count; i++)
                {
                    message += "<h2>| " + c.displayCard(p2.ElementAt(i)) + "</h2><b/>";
                }
            }
            message += "_____________________________________________________";

            return message;
        }
        public int countCards(List<Card> cards)
        {
            return cards.Count;
        }

        public int countScore(List<Card> cards)
        {
            int total = 0;
            foreach (var card in cards)
            {
                if(card !=null)total += card.Value;
            }
            return total;
        }

        public void updateScores(List<Card> cards, Player p)
        {
            p.Score = p.countScore(cards);
            p.NumberofCards = p.countCards(cards);
        }
        
        

    }
}





    
