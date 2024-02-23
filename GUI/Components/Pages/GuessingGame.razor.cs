using Microsoft.AspNetCore.Components;

namespace GUI.Components.Pages
{
    public partial class GuessingGame : ComponentBase
    {
        private const int MAX_NUMBER = 100;
        private const int MAX_GUESSES = 5;

        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        //This will never get constructed by you
        //This will be injected into the class 
        private int RandomNumber {  get; set; }
        private int UsersGuess { get; set; } = 1;
        private int GuessesLeft { get; set; } = MAX_GUESSES; //Initializes backing field
        private String ErrorMessage { get; set; } = String.Empty; //Set so it will not be null unless set
        private List<String> Messages { get; set; } = [];
        private String GameStateMessage { get; set; } = String.Empty;
        private bool gameWon = false; //Not a property because it will not be used by the razor file

        private bool InputDisabled => GuessesLeft == 0 || gameWon ; //True if guesses left= 0 or the game is won, false otherwise
       
        protected override void OnInitialized()
        {
            base.OnInitialized(); //Component initialization, can think of as constructor
            RandomNumber = new Random().Next(1, MAX_NUMBER + 1); //Anonymous random object
            Console.WriteLine(RandomNumber); //Cheat
        }
        private void Guess()
        {
            //Console.WriteLine() will only be useful for debugging when working with GUIs
            if (UsersGuess < 1 || UsersGuess > MAX_NUMBER)
            {
                ErrorMessage = $"Please enter a number between 1 and {MAX_NUMBER}"; //Properties are still being used here, just implicitly.
                return; //Returning here takes the execution back to the app.Run(), which is essentially a big while true loop that everything goes in
                //Also re-draws page since user has interacted
            }

            ErrorMessage = String.Empty;

            if (UsersGuess < RandomNumber)
            {
                Messages.Add($"Your guess of {UsersGuess} is too low");
                GuessesLeft--;
            }
            else if(UsersGuess > RandomNumber) 
            {
                Messages.Add($"Your guess of {UsersGuess} is too high");
                GuessesLeft--;

            }
            else //Correct Guess
            {
                GameStateMessage = $"Congratulations! You guessed the number {RandomNumber}";
                gameWon = true;
                return; //Necessary for if user guesses correctly on last guess
            }

            if (GuessesLeft == 0)
            {
                GameStateMessage = $"Sorry, you didn't guess the number {RandomNumber}";
            }

        }

        private void Reset()
        {
            RandomNumber = new Random().Next(1, MAX_NUMBER + 1);
            UsersGuess = 1;
            GuessesLeft = MAX_GUESSES;
            ErrorMessage = String.Empty;
            GameStateMessage = String.Empty;
            gameWon = false;
            Messages.Clear();
        }

        private void GoHome()
        {
            //? guards null, if null it will skip instruction
            //! says it will never be null
            NavigationManager?.NavigateTo("/");
        }
    }
}
