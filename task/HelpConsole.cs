namespace Checkup;

internal class HelpConsole
{
    public static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
            Console.WriteLine("Неккоректное значение. Повторите ввод");
        }
    }

    public static byte ReadByte(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (byte.TryParse(Console.ReadLine(), out byte value))
                return value;
            Console.WriteLine("Ошибка: введите целое число от 0 до 255.");
        }
    }

    public static int ReadPositiveInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("Ошибка: введите целое число больше 0.");
        }
    }
}