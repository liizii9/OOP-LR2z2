using System;

class Ar
{
    private int n;
    private int[] a;
    private int s;

    public int S
    {
        get { return s; }
    }

    public int N
    {
        get { return n; }
    }

    public Ar(int n, int x)
    {
        this.n = n;
        a = new int[n];
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            a[i] = random.Next(-x, x + 1);
            if (a[i] < 0)
                s += a[i];
        }
    }

    public Ar(string input)
    {
        string[] numbers = input.Split(' ');
        n = numbers.Length;
        a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = Convert.ToInt32(numbers[i]);
            if (a[i] < 0)
                s += a[i];
        }
    }

    public void Print()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();
    }

    public int P()
    {
        for (int i = n - 1; i >= 0; i--)
        {
            if (a[i] % 7 == 0)
                return i;
        }
        return -1;
    }

    public int Pr(int i1, int i2)
    {
        int product = 1;
        for (int i = i1; i <= i2; i++)
        {
            product *= a[i];
        }
        return product;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Оберiть конструктор (1 або 2): ");
            int constructorChoice = Convert.ToInt32(Console.ReadLine());

            Ar ar;

            if (constructorChoice == 1)
            {
                Console.Write("Введiть кiлькiсть елементiв в масивi: ");
                int n = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введiть число x: ");
                int x = Convert.ToInt32(Console.ReadLine());

                ar = new Ar(n, x);
            }
            else if (constructorChoice == 2)
            {
                Console.Write("Введiть числа, роздiленi пропуском: ");
                string input = Console.ReadLine();

                ar = new Ar(input);
            }
            else
            {
                Console.WriteLine("Невiрний вибiр конструктора.");
                return;
            }

            ar.Print();

            Console.WriteLine($"Сума негативних елементiв масиву: {ar.S}");

            int lastIndexMultipleOf7 = ar.P();
            if (lastIndexMultipleOf7 != -1)
            {
                Console.WriteLine($"iндекс останнього кратного 7 елемента: {lastIndexMultipleOf7}");
                Console.WriteLine($"Добуток всiх елементiв масиву до цього iндексу: {ar.Pr(0, lastIndexMultipleOf7)}");
            }
            else
            {
                Console.WriteLine("Елемент, кратний 7, не знайдено.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
