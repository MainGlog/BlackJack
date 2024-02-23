namespace OOPTriviaGame
{
    public class Question
    {
        public String question;
        public String answer;
        public bool AskQuestion()
        {
            Console.WriteLine(question);
            Console.Write("Answer: ");
            String answer = Console.ReadLine();
            //answer in method will refer to the local, variables always refer to the ones closest to it
            if(answer.Equals(this.answer)) //this means this instance's variable. Only necessary when ambiguity is present
            {
                Console.WriteLine("Correct!");
                return true;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was: {this.answer}");
                Console.WriteLine("");
                return false;
            }
            //View -> other windows -> document outline shows variables and methods

        }
    }
}
