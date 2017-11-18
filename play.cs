using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarMegaChallenge
{
    static class Play
    {
        

        public static void createShuffledDeck(List<Card> cards)
        {
            createDeck(cards);
            cards.Shuffle();
            createIndex(cards);
            
        }
        
        private static void createDeck(List<Card> cards)
        {
            for (int i = 1; i < 53; i++)
            {
                int math = (i - 1) / 13;
                cards.Add(new Card { Number = i, Suite = math, Value = i - (math * 13) });
            }
        }
        private static void createIndex(List<Card> cards)
        {
            int j = 1;
            foreach (var card in cards)
            {
                card.Index = j;
                j++;
            }
        }
    }
}