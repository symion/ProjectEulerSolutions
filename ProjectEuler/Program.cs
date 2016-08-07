using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Problem1.Answer();
            Problem2.Answer();
            Problem3.Answer();
            Problem4.Answer();
            Problem5.Answer();
            Problem6.Answer();
            Problem7.Answer();
            Console.Read();
        }
    }

    internal class Problem1
    {
        public static int Answer()
        {
            var total = 0;
            for (int x = 3; x < 1000; x++)
            {
                if (x%3 == 0 || x%5 == 0)
                {
                    total += x;
                }
            }
            Console.WriteLine($"Problem 1 answer is '{total}'");
            return total;
        }
    }

    internal class Problem2
    {
        public static int Answer()
        {
            var prev = 1;
            var curr = 1;
            var total = 0;
            var sequence = 2;
            while (curr <= 4000000)
            {
                var temp = curr;
                curr += prev;
                prev = temp;

                if (sequence == 3)
                {
                    sequence = 0;
                }

                if (++sequence == 3)
                {
                    total += curr;

                }
            }
            Console.WriteLine($"Problem 2 answer is '{total}'");
            return total;
        }
    }

    internal class Problem3
    {
        public static long Answer()
        {
            var start = DateTime.Now;
            const long TheNumber = 600851475143;
                // worst case seems to be powers of 2 such as 4611686018427387904 (2^62)
            var sqrt = Convert.ToInt64(Math.Sqrt(TheNumber));
            long largestPrimeFactor = 0;

            var factorList = GetFactors(TheNumber);

            if (factorList.Count == 2)
            {
                largestPrimeFactor = TheNumber;
            }
            else
            {
                for (var x = factorList.Count - 2; x > 0; x--)
                {
                    if (GetFactors(factorList[x]).Count == 2)
                    {
                        largestPrimeFactor = factorList[x];
                        break;
                    }
                }
            }

            Console.WriteLine(
                $"Problem 3 answer is '{largestPrimeFactor}' and finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds");
            return largestPrimeFactor;
        }

        public static List<long> GetFactors(long num)
        {
            var list = new List<long> {1};
            if (num > 1)
            {
                list.Add(num);
            }
            long posDivisor = 2;
            long sqrt = Convert.ToInt64(Math.Sqrt(num));

            while (posDivisor <= sqrt)
            {
                if (num%posDivisor == 0)
                {
                    list.Add(posDivisor);
                    list.Add(num/posDivisor);
                }
                posDivisor++;
            }
            list.Sort();
            return list;
        }

        public static bool IsPrime(long num)
        {
            for (long x = 2; x < num/2; x++)
            {
                if (num%x == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    internal class Problem4
    {
        public static long Answer()
        {
            var start = DateTime.Now;
            var highest = 0;
            var mtcand = 0;
            var mtplier = 0;
            for (int x = 999; x > 99; x--)
            {
                for (int y = 999; y > 99; y--)
                {
                    var current = x * y;
                    if (current <= highest)
                    {
                        break;
                    }

                    if (current.ToString() == new string(current.ToString().Reverse().ToArray()))
                    {
                        highest = current;
                        mtcand = x;
                        mtplier = y;
                    }
                }
            }

            Console.WriteLine(
                $"Problem 4 answer is '{highest}'. x was '{mtcand}' and y was '{mtplier}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds");
            return highest;
        }
    }

    internal class Problem5
    {
        public static BigInteger Answer()
        {
            var start = DateTime.Now;
            Func<ulong, BigInteger> SumOfIntegersUpToX = (num) => num*(num + 1)/2;

            Func<ulong, BigInteger> SumOfSquaresUpToX = (num) =>
            {
                BigInteger total = 0;
                for (BigInteger x = 1; x <= num; x++)
                {
                    total += (x * x);
                }
                return total;
            };
            var input = 100ul;
            var squareOfSum = SumOfIntegersUpToX(input);
            squareOfSum *= squareOfSum;
            var answer = squareOfSum - SumOfSquaresUpToX(input);

            Console.WriteLine(
                $"Problem 5 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds");
            Debug.WriteLine(
                $"Problem 5 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds");
            return answer;
        }
    }

    internal class Problem6
    {
        public static ulong Answer()
        {
            var start = DateTime.Now;

            var primeList = new List<ulong> {2};

            var current = 2ul;

            while (primeList.Count < 10001)
            {
                ++current;
                var prime = primeList.All(t => current%t != 0);
                if (prime)
                {
                    primeList.Add(current);
                }
            }
            var answer = primeList.Max();
            var answerText =
                $"Problem 6 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
            return answer;
        }
    }

    internal class Problem7
    {
        public static ulong Answer()
        {
            var start = DateTime.Now;
            var consecutiveDigits = 13;

            var longNumString =
                "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            var index = consecutiveDigits;
            var numQueue = new Queue<ulong>(longNumString.Substring(0, consecutiveDigits).Select(c => ulong.Parse(c.ToString())));

            Func<Queue<ulong>, ulong> findProduct = container =>
            {
                return container.Aggregate(0ul, (current, num) => current == 0 ? num : current*num);
            };
            var highestProduct = findProduct(numQueue);

            for (var x = consecutiveDigits; x < longNumString.Length; x++)
            {
                numQueue.Dequeue();
                numQueue.Enqueue(ulong.Parse(longNumString[x].ToString()));
                var product = findProduct(numQueue);
                if (product > highestProduct)
                {
                    highestProduct = product;
                }
            }

            var answerText =
                $"Problem 7 answer is '{highestProduct}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
            return highestProduct;
        }
    }
}
