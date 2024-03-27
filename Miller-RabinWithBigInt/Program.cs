using System.Collections;
using System.Diagnostics;
using System.Numerics;


class Program
{
    /*В каждой из работ запрашивать у пользователя 2 параметра: требуемый размер числа в битах и верхнюю границу вероятности ошибки.
      В зависимости от вероятности ошибки, программа вычисляет параметр надежности самостоятельно.
      В работах использовать классы модулярной арифметики больших чисел (должно работать правильно с числами до 2048 бит),
    можно использовать встроенные или подключаемые классы языков программирования.
    Тесты с малыми числами даны вам для самопроверки. Мне их показывать не нужно.*/

    //    private static int CreateRandomNumber(int start, int end) =>
    //        new Random().Next(start, end);

    //private static int SmallEulerFunction(int n)
    //{

    //}


    // Function to return GCD of a and b
    //static int NOD(int a, int b)
    //{
    //    if (a == 0)
    //        return b;
    //    return NOD(b % a, a);
    //}

    // A simple method to evaluate
    // Euler Totient Function
    //static int EulerFunction(int n)
    //{
    //    //Func<int, int, int> NOD = (a, b) => a == 0 ? b


    //    int result = 1;
    //    for (int i = 2; i < n; i++)
    //        if (NOD(i, n) == 1)
    //            result++;
    //    return result;
    //}

    /// <summary>
    /// Метод получает на вход 3 числа
    /// </summary>
    /// <param name="s, r">Числа для создания n, где s>=0, r - нечетное</param>
    /// <param name="e">Значение для определения параметра надёжности</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    //public static string MillerRabinTest(ushort s, int r, double maxErrorKoef)
    /*
    public static string MillerRabinTest(int n, double maxErrorKoef)
    {
        Func<int, bool> IsPowerOf2 = n => n > 0 && (n & -n) == n;

        //while (!IsPowerOf2(nCopy)) {}
        int nCopy = n - 1;
        int r;
        int s = 0;
        if (!IsPowerOf2(nCopy))
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
            s = Convert.ToInt32(Math.Log2(Convert.ToDouble(nCopy)));
        }

        // Тупой способ


        if (r % 2 == 0) throw new ArgumentException("Входной параметр r должен быть нечётными");

        //int n = (2^s) * r + 1;

        // Находим е (макс ошибку для одной итерации)
        double e = EulerFunction(n) / 4 * n;

        // Находим t (количество итераций теста) в зависимости от макс ошибки
        int t = 0;
        while (e < maxErrorKoef)
        {
            t++;
            e *= t;
        }

        int a = new Random().Next(2, n - 2);

        int[] bEnum = new int[s];
        bEnum[0] = (a ^ r) % n;

        int iterCount = 0;

        while (t > 0) {
            for (int j = 1; j < s; j++)
            {
                bEnum[j] = (bEnum[j - 1] ^ 2) % n;
                iterCount++;
                if (bEnum[j] == 1 && bEnum[j - 1] == -1)
                {
                    Console.WriteLine("Количество перебранных чисел до получения простого: " + iterCount);
                    Console.WriteLine($"n = {n}");
                    return $"n - простое с вероятностью{Math.Pow(e, t)}";
                }

            }
            t--;
        }
        Console.WriteLine("Количество перебранных чисел до получения простого: " + iterCount);
        Console.WriteLine($"n = {n}");
        return "n - составное";
    }*/

    // Тупое решение
    // Если первый ненулевой бит числа а = 1, а числа b = 0, значит a > b



    /// <summary>
    /// Метод выполняет деление с остатком для битовых последовательностей
    /// </summary>
    /// <param name="a">Делимое</param>
    /// <param name="b">Делитель</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /*
    private static BitArray MOD(BitArray a, BitArray b)
    {
        int lenA = a.Length;
        int lenB = b.Length;
        BitArray k = a;

        if (lenA > 2 * lenB)
        {
            BitArray g = b.LeftShift(lenA - lenB);
            if (g > k)
    }


    }*/

