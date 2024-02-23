namespace Blackjack
{
    public class Card
    {
        public CardSuit suit;
        public CardFace face;
        public int value;

        public String GetName()
        {
            if ("aeiou".Contains(face.ToString().ToLower()[0]))
            {
                return "n " + face + " of " + suit;
            }
            else
            {
                return face + " of " + suit;
            }
        }
        public bool IsAce()
        {
            return face == CardFace.Ace;
        }
    }
}
