using System.Diagnostics;

namespace FileOperations
{
    public class Program
    {
        public const String FILE_NAME = "data.txt";
        public static void Main()
        {
            CreateFile();
            WriteToFile("Hello, world!");
            AppendToFile(Environment.NewLine + "Good afternoon.");
            String text = ReadFromFile();
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Write(Environment.NewLine);

            String[] lines = ReadAllLines();
            foreach(String line in lines)
            {
                Console.WriteLine(line);
            }
            //Pauses program to debug
            Debugger.Break(); 
            File.Delete(FILE_NAME);
        }
        public static void CreateFile()
        {
            //Created in same folder as exe (right click cs, open in location

            if(File.Exists(FILE_NAME)) 
            {
                File.Delete(FILE_NAME);
            }
            File.Create(FILE_NAME).Close();
            //Returns a file stream, opening it in this method which is why .Close() is required
        }
        public static void WriteToFile(String text)
        {
            //Opens the file, writes to it, and closes it
            File.WriteAllText(FILE_NAME, text);
        }
        public static void WriteToFile(List<String> text)
        {
            //Overwrites
            File.WriteAllLines(FILE_NAME, text);
        }
        public static void AppendToFile(String text)
        {
            File.AppendAllText(FILE_NAME, text);
        }
        public static void AppendToFile(List <String> text)
        {
            File.AppendAllLines(FILE_NAME, text);
        }
        public static String ReadFromFile()
        {
            //Does not remove new line characters, jams all into one string
            return File.ReadAllText(FILE_NAME);
        }
        public static String[] ReadAllLines()
        { 
            return File.ReadAllLines(FILE_NAME);
        }
    }
}
