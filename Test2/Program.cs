namespace Test2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Parameterized Constructor
            Student John = new Student("John", 18);

            //Default Constructor
            Student Johnny = new Student();
            Johnny.SetName("Johnny");
            Johnny.SetAge(18);
        }

        class Person //Quiz 3 Notes
        {
            public int Id { get; private set; } //only members of the class can set the ID
            private static Person instance; 
            public String FirstName { get; private set; }
            public String LastName { get; private set; }
            public String FullName => FirstName + " " + LastName; //Property without setter or backing field
            private Person() { } //Would be used for singleton approach
            public static Person GetInstance()
            {
                instance ??= new Person(); //if instance is null assign instance to a new person
                return instance;
            }


        }
    }
}
