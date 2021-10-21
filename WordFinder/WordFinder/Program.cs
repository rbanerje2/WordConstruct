using System;
using System.Linq;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var obj = FileAccess.GetFileAccess();

                var inpuFilePath = GetInputFilePath();

                var allItems = obj.GetAllItems(inpuFilePath);

                var iterator = new Iterator();
                var allCompundItems = iterator.GetAllCompoundWords(allItems);

                Console.WriteLine("Longest Word:     " + allCompundItems.First());
                Console.WriteLine("2nd Longest Word: " + allCompundItems.Skip(1).First());
                Console.WriteLine("words that can be constructed as an output: " + allCompundItems.Count);
                Console.WriteLine("Press ENTER to exit...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetInputFilePath()
        {
            FileAccess fileAccess = FileAccess.GetFileAccess();
            Console.WriteLine("Input File Path (Press enter to use the deualt file _NET_Test_00.txt):");
            var inpuFilePath = Console.ReadLine();
            if (string.IsNullOrEmpty(inpuFilePath))
                inpuFilePath = @"_NET_Test_00.txt";

            while (!fileAccess.CheckFileExists(inpuFilePath))
            {
                Console.WriteLine("Input File does not exists in the path mentioned, please check and enter the correct path (Press ENTER key to use the deualt file _NET_Test_00.txt):");
                inpuFilePath = Console.ReadLine();
                if (string.IsNullOrEmpty(inpuFilePath))
                    inpuFilePath = @"_NET_Test_00.txt";
            }

            return inpuFilePath;
        }


    }
}

