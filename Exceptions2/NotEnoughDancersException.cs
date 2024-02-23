namespace Exceptions2
{
    public class NotEnoughDancersException : Exception
    {
        public NotEnoughDancersException(String message)
            : base (message) //We are feeding our message into the constructor for Exception
        { 
                    
        }
    }

    public class NotEnoughMaleDancersException : NotEnoughDancersException
    {
        public NotEnoughMaleDancersException (String message)
            : base (message) 
        { 
        
        }
    }

    public class NotEnoughFemaleDancersException : NotEnoughDancersException
    {
        public NotEnoughFemaleDancersException(String message)
            : base(message)
        {

        }
    }

}
