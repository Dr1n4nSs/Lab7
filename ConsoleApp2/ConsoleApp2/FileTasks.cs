using System;
using System.IO;
using System.Xml.Serialization;
public static class FileTasks
{
    private static  Random _random;
    
    static FileTasks()
    {
        _random = new Random();
    }
    
    public static void GenerateTask1File(string filePath, int count)
    {
        if (ValidateFile(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(_random.Next(-100, 101));
                }
            }
        }
    }
    
    public static void GenerateTask2File(string filePath, int rows, int cols)
    {
        if (ValidateFile(filePath))
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                for (int i = 0; i < rows; i++)
                {
                    string line = "";
                    for (int j = 0; j < cols; j++)
                    {
                        line += _random.Next(1, 101) + " ";
                    }

                    writer.WriteLine(line.Trim());
                }
            }
        }
    }
    
    public static void GenerateBinaryRandomFile(string filePath, int count)
    {
        if (ValidateFile(filePath))
        {
            using (BinaryWriter writer = new BinaryWriter
                       (File.Open(filePath, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.Write(_random.Next(1, 51));
                }
            }
        }
    }
    public static double DiffSquare(string filePath)
    {
        if (ValidateFile(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                return 0;
            }

            double max = double.MinValue;
            double min = double.MaxValue;
            bool found = false;

            foreach (string line in lines)
            {
                if (double.TryParse(line, out double num))
                {
                    if (num > max)
                    {
                        max = num;
                    }

                    if (num < min)
                    {
                        min = num;
                    }
                    found = true;
                }
            }
            return found ? (max - min) * (max - min) : 0;
        }
        return 0;
    }

    public static int SumOddElements(string filePath)
    {
        if (ValidateFile(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int sum = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split
                    (new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int num))
                    {
                        if (num % 2 != 0)
                        {
                            sum += num;
                        }
                    }
                }
            }
            return sum;
        }
        return 0;
    }

    public static void ExtractLastCharacters(string inputP, string outputP)
    {
        if (ValidateFile(inputP))
        {
            if (ValidateFile(outputP))
            {
                string[] lines = File.ReadAllLines(inputP);
                string[] results = new string[lines.Length];
                string currentLine;
                for (int i = 0; i < lines.Length; i++)
                {
                    currentLine = lines[i];
                    results[i] = currentLine.Length > 0 ? 
                        currentLine[currentLine.Length - 1].ToString() : "";
                }
                File.WriteAllLines(outputP, results);
            }
        }
    }
    
    public static void PrintBinaryNumbers(string filePath)
    {
        if (ValidateFile(filePath))
        {
            Console.Write("Содержимое файла: ");
            using (BinaryReader reader = new BinaryReader
                       (File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int num = reader.ReadInt32();
                    Console.Write(num + " ");
                }
            }
            Console.WriteLine();
        }
    }
        
    public static int CountDoubleOddsBinary(string filePath)
    {
        if (ValidateFile(filePath))
        {
            int count = 0;
            int num = 0;
            using (BinaryReader reader = new BinaryReader
                       (File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    num = reader.ReadInt32();
                    if (num % 2 == 0 && (num / 2) % 2 != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        return 0;
    }
    
    public static void PrintTaskFile(string filePath)
    {
        if (ValidateFile(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        
    }
    
    public static void CreateToyFile(string filePath)
    {
        Toy[] toys = new Toy[3];
        toys[0] = new Toy ("Машинка", 1500, 3, 7 );
        toys[1] = new Toy ( "Кубики", 450, 1, 4 );
        toys[2] = new Toy ( "Пазл", 800, 5, 10 );

        XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, toys);
        }
    }
    
    public static void PrintToyFile(string filePath)
    {
        FileTasks.ValidateFile(filePath);
        XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
        Toy[] toys;
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            toys = (Toy[])serializer.Deserialize(fs);
        }

        Console.WriteLine("\nСодержимое бинарного файла");
        foreach (var toy in toys)
        {
            Console.WriteLine("Игрушка: {0}, Цена: {1} руб, Возраст: {2}-{3}", 
                toy.Name, toy.Price, toy.MinAge, toy.MaxAge);
        }
    }

    public static string GetCheapestToy(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
        Toy[] toys;
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            toys = (Toy[])serializer.Deserialize(fs);
        }

        double min = double.MaxValue;
        string name = "";
        foreach (var t in toys)
        {
            if (t.Price < min)
            {
                min = t.Price; name = t.Name;
            }
        }
        return name;
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
