using System.IO;
using System;
using System.Collections.Generic;

public class OtherTasks
{
    private static  Random rnd;
    static OtherTasks()
    {
        rnd = new Random();
    }
    public static void RemoveDuplicates<T>(List<T> list)
    {
        if (list == null)
        {
            Console.Write("Список пуст");
            return;
        }
            
        Console.Write("Список до: ");
        PrintList(list);
            
        for (int i = list.Count - 1; i > 0; i--)
        {
            if (list[i].Equals(list[i - 1]))
            {
                list.RemoveAt(i);
            }
        }
        Console.Write("Список после: ");
        PrintList(list);
    }
    
    public static LinkedList<T> BuildDouble<T>(List<T> singleList)
    {
        LinkedList<T> doubleList = new LinkedList<T>();
        if (singleList == null)
        {
            Console.Write("Список пуст");
            return doubleList;
        }

        foreach (T item in singleList)
        {
            doubleList.AddLast(item);
        }
        return doubleList;
    }
    
    public static void Electives(string[] allE, List<string[]> choices)
    {
        if (allE == null || choices == null || choices.Count == 0)
        {
            return;
        }
        HashSet<string> allSet = new HashSet<string>(allE);
        HashSet<string> attendAll = new HashSet<string>(choices[0]);
        for (int i = 1; i < choices.Count; i++)
        {
            attendAll.IntersectWith(new HashSet<string>(choices[i]));
        }
            
        HashSet<string> attendAtLeastOne = new HashSet<string>();
        foreach (string[] choice in choices)
        {
            attendAtLeastOne.UnionWith(new HashSet<string>(choice));
        }
            
        HashSet<string> attendNone = new HashSet<string>(allSet);
        attendNone.ExceptWith(attendAtLeastOne);

        PrintSet("Ходят все студенты: ", attendAll);
        PrintSet("Ходит хотя бы один: ", attendAtLeastOne);
        PrintSet("Не ходит никто: ", attendNone);
    }
    
    public static void GenerateElectivesData
        (out string[] allElectives, out List<string[]> studentChoices)
    {
        allElectives = new string[] 
        { 
            "Высшая математика", "Физика", "Программирование C#", 
            "Базы данных", "История", "Психология", "Философия" 
        };

        studentChoices = new List<string[]>();
        
        int studentsCount = rnd.Next(3, 6);

        for (int i = 0; i < studentsCount; i++)
        {
            int electivesCount = rnd.Next(1, 5);
            HashSet<string> choice = new HashSet<string>();

            while (choice.Count < electivesCount)
            {
                string randomSubject = allElectives
                    [rnd.Next(allElectives.Length)];
                choice.Add(randomSubject);
            }
            string[] choiceArray = new string[choice.Count];
            choice.CopyTo(choiceArray);
            studentChoices.Add(choiceArray);
        }
    }
    
    public static void ProcessOddWordsChars(string filePath)
    {
        if (ValidateFile(filePath))
        {
            string text = File.ReadAllText(filePath);
            char[] separators = { ' ', '\r', '\n', '\t' };
            string[] words = text.Split
                (separators, StringSplitOptions.RemoveEmptyEntries);
            HashSet<char> uniqueChars = new HashSet<char>();

            for (int i = 0; i < words.Length; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    foreach (char c in words[i].ToLower())
                    {
                        if (char.IsLetter(c))
                        {
                            uniqueChars.Add(c);
                        }
                    }
                }
            }

            List<char> sortedChars = new List<char>(uniqueChars);
            sortedChars.Sort();

            Console.Write("Символы из нечетных слов: ");
            foreach (char c in sortedChars) Console.Write(c + " ");
            Console.WriteLine();
        }
        return;
    }
    public static void GenerateGasDataFile(string filePath)
    {
        if (ValidateFile(filePath))
        {
            string[] companies = { "Синойл", "Газпром", "Лукойл", "Роснефть" };
            string[] streets = { "Цветочная", "Ленина", "Мира", "Новая" };
            int[] brands = { 92, 95, 98 };
            int n = 10; 
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(n); 
                for (int i = 0; i < n; i++)
                {
                    string comp = companies[rnd.Next(companies.Length)];
                    string street = streets[rnd.Next(streets.Length)];
                    int brand = brands[rnd.Next(brands.Length)];
                    int price = rnd.Next(1000, 3001);
            
                    sw.WriteLine
                        ("{0} {1} {2} {3}", comp, street, brand, price);
                }
            }
            Console.WriteLine("Файл АЗС {0} сгенерирован.", filePath);
        }
    }
    
    public static void SolveGasTask(string filePath)
    {
        if (ValidateFile(filePath))
        {
            string[] allLines = File.ReadAllLines(filePath);
            if (allLines.Length == 0)
            {
                return;
            }

            if (!int.TryParse(allLines[0], out int n))
            {
                return;
            }

            Dictionary<int, List<int>> gasD = new Dictionary<int, List<int>>();
            gasD.Add(92, new List<int>());
            gasD.Add(95, new List<int>());
            gasD.Add(98, new List<int>());

            for (int i = 1; i <= n && i < allLines.Length; i++)
            {
                string line = allLines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split
                    (new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 4)
                {
                    if (int.TryParse(parts[2], out int brand) && 
                        int.TryParse(parts[3], out int price))
                    {
                        if (gasD.ContainsKey(brand))
                        {
                            gasD[brand].Add(price);
                        }
                    }
                }
            }

            int[] brands = { 92, 95, 98 };
            int[] c = new int[3];

            for (int i = 0; i < brands.Length; i++)
            {
                List<int> prices = gasD[brands[i]];
                if (prices.Count == 0)
                {
                    c[i] = 0;
                    continue;
                }

                int minPrice = int.MaxValue;
                foreach (int p in prices)
                    if (p < minPrice)
                        minPrice = p;

                int minCount = 0;
                foreach (int p in prices)
                    if (p == minPrice)
                    {
                        minCount++;
                    }
                c[i] = minCount;
            }

            Console.WriteLine
                ("Результат (92 95 98): {0} {1} {2}", c[0], c[1], c[2]);
        }
    }
    
    public static void PrintList<T>(List<T> list)
    {
        foreach (T item in list) Console.Write(item + " ");
        Console.WriteLine();
    }
    public static void PrintLinkedList<T>(LinkedList<T> list)
    {
        foreach (T item in list) Console.Write(item + " ");
        Console.WriteLine();
    }
    
    public static void PrintSet(string msg, HashSet<string> set)
    {
        Console.Write(msg);
        foreach (string s in set) Console.Write(s + " ");
        Console.WriteLine();
    }
    
    public static void PrintGasFile(string filePath)
    {
        if (ValidateFile(filePath))
        {
            Console.WriteLine("Содержимое файла");
            Console.WriteLine(File.ReadAllText(filePath));
        }
    }
    
    public static bool ValidateFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("По такому пути файл не найден");
            return false;
        }
        return true;
    }
}
