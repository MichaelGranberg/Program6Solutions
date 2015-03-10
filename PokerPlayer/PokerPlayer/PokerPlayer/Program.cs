using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.ReadKey();
        }
    }
    /// <summary>
    /// This Class plays the game of Poker
    /// </summary>
    class PokerPlayer
    {
        List<Card> hand { get; set;  }
        /// <summary>
        /// This function will draw cards into a hand
        /// </summary>
        /// <param name="cards">deck of cards</param>
        public void DrawHand(List<Card> cards)
        {
            this.hand = cards;
        }
        /// <summary>
        ///  Enum of different hand types starting from the least to the greatest
        /// </summary>
        public enum HandType
        {
            HighCard =1,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush

        }
        /// <summary>
        /// Rank of hand that player holds;This checks the Hand in the reverse Order, so no lesser hand qualifies
        /// that is: a full house will qualify as such, instead of a pair or three of a kind.
        /// </summary>
        public HandType HandRank
        {
           get 

            {
               if (HasRoyalFlush ()) { return HandType.RoyalFlush;} 
               if (HasStraightFlush()) { return HandType.StraightFlush;}
               if (HasFourOfAKind()) { return HandType.FourOfAKind;}
               if (HasFullHouse()) { return HandType.FullHouse;}
               if (HasFlush()) { return HandType.Flush;}
               if (HasStraight()) { return HandType.Straight;}
               if (HasThreeOfAKind()) { return HandType.ThreeOfAKind;}
               if (HasTwoPair()) { return HandType.TwoPair;}
               if (HasPair()) { return HandType.OnePair;}
               else { return HandType.HighCard;}
            }
        }
        /// <summary>
        /// This fuction will show the cards in the hand dealt
        /// </summary>
        public void ShowHand()
        {
           foreach (var item in this.hand)
	        {
                 Console.WriteLine(item);
	        }
           
        }
        // Constructor not used
        public PokerPlayer() { }
        /// <summary>
        /// This function will check to see if you have a pair
        /// </summary>
        /// <returns>bool:true or false</returns>
        public bool HasPair()
        {
            return this.hand.GroupBy(x=>x.Rank).Count(x=>x.Count()==2)==1;
           
        }
        /// <summary>
        /// This function checks for two pair
        /// </summary>
        /// <returns>bool</returns>
        public bool HasTwoPair()
        {
            return this.hand.GroupBy(x => x.Rank).Count(x => x.Count() == 2) == 2;
        }
        /// <summary>
        /// This function checks for 3 of a kind
        /// </summary>
        /// <returns>bool</returns>
        public bool HasThreeOfAKind()
        {
            return this.hand.GroupBy(x => x.Rank).Count(x => x.Count() == 3) == 1;
        }
        /// <summary>
        /// This function will check to see if you have a straight by ordering the cards 
        /// and checking to see if you have a difference of 4
        /// </summary>
        /// <returns>bool</returns>
        public bool HasStraight()
        {
           
          return this.hand.OrderBy(x => x.Rank).Count()== 5  && (this.hand.Max(x=>x.Rank) - this.hand.Min(x=>x.Rank) == 4);
             
        }
        /// <summary>
        /// This function checks to see if you have a flush (all cards the same suit)
        /// </summary>
        /// <returns>bool</returns>
        public bool HasFlush()
        {

            return this.hand.GroupBy(x => x.Suit).Count() == 1;
           
        }
        /// <summary>
        /// This function checks to see if it's a full house
        /// </summary>
        /// <returns>bool</returns>
        public bool HasFullHouse()
        {
            return (HasPair() && HasThreeOfAKind());
        }
        /// <summary>
        /// This function checks to see if you have 4 of a kind, and that you don't have more than one per suit
        /// </summary>
        /// <returns>bool</returns>
        public bool HasFourOfAKind()
        {
            return this.hand.GroupBy(x => x.Rank).Count(x => x.Count() == 4) == 1 && this.hand.GroupBy (x=>x.Suit).Count() == 4;
        }
        /// <summary>
        /// This function will check for a straight flush
        /// </summary>
        /// <returns>bool</returns>
        public bool HasStraightFlush()
        {
            return (HasFlush() && HasStraight());
        }
        /// <summary>
        /// This function will check for a Royal flush by checking for a straight flush 
        /// and then making sure the smallest card is a ten
        /// </summary>
        /// <returns>bool</returns>
        public bool HasRoyalFlush()
        {
            return HasStraightFlush() &&  this.hand.Min(x=>x.Rank)  == Rank.Ten;
        }
    }
   
    /// <summary>
    /// This is the Class for Deck
    /// </summary>
    class Deck
    {
        public int CardsRemaining { get; set; }
        public List<Card> DeckOfCards { get; set; }
        public List<Card> DiscardedCards { get; set; }
        /// <summary>
        /// This function builds the deck by suit and rank
        /// </summary>
        public Deck()
        {
            this.DeckOfCards = new List<Card>();
            this.DiscardedCards = new List<Card>();

            for (int i = 2; i < 15; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    this.DeckOfCards.Add(new Card(i,j));

                }
            }
        }

        /// <summary>
        /// This function shuffles the deck
        /// </summary>
        public void Shuffle()
        {
            List<Card> ShuffledDeck = new List<Card>();
            this.DeckOfCards.AddRange(DiscardedCards);
          
            Random rng = new Random();

            while (this.DeckOfCards.Count > 0)
            {
                Card newCard = this.DeckOfCards[rng.Next(0, this.DeckOfCards.Count)];
                ShuffledDeck.Add(newCard);
                this.DeckOfCards.Remove(newCard);

            }
            this.DeckOfCards = ShuffledDeck;
        }
        /// <summary>
        /// This function deals the cards
        /// </summary>
        /// <param name="numberOfCards">int number of cards</param>
        /// <returns>returnList</returns>
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

        /// <summary>
        /// This function will add a ard to your discarded cards
        /// </summary>
        /// <param name="card">card</param>
        public void Discard(Card card)
        {
            this.DiscardedCards.Add(card);
        }
        /// <summary>
        /// This function adds the hand to discarded cards
        /// </summary>
        /// <param name="hand">List of cards in hand</param>
        public void Discard(List<Card> hand)
        {
            
            this.DiscardedCards.AddRange(hand);
           
        }


    }

    /// <summary>
    /// Enumeration for suit
    /// </summary>
    public enum Suit
    {
        //fill in 
        Club = 1,
        Diamond,
        Heart,
        Spade

    }
    /// <summary>
    /// Enumeration for rank
    /// </summary>
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    /// <summary>
    /// Class for Card
    /// </summary>
        public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public Card(int rank, int suit)
        {
            this.Suit = (Suit)suit;
            this.Rank = (Rank)rank;

        }


    }

}


