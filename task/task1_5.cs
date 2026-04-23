using System.Xml.Serialization;

internal class Task1_5
{
    // Задание 1.
    public static void FillFile(string fileName, int count)
    {
        Random random = new Random();
        using (StreamWriter file = new StreamWriter(fileName))
        {
            for (int i = 0; i < count; i++)
            {
                file.WriteLine(random.Next(-100, 101));
            }
        }
    }

    public static int FindMaxElement(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        int max = int.MinValue;
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
                int element = int.Parse(line);
                if (element > max)
                {
                    max = element;
                }
            }
        }
        return max;
    }

    public static int CountMax(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        int max = FindMaxElement(fileName);
        int count = 0;
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
                int element = int.Parse(line);
                if (element == max)
                {
                    count++;
                }
            }
        }
        return count;
    }

    // Задание 2.
    public static void FillFile2(string fileName, int rowCount, int colCount)
    {
        Random random = new Random();
        using (StreamWriter file = new StreamWriter(fileName))
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    file.Write(random.Next(-100, 101));
                    if (j < colCount - 1)
                    {
                        file.Write(" ");
                    }
                }
                file.WriteLine();
            }
        }
    }

    public static int CountEvenElements(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        int count = 0;
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
                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i] == "")
                    {
                        continue;
                    }
                    int element = int.Parse(parts[i]);
                    if (element % 2 == 0)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    // Задание 3.
    public static void CopyLinesWithSubstring(string sourceFileName, string destFileName, string substring)
    {
        if (!File.Exists(sourceFileName))
        {
            throw new FileNotFoundException($"Файл не найден: {sourceFileName}");
        }
        using (StreamReader source = new StreamReader(sourceFileName))
        using (StreamWriter dest = new StreamWriter(destFileName))
        {
            string line;
            while ((line = source.ReadLine()) != null)
            {
                if (line.Contains(substring))
                {
                    dest.WriteLine(line);
                }
            }
        }
    }

    // Задание 4.
    public static void FillBinaryFile(string fileName, int count)
    {
        Random random = new Random();
        using (FileStream f = new FileStream(fileName, FileMode.Create))
        using (BinaryWriter file = new BinaryWriter(f))
        {
            for (int i = 0; i < count; i++)
            {
                file.Write(random.Next(-100, 101));
            }
        }
    }

    public static int FindMinElementBinary(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        int min = int.MaxValue;
        using (FileStream f = new FileStream(fileName, FileMode.Open))
        using (BinaryReader file = new BinaryReader(f))
        {
            while (file.BaseStream.Position < file.BaseStream.Length)
            {
                int element = file.ReadInt32();
                if (element < min)
                {
                    min = element;
                }
            }
        }
        return min;
    }

    public static void PrintBinaryFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        using (FileStream f = new FileStream(fileName, FileMode.Open))
        using (BinaryReader file = new BinaryReader(f))
        {
            while (file.BaseStream.Position < file.BaseStream.Length)
            {
                Console.Write(file.ReadInt32());
                if (file.BaseStream.Position < file.BaseStream.Length)
                {
                    Console.Write(", ");
                }
            }
        }
        Console.WriteLine();
    }

    public static int FindMaxElementBinary(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        int max = int.MinValue;
        using (FileStream f = new FileStream(fileName, FileMode.Open))
        using (BinaryReader file = new BinaryReader(f))
        {
            while (file.BaseStream.Position < file.BaseStream.Length)
            {
                int element = file.ReadInt32();
                if (element > max)
                {
                    max = element;
                }
            }
        }
        return max;
    }

    public static int GetMaxMinDifference(string fileName)
    {
        return FindMaxElementBinary(fileName) - FindMinElementBinary(fileName);
    }

    // Задание 5.
    public static void FillToysFile(string fileName)
    {
        List<Toy> toys = new List<Toy>();
        string[] names =
        {
        "Кубики",
        "Конструктор",
        "Кукла",
        "Мяч",
        "Машинка",
        "Пазл",
        "Робот"
    };
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            int ageFrom = random.Next(1, 8);
            int ageTo = ageFrom + random.Next(1, 5);
            toys.Add(new Toy(names[random.Next(names.Length)], random.Next(100, 2000), ageFrom, ageTo));
        }
        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        using (FileStream f = new FileStream(fileName, FileMode.Create))
        {
            serializer.Serialize(f, toys);
        }
    }

    public static void SaveToysToBinary(string xmlFileName, string binFileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        List<Toy> toys;
        using (FileStream f = new FileStream(xmlFileName, FileMode.Open))
        {
            toys = (List<Toy>)serializer.Deserialize(f);
        }
        using (FileStream f = new FileStream(binFileName, FileMode.Create))
        using (BinaryWriter file = new BinaryWriter(f))
        {
            for (int i = 0; i < toys.Count; i++)
            {
                file.Write(toys[i].Name);
                file.Write(toys[i].Price);
                file.Write(toys[i].AgeFrom);
                file.Write(toys[i].AgeTo);
            }
        }
    }

    private static List<Toy> ReadToysFromBinary(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"Файл не найден: {fileName}");
        }
        List<Toy> toys = new List<Toy>();
        using (FileStream f = new FileStream(fileName, FileMode.Open))
        using (BinaryReader file = new BinaryReader(f))
        {
            while (file.BaseStream.Position < file.BaseStream.Length)
            {
                string name = file.ReadString();
                int price = file.ReadInt32();
                int ageFrom = file.ReadInt32();
                int ageTo = file.ReadInt32();
                toys.Add(new Toy(name, price, ageFrom, ageTo));
            }
        }
        return toys;
    }

    private static int FindMaxPrice(List<Toy> toys)
    {
        int max = int.MinValue;
        for (int i = 0; i < toys.Count; i++)
        {
            if (toys[i].Price > max)
            {
                max = toys[i].Price;
            }
        }
        return max;
    }

    public static List<string> GetMostExpensiveToys(string binFileName, int k)
    {
        List<Toy> toys = ReadToysFromBinary(binFileName);
        int maxPrice = FindMaxPrice(toys);
        List<string> result = new List<string>();
        for (int i = 0; i < toys.Count; i++)
        {
            if (maxPrice - toys[i].Price <= k)
            {
                result.Add(toys[i].Name);
            }
        }
        return result;
    }
}