    /*
    public static string MillerRabinTest(BitArray n, double maxErrorKoef)
    {
        Func<int, bool> IsPowerOf2 = n => n > 0 && (n & -n) == n;

        //while (!IsPowerOf2(nCopy)) {}
        int nCopy = n - 1;
        int r;
        int s = 0;
        if (!IsPowerOf2(nCopy))
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
            s = Convert.ToInt32(Math.Log2(Convert.ToDouble(nCopy)));
        }

        // Тупой способ


        if (r % 2 == 0) throw new ArgumentException("Входной параметр r должен быть нечётными");

        //int n = (2^s) * r + 1;

        // Находим е (макс ошибку для одной итерации)
        double e = EulerFunction(n) / 4 * n;

        // Находим t (количество итераций теста) в зависимости от макс ошибки
        int t = 0;
        while (e < maxErrorKoef)
        {
            t++;
            e *= t;
        }

        int a = new Random().Next(2, n - 2);

        int[] bEnum = new int[s];
        bEnum[0] = (a ^ r) % n;

        int iterCount = 0;

        while (t > 0)
        {
            for (int j = 1; j < s; j++)
            {
                bEnum[j] = (bEnum[j - 1] ^ 2) % n;
                iterCount++;
                if (bEnum[j] == 1 && bEnum[j - 1] == -1)
                {
                    Console.WriteLine("Количество перебранных чисел до получения простого: " + iterCount);
                    Console.WriteLine($"n = {n}");
                    return $"n - простое с вероятностью{Math.Pow(e, t)}";
                }

            }
            t--;
        }
        Console.WriteLine("Количество перебранных чисел до получения простого: " + iterCount);
        Console.WriteLine($"n = {n}");
        return "n - составное";
    }*/




