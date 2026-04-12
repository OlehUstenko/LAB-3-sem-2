using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab_3
{
    internal class Block_1_List
    {
        public static void Block1ListStart()
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<int> list = FillingMethodList();
            PrintList(list, "Масив до обробки: ");
            RemoveElementsList(list);
            PrintList(list, "Масив після видалення:");
        }
        public static List<int> FillingMethodList()
        {
            Console.Write("Яким чином  бажаєте заповнити масив? \n" +
               "1. випадковим чином\n" +
               "2. вручну через пробіл\n" +
               "Ваш вибір: ");
            int choise = int.Parse(Console.ReadLine());
            //Console.Write("Введіть розмір масиву: ");
            //int size = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            switch (choise)
            {
                case 1:
                    list = RandomArrayList();
                    break;
                case 2:
                    list = HandSpaceList();
                    break;

                default:
                    Console.WriteLine("Некоректний вибір способу заповнення. Обрано рандом.");
                    list = RandomArrayList();
                    break;
            }
            return list;
        }
        public static List<int> HandSpaceList()
        {
            Console.WriteLine("Введіть значення масиву через пробіл:");
            List<int> list = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)//розбиваємо
                .Select(int.Parse)//парсимо в інт
                .ToList();//і перетворюємо на ліст 
            return list;
        }
        public static List<int> RandomArrayList()
        {
            Console.Write("Введіть мінімальне значення рандому: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Введіть максимальне значення рандому: ");
            int max = int.Parse(Console.ReadLine());

            Console.Write("Скільки елементів у створити: ");
            int size = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(min, max)); //додаємо в кінець 
            }
            Console.WriteLine("\n");
            return list;
        }
        public static void PrintList(List<int> list , string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(string.Join(" ",list));
            Console.WriteLine("\nДовжина масиву: " + list.Count);
        }
        public static void RemoveElementsList(List<int> list)
        {
            Console.WriteLine("Введіть скільки елементів треба знищити: ");
            int T = int.Parse(Console.ReadLine());
            Console.WriteLine("З якого елементу починати : ");
            int K = int.Parse(Console.ReadLine()) - 1;
            if (K < 0)
            {
                Console.WriteLine("Помилка: Індекс K не може бути від'ємним. Операцію скасовано.");
                return;
            }
            if (K >= list.Count)
            {
                Console.WriteLine($"Помилка: Індекс {K + 1} поза межами масиву (довжина {list.Count}).");
                return;
            }
            int count = T;
            if (K + T > list.Count)
            {
                count = list.Count - K;
                Console.WriteLine($"Попередження: Буде видалено {count} елементів (все, що було доступно).");
            }

            if (count <= 0)
            {
                Console.WriteLine("Кількість елементів для видалення має бути більшою за 0.");
                return;
            }

            list.RemoveRange(K, count);

            Console.WriteLine("Елементи успішно видалено.");
        }
    }
}
