namespace Yahtzee_Redo
{
    public class Program
    {
        public static List<int> DiceVals = new List<int>();
        public static void Main()
        {
            StartGamePrint();
            int rollsRemaining = 3;
            bool playerChoice = true;
            while(rollsRemaining > 0 && playerChoice) 
            {
                RollDice(5);
                PlayerChoice();

            }
        }
        public static void RollDice(int rollNumber)
        {
            for (int i = 0; i < rollNumber; i++)
            {
                Dice dice = new Dice();
                dice.Roll();
                DiceVals.Add(dice.GetNumber());
            }
        }
        public static bool PlayerChoice()
        {
            return false;
        }
        public static void StartGamePrint()
        {

        }
        public static int CalculateScore()
        {
            return 0;
        }
    }
}
