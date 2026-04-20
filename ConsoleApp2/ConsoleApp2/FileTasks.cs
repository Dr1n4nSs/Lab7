namespace ConsoleApp7;

using System;
using System.Xml.Serialization;
public static class FileTasks
{
    public static double DiffSquare(string filePath)
    {
        ValidateFile(filePath);
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
                if (num > max) max = num;
                if (num < min) min = num;
                found = true;
            }
        }

        if (!found)
        {
            return 0;
        }
        else
        {
            double diff = max - min;
            return diff * diff;
        }
    }
    
    public static int SumOddElements(string filePath)
    {
        ValidateFile(filePath);
        string[] lines = File.ReadAllLines(filePath);
        int sum = 0;

        foreach (string line in lines)
        {
            if (int.TryParse(line, out int num))
            {
                if (num % 2 != 0)
                {
                    sum += num;
                }
            }
        }
        return sum;
    }

    public static void ExtractLastCharacters(string inputP, string outputP)
    {
        ValidateFile(inputP);
        string[] lines = File.ReadAllLines(inputP);
        string[] results = new string[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string currentLine = lines[i];
            if (currentLine.Length > 0)
            {
                results[i] = currentLine[currentLine.Length - 1].ToString();
            }
            else
            {
                results[i] = "";
            }
        }
        File.WriteAllLines(outputP, results);
    }
    
    public static void CreateBinaryNumbersFile(string filePath)
        {
            int[] numbers = { 6, 10, 8, 7, 14, 20, 22 };
            using (BinaryWriter writer = new BinaryWriter
                       (File.Open(filePath, FileMode.Create)))
            {
                foreach (int num in numbers)
                {
                    writer.Write(num);
                }
            }
        }
    
        public static void PrintBinaryNumbers(string filePath)
        {
            ValidateFile(filePath);
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
        
        public static int CountDoubleOddsBinary(string filePath)
        {
            ValidateFile(filePath);
            int count = 0;
            using (BinaryReader reader = new BinaryReader
                       (File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int num = reader.ReadInt32();
                    if (num % 2 == 0 && (num / 2) % 2 != 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    
    public struct Toy
    {
        private string _name;
        private double _price;
        private int _minAge;
        private int _maxAge;
        
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public int MinAge
        {
            get
            {
                return _minAge;
            }
            set
            {
                _minAge = value;
            }
        }

        public int MaxAge
        {
            get
            {
                return _maxAge;
            }
            set
            {
                _maxAge = value;
            }
        }
    }

    public static void CreateInitialToyFile(string filePath)
    {
        Toy[] toys = new Toy[3];
        toys[0] = new Toy { Name = "Машинка", Price = 1500, MinAge = 3, MaxAge = 7 };
        toys[1] = new Toy { Name = "Кубики", Price = 450, MinAge = 1, MaxAge = 4 };
        toys[2] = new Toy { Name = "Пазл", Price = 800, MinAge = 5, MaxAge = 10 };

        XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, toys);
        }
    }
    
    public static void PrintToyFileContents(string filePath)
    {
        ValidateFile(filePath);
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

    private static void ValidateFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Файл не найден: " + path);
        }
    }
}
