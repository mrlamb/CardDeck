using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public class Deck : List<Card> 
    {
        
    }

    public class ShuffledDeck : Deck
    {
        public Queue<Card> Cards { get; set; }
        public ShuffledDeck (Queue<Card> Cards)
        {
            this.Cards = Cards;
        }

    }

    public class UnshuffledDeck : Deck
    {
        public ShuffledDeck Shuffle()
        {
            Random rand = new Random();
            var outDeck = new Queue<Card>();
            for (int i = Count - 1; i >= 0; i--)
            {
                //Notice random access for the list
                int rndNum = rand.Next(0, i);
                Card tmpCard = this[i];
                //This places the random card into the first position of our play deck
                //Enforcing first in, first out
                outDeck.Enqueue(this[rndNum]);
                this[rndNum] = this[i];
                               
            }

            return new ShuffledDeck(outDeck);
        }
    }
}
