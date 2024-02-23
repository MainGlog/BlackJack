namespace OOPTriviaGame
{
    public class Program
    {
        public const String QUESTION_FILE = "questions.txt";
        public const String HIGH_SCORE_FILE = "highscore.txt";
        public static int highScore;
        public static void Main()
        {
            StartGamePrint();
            Console.Clear();

            bool playAgain = true;
            while(playAgain)
            {
                Game currentGame = new Game();
                currentGame.SetQuestions(LoadQuestions()); //Interfacing with questions list but not modifying it
                int score = currentGame.PlayGame(); //Interfacing with score of Game class but not modifying it

                Console.Clear();
                Console.WriteLine($"You got {score} out of {Game.QUESTIONS_TO_ASK} questions correct!");
                CheckHighScore(score);

                Console.Write("Play again? (y/n) ");
                String input = Console.ReadLine();

                String[] validChoices = { "y", "n" };
                while(!validChoices.Contains(input, StringComparer.OrdinalIgnoreCase)) //StringComparer for .Contains 
                {
                    Console.Write("Invalid input. Play again? (y/n) ");
                    input = Console.ReadLine();
                }
                playAgain = input.Equals("y", StringComparison.OrdinalIgnoreCase);
            }
        }
        public static List<Question> LoadQuestions()
        {
            List<Question> questions = [];

            List<String> lines = new List<String>(File.ReadAllLines(QUESTION_FILE)); //() at the end of list will turn an array into a list
            //List<String> lines = File.ReadAllLines.ToList() does the same thing but slower, more instructions in background
            //() pass in a collection, iterates through collection and adds it to the list
            lines.RemoveAll(String.IsNullOrWhiteSpace); //IsNullOrWhiteSpace method is treated as the predicate, calls method for each iteration

            for (int i = 0; i < lines.Count; i+=2)
            {
                Question q = new Question
                {
                    question = lines[i],
                    answer = lines[i + 1]
                };
                questions.Add(q);
            }
            return questions;
        }
        public static void CheckHighScore(int score) 
        { 
            if(score > highScore) 
            {
                Console.WriteLine("You set a new high score!");
                highScore = score;
                File.WriteAllText(HIGH_SCORE_FILE, score.ToString());
            }
        }
        public static void StartGamePrint()
        {
            Console.WriteLine("~~~TRIVIA GAME~~~");
            Console.WriteLine($"Answer the {Game.QUESTIONS_TO_ASK} questions."); //A class method can only access class variables
            Console.WriteLine($"The current high score is {highScore}");
            Console.WriteLine("All answers will be one word.  Answers will not include numbers.");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
        }
        public static int LoadHighScore()
        {
            if (!File.Exists(HIGH_SCORE_FILE))
            {//No high score
                return 0;
            }
            return int.Parse(File.ReadAllText(HIGH_SCORE_FILE));
        }
    }
}
