using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }


    // When a new deck is created, you’ll create a card of each rank for each suit and add them to the deck of cards, 
    //      which in this case will be a List of Card objects.
    //
    // A deck can perform the following actions:
    //     void Shuffle() -- Merges the discarded pile with the deck and shuffles the cards
    //     List<card> Deal(int numberOfCards) - returns a number of cards from the top of the deck
    //     void Discard(Card card) / void Discard(List<Card> cards) - returns a card from a player to the 
    //         discard pile	
    // 
    // A deck knows the following information about itself:
    //     int CardsRemaining -- number of cards left in the deck
    //     List<Card> DeckOfCards -- card waiting to be dealt
    //     List<Card> DiscardedCards -- cards that have been played
    class Deck
    {
        public int CardsRemaining { get; set; }
        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }

        public Deck()
        {
            this.DeckOfCards = new List<Card>();
            //List<Card> DiscardedCards = new List<Card>();
            this.DiscardedCards = new List<Card>();

            for (int i = 2; i < 15; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    this.DeckOfCards.Add(new Card((Suit)j, (Rank)i));

                }
            }
        }


        public void Shuffle()
        {
            List<Card> ShuffledDeck = new List<Card>();
            this.DeckOfCards.AddRange(DiscardedCards);
            // DiscardedCards.Clear();
            
            Random rng = new Random();

            while (this.DeckOfCards.Count > 0)
            {
                Card newCard = this.DeckOfCards[rng.Next(0, this.DeckOfCards.Count)];
                ShuffledDeck.Add(newCard);
               this.DeckOfCards.Remove(newCard);

            }
            this.DeckOfCards = ShuffledDeck;
        }
        public List<Card> Deal(int numberOfCards)
        {
            List<Card> returnList = new List<Card>();
         

            //loop to go through deck elements
            for (int i = 0; i < numberOfCards; i++)
            {
                if (this.DeckOfCards[0] != null)
                {
                    returnList.Add(this.DeckOfCards[0]);
                    this.DeckOfCards.RemoveAt(0);
                   
                }

            }
            return returnList;
        }


        public void Discard(Card card)
        {
            this.DiscardedCards.Add(card);
        }

        public void Discard(List<Card> hand)
        {
           // for (int i = 0; i < hand.Count; i++)
            
                this.DiscardedCards.AddRange(hand);
               // Console.WriteLine(DiscardedCards);
              //  Console.ReadKey();
            
        }


    }


    public enum Suit
    {
        //fill in 
        Clubs = 1,
        Diamonds,
        Hearts,
        Spades

    }
    public enum Rank
    {
        two = 2,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        jack,
        queen,
        king,
        ace
    }


    // What makes a card?
    //     A card is comprised of it’s suit and its rank.  Both of which are enumerations.
    //     These enumerations should be "Suit" and "Rank"
    class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;

        }


    }

}


