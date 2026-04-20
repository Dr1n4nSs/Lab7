namespace UnifiedProject;

public static class Tasks
    {
        public static void RemoveDuplicates(List<int> list)
        {
            if (list == null || list.Count < 2)
            {
                return;
            }
            
            Console.Write("Список ДО: ");
            PrintIntList(list);
            
            for (int i = list.Count - 1; i > 0; i--)
            {
                if (list[i] == list[i - 1])
                {
                    list.RemoveAt(i);
                }
            }
            
            Console.Write("Список ПОСЛЕ: ");
            PrintIntList(list);
        }
        
        public static LinkedList<int> BuildDouble(List<int> singleList)
        {
            LinkedList<int> doubleList = new LinkedList<int>();
            if (singleList == null)
            {
                return doubleList;
            }

            foreach (int item in singleList)
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
        
        public static void ProcessOddWordsChars(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл для задачи 4 не найден.");
                return;
            }

            string text = File.ReadAllText(filePath);
            char[] separators = { ' ', '\r', '\n', '\t' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            HashSet<char> uniqueChars = new HashSet<char>();

            for (int i = 0; i < words.Length; i++)
            {
                if ((i + 1) % 2 != 0) 
                {
                    foreach (char c in words[i].ToLower())
                    {
                        if (char.IsLetter(c)) uniqueChars.Add(c);
                    }
                }
            }
            List<char> sortedChars = new List<char>(uniqueChars);
            sortedChars.Sort();
            
            Console.Write("Символы из нечетных слов: ");
            foreach (char c in sortedChars) Console.Write(c + " ");
            Console.WriteLine();
        }
        
        public static void SolveGasTask()
        {
            int n = ReadInt("Введите количество данных АЗС (N): ");
            Dictionary<int, List<int>> gasD = new Dictionary<int, List<int>>();
            
            gasD.Add(92, new List<int>());
            gasD.Add(95, new List<int>());
            gasD.Add(98, new List<int>());

            Console.WriteLine("Введите <Компания> <Улица> <Марка> <Цена>:");
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) { i--; continue; }

                string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 4)
                {
                    if (int.TryParse(parts[2], out int brand))
                    {
                        if(int.TryParse(parts[3], out int price))
                        {
                            if (gasD.ContainsKey(brand)) 
                            {
                                gasD[brand].Add(price);
                            }
                        }
                    }
                }
            }

            int[] brands = { 92, 95, 98 };
            int[] counts = new int[3];

            for (int i = 0; i < brands.Length; i++)
            {
                List<int> prices = gasD[brands[i]];
                if (prices.Count == 0)
                {
                    counts[i] = 0;
                    continue;
                }

                int minPrice = int.MaxValue;
                foreach (int p in prices) if (p < minPrice) minPrice = p;

                int minCount = 0;
                foreach (int p in prices) if (p == minPrice) minCount++;
                counts[i] = minCount;
            }

            Console.WriteLine("\nРезультат:");
            Console.WriteLine("{0} {1} {2}", counts[0], counts[1], counts[2]);
        }
        
        private static void PrintIntList(List<int> list)
        {
            foreach (int item in list) Console.Write(item + " ");
            Console.WriteLine();
        }
        private static void PrintSet(string msg, HashSet<string> set)
        {
            Console.Write(msg);
            foreach (string s in set) Console.Write(s + " ");
            Console.WriteLine();
        }

        private static int ReadInt(string message)
        {
            int res;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out res))
            {
                Console.Write("Ошибка. Введите целое число: ");
            }
            return res;
        }
        
    }
//Синойл Цветочная 95 2250
//Газпром Ленина 92 2100
//Лукойл Мира 95 2250
//Роснефть Степная 92 2100
//Шелл Дубравная 92 2150
//Татнефть Новая 95 2300
//ННК Горная 92 2100
