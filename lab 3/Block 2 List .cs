using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_3
{
    internal class Block_2_lList
    {
        public static void Block2ListStart()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Оберіть дію" +
                "\n1.Заповнити масив вручну" +
                "\n2. Заповнити масив рандом");
            string choise = Console.ReadLine();
            List<List<int>> matrix = null;
            
            switch (choise)
            {
                case "1":
                    matrix = ManualFilling();
                    break;
                case "2":
                    matrix = RandomFilling();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            PrintArray(matrix);
            RemoveRows(ref matrix);
            PrintArray(matrix);
        }
        public static List<List<int>> ManualFilling()
        {
            Console.WriteLine("Введіть клькіть рядків: ");//прибрати повторюваний код
            int rows = int.Parse(Console.ReadLine());

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введіть рядок {i + 1} через пробіли : ");
                List<int> row = Console.ReadLine()
                     .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToList();
                matrix.Add(row);
            }
            return matrix;
        }
        public static List<List<int>> RandomFilling()
        {
            Random random = new Random();
            Console.WriteLine("Введіть кількість рядків: ");//прибрати повторюваний код
            int rows = int.Parse(Console.ReadLine());

            List<List<int>> matrix = new List<List<int>>();

            Console.Write("Введіть мінімальне значення рандому: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Введіть максимальне значення рандому: ");
            int max = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Введіть кількість елементів рядка {i + 1} : ");
                int elements = int.Parse(Console.ReadLine());
                List<int> row = new List<int>();
                for (int j = 0; j < elements; j++)
                {
                    row.Add(random.Next(min, max));
                }
                matrix.Add(row);
            }
            return matrix;
        }
        public static void PrintArray(List<List<int>> matrix)
        {
            Console.WriteLine("\nПоточний зубчастий список:");
            for (int i = 0; i < matrix.Count; i++)
            {
                Console.Write($"Рядок {i} (Count: {matrix[i].Count}):\t");
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
            Console.WriteLine();
        }
        public static void RemoveRows(List<List<int>> matrix)
        {
            Console.Write("Введіть порядковий номер рядка з якого починати : ");
            int k1 = int.Parse(Console.ReadLine());

            Console.Write("Введіть порядковий номер рядка на якому завершити : ");
            int k2 = int.Parse(Console.ReadLine());

            if (k1 > k2)
            {
                (k1, k2) = (k2, k1);
            }

            if (k2 > matrix.Count || k1 < 1)
            {
                Console.WriteLine("ви вийшли за межі");
                return;
            }

            int index = k1 - 1; 
            int count = k2 - k1 + 1; 

            matrix.RemoveRange(index, count);

            Console.WriteLine($"Успішно видалено {count} рядків.");

        }
    }
}
