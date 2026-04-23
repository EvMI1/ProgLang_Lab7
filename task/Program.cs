using Checkup;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("1. Задание 1 — количество вхождений максимального элемента");
            Console.WriteLine("2. Задание 2 — количество чётных элементов");
            Console.WriteLine("3. Задание 3 — строки с заданной комбинацией символов");
            Console.WriteLine("4. Задание 4 — разность максимального и минимального");
            Console.WriteLine("5. Задание 5 — наиболее дорогие игрушки");
            Console.WriteLine("6. Задание 6 — перемещение первого элемента списка в конец");
            Console.WriteLine("7. Задание 7 — удаление равных соседей в связном списке");
            Console.WriteLine("8. Задание 8 — анализ покупок фабрик (мебельные магазины)");
            Console.WriteLine("9. Задание 9 — печать глухих согласных в нечётных словах");
            Console.WriteLine("10. Задание 10 — анализ цен на сметану");
            Console.WriteLine("0. Выход");
            int choice = HelpConsole.ReadInt("Выберите задание: ");
            if (choice == 0)
            {
                break;
            }
            try
            {
                switch (choice)
                {
                    case 1:
                        string file1 = "task1.txt";
                        int count1 = HelpConsole.ReadPositiveInt("Введите количество элементов: ");
                        Task1_5.FillFile(file1, count1);
                        Console.WriteLine($"Максимальный элемент = {Task1_5.FindMaxElement(file1)}." +
                        $"Максимальный элемент встречается {Task1_5.CountMax(file1)} раз.");
                        break;
                    case 2:
                        string file2 = "task2.txt";
                        int rows = HelpConsole.ReadPositiveInt("Введите количество строк: ");
                        int cols = HelpConsole.ReadPositiveInt("Введите количество чисел в строке: ");
                        Task1_5.FillFile2(file2, rows, cols);
                        Console.WriteLine($"Количество чётных элементов: {Task1_5.CountEvenElements(file2)}");
                        break;
                    case 3:
                        Console.Write("Введите путь к исходному файлу: ");
                        string file3Source = Console.ReadLine() ?? "";
                        string file3Dest = "task3_result.txt";
                        Console.Write("Введите комбинацию символов для поиска: ");
                        string substring = Console.ReadLine() ?? "";
                        Task1_5.CopyLinesWithSubstring(file3Source, file3Dest, substring);
                        Console.WriteLine($"Результат записан в {file3Dest}");
                        break;
                    case 4:
                        string file4 = "task4.bin";
                        int count4 = HelpConsole.ReadPositiveInt("Введите количество элементов для заполнения файла: ");
                        Task1_5.FillBinaryFile(file4, count4);
                        Task1_5.PrintBinaryFile(file4);
                        Console.WriteLine($"Max = {Task1_5.FindMaxElementBinary(file4)}\t" +
                        $"Min = {Task1_5.FindMinElementBinary(file4)}");
                        Console.WriteLine($"Разность максимального и минимального:" +
                        $"{Task1_5.GetMaxMinDifference(file4)}");
                        break;
                    case 5:
                        string file5xml = "task5.xml";
                        string file5bin = "task5.bin";
                        Task1_5.FillToysFile(file5xml);
                        Task1_5.SaveToysToBinary(file5xml, file5bin);
                        int k = HelpConsole.ReadInt("Введите допустимое отклонение от максимальной цены (k): ");
                        List<string> expensiveToys = Task1_5.GetMostExpensiveToys(file5bin, k);
                        Console.WriteLine("Наиболее дорогие игрушки:");
                        for (int i = 0; i < expensiveToys.Count; i++)
                        {
                            Console.WriteLine($"  {expensiveToys[i]}");
                        }
                        break;
                    case 6:
                        List<float> list6 = new List<float>();
                        int count6 = HelpConsole.ReadPositiveInt("Введите количество элементов списка: ");
                        for (int i = 0; i < count6; i++)
                        {
                            list6.Add(HelpConsole.ReadInt($"Элемент {i + 1}: "));
                        }
                        Console.WriteLine("Список до: " + string.Join(", ", list6));
                        Task6_10.MoveFirstToEnd(list6);
                        Console.WriteLine("Список после: " + string.Join(", ", list6));
                        break;
                    case 7:
                        LinkedList<float> list7 = new LinkedList<float>();
                        int count7;
                        do
                        {
                            count7 = HelpConsole.ReadPositiveInt("Введите количество элементов (не менее 2): ");
                            if (count7 < 2)
                            {
                                Console.WriteLine("Ошибка: количество элементов должно быть не менее 2.");
                            }
                        } while (count7 < 2);
                        for (int i = 0; i < count7; i++)
                        {
                            list7.AddLast(HelpConsole.ReadInt($"Элемент {i + 1}: "));
                        }
                        Console.WriteLine("Список до: " + string.Join(", ", list7));
                        Task6_10.RemoveEqualNeighbours(list7);
                        Console.WriteLine("Список после: " + string.Join(", ", list7));
                        break;
                    case 8:
                        HashSet<string> allFactories = new HashSet<string>();
                        int factoryCount = HelpConsole.ReadPositiveInt("Введите количество фабрик: ");
                        for (int i = 0; i < factoryCount; i++)
                        {
                            Console.Write($"Название фабрики {i + 1}: ");
                            string factory = Console.ReadLine() ?? "";
                            allFactories.Add(factory);
                        }
                        List<HashSet<string>> purchases = new List<HashSet<string>>();
                        int buyerCount = HelpConsole.ReadPositiveInt("Введите количество покупателей: ");
                        for (int i = 0; i < buyerCount; i++)
                        {
                            HashSet<string> bought = new HashSet<string>();
                            int boughtCount = HelpConsole.ReadPositiveInt($"Сколько фабрик купил покупатель {i + 1}: ");
                            for (int j = 0; j < boughtCount; j++)
                            {
                                Console.Write($"  Фабрика {j + 1}: ");
                                string f = Console.ReadLine() ?? "";
                                bought.Add(f);
                            }
                            purchases.Add(bought);
                        }
                        Task6_10.AnalyzeFurnitureShops(purchases, allFactories);
                        break;
                    case 9:
                        Console.Write("Введите путь к текстовому файлу: ");
                        string file9 = Console.ReadLine() ?? "";
                        Task6_10.PrintDeafConsonantsInOddNotEven(file9);
                        break;
                    case 10:
                        Console.Write("Введите путь к файлу с данными о сметане: ");
                        string file10 = Console.ReadLine() ?? "";
                        Task6_10.AnalyzeSourCreamPrices(file10);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Повторите ввод.");
                        break;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}