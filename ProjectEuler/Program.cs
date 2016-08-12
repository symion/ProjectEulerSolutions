﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            //Problem1.Answer();
            //Problem2.Answer();
            //LargestPrimeFactor_3.Answer();
            //SpecialPythagoreanTriplet_4.Answer();

            //Problem6.Answer();
            //ThousandAndFirstPrime.Answer();
            //Problem8.Answer();
            //Problem9.Answer();
            //SummationOfPrimes_10.Answer();
            //LargestProductInAGrid_11.Answer();
            //TriangleNumbers_12.Answer();
            //LargeSum_13.Answer();
            //LongestCollatzsSequence_14.Answer();
            //LatticePaths_15.Answer();
            //PowerDigitSum_16.Answer();
            NumberLetterCounts_17.Answer();
            Console.Read();
        }
    }

    internal class MultiplesOf3And5_1
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

    internal class EvenFibonacciNumbers2
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

    internal class LargestPrimeFactor_3
    {
        public static ulong Answer()
        {
            // TODO: improve using Miller-Rabin algorithm
            var start = DateTime.Now;
            const long TheNumber = 600851475143;
            // worst case seems to be powers of 2 such as 4611686018427387904 (2^62)
            var sqrt = Convert.ToInt64(Math.Sqrt(TheNumber));
            ulong largestPrimeFactor = 0;

            var factorList = MathHelpers.GetFactors(TheNumber);

            if (factorList.Count == 2)
            {
                largestPrimeFactor = TheNumber;
            }
            else
            {
                for (var x = factorList.Count - 2; x > 0; x--)
                {
                    if (MathHelpers.GetFactors(factorList[x]).Count == 2)
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

    }

    internal class SpecialPythagoreanTriplet_4
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
                    var current = x*y;
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

    internal class SumSquareDifference_6
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
                    total += (x*x);
                }
                return total;
            };
            var input = 100ul;
            var squareOfSum = SumOfIntegersUpToX(input);
            squareOfSum *= squareOfSum;
            var answer = squareOfSum - SumOfSquaresUpToX(input);

            Console.WriteLine(
                $"Problem 6 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds");
            Debug.WriteLine(
                $"Problem 6 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds");
            return answer;
        }
    }

    internal class ThousandAndFirstPrime_7
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
                $"Problem 7 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
            return answer;
        }
    }

    internal class LargestProductInASeries_8
    {
        public static ulong Answer()
        {
            var start = DateTime.Now;
            var consecutiveDigits = 13;

            var longNumString =
                "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            var index = consecutiveDigits;
            var numQueue =
                new Queue<ulong>(longNumString.Substring(0, consecutiveDigits).Select(c => ulong.Parse(c.ToString())));

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
                $"Problem 8 answer is '{highestProduct}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
            return highestProduct;
        }
    }

    internal class SpecialPythagoreanTriplet_9
    {
        public static ulong Answer()
        {
            var start = DateTime.Now;

            //var a = 1;
            //var b = 2;
            //var c = 3;
            ulong opcount = 0;
            for (var a = 1ul; a < 1000; a++)
            {
                for (var b = a + 1; b < 1000; b++)
                {
                    for (var c = b + 1; c < 1000; c++)
                    {
                        opcount++;
                        if (a + b + c > 1000)
                        {
                            break;
                        }

                        if ((a + b + c == 1000) && (a*a + b*b == c*c))
                        {
                            var product = a*b*c;
                            var answerText =
                                $"Problem 7 answer is '{product}'. a = {a}, b = {b}, and c = {c}.\nOperations = {opcount}.\nAlgorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
                            Console.WriteLine(answerText);
                            Debug.WriteLine(answerText);
                            return product;
                        }
                    }
                    if (a + b >= 1000)
                    {
                        break;
                    }
                }
            }
            throw new ApplicationException("Couldn't find answer.");
        }
    }

    internal class SummationOfPrimes_10
    {
        public static ulong Answer()
        {
            var start = DateTime.Now;

            var primeList = new List<ulong> {2};

            var current = 3ul;

            while (current < 2000000)
            {
                var prime = MathHelpers.ProbablyPrimeMiller_Rabin(current);
                if (prime)
                {
                    primeList.Add(current);
                }
                current += 2;
            }
            ulong answer = primeList.Aggregate<ulong, ulong>(0, (current1, value) => current1 + value);

            var answerText =
                $"Problem 10 answer is '{answer}'.\nNumber of primes was {primeList.Count}.\nAlgorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
            return answer;
        }
    }

    internal class LargestProductInAGrid_11
    {
        private const int SquareArrayLength = 20;
        private static ulong[,] _grid = new ulong[SquareArrayLength,SquareArrayLength]
        {
            { 08ul,02ul,22ul,97ul,38ul,15ul,00ul,40ul,00ul,75ul,04ul,05ul,07ul,78ul,52ul,12ul,50ul,77ul,91ul,08ul},
            { 49ul,49ul,99ul,40ul,17ul,81ul,18ul,57ul,60ul,87ul,17ul,40ul,98ul,43ul,69ul,48ul,04ul,56ul,62ul,00ul},
            { 81ul,49ul,31ul,73ul,55ul,79ul,14ul,29ul,93ul,71ul,40ul,67ul,53ul,88ul,30ul,03ul,49ul,13ul,36ul,65ul},
            { 52ul,70ul,95ul,23ul,04ul,60ul,11ul,42ul,69ul,24ul,68ul,56ul,01ul,32ul,56ul,71ul,37ul,02ul,36ul,91ul},
            { 22ul,31ul,16ul,71ul,51ul,67ul,63ul,89ul,41ul,92ul,36ul,54ul,22ul,40ul,40ul,28ul,66ul,33ul,13ul,80ul},
            { 24ul,47ul,32ul,60ul,99ul,03ul,45ul,02ul,44ul,75ul,33ul,53ul,78ul,36ul,84ul,20ul,35ul,17ul,12ul,50ul},
            { 32ul,98ul,81ul,28ul,64ul,23ul,67ul,10ul,26ul,38ul,40ul,67ul,59ul,54ul,70ul,66ul,18ul,38ul,64ul,70ul},
            { 67ul,26ul,20ul,68ul,02ul,62ul,12ul,20ul,95ul,63ul,94ul,39ul,63ul,08ul,40ul,91ul,66ul,49ul,94ul,21ul},
            { 24ul,55ul,58ul,05ul,66ul,73ul,99ul,26ul,97ul,17ul,78ul,78ul,96ul,83ul,14ul,88ul,34ul,89ul,63ul,72ul},
            { 21ul,36ul,23ul,09ul,75ul,00ul,76ul,44ul,20ul,45ul,35ul,14ul,00ul,61ul,33ul,97ul,34ul,31ul,33ul,95ul},
            { 78ul,17ul,53ul,28ul,22ul,75ul,31ul,67ul,15ul,94ul,03ul,80ul,04ul,62ul,16ul,14ul,09ul,53ul,56ul,92ul},
            { 16ul,39ul,05ul,42ul,96ul,35ul,31ul,47ul,55ul,58ul,88ul,24ul,00ul,17ul,54ul,24ul,36ul,29ul,85ul,57ul},
            { 86ul,56ul,00ul,48ul,35ul,71ul,89ul,07ul,05ul,44ul,44ul,37ul,44ul,60ul,21ul,58ul,51ul,54ul,17ul,58ul},
            { 19ul,80ul,81ul,68ul,05ul,94ul,47ul,69ul,28ul,73ul,92ul,13ul,86ul,52ul,17ul,77ul,04ul,89ul,55ul,40ul},
            { 04ul,52ul,08ul,83ul,97ul,35ul,99ul,16ul,07ul,97ul,57ul,32ul,16ul,26ul,26ul,79ul,33ul,27ul,98ul,66ul},
            { 88ul,36ul,68ul,87ul,57ul,62ul,20ul,72ul,03ul,46ul,33ul,67ul,46ul,55ul,12ul,32ul,63ul,93ul,53ul,69ul},
            { 04ul,42ul,16ul,73ul,38ul,25ul,39ul,11ul,24ul,94ul,72ul,18ul,08ul,46ul,29ul,32ul,40ul,62ul,76ul,36ul},
            { 20ul,69ul,36ul,41ul,72ul,30ul,23ul,88ul,34ul,62ul,99ul,69ul,82ul,67ul,59ul,85ul,74ul,04ul,36ul,16ul},
            { 20ul,73ul,35ul,29ul,78ul,31ul,90ul,01ul,74ul,31ul,49ul,71ul,48ul,86ul,81ul,16ul,23ul,57ul,05ul,54ul},
            { 01ul,70ul,54ul,71ul,83ul,51ul,54ul,69ul,16ul,92ul,33ul,48ul,61ul,43ul,52ul,01ul,89ul,19ul,67ul,48ul}
        };

        private static ulong[] _topResult;
        private static ulong _maxProduct;

        public static ulong Answer()
        {
            var start = DateTime.Now;
            _topResult = new ulong[]{ 0, 0, 0, 0 };
            _maxProduct = 0;

            // Horizontal section
            for (var row = 0; row < SquareArrayLength; row++)
            {
                ulong[] current = new[]
                    {_grid[row, 0], _grid[row, 1], _grid[row, 2], 0ul};
                var replace = 3;
                for (var column = 3; column < SquareArrayLength; column++)
                {
                    TestValue(current, ref replace, row, column);
                }
            }

            //Vertical section
            for (var column = 0; column < SquareArrayLength; column++)
            {
                ulong[] current = new[]
                {_grid[0, column], _grid[1, column], _grid[2, column], 0ul};
                var replace = 3;
                for (var row = 3; row < SquareArrayLength; row++)
                {
                    TestValue(current, ref replace, row, column);
                }
            }

            var startRow = 16;
            var startColumn = 0;
            while (startColumn < SquareArrayLength - 4)
            {
                ulong[] current = new[]
                {
                    _grid[startRow, startColumn], _grid[startRow + 1, startColumn + 1],
                    _grid[startRow + 2, startColumn + 2], 0ul
                };
                var replace = 3;
                for (var row = startRow + 3; row < SquareArrayLength && (startColumn + row - startRow < SquareArrayLength); row++)
                {
                    TestValue(current, ref replace, row, startColumn + row - startRow);
                }

                startColumn = startRow > 0 ? 0 : startColumn + 1;
                startRow = startRow > 0 ? startRow - 1 : startRow;
            }

            startRow = 3;
            startColumn = 0;
            while (startColumn < SquareArrayLength - 4)
            {
                ulong[] current = new[]
                {
                    _grid[startRow, startColumn], _grid[startRow - 1, startColumn + 1],
                    _grid[startRow - 2, startColumn + 2], 0ul
                };
                var replace = 3;
                for (var row = startRow - 3; row >= 0 && (startColumn + startRow - row) < SquareArrayLength; row--)
                {
                    TestValue(current, ref replace, row, startColumn + startRow - row);
                }

                startColumn = startRow < 19 ? 0 : startColumn + 1;
                startRow = startRow < 19 ? startRow + 1 : startRow;
            }



            var answerText =
                $"Problem 11 answer is {_maxProduct}. Value1: {_topResult[0]}, Value2: {_topResult[1]}, Value3: {_topResult[2]}, Value4: {_topResult[3]}.\nAlgorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";

            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
            return _maxProduct;
        }

        private static void TestValue(ulong[] current, ref int replace, int row, int column)
        {
            current[replace] = _grid[row, column];
            replace = replace < 3 ? replace + 1 : 0;
            var currentProduct = 1ul;
            foreach (var value in current)
            {
                if (value == 0)
                {
                    currentProduct = 0;
                    break;
                }
                currentProduct *= value;
            }

            if (currentProduct > _maxProduct)
            {
                current.CopyTo(_topResult, 0);
                _maxProduct = currentProduct;
            }
        }
    }

    internal class TriangleNumbers_12
    {
        public static ulong Answer()
        {
            var start = DateTime.Now;

            var triangelList = new List<ulong> { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55 };
            var lastTriangleBase = 10ul;
            var lastTriangleNum = 55ul;

            var numfactors = MathHelpers.GetFactors(lastTriangleNum).Count;

            while (numfactors <= 500)
            {
                lastTriangleBase++;
                lastTriangleNum = (lastTriangleBase*(lastTriangleBase + 1))/2;
                numfactors = MathHelpers.GetFactors(lastTriangleNum).Count;
            }

            var answerText =
                $"Problem 12 answer is '{lastTriangleNum}'.\nAlgorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
            return lastTriangleNum;
        }
    }

    internal class LargeSum_13
    {
        public static string Answer()
        {
            var start = DateTime.Now;
            List<string> numStrings = new List<string>();
            using (var streamReader = new StreamReader("ProblemSpecificFiles/EulerProblem13.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    numStrings.Add(streamReader.ReadLine());
                }
            }

            //Only need the first 12 digits to calculate the first 10 digits of the answer. 
            // Digits less significant than that will not contribute.
            var intList = numStrings.Select(ns => ulong.Parse(ns.Substring(0, 12)));

            //var answer = intList.Aggregate(0ul, (total, next) => total + next).ToString().Substring(0, 10);
            var answer = intList.Aggregate(0ul, (total, next) => total + next);
            while (answer > 9999999999)
            {
                answer /= 10;
            }

            var answerText =
                $"Problem 13 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
            return answerText;
        }
    }

    internal class LongestCollatzsSequence_14
    {
        public static void Answer()
        {
            var numArray = new int[2000000];
            var start = DateTime.Now;
            var answer = 1ul;
            var length = 1;

            for (uint num = 2; num < 1000000; num++)
            {
                var cLength = MathHelpers.FindCollatzsLength(num, numArray);
                if (cLength > length)
                {
                    answer = num;
                    length = cLength;
                }
                //if (num <= 101)
                //{
                //    numArray[num - 2] = cLength;
                //}
            }
            
            var answerText =
                $"Problem 14 answer is '{answer}', length was '{length}'. Algorithm finished in {Convert.ToInt64(DateTime.Now.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);

            //for (int x = 0; x < 100; x++)
            //{
            //    Debug.WriteLine($"{x+2}: {numArray[x]}");
            //}
        }
    }

    internal class LatticePaths_15
    {
        private static ulong[,] _gridPaths;
        public static void Answer()
        {
            var gridSize = 20u;
            _gridPaths = new ulong[gridSize + 1, gridSize + 1];
            var start = DateTime.Now;
            var answer = GetPathsRecursive(gridSize, gridSize);
            var endTime = DateTime.Now;
            var answerText =
                $"Problem 15 answer is '{answer}' for grid size:{gridSize}. Algorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);

        }

        private static ulong GetPathsRecursive(ulong x, ulong y)
        {
            if (x == 0 || y == 0)
            {
                return 1;
            }

            if (_gridPaths[x, y] != default(ulong))
            {
                return _gridPaths[x, y];
            }

            return _gridPaths[x, y] = GetPathsRecursive(x, y - 1) + GetPathsRecursive(x - 1, y);
        }
    }

    internal class PowerDigitSum_16
    {
        public static void Answer()
        {
            var start = DateTime.Now;
            BigInteger num = 1;
            num <<= 1000;
            var numString = num.ToString();
            var total = 0;
            foreach (var character in numString)
            {
                total += int.Parse(character.ToString());
            }
            var endTime = DateTime.Now;
            var answerText =
                $"Problem 16 answer is '{total}'. Algorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);

        }
    }

    internal class NumberLetterCounts_17
    {
        private Dictionary<int, int> LettersPerNumber = new Dictionary<int, int>
        {
            {1, "one".Length},
            {2, "two".Length},
            {3, "three".Length},
            {4, "four".Length},
            {5, "five".Length},
            {6, "six".Length},
            {7, "seven".Length},
            {8, "eight".Length},
            {9, "nine".Length},
            {10, "ten".Length},
            {11, "eleven".Length},
            {12, "twelve".Length},
            {13, "thirteen".Length}
        };

        private static ulong CountLettersInNumber(uint number)
        {
            var total = 0ul;
            
            return total;
        }
        public static void Answer()
        {
            var start = DateTime.Now;
            var total = 212%20;
            var endTime = DateTime.Now;
            var answerText =
                $"Problem 16 answer is '{total}'. Algorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);

        }
    }

    public struct U2DPoint
    {
        public U2DPoint(ulong x, ulong y)
        {
            X = x;
            Y = y;
        }
        public ulong X { get; set; }
        public ulong Y { get; set; }
    }

    static class MathHelpers
    {
        public static int FindCollatzsLength(ulong originalNum, int[] numArray)
        {
            var length = 1;
            if (numArray[originalNum] != default(int))
            {
                return numArray[originalNum];
            }

            var num = originalNum;
            var foundInArray = false;

            while (num > 1)
            {
                if ((num & 1) == 0)
                {
                    num >>= 1;
                }
                else
                {
                    num = 3*num + 1;
                }
                if (num < (ulong)numArray.Length && numArray[num] != default(int))
                {
                    foundInArray = true;
                    break;
                }
                ++length;
            }

            if (foundInArray)
            {
                numArray[originalNum] = length + numArray[num];
                return length + numArray[num];
            }
            else
            {
                numArray[originalNum] = length;
                return length;
            }
        }
        public static List<ulong> GetFactors(ulong num)
        {
            var list = new List<ulong> { 1 };
            if (num > 1)
            {
                list.Add(num);
            }
            ulong posDivisor = 2;
            ulong sqrt = Convert.ToUInt64(Math.Sqrt(num));

            while (posDivisor <= sqrt)
            {
                if (num % posDivisor == 0)
                {
                    list.Add(posDivisor);
                    list.Add(num / posDivisor);
                }
                posDivisor++;
            }
            list.Sort();
            return list;
        }

        public static ulong ModulusOfPower(ulong b, ulong e, ulong mod)
        {
            if (mod == 1)
            {
                return 0;
            }
            //Assert :: (modulus - 1) * (modulus - 1) does not overflow base
            var result = 1ul;
            b = b%mod;
            while (e > 0)
            {
                if (e%2 == 1)
                {
                    result = (result*b)%mod;
                }
                e = e >> 1;
                b = (b*b)%mod;
            }
            return result;
        }
        public static bool ProbablyPrimeMiller_Rabin(ulong num)
        {
            if ((num & 1) == 0 || num < 2)
            {
                return false;
            }
            var witnesses = GetMillerRabinWitnesses(num);

            var d = num - 1;

            var r = 0ul;

            //write n − 1 as 2^r·d with d odd by factoring powers of 2 from n − 1
            while ((d & 1) == 0)
            {
                d >>= 1;
                r++;
            }

            foreach (var a in witnesses)
            {
                //   x ← a^d mod n
                //   if x = 1 or x = n − 1 then
                //      continue WitnessLoop
                var x = ModulusOfPower(a, d, num);
                if (x == 1)
                {
                    continue;
                }
                //   repeat r − 1 times:
                for (var index = 1ul; index < r && (x != num - 1); index++)
                {
                    //      x ← x^2 mod n
                    x = ModulusOfPower(x, 2, num);

                    //      if x = 1 then
                    //         return composite
                    if (x == 1)
                    {
                        return false;
                    }
                }
                if (x != num -1 ){
                    return false;
                }
            }
            //return probably prime
            return true;
        }

        private static ulong[] GetMillerRabinWitnesses(ulong num)
        {
            if (num < 2047)
            {
                return new[] { 2ul };
            }
            else if (num < 1373653)
            {
                return new[] { 2ul, 3ul };
            }
            else if (num < 9080191)
            {
                return new[] { 31ul, 73ul };
            }
            else if (num < 25326001)
            {
                return new[] { 2ul, 3ul, 5ul };
            }
            else if (num < 3215031751)
            {
                return new[] { 2ul, 3ul, 5ul, 7ul };
            }
            else if (num < 4759123141)
            {
                return new[] { 2ul, 7ul, 61ul };
            }
            else if (num < 1122004669633)
            {
                return new[] { 2ul, 13ul, 23ul, 1662803ul };
            }
            else if (num < 2152302898747)
            {
                return new[] { 2ul, 3ul, 5ul, 7ul, 11ul };
            }
            else if (num < 3474749660383)
            {
                return new[] { 2ul, 3ul, 5ul, 7ul, 11ul, 13ul };
            }
            else if (num < 341550071728321)
            {
                return new[] { 2ul, 3ul, 5ul, 7ul, 11ul, 13ul, 17ul };
            }
            else if (num < 3825123056546413051)
            {
                return new[] { 2ul, 3ul, 5ul, 7ul, 11ul, 13ul, 17ul, 19ul, 23ul };
            }
            else
            {
                return new[] { 2ul, 3ul, 5ul, 7ul, 11ul, 13ul, 17ul, 19ul, 23ul, 29ul, 31ul, 37ul };
            }
        }
    }
}