    /// <summary>
    /// Returns a random BigInteger that is within a specified range.
    /// The lower bound is inclusive, and the upper bound is exclusive.
    /// </summary>
    //public static BigInteger NextBigInteger(this Random random, BigInteger minValue, BigInteger maxValue)
    public static BigInteger NextBigInteger(Random random, BigInteger minValue, BigInteger maxValue)
    {
        if (minValue > maxValue) throw new ArgumentException();
        if (minValue == maxValue) return minValue;
        BigInteger zeroBasedUpperBound = maxValue - 1 - minValue; // Inclusive
        Debug.Assert(zeroBasedUpperBound.Sign >= 0);
        byte[] bytes = zeroBasedUpperBound.ToByteArray();
        Debug.Assert(bytes.Length > 0);
        Debug.Assert((bytes[bytes.Length - 1] & 0b10000000) == 0);

        // Search for the most significant non-zero bit
        byte lastByteMask = 0b11111111;
        for (byte mask = 0b10000000; mask > 0; mask >>= 1, lastByteMask >>= 1)
        {
            if ((bytes[bytes.Length - 1] & mask) == mask) break; // We found it
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


    public static BigInteger Sqrt(BigInteger n)
    {
        if (n == 0) return 0;
        if (n > 0)
        {
            int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
            BigInteger root = BigInteger.One << (bitLength / 2);

            while (!isSqrt(n, root))
            {
                root += n / root;
                root /= 2;
            }

            return root;
        }

        throw new ArithmeticException("NaN");
    }

    private static bool isSqrt(BigInteger n, BigInteger root)
    {
        BigInteger lowerBound = root * root;
        BigInteger upperBound = (root + 1) * (root + 1);

        return (n >= lowerBound && n < upperBound);
    }


    public static BigInteger EulerFunction(BigInteger n)
    {
        //Func<int, int, int> NOD = (a, b) => a == 0 ? b

        Console.WriteLine("Выполняем функцию Эйлера...");

        // Initialize result as n
        //float result = n;

        var result = n;

        // Consider all prime factors
        // of n and for every prime 
        // factor p, multiply result
        // with (1 - 1 / p)
        for (BigInteger p = 2; p * p <= n; ++p)
        {

            // Check if p is a prime factor.
            if (n % p == 0)
            {

                // If yes, then update
                // n and result
                while (n % p == 0)
                    n /= p;
                //result *= (float)(1.0 - (1.0 / (float)p));
                result = result * (1 - 1 / p);
            }
        }

        // If n has a prime factor 
        // greater than sqrt(n)
        // (There can be at-most 
        // one such prime factor)
        if (n > 1)
            result -= result / n;
        //Since in the set {1,2,....,n-1}, all numbers are relatively prime with n
        //if n is a prime number

        return result;
    }

    public static BigInteger BinaryPow(BigInteger baseNumber, BigInteger exponent)
    {
        Console.WriteLine("Возедение в степень...");
        BigInteger result = 1;
        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
                result *= baseNumber;
            baseNumber *= baseNumber;
            exponent >>= 1;
        }
        Console.WriteLine($"result = {result}");
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x">Число возводимое в степень</param>
    /// <param name="y">Степень</param>
    /// <returns></returns>
    public static BigInteger DihatomicPow(BigInteger x, BigInteger y)
    {
        BigInteger z = x;
        //var byteY = y.ToByteArray();
        var bitY = new BitArray(y.ToByteArray());
        for (int i = bitY.Length - 2; i > 0; i--)
        {
            z = z * z;
            if (bitY[i] == true) z = z * x;
        }
        Console.WriteLine("Число было возведено в степень");
        return z;
    }

    //return 


    //var sqrt = Sqrt(n);
    //Console.WriteLine($"Корень = {sqrt}");
    //BigInteger result = 1;
    //for (uint i = 2; i < sqrt; i++)
    //    if (BigInteger.GreatestCommonDivisor(n, i) == 1) result++;


    //static bool IsPrimeNumber(BigInteger number)
    //{
    //    var sqrtNumber = BigInteger.Pow(number, -2);
    //    for (int i = 2; i <= sqrtNumber; i++)
    //    {
    //        if (number % i == 0)
    //            return false;
    //    }
    //    return true;
    //}

    //int count = 0;

    //for (BigInteger i = 2; i <= n; i++)
    //{
    //    var sqrtNumber = BigInteger.Pow(number, -2);
    //    for (int i = 2; i <= sqrtNumber; i++)
    //    {
    //        if (number % i == 0)
    //            return false;
    //    }
    //    return true;


    //    if (IsPrimeNumber(i))
    //    {
    //        count++;
    //        // Console.Write(num.ToString()+","); // можно вывести на экран
    //    }
    //}

    //return result;


    const double e = 0.25;
    //public static List<int> primeNumbers;
    //public static Dictionary<BigInteger, int> primeNumbers;
    public static List<BigInteger> primeNumbers;
    public static List<int> iterationCounts;

    public static string MillerRabinTest(BigInteger n, int t)
    {
        //Func<BigInteger, bool> IsPowerOf2 = n => n > 0 && (n & -n) == n;

        //while (!IsPowerOf2(nCopy)) {}
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
                //Console.WriteLine(nCopy.ToString());
            }
            r = nCopy;
        }
        else
        {
            r = 1;
            s = Convert.ToInt32(Math.Log2((double)nCopy));
        }

        //Console.WriteLine($"r = {r}");
        //Console.WriteLine("Вероятность ошибки = " + e.ToString());
        //Console.WriteLine($"t = {t}");
        //Console.WriteLine($"a = {a}");
        //Console.WriteLine($"s = {s}");

        int iterCount = 1;
        int countUnits = 0;
        // Проверяет встретилась ли единица
        bool firstUnitAppeared = false;

        while (t > 0)
        {
            BigInteger[] bEnum = new BigInteger[s + 1];
            BigInteger end = n - 2;
            var a = NextBigInteger(new Random(), 2, end);

            //bEnum[0] = BinaryPow(a, r) % n;
            bEnum[0] = DihatomicPow(a, r) % n;
            //Console.WriteLine(r);
            //bEnum[0] = BigInteger.Pow(a, (int)r) % n; // !!!!!!!!!!!!!!!!!!!

            //Console.WriteLine($"b0 = {bEnum[0]}");

            if (bEnum[0] == 1) countUnits++;

            for (int j = 1; j < s + 1; j++)
            {

                bEnum[j] = BigInteger.Pow(bEnum[j - 1], 2) % n;
                iterCount++;

                //Console.WriteLine($"b{j} = {bEnum[j]}");

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
        //Console.WriteLine("Количество перебранных чисел до получения простого: " + iterCount);
        //Console.WriteLine($"n = {n}");


        //countPrimeNumbers++;
        primeNumbers.Add(n);
        iterationCounts.Add(iterCount);
        return $"n - простое с вероятностью {1 - Math.Pow(e, tCopy)}";

    }


    private static void Section2Task()
    {
        var byteArr = new byte[16];
        var rnd = new Random();
        rnd.NextBytes(byteArr);
        byteArr[0] = 1;

        var n = new BigInteger(byteArr);
        n = BigInteger.Abs(n);

        if (n % 2 == 0) n++;

        Console.WriteLine(MillerRabinTest(n, 5));

    }
    //private static void Section2Task()
    //{
    //    string bitStr = "1";
    //    int bitStrLength = 127;
    //    var randBit = new Random();

    //    for (; bitStrLength > 0; bitStrLength--)
    //    {
    //        bitStr += randBit.Next(0, 1);
    //    }
    //    Console.WriteLine(bitStr);


    //    MillerRabinTest(Convert.ToInt32(bitStr), 0.1);
    //}


    static void Main()
    {
        //BigInteger x = 12345678912345678912;

        //Console.WriteLine(DihatomicPow(x, 777));

        for (int i = 0; i < 100; i++)
        {
            Section2Task();
            if (primeNumbers.Count >= 10)
            {

                BigInteger[] primeNumbersArr = primeNumbers.ToArray();
                int[] iterCountsArr = iterationCounts.ToArray();

                for (int l = 0; l < 3; l++)
                {
                    if (l == 0)
                        Console.WriteLine("N");

                    if (l == 1)
                        Console.WriteLine("p");

                    if (l == 2)
                        Console.WriteLine("n");

                    for (int j = 0; j < 10; j++)
                    {
                        if (l == 0)
                            Console.Write(j);

                        if (l == 1)
                            Console.Write(primeNumbersArr[j]);

                        if (l == 2)
                            Console.Write(iterCountsArr[j]);
                    }
                }
                break;
            }

        }



        //Samoproverka();
        //Console.WriteLine(MillerRabinTest(65, 5));


        //Console.WriteLine("Введите длину битовой строки");
        //int bitStrLength = Convert.ToInt32(Console.ReadLine());
        //string bitStr = "";

        //var randBit = new Random();

        //for (; bitStrLength > 0; bitStrLength--)
        //{
        //    bitStr += randBit.Next(0, 1);
        //}


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
                Console.WriteLine(MillerRabinTest(simpleNumbers[i], 1));
            }
        }

        Console.WriteLine("Числа Кармайкла");
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine(MillerRabinTest(karmikleNumbers[i], 1));
            }
        }

        Console.WriteLine("Составные, нечетные, не являющиеся числами Кармайкла");
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine(MillerRabinTest(sostavnieNumbers[i], 1));
            }
        }
    }
}
//}


// Для 128 битного числа достаточно сгенерить всего 7 int чисел
// 1 СПОСОБ

//var intArr = new int[7];

//var randBit = new Random();

//for (int i = 0; i < intArr.Length; i++)
//{
//    intArr[i] = randBit.Next(0, 100000);
//}
//BitArray BitArr = new BitArray(intArr);


/*
//int[] choices = [0, 1];
//Span<int> span = choices;
//int[] n = new Random().GetItems<int>(span, 128);
*/
// 2 СПОСОБ


//rnd.Next(x);

//bool[] choices = [false, true];
//Span<bool> span = choices;
//bool[] n = new Random().GetItems<bool>(span, 128);
