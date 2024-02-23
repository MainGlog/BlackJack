namespace OOPTriviaGame
{
    public class Game
    {
        private List<Question> questions = [];

        public const int QUESTIONS_TO_ASK = 10;
        public int score = 0;
        private int questionsAsked = 0;
        //constant variables are static by default, static const doesn't work. Const already makes it belong to the class
        public void SetQuestions(List<Question> questions) //Interfacing with the questions is public, but changing it is private
        {
            //Interface 
            this.questions = questions;
        }
        public int PlayGame()
        {
            Random rand = new Random();
            while(questionsAsked > QUESTIONS_TO_ASK)
            {
                Question question = questions[rand.Next(questions.Count)]; //When the lower bound is excluded from the rand, it defaults to 0.

                Console.WriteLine($"Question {questionsAsked + 1}:");                
                if(question.AskQuestion())
                {
                    score++;
                }
                
                questions.Remove(question); 
                questionsAsked++;
            
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            return score;
        }
    }
}
