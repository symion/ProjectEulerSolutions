using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public static class TextHelpers
    {
        public static uint GetLetterScore(char letter)
        {
            var isLowerCaseLetter = letter >= 'a' && letter <= 'z';
            var isUpperCaseLetter = letter >= 'A' && letter <= 'Z';
            if (!isLowerCaseLetter && !isUpperCaseLetter)
            {
                throw new ArgumentOutOfRangeException(nameof(letter), "Must be a letter");
            }

            return isLowerCaseLetter ? letter - (uint)'a' + 1u : letter - (uint)'A' + 1;
        }

        public static uint GetWordScore(string word)
        {
            return word.Select(GetLetterScore).Aggregate(0u, (current, score) => current + score);
        }
    }
}
