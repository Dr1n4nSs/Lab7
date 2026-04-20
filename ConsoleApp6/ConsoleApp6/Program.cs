using System;
using System.Collections.Generic;
using System.IO;

namespace UnifiedProject
{
    class Program
    {
        static void Main()
        {
            // Тест Задача 1 и 2
            List<int> list1 = new List<int> { 1, 1, 2, 2, 2, 3, 4, 4 };
            Console.WriteLine("Задача 1: ");
            Tasks.RemoveDuplicates(list1);
            
            Console.WriteLine("Задача 2: Создание двунаправленного списка...");
            LinkedList<int> linked = Tasks.BuildDouble(list1);
            
            string[] all = { "Йога", "Теннис", "Хор" };
            List<string[]> students = new List<string[]> {
                new string[] { "Йога", "Хор" },
                new string[] { "Йога" }
            };
            Console.WriteLine("\nЗадача 3:");
            Tasks.Electives(all, students);

            // Тест Задача 4 (нужен файл "data.txt")
            Console.WriteLine("\nЗадача 4:");
            Tasks.ProcessOddWordsChars("data.txt");

            // Тест Задача 5
            Console.WriteLine("\nЗадача 5:");
            Tasks.SolveGasTask();
        }
    }
}