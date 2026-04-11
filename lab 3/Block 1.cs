using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    internal class Block_1
    {
        static void Block1()
        {
            int[][] array;

        }
        static void ManualFilling(ref int[][] array)
        {
            Console.WriteLine("Введіть клькіть рядків: ");
            int rows = int.Parse(Console.ReadLine());
            array = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введіть рядок {i+1} через пробіли : ");
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                array[i] = Array.ConvertAll(input, int.Parse);
            }
        }

    }
}
