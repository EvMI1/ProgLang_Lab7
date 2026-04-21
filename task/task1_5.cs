using System.Xml.Serialization;

public struct Toy
{
    public string Name;
    public int Price;
    public int AgeFrom;
    public int AgeTo;
}

internal class Task1_5
{
    // Задание 1, вариант 7
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

    // Задание 2, вариант 7
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

    // Задание 3, вариант 7
    public static void CopyLinesWithSubstring(string sourceFileName, string destFileName, string substring)
    {
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

    // Задание 4, вариант 7
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

    private static int FindMinElement(string fileName)
    {
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

    private static int FindMaxElementBinary(string fileName)
    {
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
        using (FileStream f = new FileStream(fileName, FileMode.Open))
        using (BinaryReader reader = new BinaryReader(f))
        {
            if (f.Length == 0)
            {
                Console.WriteLine("Предупреждение: файл пустой.");
                return 0;                    
            }

            int max = reader.ReadInt32();
            int min = max;

            while (f.Position < f.Length)
            {
                int num = reader.ReadInt32();
                if (num > max) max = num;
                if (num < min) min = num;
            }

            return max - min;
        }
    }

    public static void FillToysFile(string fileName)
    {
        List<Toy> toys = new List<Toy>();
        string[] names = { "Кубики", "Конструктор", "Кукла", "Мяч", "Машинка", "Пазл", "Робот" };
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            Toy toy = new Toy();
            toy.Name = names[random.Next(names.Length)];
            toy.Price = random.Next(100, 2000);
            toy.AgeFrom = random.Next(1, 8);
            toy.AgeTo = toy.AgeFrom + random.Next(1, 5);
            toys.Add(toy);
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        using (FileStream f = new FileStream(fileName, FileMode.Create))
        {
            serializer.Serialize(f, toys);
        }
    }

    private static List<Toy> ReadToysFile(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        using (FileStream f = new FileStream(fileName, FileMode.Open))
        {
            return (List<Toy>)serializer.Deserialize(f);
        }
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

    public static List<string> GetMostExpensiveToys(string fileName, int k)
    {
        List<Toy> toys = ReadToysFile(fileName);
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