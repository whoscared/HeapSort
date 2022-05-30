using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] check = { 6, 7, 3, 0, 1, 11, 23 };
            Heap heap;
            heap = new Heap(check);
            Console.WriteLine("1. Make heap\n2. Default heap");
            int what = Int32.Parse(Console.ReadLine());
            if (what == 1)
            {
                Console.WriteLine("example: 3, 4, 15\nyour array:");
                string input = Console.ReadLine();
                var inputnumbers = input.Split(',',StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = new int[inputnumbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = Int32.Parse(inputnumbers[i]);
                }
                heap = new Heap(numbers);
            }

            bool menu = true;
            while (menu)
            {
                Console.WriteLine("1. Print heap\n2. Print array\n3. Array sort\n4. Add value\n5. Delete value\n6. Search value\n7. Exit");
                int choose = Int32.Parse(Console.ReadLine());
                if (choose == 1)
                    heap.HeapWrite();
                if (choose == 2)
                    heap.ArrayWrite();
                if (choose == 3)
                {
                    heap.SortArray();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Done!");
                    Console.ResetColor();
                }
                if (choose == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Value: ");
                    Console.ResetColor();
                    int value = Int32.Parse(Console.ReadLine());
                    heap.Add(value);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Done!");
                    Console.ResetColor();
                }

                if (choose == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Value: ");
                    Console.ResetColor();
                    int value = Int32.Parse(Console.ReadLine());
                    if (heap.Delete(value))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("error");
                    }
                    Console.ResetColor();
                }

                if (choose == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Value: ");
                    Console.ResetColor();
                    int value = Int32.Parse(Console.ReadLine());
                    if (heap.Search(ref value))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Done! index: ");
                        Console.ResetColor();
                        Console.Write(value);
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("error");
                    }
                    Console.ResetColor();
                }

                if (choose == 7)
                    menu = !menu;
            }
        }
    }
}
