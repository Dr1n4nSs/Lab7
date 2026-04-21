using System.Xml.Serialization;
namespace ConsoleApp7;

public class Toy
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
}