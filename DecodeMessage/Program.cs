using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DecodeMessage
{
    public class Program
    {
        private const String FILE_PATH = "File.txt";
        private static void Main()
        {
            Console.WriteLine(GetMessage());
            Console.WriteLine(CreateStaircase([1, 2, 3, 4]));
        }
        private static bool CreateStaircase(List<int> nums)
        {  
            while (nums.Count > 0) 
            {
                int step = 1;
                List<int> subsets = new List<int>();
                if (nums.Count >= step)
                {
                    subsets.AddRange(nums[0..(step - 1)]);
                    nums = nums[step..];
                    step++;
                }
                else return false;
            }
            return true;
        }
        private static String GetMessage()
        {
            SortedDictionary<int, String> contents = new SortedDictionary<int, String>();

            String[] temp = File.ReadAllLines(FILE_PATH);

            foreach (String line in temp)
            {
                if (String.IsNullOrWhiteSpace(line)) continue;
                String[] s = line.Split(' ', 2);
                contents.Add(int.Parse(s[0]), s[1]);
            }

            List<String> strings = new List<String>();
            int numberOfLayers = (int)Math.Floor((Math.Sqrt(8 * contents.Count + 1) - 1) / 2);
            int layerNumber = 0;
            {
                for (int i = 0; i < contents.Count; i++)
                {
                    for (int k = i; k <= layerNumber + i; k++)
                    {
                        if (k == layerNumber + i)
                        { 
                            strings.Add(contents[k + 1]);
                        }
                    }
                    i += layerNumber;
                    layerNumber++;
                }
            }
            return String.Join(' ', strings);
        }
    }
}
