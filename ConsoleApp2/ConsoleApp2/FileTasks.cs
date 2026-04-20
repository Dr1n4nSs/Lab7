namespace ConsoleApp2;

using System;
using System.Xml.Serialization;
public static class FileTasks
{
    public static double CalculateMaxMinDiffSquare(string filePath)
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
    
    public static int CountDoubleOdds(string filePath)
    {
        ValidateFile(filePath);
        string[] lines = File.ReadAllLines(filePath);
        int count = 0;

        foreach (string line in lines)
        {
            if (int.TryParse(line, out int num))
            {
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
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int MinAge
        {
            get { return _minAge; }
            set { _minAge = value; }
        }

        public int MaxAge
        {
            get { return _maxAge; }
            set { _maxAge = value; }
        }
    }

    public static void CreateInitialFile(string filePath)
        {
            Toy[] toys = new Toy[3];

            toys[0].Name = "Конструктор";
            toys[0].Price = 2500.0;
            toys[0].MinAge = 5;
            toys[0].MaxAge = 12;

            toys[1].Name = "Мыльные пузыри";
            toys[1].Price = 50.0;
            toys[1].MinAge = 2;
            toys[1].MaxAge = 5;

            toys[2].Name = "Кукла";
            toys[2].Price = 1200.0;
            toys[2].MinAge = 3;
            toys[2].MaxAge = 10;
            
            XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
            
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, toys);
            }
        }
    
        public static string GetCheapestToyName(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return "Файл не найден";
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
            Toy[] toys;

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                toys = (Toy[])serializer.Deserialize(fs);
            }

            if (toys == null || toys.Length == 0)
            {
                return "Список пуст";
            }
            
            double minPrice = double.MaxValue;
            string cheapestName = "";

            for (int i = 0; i < toys.Length; i++)
            {
                if (toys[i].Price < minPrice)
                {
                    minPrice = toys[i].Price;
                    cheapestName = toys[i].Name;
                }
            }

            return cheapestName;
        }

    private static void ValidateFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Файл не найден: " + path);
        }
    }
}
