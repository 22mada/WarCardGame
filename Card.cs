using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarMegaChallenge
{
    [Serializable]
    public class Card
    {
        public int Index { get; set; }
        public int Number { get; set; }
        public int Suite { get; set; }
        public int Value { get; set; }

        public string displayCard(Card card)
        {
            string message = "Blank";
            if(card != null)
            { 
                message = displayValue(card);
                message += displaySuite(card);
            }
            return message;
        }

        public string displayValue(Card card)
        {
            string message = "";
            if (card.Value == 1) message += "Ace ";
            else if (card.Value > 0 && card.Value < 11) message += card.Value.ToString();
            else if (card.Value == 11) message += "Jack ";
            else if (card.Value == 12) message += "Queen ";
            else message += "King ";
            return message;
        }
        public string displaySuite(Card card)
        {
            string message = "";
            if (card.Suite == 0) message += " of Clubs";
            else if (card.Suite == 1) message += " of Diamonds";
            else if (card.Suite == 2) message += " of Hearts";
            else message += " of Spades";

            return message;
        }

    }
}
