using System;
using System.Collections.Generic;
namespace ConsoleApp20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1:");
            FileTasks.GenerateTask1File("numbers1.txt", 10);
            double res1 = FileTasks.DiffSquare("numbers1.txt");
            FileTasks.PrintTaskFile("numbers1.txt");
            Console.WriteLine("Результат задачи 1: " + res1);

            Console.WriteLine("\nЗадача 2:");
            FileTasks.GenerateTask2File("numbers2.txt", 5, 3);
            int res2 = FileTasks.SumOddElements("numbers2.txt");
            FileTasks.PrintTaskFile("numbers2.txt");
            Console.WriteLine("Результат задачи 2: " + res2);

            Console.WriteLine("\nЗадача 3:");
            FileTasks.ExtractLastCharacters("text.txt", "output.txt");
            Console.WriteLine("Файл 'output.txt' сформирован.");
            FileTasks.PrintTaskFile("output.txt");

            Console.WriteLine("\nЗадача 4:");
            string binFile = "data.bin";
            FileTasks.GenerateBinaryRandomFile(binFile, 15);
            FileTasks.PrintBinaryNumbers(binFile);
            int res4 = FileTasks.CountDoubleOddsBinary(binFile);
            Console.WriteLine("Количество удвоенных нечетных: " + res4);

            Console.WriteLine("\nЗадача 5:");
            string toyFile = "toys.bin";
            FileTasks.CreateToyFile(toyFile);
            FileTasks.PrintToyFile(toyFile);
            string cheapest = FileTasks.GetCheapestToy(toyFile);
            Console.WriteLine("\nСамая дешевая игрушка: " + cheapest);
            
            List<double> list1 = new List<double> { 1, 1, 1, 1, 2, 3, 2, 3, 5, 5, 5, 1, 1, 4};
            List<string> list2 = new List<string> { "asd", "asd", "asd", "a", "a", "ddd"};
            Console.WriteLine("\nЗадача 6: ");
            OtherTasks.RemoveDuplicates(list1);
            OtherTasks.RemoveDuplicates(list2);
            
            Console.WriteLine("\nЗадача 7: ");
            LinkedList<double> linked1 = OtherTasks.BuildDouble(list1);
            LinkedList<string> linked2 = OtherTasks.BuildDouble(list2);
            OtherTasks.PrintLinkedList(linked1);
            OtherTasks.PrintLinkedList(linked2);
            
            Console.WriteLine("\nЗадача 8:");
            string[] allE;
            List<string[]> choices;
            OtherTasks.GenerateElectivesData(out allE, out choices);
            Console.WriteLine("Факультативы");
            Console.WriteLine(string.Join(", ", allE));
            Console.WriteLine("\nВыбор студентов");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine("Студент {0}: {1}", i + 1, string.Join(", ", choices[i]));
            }
            Console.WriteLine();
            OtherTasks.Electives(allE, choices);
            
            Console.WriteLine("\nЗадача 9:");
            OtherTasks.ProcessOddWordsChars("data.txt");
            
            Console.WriteLine("\nЗадача 10:");
            string gasFile = "gas_monitoring.txt";
            OtherTasks.GenerateGasDataFile(gasFile);
            OtherTasks.PrintGasFile(gasFile);       
            OtherTasks.SolveGasTask(gasFile);
        }
    }
}
