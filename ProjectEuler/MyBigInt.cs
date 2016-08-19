using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class MyBigInt
    {
        private readonly List<byte> _number = new List<byte>();
        public MyBigInt()
        {
            _number.Add(0);
        }

        public MyBigInt(ulong value)
        {
            while (value > 0)
            {
                _number.Add((byte) (value%10));
                value /= 10;
            }
        }

        public MyBigInt(decimal value)
        {
            while (value > 0)
            {
                _number.Add((byte) (value%10));
                value /= 10;
            }
        }

        public MyBigInt(MyBigInt cloneMe)
        {
            if (cloneMe == null)
            {
                throw new ArgumentNullException(nameof(cloneMe));
            }
            _number.AddRange(cloneMe._number);
        }

        public bool IsEven => (_number[0] & 1) == 0;

        public override string ToString()
        {
            var output = _number.ToList();
            output.Reverse();
            return string.Concat(output.Select(c => c));
        }

        public bool FitsInULong()
        {
            if (_number.Count < 20)
            {
                return true;
            }
            if (_number.Count > 20)
            {
                return false;
            }
            if (_number[_number.Count - 1] > 1)
            {
                return false;
            }
            if (_number[_number.Count - 2] > 8)
            {
                return false;
            }
            if (_number[_number.Count - 3] > 4)
            {
                return false;
            }
            if (_number[_number.Count - 4] > 4)
            {
                return false;
            }
            if (_number[_number.Count - 5] > 6)
            {
                return false;
            }
            if (_number[_number.Count - 6] > 7)
            {
                return false;
            }
            if (_number[_number.Count - 7] > 4)
            {
                return false;
            }
            if (_number[_number.Count - 8] > 4)
            {
                return false;
            }
            if (_number[_number.Count - 9] > 0)
            {
                return false;
            }
            if (_number[_number.Count - 10] > 7)
            {
                return false;
            }
            if (_number[_number.Count - 11] > 3)
            {
                return false;
            }
            if (_number[_number.Count - 12] > 7)
            {
                return false;
            }
            if (_number[_number.Count - 13] > 0)
            {
                return false;
            }
            if (_number[_number.Count - 14] > 9)
            {
                return false;
            }
            if (_number[_number.Count - 15] > 5)
            {
                return false;
            }
            if (_number[_number.Count - 16] > 5)
            {
                return false;
            }
            if (_number[_number.Count - 17] > 1)
            {
                return false;
            }
            if (_number[_number.Count - 18] > 6)
            {
                return false;
            }
            if (_number[_number.Count - 19] > 1)
            {
                return false;
            }
            if (_number[_number.Count - 20] > 5)
            {
                return false;
            }
            return true;
        }

        public void Add(MyBigInt othernum)
        {
            for (int index = 0; index < othernum._number.Count; index++)
            {
                SumValueWithCarry(index, othernum._number[index]);
            }
        }

        public void Subtract(MyBigInt othernum)
        {
            if (!IsGreaterThanOrEqualTo(othernum))
            {
                throw new ArgumentOutOfRangeException(nameof(othernum), "Value would take us negative");
            }

            for (int x = 0; x < othernum._number.Count; x++)
            {
                if (_number[x] < othernum._number[x])
                {
                    _number[x + 1]--;
                    _number[x] += 10;
                }

                _number[x] -= othernum._number[x];
            }
        }

        public bool IsGreaterThanOrEqualTo(MyBigInt otherNum)
        {
            if (_number.Count > otherNum._number.Count)
            {
                return true;
            }
            if (_number.Count < otherNum._number.Count)
            {
                return false;
            }

            for (var x = _number.Count - 1; x >= 0; x--)
            {
                if (_number[x] < otherNum._number[x])
                {
                    return false;
                }

                if (_number[x] > otherNum._number[x])
                {
                    return true;
                }
            }
            return true;
        }

        private ulong ConvertToULong()
        {
            if (!FitsInULong())
            {
                throw new IndexOutOfRangeException("It don't fit in a ULong");
            }
            var result = 0ul;
            var mult = 1ul;
            foreach (var digit in _number)
            {
                result += digit * mult;
                mult *= 10;
            }
            return result;
        }

        public T Cast<T>()
        {
            if (typeof (T) == typeof (ulong))
            {
                return (T)(object)ConvertToULong();
            }
            throw new InvalidCastException($"Object does not support casting to type {typeof (T).Name}");
        }

        public static MyBigInt Factorial(ulong num)
        {
            var bigInt = new MyBigInt(num);
            bigInt.Factorial();
            return bigInt;
        }

        private void SumValueWithCarry(int index, byte addend)
        {
            var localIndex = index;
            do
            {
                if (_number.Count < localIndex + 1)
                {
                    _number.Add(addend);
                    return;
                }

                addend += _number[localIndex];
                if (addend < 10)
                {
                    _number[localIndex] = addend;
                    return;
                }

                _number[localIndex] = (byte) (addend%10);
                addend /= 10;
                localIndex++;
            } while (addend > 0);
        }

        public int Base10Digits => _number.Count;

        public ulong GetDigitSum()
        {
            return _number.Aggregate(0ul, (current, digit) => current + digit);
        }

        public void Factorial()
        {
            if (!FitsInULong())
            {
                throw new IndexOutOfRangeException(
                    $"Number {this} is bigger than ulong maxval. No way this finishes ever.");
            }

            var nextMult = Cast<ulong>() - 1;

            while (nextMult > 0)
            {
                var currentVal = new MyBigInt(this);
                for (var addCount = 0ul; addCount < nextMult - 1; addCount++)
                {
                    Add(currentVal);
                }
                --nextMult;
            }
        }

        public void Multiply(ulong mult)
        {
            var currentVal = new MyBigInt(this);
            for (var addCount = 0ul; addCount < mult - 1; addCount++)
            {
                Add(currentVal);
            }
        }
    }
}
