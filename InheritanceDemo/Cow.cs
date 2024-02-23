namespace InheritanceDemo
{
    public class Cow : Animal
    {
        public bool IsDairyCow { get; private set; }
        public Cow(String name, int age, bool isDairyCow) 
            : base (name, age)
        {
            IsDairyCow = isDairyCow;
        }

        public override void MakeSound() => Console.WriteLine("Moo");

    }
}
