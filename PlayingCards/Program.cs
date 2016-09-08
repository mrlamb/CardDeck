using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<Card> deck;
            //Setup a Deck of Ace through King, of four suits
            deck = new UnshuffledDeck();
            for (int i = (int)Suits.Hearts; i <= (int)Suits.Clubs; i++)
            {
                for (int j = (int)Faces.Ace; j <= (int)Faces.King; j++)
                {
                    deck.Add(new Card(Enum.GetName(typeof(Faces), j) + " of " +
                        Enum.GetName(typeof(Suits), i)));
                }
            }
            
            //Shuffle the deck
            deck = (deck as UnshuffledDeck).Shuffle();

            //Make the player hands
            var player1 = new List<Card>();
            var player2 = new List<Card>();

            //Deal seven cards to each
            for (int i = 0; i < 7; i++)
            {
                player1.Add((deck as ShuffledDeck).Cards.Dequeue());
                player2.Add((deck as ShuffledDeck).Cards.Dequeue());
            }

            //Create a discard pile
            Stack<Card> discardPile = new Stack<Card>();

            do
            {
                //List each hand
                Console.WriteLine("Player 1's Hand");
                foreach (var item in player1)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Player 2's Hand");
                foreach (var item in player2)
                {
                    Console.WriteLine(item.ToString());
                }

                //Discard a card from each hand onto discard pile
                Console.WriteLine("Player 1, choose a card to discard (1 - {0})",
                    (player1.Count).ToString());

                //No Error checking for this simple example
                string resp = Console.ReadLine();

                //add to discard pile before removing from hand else we lose the reference!
                discardPile.Push(player1[Int32.Parse(resp) - 1]);
                player1.RemoveAt(Int32.Parse(resp) - 1);

                Console.WriteLine("The top card of the discard pile is {0}",
                    discardPile.Peek().ToString());

                Console.WriteLine("Player 2, choose a card to discard (1 - {0})",
                    (player2.Count).ToString());

                //No Error checking for this simple example
                resp = Console.ReadLine();
                discardPile.Push(player2[Int32.Parse(resp) - 1]);
                player2.RemoveAt(Int32.Parse(resp) - 1);

                Console.WriteLine("The top card of the discard pile is {0}",
                    discardPile.Peek().ToString());


            } while (player2.Count > 0);

            //List the discard pile popping each card off into oblivion to illustrate
            //last in first out
            Console.Write("The discard pile in order from top down: ");
            do
            {
                Console.Write(discardPile.Pop().ToString() + " ");
            } while (discardPile.Count >0);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
