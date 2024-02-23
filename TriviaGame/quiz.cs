using System.Reflection.PortableExecutable;

namespace TriviaGame
{
    public class quiz
    {
        public const String QUESTION_FILE = "questions.txt";
        public const String HIGH_SCORE_FILE = "highscore.txt";

        public static List<String> questions = new List<String>();
        public static List<String> answers = new List<String>();//Parallel arrays
        public static List<int> questionsAvailable = new List<int>();

        public const int QUESTIONS_TO_ASK = 10; //How long your quiz will be.
        public static int questionsAsked = 0;
        public static int score = 0;
        public static int highScore = LoadHighScore();
        public static void Main()
        {//Copy pasting a file by right clicking on the project and pasting
            //Properties --> Copy if newer allows it to only open once in our executeable folder
            LoadQuestions();
            //If you wanted to change the questions file while having this program open, it would not take effect.
            StartGamePrint();

            questionsAvailable = Enumerable.Range(0, questions.Count).ToList();

            bool playAgain = true;
            while (playAgain)
            {
                GameLogicLoop();
                Console.Write("Play again? (y/n) ");
                String input = Console.ReadLine();

                while(!input.Equals("y", StringComparison.OrdinalIgnoreCase) //Shortcut for StringComparison.OrdinalIgnoreCase --> stco.oi
                    && !input.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Invalid input.");
                    Console.Write("Play again? (y/n) ");
                    input = Console.ReadLine();
                }
                
                playAgain = input.Equals("y", StringComparison.OrdinalIgnoreCase);
                questionsAsked = 0;
                score = 0;
                questionsAvailable = Enumerable.Range(0, questions.Count).ToList();
            }
        }
        public static int LoadHighScore()
        {
            if (!File.Exists(HIGH_SCORE_FILE))
            {//No high score
                return 0;
            }
            return int.Parse(File.ReadAllText(HIGH_SCORE_FILE));
        }
        public static void LoadQuestions()
        {
            List<String> lines = new List<String>(File.ReadAllLines(QUESTION_FILE)); //loads questions into new string list from file
            lines.RemoveAll(String.IsNullOrWhiteSpace);//If it finds lines that are null or whitespace, they are gone

            for (int i = 0; i < lines.Count; i += 2)//Skips every other line
            {
                questions.Add(lines[i]);//Questions on odd lines
                answers.Add(lines[i + 1]);//Answers on even lines
            }
        }
        public static void StartGamePrint()
        {
            Console.WriteLine("~~~TRIVIA GAME~~~");
            Console.WriteLine($"Answer the {QUESTIONS_TO_ASK} questions.");
            Console.WriteLine($"The current high score is {highScore}");
            Console.WriteLine("All answers will be one word.  Answers will not include numbers.");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
        }
        public static void GameLogicLoop()
        {
            Random random = new Random();

            while (questionsAsked++ < QUESTIONS_TO_ASK)//Will be incremented after the condition is tested
            {//Essentially turning a for loop into a while loop.
                Console.Clear();//Will clear the console after every question
                Console.WriteLine($"Question {questionsAsked}/{QUESTIONS_TO_ASK}");
                int questionNum = questionsAvailable[random.Next(0, questionsAvailable.Count)];
                if(AskQuestion(questionNum))
                {
                    score++;
                }
                questionsAvailable.Remove(questionNum);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine($"You got {score} out of {QUESTIONS_TO_ASK} questions correct!");
            if(score > highScore)
            {
                Console.WriteLine("You set a new high score!");
                File.WriteAllText(HIGH_SCORE_FILE, score.ToString());
            }
            if(score == 0) 
            {
                Console.WriteLine("idiot.");
            }
        }
        public static bool AskQuestion(int questionIndex)
        {
            Console.WriteLine(questions[questionIndex]);
            Console.Write("Your answer: ");
            String answer = Console.ReadLine();

            if (answer.Equals(answers[questionIndex], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct!");
                return true;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was {answers[questionIndex]}.");
                return false;
            }
        }
    }
}
