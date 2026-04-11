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

            int[][] array = RandomFilling();

            PrintArray(array);
        }
        public static int[][] ManualFilling(int[][] array)
        {
            Console.WriteLine("Введіть клькіть рядків: ");//прибрати повторюваний код
            int rows = int.Parse(Console.ReadLine());
            array = new int[rows][];
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
    }
}
