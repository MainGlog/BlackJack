using System.Collections.Generic;

namespace War
{
    public class Program
    {
        public enum CardSuit : byte // : byte changes the data type, saves space
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }
        public enum Card : byte
        {
            Ace = 14,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }
        public enum WarWinner : byte
        {
            Player1,
            Player2
        }

        public const int WAR_CARD_COUNT = 4;

        public static List<(CardSuit suit, Card value)> player1Deck = [];//initializes it and creates an empty list
        public static List<(CardSuit suit, Card value)> player1Discard = [];
        public static List<(CardSuit suit, Card value)> player2Deck = [];
        public static List<(CardSuit suit, Card value)> player2Discard = [];
        public static void Main()
        {
            Console.Title = "War";//changes the tab title of the terminal when you run the game
            CreateDecks();
            String p1Msg = String.Empty;
            String p2Msg = String.Empty;
            while (IsGameOver() == false)
            {
                Console.Clear();
                p1Msg = "Player 1 Cards: " + (player1Deck.Count + player1Discard.Count);
                Console.WriteLine(p1Msg);
                p2Msg = "Player 2 Cards: " + (player2Deck.Count + player2Discard.Count);
                Console.WriteLine(p2Msg);
                Console.WriteLine(new String('=', Math.Max(p1Msg.Length, p2Msg.Length)));
                PlayRound();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            p1Msg = "Player 1 Cards: " + (player1Deck.Count + player1Discard.Count);
            Console.WriteLine(p1Msg);
            p2Msg = "Player 2 Cards: " + (player2Deck.Count + player2Discard.Count);
            Console.WriteLine(p2Msg);
            Console.WriteLine(new String('=', Math.Max(p1Msg.Length, p2Msg.Length)));
            Console.Clear();
            
            bool player1Wins = player1Deck.Count + player1Discard.Count > 0;
            Console.WriteLine($"Player {(player1Wins ? "1" : "2")} wins!");
        }

        public static void PlayRound()
        {
            (CardSuit suit, Card value) p1Card = player1Deck[0];
            player1Deck.RemoveAt(0);
            (CardSuit suit, Card value) p2Card = player2Deck[0];
            player2Deck.RemoveAt(0);

#if RELEASE
            Thread.Sleep(1000); 
#endif  //only compiles if the directive is in release mode
            Console.WriteLine($"Player 1 plays {p1Card.value} of {p1Card.suit}");
#if RELEASE
            Thread.Sleep(1000);
#endif
            Console.WriteLine($"Player 2 plays {p2Card.value} of {p2Card.suit}");

            if (p1Card.value > p2Card.value)
            {
                Console.WriteLine("Player 1 wins the round!");
                player1Discard.Add(p1Card);
                player1Discard.Add(p2Card);
            }
            else if (p2Card.value > p1Card.value)
            {
                Console.WriteLine("Player 2 wins the round!");
                player2Discard.Add(p1Card);
                player2Discard.Add(p2Card);
            }
            else //Value of cards are the same
            {
                if(War() == WarWinner.Player1)
                {
                    player1Discard.Add(p1Card);
                    player1Discard.Add(p2Card);
                }
                else //Player 2 Won
                {
                    player2Discard.Add(p1Card);
                    player2Discard.Add(p2Card);
                }
            }

            if (player1Deck.Count == 0)
            {
                ShuffleDiscardIntoDeck(player1Discard, player1Deck);
            }

            if (player2Deck.Count == 0)
            {
                ShuffleDiscardIntoDeck(player2Discard, player2Deck);
            }
        }
        public static WarWinner War() 
        {
            //If player 1 is out of cards
            if (player1Deck.Count + player1Discard.Count == 0)
            {
                Console.WriteLine("Player 2 wins the war!");
                return WarWinner.Player2;
            }
            else if(player2Deck.Count + player2Discard.Count == 0)
            {
                Console.WriteLine("Player 1 wins the war!");
                return WarWinner.Player1;
            }
            
            List<(CardSuit suit, Card value)> p1Cards = GetCardsForWar(player1Deck, player1Discard);
            List<(CardSuit suit, Card value)> p2Cards = GetCardsForWar(player2Deck, player2Discard);
            
            //player 1 wins
            //(^) "From end" operator
            if (p1Cards[^1].value > p2Cards[^1].value)             //if (p1Cards[p1Cards.Count - 1].value > p2Cards[p2Cards.Count - 1].value)
            {
                Console.WriteLine("Player 1 wins the war!");
                player1Discard.AddRange(p1Cards.Concat(p2Cards));
                return WarWinner.Player1;
            }
            else if (p2Cards[^1].value > p1Cards[^1].value)
            {
                Console.WriteLine("Player 2 wins the war!");
                player2Discard.AddRange(p1Cards.Concat(p2Cards));
                return WarWinner.Player2;
            }
            else //Tie in the war
            {
                if(War() == WarWinner.Player1)
                {
                    player1Discard.AddRange(p1Cards.Concat(p2Cards));
                    return WarWinner.Player1;
                }
                else 
                {
                    player2Discard.AddRange(p1Cards.Concat(p2Cards));
                    return WarWinner.Player2;
                }
            }
        }
        public static List<(CardSuit suit, Card value)> GetCardsForWar(
            List<(CardSuit suit, Card value)> deck, List<(CardSuit suit, Card value)> discard
            )
        {
            List<(CardSuit suit, Card value)> cards = [];

            while(cards.Count < WAR_CARD_COUNT)
            {
                if (deck.Count + discard.Count == 0)
                {
                    break;
                }
                else if(deck.Count == 0)
                {
                    ShuffleDiscardIntoDeck(discard, deck);
                }
                //Takes card from deck and puts it into cards
                cards.Add(deck[0]);
                deck.RemoveAt(0);
            }

            return cards;
        }
        public static void ShuffleDiscardIntoDeck(List<(CardSuit suit, Card value)> discard,
            List<(CardSuit suit, Card value)> deck)
        {
            Random random = new Random();

            while (discard.Count > 0)//shuffles cards back into the deck
            {
                int index = random.Next(0, discard.Count);
                discard.Add(discard[index]);
            }
        }

        public static void CreateDecks()
        {
            List<(CardSuit suit, Card value)> deck = [];
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (Card value in Enum.GetValues(typeof(Card)))
                {
                    deck.Add((suit, value));
                }
            }

            Random random = new Random();
            int halfDeck = deck.Count / 2;

            while (deck.Count > halfDeck)
            {
                int index = random.Next(0, deck.Count);
                player1Deck.Add(deck[index]);
                deck.RemoveAt(index);
            }
            while (deck.Count > 0)
            {
                int index = random.Next(0, deck.Count);
                player2Deck.Add(deck[index]);
                deck.RemoveAt(index);
            }
        }
        public static bool IsGameOver()
        {
            return player1Deck.Count == 0 && player1Discard.Count == 0
                || player1Deck.Count == 0 && player1Discard.Count == 0;

        }

    }
}
