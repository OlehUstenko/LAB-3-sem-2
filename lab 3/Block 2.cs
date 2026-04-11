using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class Block_2
    {
        public static void Block2Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Оберіть дію" +
                "\n1.Заповнити масив вручну" +
                "\n2. Заповнити масив рандом");
            string choise = Console.ReadLine();
            int[][] array = null;
            switch (choise)
            {
                case "1":
                    array = ManualFilling();
                    break;
                case "2":
                    array = RandomFilling();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            PrintArray(array);
            RemoveRows(ref array);
            PrintArray(array);
        }
        public static int[][] ManualFilling()
        {
            Console.WriteLine("Введіть клькіть рядків: ");//прибрати повторюваний код
            int rows = int.Parse(Console.ReadLine());

            int[][] array = new int[rows][]; 

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введіть рядок {i+1} через пробіли : ");
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                array[i] = Array.ConvertAll(input, int.Parse);
            }
            return array;
        }
        public static int[][] RandomFilling()
        {
            Random random = new Random();
            Console.WriteLine("Введіть кількість рядків: ");//прибрати повторюваний код
            int rows = int.Parse(Console.ReadLine());

            int[][] array = new int[rows][];

            Console.Write("Введіть мінімальне значення рандому: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Введіть максимальне значення рандому: ");
            int max = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Введіть кількість елементів рядка {i + 1} : ");
                int elemets = int.Parse(Console.ReadLine());
                array[i] = new int[elemets];
                for (int j = 0; j < elemets; j++)
                {
                    array[i][j] = random.Next(min, max);
                }
            }
            return array;
        }
        public static void PrintArray(int[][] array)
        {
            int rows = array.Length;
            Console.WriteLine("Поточний масив");
            for (int i = 0; i < rows; i++)
            {
                foreach (int el in array[i])
                {
                    Console.Write(el+" ");
                }
                Console.WriteLine();
            }
        }
        public static void RemoveRows(ref int[][] array)
        {
            Console.Write("Введіть порядковий номер рядка з якого починати : ");
            int k1 = int.Parse(Console.ReadLine());

            Console.Write("Введіть порядковий номер рядка на якому завершити : ");
            int k2 = int.Parse(Console.ReadLine());

            if (k1 > k2)
            {
                (k1, k2) = (k2, k1);
            }

            if (k2 > array.Length || k1 < 1)
            {
                Console.WriteLine("ви вийшли за межі");
                return;
            }
            
            int count = k2 - k1 + 1;
            for (int i = k1 - 1; i < array.Length - count; i++)
            {
                array[i] = array[i + count];
            }
            Array.Resize(ref array, array.Length - count);

            Console.WriteLine($"Успішно видалено {count} рядків.");

        }
    }
}
