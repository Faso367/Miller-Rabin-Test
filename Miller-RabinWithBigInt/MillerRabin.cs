using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Miller_RabinWithBigInt
{
    public static class MillerRabin
    {
        /// <summary>
        /// Генерирует случайное большое число в заданом диапазоне.
        /// Сама генерация происходит с помощью встроенного класса
        /// Затем соединяем куски через логическое И и сдвиги
        /// </summary> 
        /// <param name="random">Экземпляр класса Random</param>
        /// <param name="minValue">Первое значение диапазона (начало)</param>
        /// <param name="maxValue">Второе значение диапазона (конец)</param>
        /// <returns>Сгенерированное большое число</returns>
        public static BigInteger NextBigInteger(Random random, BigInteger minValue, BigInteger maxValue)
        {
            if (minValue > maxValue) throw new ArgumentException();
            if (minValue == maxValue) return minValue;
            BigInteger zeroBasedUpperBound = maxValue - 1 - minValue; 
            Debug.Assert(zeroBasedUpperBound.Sign >= 0);
            byte[] bytes = zeroBasedUpperBound.ToByteArray();
            Debug.Assert(bytes.Length > 0);
            Debug.Assert((bytes[bytes.Length - 1] & 0b10000000) == 0);

            byte lastByteMask = 0b11111111;
            for (byte mask = 0b10000000; mask > 0; mask >>= 1, lastByteMask >>= 1)
            {
                if ((bytes[bytes.Length - 1] & mask) == mask) break;
            }

            while (true)
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= lastByteMask;
                var result = new BigInteger(bytes);
                Debug.Assert(result.Sign >= 0);
                if (result <= zeroBasedUpperBound) return result + minValue;
            }
        }

        const double e = 0.25;
        public static List<BigInteger> primeNumbers = new();
        public static List<int> iterationCounts = new();

        /// <summary>
        /// Тест Миллера-Рабина
        /// </summary>
        /// <param name="n">нечётное число, проверяемое на простоту</param>
        /// <param name="t">параметр надёжности (количество итераций для одного числа)</param>
        /// <returns>n вероятно простое ИЛИ n точно составное</returns>
        public static string MillerRabinTest(BigInteger n, int t)
        {
            int tCopy = t;
            var nCopy = n - 1;
            BigInteger r;
            int s = 0;
            if (!nCopy.IsPowerOfTwo)
            {
                while (nCopy % 2 == 0)
                {
                    nCopy /= 2;
                    s += 1;
                }
                r = nCopy;
            }
            else
            {
                r = 1;
                s = Convert.ToInt32(Math.Log2((double)nCopy));
            }

            int iterCount = 1;
            int countUnits = 0;
            // Проверяет встретилась ли единица
            bool firstUnitAppeared = false;

            while (t > 0)
            {
                BigInteger[] bEnum = new BigInteger[s + 1];
                BigInteger end = n - 2;
                var a = NextBigInteger(new Random(), 2, end);

                bEnum[0] = BigInteger.ModPow(a, r, n);

                if (bEnum[0] == 1) countUnits++;

                for (int j = 1; j < s + 1; j++)
                {
                    bEnum[j] = BigInteger.ModPow(bEnum[j - 1], 2, n);
                    iterCount++;

                    // Если в последовательности встретилась единица
                    if (bEnum[j] == 1) countUnits++;

                    // Если мы еще не встретили ни одной единицы
                    if (firstUnitAppeared == false)
                    {
                        if (bEnum[j] == 1)
                        {
                            firstUnitAppeared = true;
                            // Если перед первой единицей стоит -1
                            if (bEnum[j - 1] == -1) return "n - составное";
                        }

                    }

                }
                // Если в последовательности не встретилось единиц
                if (countUnits == 0) return "n - составное";

                t--;
            }

            if (primeNumbers.Count < 10)
                primeNumbers.Add(n);

            if (iterationCounts.Count < 10)
                iterationCounts.Add(iterCount);

            return $"n - простое с вероятностью {1 - Math.Pow(e, tCopy)}";

        }
    }
}
