using System;

namespace Task12
{
    class CountingSort
    {
        public static int[] Sort(int[] arr, int max, int min)
        {
            int[] count = new int[max - min + 1]; // создание вспомогательного массива
            var z = 0;
            for (var i = 0; i < count.Length; i++) { count[i] = 0; } // заполнение вспомогательного массива нулями
            for (int i = 0; i < arr.Length; i++) { count[arr[i] - min]++; }
            for (var i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    arr[z] = i;
                    z++;
                }
            }
            return arr;
        }
    }
}
