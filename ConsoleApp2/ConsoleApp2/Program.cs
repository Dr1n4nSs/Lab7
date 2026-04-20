using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            FileTasks.ExtractLastCharacters("text.txt", "tebe2/zaetylaby/potomychtonetproverki");
            try
            {
                Console.WriteLine("Задача 1:");
                double task1Result = FileTasks.DiffSquare("numbers.txt");
                Console.WriteLine("Результат: {0}", task1Result);

                Console.WriteLine("\nЗадача 2:");
                int task2Result = FileTasks.SumOddElements("numbers.txt");
                Console.WriteLine("Сумма: {0}", task2Result);

                Console.WriteLine("\nЗадача 3:");
                FileTasks.ExtractLastCharacters("text.txt", "output.txt");
                Console.WriteLine("Файл 'output.txt' сформирован.");

                Console.WriteLine("\nЗадача 4:");
                string fileName = "numbers.bin";
                FileTasks.CreateBinaryNumbersFile(fileName);
                FileTasks.PrintBinaryNumbers(fileName);
                int result = FileTasks.CountDoubleOddsBinary(fileName);
                Console.WriteLine("\nКоличество удвоенных нечетных чисел: {0}", result);

                Console.WriteLine("\nЗадача 5:");
                string toyFile = "toys.bin";
                FileTasks.CreateInitialToyFile(toyFile);
                FileTasks.PrintToyFileContents(toyFile);
                string cheapest = FileTasks.GetCheapestToy(toyFile);
                Console.WriteLine("\nСамая дешевая игрушка: " + cheapest);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
