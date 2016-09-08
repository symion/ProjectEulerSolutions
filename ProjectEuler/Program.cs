using System;
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
            //NumberLetterCounts_17.Answer();
            //MaximumPathSum_18_67.Answer();
            //CountingSundays_19.Answer();
            //FactorialDigitSum_20.Answer();
            //AmicableNumbers_21.Answer();
            //NameScores_22.Answer();
            //NonAbundantSums_23.Answer();
            //Thousand_DigitFibonacciNumber_25.Answer();
            //LexicoGraphicPermutations_24.Answer();
            //ReciprocalCycles_26.BetterAnswer();
            //QuadraticPrimes_27.TestMultiple();
            //NumberSpiralDiagonals_28.Answer();
            DistinctPowers_29.Answer();
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
            var gridSize = 3u;
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
        private readonly static Dictionary<int, int> LettersPerNumber = new Dictionary<int, int>
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
            {13, "thirteen".Length},
            {14, "fourteen".Length },
            {15, "fifteen".Length },
            {16, "sixteen".Length },
            {17, "seventeen".Length },
            {18, "eighteen".Length },
            {19, "nineteen".Length },
            {20, "twenty".Length },
            {30, "thirty".Length },
            {40, "forty".Length },
            {50, "fifty".Length },
            {60, "sixty".Length },
            {70, "seventy".Length },
            {80, "eighty".Length },
            {90, "ninety".Length },
        };

        private static int CountLettersInNumber(int number)
        {
            var total = 0;
            var numTest = 0;

            if ((numTest = number%100) < 20 && numTest > 0)
            {
                total += LettersPerNumber[numTest];
                number -= numTest;
            }
            else if((numTest = number % 10) > 0)
            {
                total += LettersPerNumber[numTest];
                number -= numTest;
            }

            if ((numTest = number%100) > 0)
            {
                total += LettersPerNumber[numTest];
                number -= numTest;
            }

            if ((numTest = number % 1000) > 0)
            {
                if (total > 0)
                {
                    total += "and".Length;
                }
                number -= numTest;
                numTest /= 100;
                total += LettersPerNumber[numTest] + "hundred".Length;
            }

            if (number > 0)
            {
                total += "onethousand".Length;
            }
            
            return total;
        }
        public static void Answer()
        {
            var start = DateTime.Now;
            var total = 0;
            for (var x = 1; x <= 1000; x++)
            {
                total += CountLettersInNumber(x);
            }
            var endTime = DateTime.Now;
            var answerText =
                $"Problem 17 answer is '{total}'. Algorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);

        }
    }

    internal class MaximumPathSum_18_67
    {
        public static void Answer()
        {
            var prob18Nums = new List<int>
            {
                75,
                95, 64,
                17, 47, 82,
                18, 35, 87, 10,
                20, 04, 82, 47, 65,
                19, 01, 23, 75, 03, 34,
                88, 02, 77, 73, 07, 63, 67,
                99, 65, 04, 28, 06, 16, 70, 92,
                41, 41, 26, 56, 83, 40, 80, 70, 33,
                41, 48, 72, 33, 47, 32, 37, 16, 94, 29,
                53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14,
                70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57,
                91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48,
                63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31,
                04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23
            };

            List<int> nums = null;
            using (var streamReader = new StreamReader("ProblemSpecificFiles/EulerProblem67.txt"))
            {
                nums = streamReader.ReadToEnd().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            }
            var tree = new Tree();
            foreach (var val in nums)
            {
                tree.Add(val);
            }
            var start = DateTime.Now;
            var answer = tree.Root.GetMaxSubtreePathTotal();
            var endTime = DateTime.Now;
            var answerText =
                $"Problem 19 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }
    }

    enum Months
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    internal class CountingSundays_19
    {
        public static void Answer()
        {
            var start = DateTime.Now;
            var day = 6;
            var month = Months.January;
            var year = 1901;
            var firstSundays = 0;
            var daysInMonth = GetDaysInMonth(month, year);
            var loops = 0ul;

            while (year < 2001)
            {
                loops++;
                if (day + 7 <= daysInMonth)
                {
                    day += 7;
                    continue;
                }
                else
                {
                    day = 7 - (daysInMonth - day);
                    if (month == Months.December)
                    {
                        year++;
                        month = Months.January;
                    }
                    else
                    {
                        month += 1;
                    }
                    daysInMonth = GetDaysInMonth(month, year);
                }
                if (day == 1)
                {
                    firstSundays++;
                }
            }
            var endTime = DateTime.Now;
            var answerText =
                $"Problem 19 answer is '{firstSundays}'. There were {loops} loops. Algorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }

        public static int GetDaysInMonth(Months month, int year)
        {
            switch (month)
            {
                case Months.January:
                case Months.March:
                case Months.May:
                case Months.July:
                case Months.August:
                case Months.October:
                case Months.December:
                    return 31;

                case Months.April:
                case Months.June:
                case Months.September:
                case Months.November:
                    return 30;

                case Months.February:
                    if (year%400 == 0 || (year%4 == 0 && year%100 != 0))
                    {
                        return 29;
                    }
                    return 28;
                default:
                    throw new ArgumentOutOfRangeException(nameof(month));
            }
        }
    }

    internal class FactorialDigitSum_20
    {
        public static void Answer()
        {
            var num = new MyBigInt(100);
            var start = DateTime.Now;
            num.Factorial();
            var answer = num.GetDigitSum();
            var endTime = DateTime.Now;
            var answerText =
                $"Problem 20 answer is '{answer}'. Final num was was\n{num}.\nAlgorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }
    }

    internal class AmicableNumbers_21
    {
        public static void Answer()
        {
            var sumOfTimes = 0L;
            var answer = 0ul;
            for (var count = 0; count < 100; count++)
            {
                var amicableNums = new bool[10000];
                var start = DateTime.Now;
                for (uint x = 4; x < 10000; x++)
                {
                    if (amicableNums[x])
                    {
                        continue;
                    }
                    var partner = MathHelpers.GetAmicablePartner(x);
                    if (partner != 0)
                    {
                        amicableNums[x] = true;
                        if (partner < 10000)
                        {
                            amicableNums[partner] = true;
                        }
                    }
                }
                
                for (var x = 4; x < 10000; x++)
                {
                    if (amicableNums[x])
                    {
                        answer += (ulong) x;
                    }
                }
                var endTime = DateTime.Now;
                sumOfTimes += Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds);
            }
            var answerText =
                $"Problem 21 answer is '{answer}'. Algorithm finished in {sumOfTimes/100} milliseconds on average";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }
    }

    internal class NameScores_22
    {
        public static void Answer()
        {
            //var sumOfTimes = 0L;
            //for (var count = 0; count < 100; count++)
            //{
            var start = DateTime.Now;
            List<string> nameStrings = null;
            using (var streamReader = new StreamReader("ProblemSpecificFiles/EulerProblem22.txt"))
            {
                nameStrings =
                    streamReader.ReadLine().Replace("\"", "")
                        .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
            }
            nameStrings.Sort();

            var answer = 0ul;
            for (var x = 0; x < nameStrings.Count; x++)
            {
                answer += (uint)(x + 1)*TextHelpers.GetWordScore(nameStrings[x]);
            }

            var endTime = DateTime.Now;
            //    sumOfTimes += Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds);

            var answerText =
                $"Problem 22 answer is '{answer}'. Algorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }
    }

    internal class NonAbundantSums_23
    {
        public static void Answer()
        {
            var abundantNums = new SortedSet<ulong> {12};
            var sumsOfAbundants = new SortedSet<ulong> {24};
            var boolOFAbundants = new bool[28123];

            var start = DateTime.Now;
            var total = (12ul*13ul)/2;
            for (var x = 13UL; x <= 28123; x++)
            {
                if (MathHelpers.GetPerfectionRating(x) == MathHelpers.PerfectionRating.Abundant)
                {
                    abundantNums.Add(x);
                    foreach (var abundant in abundantNums.Where(a => x + a <= 28123))
                    {
                        //sumsOfAbundants.Add(x + abundant);
                        boolOFAbundants[x + abundant - 1] = true;
                    }
                }
                //if (!sumsOfAbundants.Contains(x))
                if(!boolOFAbundants[x-1])
                {
                    total += x;
                }
            }
            var endTime = DateTime.Now;
            
            var answerText =
                $"Problem 23 answer is '{total}'. Algorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }

    }

    internal class LexicoGraphicPermutations_24
    {
        public static void Answer()
        {
            var set = new SortedSet<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var start = DateTime.Now;
            string answer = null;
            for (int x = 0; x < 100; x++)
            {
                answer = MathHelpers.GetNthLexicographicPermutationOfS(set, 1000000);
            }
            var endTime = DateTime.Now;

            var timeDif = Convert.ToDouble(endTime.Subtract(start).TotalMilliseconds);
            var answerText =
                $"Problem 23 answer is '{answer}'. Algorithm finished in {timeDif/100} milliseconds on average";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }
        //GetNthLexicographicPermutationOfS
    }

    internal class Thousand_DigitFibonacciNumber_25
    {
        public static void Answer()
        {
            var start = DateTime.Now;
            var fibIndex = 2;
            var termA = new MyBigInt(1);
            var termB = new MyBigInt(1);
            while (termB.Base10Digits < 1000)
            {
                var holder = new MyBigInt(termB);
                termB.Add(termA);
                termA = holder;
                ++fibIndex;
            }
            var endTime = DateTime.Now;

            var answerText =
                $"Problem 25 answer is '{fibIndex}'. Number was:\n'{termB}'\nAlgorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }
    }

    internal class ReciprocalCycles_26
    {
        public static void BetterAnswer()
        {
            var start = DateTime.Now;
            var numWithLongestRepeat = 3;
            var longestRepeat = 1;
            for (var x = 7; x < 1000; x+=2)
            {
                if (x%5 == 0)
                {
                    continue;
                }

                var tensPower = 1;
                var powerOfTen = new BigInteger(10);
                while ((powerOfTen - 1)%x != 0)
                {
                    powerOfTen *= 10;
                    ++tensPower;
                }

                if (tensPower > longestRepeat)
                {
                    longestRepeat = tensPower;
                    numWithLongestRepeat = x;
                }
            }
            var endTime = DateTime.Now;

            var answerText =
                $"Problem 26 answer is '{numWithLongestRepeat}'. Repeat length was '{longestRepeat}'.\nAlgorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }
        public static void Answer()
        {
            var start = DateTime.Now;
            var numWithLongestRepeat = 3;
            var longestRepeat = new List<int> {3};
            List<int> largestDecimalPart = null;
            for (var x = 4; x < 1000; x++)
            {
                var decimalPart = new List<int>();
                var mod = 10;
                var padding = (int) Math.Log10(x);
                var borrowCount = 1;

                while (mod != 0)
                {
                    while (mod < x)
                    {
                        mod *= 10;
                        if (++borrowCount > 1)
                        {
                            decimalPart.Add(0);
                        }
                    }
                    borrowCount = 0;
                    decimalPart.Add(mod/x);
                    mod %= x;
                    if (mod == 0)
                    {
                        break;
                    }
                    List<int> sequence;
                    if (decimalPart.Count >= (padding+2) && FoundRepeatingSequence(padding, decimalPart, out sequence))
                    {
                        if (sequence.Count > longestRepeat.Count)
                        {
                            numWithLongestRepeat = x;
                            longestRepeat = sequence;
                            largestDecimalPart = decimalPart;
                        }
                        break;
                    }
                } 
            }
            var repeatString = string.Concat(longestRepeat.Select(n => n.ToString()));
            var endTime = DateTime.Now;

            var answerText =
                $"Problem 26 answer is '{numWithLongestRepeat}'.\nDecimal part was\n'{string.Concat(largestDecimalPart.Select(n => n.ToString()))}'\nRepeat length was '{repeatString.Length}'.\nRepeat was:\n'{repeatString}'\nAlgorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }

        private static bool FoundRepeatingSequence(int padding, List<int> decimalPart, out List<int> sequence)
        {
            sequence = null;
            var searchList = decimalPart;
            var decimalCount = searchList.Count;
            if (decimalCount < 3)
            {
                return false;
            }
            var maxDecimalIndex = decimalCount - 1;
            var testSequence = searchList.GetRange(maxDecimalIndex - (padding + 1), padding + 2);
            
            while (testSequence.Count <= searchList.Count/2) // /3)
            {
                var match = true;
                for (int x = testSequence.Count - 1; x >= 0; x--)
                {
                    var distanceFromEnd = testSequence.Count - 1 - x;
                    var secondSequenceIndex = maxDecimalIndex - testSequence.Count - distanceFromEnd;
                    //var firstSequenceIndex = maxDecimalIndex - (2*testSequence.Count) - distanceFromEnd;
                    match = (testSequence[x] == searchList[secondSequenceIndex]);
                           // && (testSequence[x] == searchList[firstSequenceIndex]);
                    if (!match)
                    {
                        break;
                    }
                }
                if (match)
                {
                    sequence = testSequence;
                    return true;
                }
                testSequence.Insert(0, searchList[searchList.Count - 1 - testSequence.Count]);
            }

            return false;
        }
    }

    internal class QuadraticPrimes_27
    {
        public static void TestMultiple()
        {
            var start = DateTime.Now;
            for (var x = 0; x < 100; x++)
            {
                Answer();
            }
            var end = DateTime.Now;
            var avgMilliseconds = (end - start).TotalMilliseconds/100;
            System.Console.WriteLine($"Problem avg execution was {avgMilliseconds}ms.");
        }
        public static void Answer()
        {
            //var start = DateTime.Now;
            var aForMaxPrimes = 0;
            var bForMaxPrimes = 3;
            var maxConsecutivePrimes = 0;
            
            for (var b = 3; b <= 1000; b += 2)
            {
                if (!MathHelpers.ProbablyPrimeMiller_Rabin((ulong) b))
                {
                    continue;
                }

                for (var a = 0; a < 1000; a++)
                {
                    var currentMax = FindNumConsecutivePrimes(a, b);
                    if (currentMax > maxConsecutivePrimes)
                    {
                        aForMaxPrimes = a;
                        bForMaxPrimes = b;
                        maxConsecutivePrimes = currentMax;
                    }

                    currentMax = FindNumConsecutivePrimes(-a, b);
                    if (currentMax > maxConsecutivePrimes)
                    {
                        aForMaxPrimes = -a;
                        bForMaxPrimes = b;
                        maxConsecutivePrimes = currentMax;
                    }

                    currentMax = FindNumConsecutivePrimes(a, -b);
                    if (currentMax > maxConsecutivePrimes)
                    {
                        aForMaxPrimes = a;
                        bForMaxPrimes = -b;
                        maxConsecutivePrimes = currentMax;
                    }

                    currentMax = FindNumConsecutivePrimes(-a, -b);
                    if (currentMax > maxConsecutivePrimes)
                    {
                        aForMaxPrimes = -a;
                        bForMaxPrimes = -b;
                        maxConsecutivePrimes = currentMax;
                    }
                }
            }
            //var endTime = DateTime.Now;

            //var answerText =
            //    $"Problem 27 answer is '{aForMaxPrimes * bForMaxPrimes}'.\nA was '{aForMaxPrimes}' and B was '{bForMaxPrimes}'.\nNumber of consecutive primes was '{maxConsecutivePrimes}.'\nAlgorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
           // Console.WriteLine(answerText);
           // Debug.WriteLine(answerText);
        }

        private static int FindNumConsecutivePrimes(int a, int b)
        {
            var consecutive = 0;
            var n = 0;
            var product = (n * n) + (a * n) + b;
            var isPrime = product > 1 && MathHelpers.ProbablyPrimeMiller_Rabin((ulong) product);

            while (isPrime)
            {
                ++consecutive;
                ++n;
                product = (n * n) + (a * n) + b;
                isPrime = product > 1 && MathHelpers.ProbablyPrimeMiller_Rabin((ulong) product);
            }

            return consecutive;
        }
    }

    internal class NumberSpiralDiagonals_28
    {
        public static void Answer()
        {
            var start = DateTime.Now;
            var diagonal = 1001;
            var additionalTerms = (diagonal - 1) / 2;
            var total = 1;
            var diagonalJTerm = 1;
            var diagonalkTerm = 1;
            var diagonallTerm = 1;
            var diagonalmTerm = 1;
            var j = 2;
            var k = 4;
            var l = 6;
            var m = 8;

            for (var count = 0; count < additionalTerms; count++)
            {
                diagonalJTerm += j + count*8;
                diagonalkTerm += k + count*8;
                diagonallTerm += l + count*8;
                diagonalmTerm += m + count*8;
                total += diagonalJTerm + diagonalkTerm + diagonallTerm + diagonalmTerm;
            }

            var endTime = DateTime.Now;

            var answerText =
                $"Problem 28 answer is '{total}'.\nAlgorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
            Console.WriteLine(answerText);
            Debug.WriteLine(answerText);
        }
    }

    internal class DistinctPowers_29
    {
        public static void Answer()
        {
            var start = DateTime.Now;
            const ulong maxA = 16;
            var distinctTermArray = new ulong[maxA + 1];
            using (var stream = new StreamWriter("c:/temp/euler.txt"))
            {

                //var list = new SortedSet<ulong>();

                //for (var a = 2ul; a <= maxA; a++)
                //{
                //    for (var b = 2ul; b <= maxA; b++)
                //    {
                //        stream.WriteLine((ulong) Math.Pow(a, b));
                //        list.Add((ulong) Math.Pow(a, b));
                //    }
                //}

                //foreach (var value in list)
                //{
                //    stream.WriteLine(value);
                //}

                //stream.WriteLine($"Correct answer: {list.Count}");


                var listOfLists = new List<SortedSet<ulong>>();

                for (var count = 2ul; count <= maxA; count++)
                {
                    var currentList = new SortedSet<ulong>();
                    listOfLists.Add(currentList);
                    for (var exp = 2ul; exp <= maxA; exp++)
                    {
                        currentList.Add((ulong) Math.Pow(count, exp));
                    }
                }
                // 2:0 4:2 8:6 16:14
                var sixteenIntersect2 = new SortedSet<ulong>();
                sixteenIntersect2.UnionWith(listOfLists[14]);
                sixteenIntersect2.IntersectWith(listOfLists[0]);
                var sixteenIntersect4 = new SortedSet<ulong>();
                sixteenIntersect4.UnionWith(listOfLists[14]);
                sixteenIntersect4.IntersectWith(listOfLists[2]);
                var sixteenIntersect8 = new SortedSet<ulong>();
                sixteenIntersect8.UnionWith(listOfLists[14]);
                sixteenIntersect8.IntersectWith(listOfLists[6]);

                stream.WriteLine(
                    $"16 common with 2 is {sixteenIntersect2.Count} terms:\n{string.Concat(sixteenIntersect2.Select(t => $" {t}"))}");
                stream.WriteLine(
                    $"16 common with 4 is {sixteenIntersect4.Count} terms:\n{string.Concat(sixteenIntersect4.Select(t => $" {t}"))}");
                stream.WriteLine(
                    $"16 common with 8 is {sixteenIntersect8.Count} terms:\n{string.Concat(sixteenIntersect8.Select(t => $" {t}"))}");
                //stream.WriteLine($"2 had {listOfLists[0].Count} unique exponenents");
                //stream.WriteLine($"4 had {listOfLists[2].UnionWith(listOfLists[0]).Cou} unique exponenents");

                //for (var num = 2u; num <= maxA; num++)
                //{
                //    if (distinctTermArray[num] > 0)
                //    {
                //        continue;
                //    }

                //    distinctTermArray[num] = maxA - 1;

                //    // Find out the number of unique terms fr each power of a less than maxA
                //    var power = num*num;
                //    var exponent = 2ul;
                //    while (power <= maxA)
                //    {
                //        //distinctTermArray[power] = maxA;

                //        //for (var expCount = 2ul; expCount < exponent; expCount++)
                //        //{
                //        //    distinctTermArray[power] = (uint)((maxA) - (maxA / expCount));
                //        //}
                //        distinctTermArray[power] = maxA;
                //        //Walk up the exponent chain subtracting out terms that are common with previous powers
                //        for (var tempExp = exponent; tempExp > 0; tempExp--)
                //        {
                //            distinctTermArray[power] -= 
                //        }


                //        distinctTermArray[power] = (uint) ((maxA) - (maxA/exponent));
                //        power *= num;
                //        exponent++;
                //    }
                //}

                //var answer = distinctTermArray.Aggregate(0ul, (total, value) => total + value);
                //var endTime = DateTime.Now;
                //var answerText =
                //    $"Problem 29 answer is '{answer}'.\nAlgorithm finished in {Convert.ToInt64(endTime.Subtract(start).TotalMilliseconds)} milliseconds";
                //stream.WriteLine(answerText);
                //Debug.WriteLine(answerText);
            }
        }
    }

    class Tree
    {
        private readonly List<TreeNode> _treeList = new List<TreeNode>();
        public TreeNode Root => _treeList.Count > 0 ? _treeList[0] : null;
        private int _currentRowStart = 0;
        private int _maxCurrentRowSize = 1;
        public void Add(int value)
        {
            _treeList.Add(new TreeNode(value));
            var currentSpot = _treeList.Count - 1;

            if (_treeList.Count > _currentRowStart + _maxCurrentRowSize)
            {
                _currentRowStart += _maxCurrentRowSize++;
            }

            var leftParent = currentSpot > _currentRowStart ? _treeList[currentSpot - _maxCurrentRowSize] : null;
            var rightParent = currentSpot < _currentRowStart + _maxCurrentRowSize - 1 ? _treeList[currentSpot - _maxCurrentRowSize + 1] : null;

            if (leftParent != null)
            {
                leftParent.RightChild = _treeList[currentSpot];
                _treeList[currentSpot].LeftParent = leftParent;
            }

            if (rightParent != null)
            {
                rightParent.LeftChild = _treeList[currentSpot];
                _treeList[currentSpot].RightParent = rightParent;
            }
        }
    }

    
    class TreeNode
    {
        public TreeNode(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        private int subTreeMax = -1;

        public int GetMaxSubtreePathTotal()
        {
            if (subTreeMax != -1)
            {
                return subTreeMax;
            }
            if (LeftChild == null && RightChild == null)
            {
                subTreeMax = Value;
                return subTreeMax;
            }
            if (LeftChild == null)
            {
                subTreeMax = Value + RightChild.GetMaxSubtreePathTotal();
                return subTreeMax;
            }
            if (RightChild == null)
            {
                subTreeMax = Value + LeftChild.GetMaxSubtreePathTotal();
                return subTreeMax;
            }
            var leftMax = LeftChild.GetMaxSubtreePathTotal();
            var rightMax = RightChild.GetMaxSubtreePathTotal();

            subTreeMax = Value + (leftMax > rightMax ? leftMax : rightMax);
            return subTreeMax;
        }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode LeftParent { get; set; }
        public TreeNode RightParent { get; set; }
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

    public static class MathHelpers
    {
        public enum PerfectionRating
        {
            Invalid = 0,
            Deficient,
            Perfect,
            Abundant
        }

        public static string GetNthLexicographicPermutationOfS(SortedSet<char> characterSet, ulong permutation)
        {
            characterSet = new SortedSet<char>(characterSet); //make a copy
            var outString = string.Empty;
            var totalCount = characterSet.Count;
            for (var count = 0; count < totalCount - 1; count++)
            {
                var nextPermutations = MyBigInt.Factorial((ulong) (totalCount - count - 1)).Cast<ulong>();
                var nextSetIndex = 0;
                while (permutation > nextPermutations)
                {
                    permutation -= nextPermutations;
                    ++nextSetIndex;
                }
                var nextChar = characterSet.ElementAt(nextSetIndex);
                outString += nextChar.ToString();
                characterSet.Remove(nextChar);
            }
            outString += characterSet.First();
            return outString;
        }

        public static PerfectionRating GetPerfectionRating(ulong num)
        {
            var sumOfFactors = SumOfProperFactors(num);

            if (sumOfFactors > num)
            {
                return PerfectionRating.Abundant;
            }

            if (sumOfFactors == num)
            {
                return PerfectionRating.Perfect;
            }

            return PerfectionRating.Deficient;
        }

        public static ulong SumOfProperFactors(ulong num)
        {
            return SumOfFactors(num) - num;
        }

        public static ulong SumOfFactors(ulong num)
        {
            var sum = 1UL;
            var nextPrime = 2UL;
            while (nextPrime*nextPrime <= num && num > 1)
            {
                if (num%nextPrime == 0)
                {
                    var j = nextPrime*nextPrime;
                    num /= nextPrime;
                    while (num%nextPrime == 0)
                    {
                        j *= nextPrime;
                        num /= nextPrime;
                    }
                    sum *= j - 1;
                    sum /= nextPrime - 1;
                }
                nextPrime = (nextPrime == 2) ? 3 : nextPrime + 2;
            }
            if (num > 1)
            {
                sum *= (num + 1);
            }

            return sum;
        }

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

            while (posDivisor*posDivisor <= num)
            {
                if (num % posDivisor == 0)
                {
                    list.Add(posDivisor);
                    if (posDivisor * posDivisor != num)
                    {
                        list.Add(num / posDivisor);
                    }
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

        public static ulong GetAmicablePartner(ulong num)
        {
            if (num < 1)
            {
                return 0;
            }

            var factors = GetFactors(num).Where(n => n != num).ToList();

            if (factors.Count < 2)
            {
                return 0;
            }

            var sum = factors.Aggregate(0ul, (current, total) => total + current);
            if (sum == num)
            {
                return 0;
            }
            var sumFactors = GetFactors(sum).Where(n => n != sum).ToList();

            if (sumFactors.Count < 2)
            {
                return 0;
            }

            return sumFactors.Aggregate(0ul, (current, total) => total + current) == num ? sum : 0;
        }
    }
}
