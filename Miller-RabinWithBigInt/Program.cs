using System.Collections;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using ConsoleTables;

namespace Miller_RabinWithBigInt
{
    class Program
    {
        /// <summary>
        /// Генерирует случайное число указанной длины в битовом представлении,
        /// затем вызывает тест Миллера-Рабина для этого числа
        /// </summary>
        /// <param name="bitEnumLength">Длина битовой последовательности</param>
        /// <returns>1 - успех. 0 - простое число не было найдено</returns>
        private static int GenerateNumberAndStartTest(int bitEnumLength)
        {
            var byteArr = new byte[bitEnumLength / 8];
            var rnd = new Random();
            rnd.NextBytes(byteArr);

            var n = new BigInteger(byteArr);
            n = BigInteger.Abs(n);

            if (n % 2 == 0) n++;

            var res = MillerRabin.MillerRabinTest(n, 3);

            // Выполняем по 3 проверки для повышения точности
            if (res != "n - составное")
            {
                Console.WriteLine(res);
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Выводит в консоль первое попавшееся простое число заданной длины
        /// и количество итераций теста до него
        /// </summary>
        /// <param name="bitEnumLength">Длина числа в битовом представлении</param>
        private static void MainTask(int bitEnumLength)
        {
            while (MillerRabin.primeNumbers.Count != 1)
            {
                GenerateNumberAndStartTest(bitEnumLength);
            }
            BigInteger[] pNA = MillerRabin.primeNumbers.ToArray();
            int[] iCA = MillerRabin.iterationCounts.ToArray();

            Console.WriteLine($"Простое число = {pNA[0]}");
            Console.WriteLine($"Количество итераций до получения простого = {iCA[0]}");
        }
        static void Main()
        {
            Console.WriteLine("Введите длину числа в битовом представлении:");
            // Запрашиваем длину битовой последовательности у пользователя
            int dlina = Convert.ToInt32(Console.ReadLine());

            MainTask(dlina);
        }
    }
}