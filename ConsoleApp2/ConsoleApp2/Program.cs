using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Console.WriteLine("--- Задача 1: Квадрат разности max и min ---");
                double task1Result = FileTasks.CalculateMaxMinDiffSquare("numbers.txt");
                Console.WriteLine("Результат: {0}", task1Result);

                Console.WriteLine("\n--- Задача 2: Сумма нечетных элементов ---");
                int task2Result = FileTasks.SumOddElements("numbers.txt");
                Console.WriteLine("Сумма: {0}", task2Result);

                Console.WriteLine("\n--- Задача 3: Последние символы строк ---");
                FileTasks.ExtractLastCharacters("text.txt", "output.txt");
                Console.WriteLine("Файл 'output.txt' сформирован.");

                Console.WriteLine("\n--- Задача 4: Количество удвоенных нечетных чисел ---");
                int task4Result = FileTasks.CountDoubleOdds("numbers.txt");
                Console.WriteLine("Количество: {0}", task4Result);

                Console.WriteLine("\n--- Задача 5: Самая дешёвая игрушка ---");
                string toyFile = "toys_data.xml";
                FileTasks.CreateInitialFile(toyFile);
                string result = FileTasks.GetCheapestToyName(toyFile);
    
                Console.WriteLine("Результат: " + result);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при тестировании: " + ex.Message);
            }
        }
    }
}