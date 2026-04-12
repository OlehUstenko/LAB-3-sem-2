using System;
using System.Drawing;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Який блок ви хочетe запустити?" +
                "\n1. Знищити T елементів, починаючи з номеру К (якщо, починаючи з номера К, елементи є, але менше,чим T штук — знищити, скільки є; однак, якщо К від'ємне, не робити нічого)" +
                "\n2. Знищити рядки, починаючи з рядка К1 і до рядка К2 (лише якщо увесь цей діапазон фактично є; якщо хоча б одного з таких рядків нема, лишити масив без змін)" +
                "\n3. Блок 1 через лісти" +
                "\n4. Блок 2 через лісти" +
                "\nВаш вибір: ");

            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    Block_1.Block1Start();
                    break;
                case "2":
                    Block_2.Block2Start();
                    break;
                case "3":
                    Block_1_List.Block1ListStart();
                    break;
                case "4":
                    Block_2_List.Block2ListStart();
                    break;
                default:
                    Console.WriteLine("Некоректний вибір");
                    break;
            }
        }
    }
}
