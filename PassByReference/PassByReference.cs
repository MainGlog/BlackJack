namespace PassByReference
{
    public class PassByReference
    {
        public static void Main()
        {
            int x = 0;
            PassInt(x);
            Console.WriteLine(x);

            PassInt(ref x);
            Console.WriteLine(x);

            int y = 1;
            Swap(x, y);
            Console.WriteLine($"x: {x}, y: {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"x: {x}, y: {y}");

            int[] array = Enumerable.Range(0,5).ToArray(); //Enumerable.Range returns a different value type, ToArray changes it to an array
            
            Console.WriteLine(String.Join(", ", array));
            Console.WriteLine(String.Empty);
            
            ModifyArray(array);
            Console.WriteLine(String.Join(", ", array));
            
            array = ModifyArrayFun(array);
            Console.WriteLine(String.Join(", ", array));

            String s = "Hello ";
            PassString(s);
            Console.WriteLine(s);
        }
        public static void PassInt(int x)
        {
            x = 5;
        }
        public static void PassInt(ref int x) //ref is C# specific, it's a reference to an int's address.
        //ref is possible in C and C++, but as &
        //This could be used to modify multiple variables from different methods, since you can only return one variable
        {
            x = 5;
        }
        public static void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        public static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static void ModifyArray(int[] array, int modAmount = 2)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] += modAmount;
            }
        }
        
        public static int[]ModifyArrayFun(int[] array, int modAmount = 2)
        /*
        ToArray() makes a copy of an array
        int[] array is a memory address(0x10 for example)
        ToArray is a new array (0x20)
        in main, int[]array = ... (0x10)
        so it can't be changed by setting it equal to another value.
        It's still pointing to the same address
                    array = array.Select(x => x + modAmount).ToArray();
            this does nothing^
         */
        {
            return array.Select(x => x + modAmount).ToArray();
        }
        public static void PassString(String s)
        {
            //Doesn't work, s is pointing to a memory location and s+= creates a new string since strings are immutable
            s += "world";
        }
    }
}
