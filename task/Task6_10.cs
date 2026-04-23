internal class Task6_10
{
    // Задание 6.
    public static void MoveFirstToEnd(List<float> list)
    {
        if (list.Count == 0)
        {
            return;
        }
        float first = list[0];
        list.RemoveAt(0);
        list.Add(first);
    }

    // Задание 7.
    public static void RemoveEqualNeighbours(LinkedList<float> list)
    {
        if (list.Count < 2)
        {
            return;
        }
        LinkedListNode<float> current = list.First;
        while (current != null)
        {
            LinkedListNode<float> prev = current.Previous ?? list.Last;
            LinkedListNode<float> next = current.Next ?? list.First;
            LinkedListNode<float> toRemove = null;
            if (prev.Value == next.Value)
            {
                toRemove = current;
            }
            current = current.Next;
            if (toRemove != null)
            {
                list.Remove(toRemove);
            }
        }
    }

    // Задание 8.
    public static void AnalyzeFurnitureShops(List<HashSet<string>> purchases, HashSet<string> allFactories)
    {
        HashSet<string> byAll = new HashSet<string>(allFactories);
        HashSet<string> bySome = new HashSet<string>();
        HashSet<string> byNone = new HashSet<string>(allFactories);

        for (int i = 0; i < purchases.Count; i++)
        {
            byAll.IntersectWith(purchases[i]);
            bySome.UnionWith(purchases[i]);
        }
        byNone.ExceptWith(bySome);
        bySome.ExceptWith(byAll);

        Console.WriteLine("Мебель каких фабрик приобреталась всеми покупателями:");
        PrintSet(byAll);
        Console.WriteLine("Мебель каких фабрик приобреталась некоторыми покупателями:");
        PrintSet(bySome);
        Console.WriteLine("Мебель каких фабрик не приобреталась никем:");
        PrintSet(byNone);
    }

    private static void PrintSet(HashSet<string> set)
    {
        if (set.Count == 0)
        {
            Console.WriteLine("(пусто)");
            return;
        }
        foreach (string item in set)
        {
            Console.WriteLine($"  {item}");
        }
    }

    // Задание 9.
    public static void PrintDeafConsonantsInOddNotEven(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        HashSet<char> deafConsonants = new HashSet<char>
        {
            'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ч', 'щ', 'ц'
        };

        string[] words;
        using (StreamReader file = new StreamReader(fileName))
        {
            string content = file.ReadToEnd();
            words = content.ToLower().Split(
                [' ', '\n', '\r', '\t', '.', ',', '!', '?', ':', ';', '-'],
                StringSplitOptions.RemoveEmptyEntries
            );
        }

        if (words.Length == 0)
        {
            Console.WriteLine("Файл не содержит слов.");
            return;
        }

        HashSet<char> inAllOdd = new HashSet<char>(deafConsonants);
        HashSet<char> inSomeEven = new HashSet<char>();

        for (int i = 0; i < words.Length; i++)
        {
            HashSet<char> wordChars = new HashSet<char>(words[i]);
            if ((i + 1) % 2 != 0)
            {
                inAllOdd.IntersectWith(wordChars);
            }
            else
            {
                foreach (char c in wordChars)
                {
                    if (deafConsonants.Contains(c))
                    {
                        inSomeEven.Add(c);
                    }
                }
            }
        }

        HashSet<char> result = new HashSet<char>(inAllOdd);
        result.ExceptWith(inSomeEven);

        List<char> sorted = new List<char>(result);
        sorted.Sort();

        Console.WriteLine("Глухие согласные, входящие в каждое нечётное слово и не входящие хотя бы в одно чётное:");
        if (sorted.Count == 0)
        {
            Console.WriteLine("  (пусто)");
            return;
        }
        for (int i = 0; i < sorted.Count; i++)
        {
            Console.WriteLine($"  {sorted[i]}");
        }
    }

    // Задание 10.
    public static void AnalyzeSourCreamPrices(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        Dictionary<int, int> minPrices = new Dictionary<int, int>();
        Dictionary<int, int> minPriceCounts = new Dictionary<int, int>();

        int[] fatTypes = { 15, 20, 25 };
        for (int i = 0; i < fatTypes.Length; i++)
        {
            minPrices[fatTypes[i]] = int.MaxValue;
            minPriceCounts[fatTypes[i]] = 0;
        }

        using (StreamReader file = new StreamReader(fileName))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                if (line == "")
                {
                    continue;
                }
                string[] parts = line.Split(' ');
                if (parts.Length < 4)
                {
                    continue;
                }
                int fat = int.Parse(parts[2]);
                int price = int.Parse(parts[3]);

                if (price < minPrices[fat])
                {
                    minPrices[fat] = price;
                    minPriceCounts[fat] = 1;
                }
                else if (price == minPrices[fat])
                {
                    minPriceCounts[fat]++;
                }
            }
        }

        for (int i = 0; i < fatTypes.Length; i++)
        {
            int count;
            if (minPrices[fatTypes[i]] == int.MaxValue)
            {
                count = 0;
            }
            else
            {
                count = minPriceCounts[fatTypes[i]];
            }
            Console.Write(count);
            if (i < fatTypes.Length - 1)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}