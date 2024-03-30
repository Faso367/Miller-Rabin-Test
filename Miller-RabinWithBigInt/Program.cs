using System.Collections;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using ConsoleTables;

namespace Miller_RabinWithBigInt
{
    class Program
    {
        /*В каждой из работ запрашивать у пользователя 2 параметра: требуемый размер числа в битах и верхнюю границу вероятности ошибки.
          В зависимости от вероятности ошибки, программа вычисляет параметр надежности самостоятельно.
          В работах использовать классы модулярной арифметики больших чисел (должно работать правильно с числами до 2048 бит),
        можно использовать встроенные или подключаемые классы языков программирования.
        Тесты с малыми числами даны вам для самопроверки. Мне их показывать не нужно.*/

        private static void GenerateNumberAndStartTest(int bitEnumLength)
        {
            var byteArr = new byte[bitEnumLength / 8];
            var rnd = new Random();
            rnd.NextBytes(byteArr);

            var n = new BigInteger(byteArr);
            n = BigInteger.Abs(n);

            if (n % 2 == 0) n++;

            // Выполняем по 3 проверки для повышения точности
            MillerRabin.MillerRabinTest(n, 3);
        }


        private static void MainTask(int bitEnumLength)
        {
            while (MillerRabin.primeNumbers.Count < 10)
            {
                GenerateNumberAndStartTest(bitEnumLength);
            }
            BigInteger[] pNA = MillerRabin.primeNumbers.ToArray();
            int[] iCA = MillerRabin.iterationCounts.ToArray();

            var table = new ConsoleTable("N", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10");
            table.AddRow("p", pNA[0], pNA[1], pNA[2], pNA[3], pNA[4], pNA[5], pNA[6], pNA[7], pNA[8], pNA[9])
                 .AddRow("n", iCA[0], iCA[1], iCA[2], iCA[3], iCA[4], iCA[5], iCA[6], iCA[7], iCA[8], iCA[9]);

            Console.WriteLine(table);

            Func<int, BigInteger> Pi = (val) => BigInteger.Pow(2, val) / (BigInteger)BigInteger.Log(BigInteger.Pow(2, val));

            // Примерное количество простых x-битных
            var countPrimaryNumbers = Pi(bitEnumLength) - Pi(bitEnumLength - 1);
            // Количество всех чисел с такой длиной битовой последовательности
            var countAllNumbers = BigInteger.Pow(2, bitEnumLength - 1); // Так как первый бит всегда = 1

            var k = countAllNumbers / countPrimaryNumbers;

            Console.WriteLine($"Ожидаемое количество перебранных чисел до получения простого числа: {k}");
        }
        static void Main()
        {
            MainTask(1024);
            //Samoproverka();
        }
        
        

        public static void Samoproverka()
        {
            int[] simpleNumbers = [
                8363,
                1867,
                1657,
                1901,
                9781,
                1303,
                9049,
                5479,
                6673,
                8111
            ];

            int[] karmikleNumbers = [
                1105,
                8911,
                2465,
                6601,
                10585,
                2821,
                1729,
                15841,
                2821,
                52633
            ];

            int[] sostavnieNumbers = [
                625,
                1969,
                791,
                5705,
                3871,
                3445,
                2007,
                6105,
                6785,
                3621
            ];

            Console.WriteLine("Простые числа");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine(MillerRabin.MillerRabinTest(simpleNumbers[i], 1));
                }
            }

            Console.WriteLine("Числа Кармайкла");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine(MillerRabin.MillerRabinTest(karmikleNumbers[i], 1));
                }
            }

            Console.WriteLine("Составные, нечетные, не являющиеся числами Кармайкла");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine(MillerRabin.MillerRabinTest(sostavnieNumbers[i], 1));
                }
            }
        }
    }
}