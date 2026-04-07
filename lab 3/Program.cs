using System;
using System.Text;

namespace lab_3
{
    internal class Program
    {
        static int[] FillingMethod()
        {
            Console.Write("Яким чином  бажаєте заповнити масив? \n" +
               "(введіть 1) випадковим чином\n" +
               "(введіть 2) вручну через пробіл\n" +
               "Ваш вибір: ");
            int choise = int.Parse(Console.ReadLine());
            Console.Write("Введіть розмір масиву: ");
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            
            switch (choise)
            {
                case 1:
                    array = RandomArray(size);
                    break;
                case 2:
                    array = HandSpace(size);
                    break;
                
                default:
                    Console.WriteLine("Некоректний вибір способу заповнення. Обрано рандом.");
                    array = RandomArray(size);
                    break;
            }
            return array;
        }
        static int[] HandSpace(int size)
        {
            Console.WriteLine("Введіть значення масиву через пробіл:");
            string input = Console.ReadLine();

            string[] parts = input.Split(' ', '\t');

            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(parts[i]);
            }
            Console.WriteLine("\n");
            return array;
        }
        static int[] RandomArray(int size)
        {
            Console.Write("Введіть мінімальне значення рандому: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Введіть максимальне значення рандому: ");
            int max = int.Parse(Console.ReadLine());

            int[] array = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(min, max);
            }
            Console.WriteLine("\n");
            return array;
        }
        static void PrintArray(int[] arr, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\nДовжина масиву: " + arr.Length);
        }
        static void RemoveElements(ref int[] arr)
        {
            Console.WriteLine("Введіть скільки елементів треба знищити: ");
            int T = int.Parse(Console.ReadLine());
            Console.WriteLine("З якого елементу починати (рахувати з 0): ");
            int K = int.Parse(Console.ReadLine());
            if (K < 0)
            {
                Console.WriteLine("Помилка: Індекс K не може бути від'ємним. Операцію скасовано."); 
                return;
            }
            if (K >= arr.Length)
            {
                Console.WriteLine($"Помилка: Індекс {K} поза межами масиву (довжина {arr.Length}).");
                return;
            }
            int count = T;
            if (K + T > arr.Length)
            {
                count = arr.Length - K; 
                Console.WriteLine($"Попередження: Буде видалено {count} елементів (все, що було доступно).");
            }

            if (count <= 0)
            {
                Console.WriteLine("Кількість елементів для видалення має бути більшою за 0.");
                return;
            }
            for (int i = K; i < arr.Length - count; i++)
            {
                arr[i] = arr[i + count];
            }
            Array.Resize(ref arr, arr.Length - count);

            Console.WriteLine("Елементи успішно видалено.");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[] arr = FillingMethod();
            PrintArray(arr, "Масив до обробки: ");
            RemoveElements(ref arr);
            PrintArray(arr, "Масив після видалення:");
        }
    }
}
