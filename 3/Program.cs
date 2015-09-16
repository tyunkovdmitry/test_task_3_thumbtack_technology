//Microsoft Visual Studio Professional 2013
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------Чтение множества из файла----------
            var line = File.ReadAllText("input.txt", Encoding.Default);
            line = Regex.Replace(line, @"-[^0-9]|[^0-9 \-]", String.Empty);
            var item = line.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            var n = item.Length;
            var sequence = new List<int>();
            for (var i = 0; i < n; i++)
                sequence.Add(Convert.ToInt32(item[i]));
            //---------------------------------------------

            //----------Вывод ответа является ли функция перестановкой последовательности натуральных чисел----------
            File.WriteAllText("output.txt", IsSequenceOfPositiveIntegers(sequence) ? "да" : "нет");
            //-------------------------------------------------------------------------------------------------------
        }

        /// <summary>
        /// Проверка последовательности на соответствие перестановке последовательности натуральных чисел
        /// </summary>
        /// <param name="sequence">Проверяемая последовательность</param>
        /// <returns></returns>
        static bool IsSequenceOfPositiveIntegers(List<int> sequence)
        {
            sequence.Sort();
            if (sequence[0] != 1)
                return false;
            for (var i = 1; i < sequence.Count; i++)
                if (sequence[i] - sequence[i - 1] != 1)
                    return false;
            return true;
        }
    }
}
