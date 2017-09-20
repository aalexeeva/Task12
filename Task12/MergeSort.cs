using System;
using System.Linq;

namespace Task12
{
    public class MergeSort
    {
        public static int[] Sort(int[] arr, int beg, int end, out int n, out int f) // сортировка слиянием 
        {
            n = 1; // количество сравнений
            f = 0; // количество пересылок
            int[] newArr; // отсортированный массив
            if (end - beg + 1 == 1) // для массива из одного элемента
            {
                newArr = new int[1];
                newArr[0] = arr[beg];
            }
            else // выполение разделения и слияния
            {
                // разделение массива
                newArr = new int[end - beg + 1];
                var middle = (beg + end) / 2; // поиск середины массива
                var left = Sort(arr, beg, middle, out var addn, out var addf); // сортировка левой части
                n += addn; f += addf; // увеличение показателей пересылок и сравнений
                var right = Sort(arr, middle + 1, end, out addn, out addf); // сортировка правой части
                n += addn; f += addf; // увеличение показателей пересылок и сравнений
                int lIndex = 0, rIndex = 0, sIndex = 0;
                while (lIndex < left.Length && rIndex < right.Length) // сравнение половин массивов
                {
                    n++; f++; // увеличение показателей пересылок и сравнений
                    if (left[lIndex] < right[rIndex]) // если левая половина больше правой
                    {
                        newArr[sIndex] = left[lIndex];
                        lIndex++;
                    }
                    else // если наоборот
                    {
                        newArr[sIndex] = right[rIndex];
                        rIndex++;
                    }
                    sIndex++;
                }
                if (lIndex != left.Length) // слияние полученных массивов
                    for (var i = lIndex; i < left.Length; i++, sIndex++, f++)
                        newArr[sIndex] = left[i];
                else if (rIndex != right.Length)
                {
                    for (var i = rIndex; i < right.Length; i++, sIndex++)
                        newArr[sIndex] = right[i];
                    f++;
                }
            }
            return newArr;
        }
    }
}