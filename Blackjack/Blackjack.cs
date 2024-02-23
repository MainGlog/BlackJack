using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Blackjack
{
    public enum CardFace
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
    public enum CardSuit
    {
        Clubs, Spades, Hearts, Diamonds
    }
    public enum CardValue
    {
        
    }
    public class Blackjack
    {
        public const int STARTING_TOKENS = 100;
        public const int DEALER_STAND = 17;
        //readonly indicates that assignment to the field can only occur as part of the declaration
        
        public static readonly String[] deck;
        public static readonly bool[] cardsUsed;
        public static List<Card> cards = []; //[] denotes an empty set
        public static int tokens = STARTING_TOKENS;


        public static void Main()
        {
            CreateDeck();
            Console.WriteLine("*--------------------*Blackjack*--------------------*");
            int tokensBet = GetBet();

            while (tokens > 0 && tokensBet != int.MinValue)
            {
                Console.Clear();
                Console.WriteLine("*--------------------*Blackjack*--------------------*");
                Console.WriteLine("Tokens: " + tokens);
                Console.WriteLine("Your bet: " + tokensBet);


                int dealersCard = GenerateCard("The dealer's first card is a", false);
                if (dealersCard == 1)//Dealer's first card was an ace
                {
                    Console.WriteLine("Because the dealer's first card was an ace, they chose to receive 11 points.");
                    dealersCard = 11;
                }
                Console.WriteLine(Environment.NewLine);
                Thread.Sleep(1000);
                int playerValue = PlayerPlay();
                int dealerValue = DealerPlay(dealersCard);
                DetermineWinner(playerValue, dealerValue, tokensBet);
                tokensBet = GetBet();
            }
            ExitPrint();
        }
        public static void CreateDeck()
        {
            //Array keyword is an array that can hold any type
            Array suits = Enum.GetValues(typeof(CardSuit));
            Array faces = Enum.GetValues(typeof(CardFace));
            cards.Clear(); //removes every item from list
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < faces.Length; j++)
                {
                    Card card = new Card()
                    {
                        face = (CardFace)faces.GetValue(j),
                        suit = (CardSuit)suits.GetValue(i),
                        value = Math.Min(j + i, 10)
                    };
                    cards.Add(card);
                }
            }
        }

        public static int GetBet()
        {
            if (tokens == 0) return 0;

            Console.Write(Environment.NewLine); //Gets new line char for whatever environment it's running on

            while (true)
            {
                Console.WriteLine($"You have {tokens} tokens.");
                Console.WriteLine("You may bet up to your token amount or type in \"Q\" to quit.");
                Console.Write("Your bet: ");
                String input = Console.ReadLine()!; //input, gets rid of input buffering, ! = null-forgiving operator

                if (int.TryParse(input, out int bet)) //if an integer is typed, it will go into varible bet
                {
                    if (bet <= 0)
                    {
                        Console.WriteLine("You must bet at least 1 token.");
                    }
                    else if (bet > tokens)
                    {
                        Console.WriteLine("You cannot bet more tokens than you currently have.");
                    }
                    else
                    {
                        return bet;
                    }
                }
                else //input != int
                {
                    if (input.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    {
                        return int.MinValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }

        }

        public static int GenerateCard(String message, bool playerCard = true)
        /*If you pass no bool in, it will default to true. If you pass in a bool, it'll be whatever you say
        For player calls of GenerateCard, you'd pass in message, but for the dealer it would be message and a bool */
        {
            Random rand = new Random();
            int cardIndex = rand.Next(0, cards.Count);

            Card card = cards[cardIndex];
            Console.WriteLine(message + card.GetName());
            
            while (cards[cardIndex].Equals(String.Empty))
            {
                cardIndex = rand.Next(0, cards.Count);
                cardTitle = cards[cardIndex].name;
            }
            //for arrays/strings, it's .length. For all other collections, it's .Count.
            //if a vowel is contained in the first letter of the string, do thingy
            
            Console.WriteLine(message + );
            int cardPointValue = cards[cardIndex].value;
            if (card.IsAce() && playerCard) return AceDecision(); 
            else return Math.Min(10, card.value);
        }

        public static int AceDecision()
        {
            Console.WriteLine("Because your card was an ace, you can choose for it to be worth either 1 or 11 points.");
            Console.Write("Enter '1' or '11' for how many points your card should be worth: ");
            String input = Console.ReadLine();
            int choice = 0;
            int.TryParse(input, out choice);
            while (choice != 1 && choice != 11)
            {
                Console.WriteLine("Invalid Input.");
                Console.Write("Enter '1' or '11' for how many points your card should be worth: ");
                input = Console.ReadLine();
            }
            
            return choice;
        }
        public static int PlayerPlay()
        {
            bool quit = false;
            int cardTotal = 0;

            cardTotal += GenerateCard("Your first card is a");
            Thread.Sleep(1000);
            cardTotal += GenerateCard("Your second card is a");
            Thread.Sleep(1000);

            while (cardTotal < 21 && !quit)
            {
                Console.WriteLine($"The point value of your cards is {cardTotal}.");
                Console.WriteLine("Would you like to hit or stand?");
                Console.Write("Enter either \"hit\" or \"stand\": ");
                String decision = Console.ReadLine();
                while (!decision.Equals("hit", StringComparison.OrdinalIgnoreCase) && !decision.Equals("stand", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid input.");
                    Console.Write("Enter either \"hit\" or \"stand\": ");
                    decision = Console.ReadLine();
                }
                if (decision.Equals("stand", StringComparison.OrdinalIgnoreCase)) quit = true;
                if (!quit) cardTotal += GenerateCard("Your next card is a");
            }
            if (cardTotal == 21)
            {
                Console.WriteLine("Blackjack!" + Environment.NewLine);
                return 21;
            }
            else if (cardTotal < 21)
            {
                Console.WriteLine("You stood with " + cardTotal + " points.");
            }
            Console.WriteLine(Environment.NewLine);
            return cardTotal;
        }

        public static int DealerPlay(int dealersFirstCard)
        {
            int dealerPoints = dealersFirstCard;
            Console.WriteLine($"The dealer starts with {dealerPoints} because of their first card.");
            Thread.Sleep(1000);
            Console.WriteLine("The dealer will hit until they reach at least 17 points.");
            Thread.Sleep(1000);
            while (dealerPoints < 17)//The dealer stops after they get 17 or higher
            {
                int nextCard = GenerateCard("The dealer's next card was a", false);

                if (nextCard == 1)
                {
                    if (dealerPoints + 11 > 21)
                    {
                        Console.WriteLine("Because adding 11 to the dealer's points would make them bust, they chose 1 point.");
                        dealerPoints += 1;
                    }
                    else
                    {
                        Console.WriteLine("The dealer chose to add 11 points");
                        dealerPoints += 11;
                    }
                }
                else
                {
                    dealerPoints += nextCard;
                }

                Console.WriteLine($"The dealer's current point total is {dealerPoints} points.");
                Thread.Sleep(1000);
            }
            if (dealerPoints < 21)
            {
                Console.WriteLine($"The dealer stood with {dealerPoints} points.");
            }
            return dealerPoints;
        }
        public static void DetermineWinner(int playerPoints, int dealerPoints, int betTokens)
        {
            Console.WriteLine("\n");

            if (playerPoints > 21 && dealerPoints > 21)
            {
                Console.WriteLine("Both you and the dealer busted! It's a tie!");
            }
            else if (playerPoints == dealerPoints)
            {
                Console.WriteLine("You tied with the dealer!");
            }
            else if (playerPoints > 21)
            {
                Console.WriteLine("You busted!");
                tokens -= betTokens;
                Console.WriteLine("You lost " + betTokens + " tokens.");
            }
            else if (dealerPoints > 21)
            {
                Console.WriteLine("The dealer busted, so you win!");
                tokens += betTokens;
                Console.WriteLine("You won " + betTokens + " tokens!");
            }
            else if (playerPoints > dealerPoints)
            {
                Console.WriteLine("You win that hand!");
                tokens += betTokens;
                Console.WriteLine("You won " + betTokens + " tokens!");
            }
            else
            {
                Console.WriteLine("You lost that hand.");
                tokens -= betTokens;
                Console.WriteLine("You lost " + betTokens + " tokens.");
            }
        }
        public static void ExitPrint()
        {
            int pointDifference = Math.Abs(tokens - STARTING_TOKENS);

            if (tokens == 0)
            {
                Console.WriteLine("Sorry, you ran out of tokens!");
            }
            else if (tokens > STARTING_TOKENS)
            {
                Console.WriteLine("Looks like you made a profit of " + pointDifference + " tokens!");
                Console.WriteLine("You're leaving with " + tokens + " tokens.");
            }
            else if (tokens < STARTING_TOKENS)
            {
                Console.WriteLine("Seems like you're " + pointDifference + " tokens lighter. Better luck next time!");
                Console.WriteLine("You're leaving with " + tokens + " tokens.");
            }
            else
            {
                Console.WriteLine("Wow, you broke even!");
                Console.WriteLine("You're leaving with " + tokens + " tokens.");
            }
            Console.WriteLine("Come back again!");
        }
    }
    
}

    
      