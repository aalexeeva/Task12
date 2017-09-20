using System;
using static System.Console;

namespace Task12
{
    class Program
    {
        public static int Input(int status) // ввод числа N
        {
            var number = 0; // переменная для числа
            bool ok; // показатель корректности ввода
            do
            {
                try
                {
                    number = Convert.ToInt32(ReadLine());
                    if (status == 1)
                        ok = number > 0 && number < 4;
                    else if (status == 2) ok = number > 0;
                    else ok = true;
                }
                catch (FormatException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
                catch (OverflowException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
            } while (!ok);
            return number;
        }

        public static int IncInput(bool status, int prev) // ввод числа N
        {
            var number = 0; // переменная для числа
            bool ok; // показатель корректности ввода
            do
            {
                try
                {
                    number = Convert.ToInt32(ReadLine());
                    if (status)
                        ok = number > prev;
                    else ok = number < prev;
                    if (ok) continue;
                    var word = status ? "больше" : "меньше";
                    WriteLine("Некорректно введено число. Оно должно быть {0}, чем предыдущее", word);
                }
                catch (FormatException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
                catch (OverflowException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
            } while (!ok);
            return number;
        }

        public static int PrintMenu()
        {
            WriteLine("Выберите вариант сортировки:");
            WriteLine("1. Сортировка слиянием");
            WriteLine("2. Сортировка подсчетом");
            WriteLine("3. Начать заново");
            WriteLine("4. Выход");
            return Input(1);
        }

        static void Main(string[] args)
        {
            bool okay = false;
            do
            {
                WriteLine("Введите размер первого (упорядоченного по возрастанию) массива:");
                var length = Input(2);
                var first = new int[length];
                for (var i = 0; i < length; i++)
                {
                    WriteLine("Введите {0} элемент массива", i + 1);
                    if (i == 0)
                        first[i] = Input(3);
                    else first[i] = IncInput(true, first[i - 1]);
                }
                WriteLine("Введите размер второго (упорядоченного по убыванию) массива:");
                length = Input(2);
                var second = new int[length];
                for (var i = 0; i < length; i++)
                {
                    WriteLine("Введите {0} элемент массива", i + 1);
                    if (i == 0)
                        second[i] = Input(3);
                    else second[i] = IncInput(false, second[i - 1]);
                }
                WriteLine("Введите размер третьего (неупорядоченного) массива:");
                length = Input(2);
                var third = new int[length];
                for (var i = 0; i < length; i++)
                {
                    WriteLine("Введите {0} элемент массива", i + 1);
                    third[i] = Input(3);
                }
                int n, f; // переменные для пересылок и сравнений
                bool ok = false;
                int[] newarr; // отсортированный массив 
                do
                {
                var userAnswer = PrintMenu();
                    switch (userAnswer)
                    {
                        case 1:
                            WriteLine("Сортировка первого массива");
                            newarr = Merge.Sort(first, 0, first.Length - 1, out n, out f);
                            WriteLine(string.Join(" ", newarr));
                            WriteLine("Количество пересылок: {0}\nКоличество сравнений: {1}", n, f);
                            WriteLine("Сортировка второго массива");
                            newarr = Merge.Sort(second, 0, second.Length - 1, out n, out f);
                            WriteLine(string.Join(" ", newarr));
                            WriteLine("Количество пересылок: {0}\nКоличество сравнений: {1}", n, f);
                            WriteLine("Сортировка третьего массива");
                            newarr = Merge.Sort(third, 0, third.Length - 1, out n, out f);
                            WriteLine(string.Join(" ", newarr));
                            WriteLine("Количество пересылок: {0}\nКоличество сравнений: {1}", n, f);
                            GC.Collect();
                            break;
                        case 2:
                            WriteLine("Сортировка первого массива");
                            newarr = Counting.Sort(first, first[first.Length - 1], first[0]);
                            foreach (var t in newarr) Write(t + " ");
                            WriteLine("\nСортировка второго массива");
                            newarr = Counting.Sort(second, second[0], second[second.Length - 1]);
                            foreach (var t in newarr) Write(t + " ");
                            WriteLine("\nСортировка третьего массива");
                            int max = third[0], min = third[0];
                            for (var i = 1; i < third.Length; i++)
                            {
                                if (third[i] > max) max = third[i];
                                if (third[i] < min) min = third[i];
                            }
                            newarr = Counting.Sort(third, max, min);
                            foreach (var t in newarr) Write(t + " ");
                            WriteLine();
                            GC.Collect();
                            break;
                        case 3:
                            Clear();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                    }
                } while (!ok);
            } while (!okay);
        }
    }
}
