using System;
using System.Linq;
using GeneralKnowledge.Test.App.Tests;

namespace GeneralKnowledge.Test.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private static void AnagramTest()
        {
            const string word = "stop";
            var possibleAnagrams = new[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine( $@"{word} > {possibleAnagram}: {possibleAnagram.IsAnagram(word)}");
            }
        }

        private static void GetUniqueCharsAndCount()
        {
            const string word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";

            // TODO
            // Write an algorithm that gets the unique characters of the word below 
            // and counts the number of occurrences for each character found
            var uniqueCharsCount = word.GroupBy(a => a)
                .Select(grp => new { character = grp.Key, occurrence = grp.Count()});
            foreach (var item in uniqueCharsCount)
            {
                Console.WriteLine($@"character {item.character} > occurrence : {item.occurrence}");
            }
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO
            // Write logic to determine whether a is an anagram of b
            if (a.Length != b.Length)
                return false;
            
            // Sort the characters alphabetically and compare them to one another.
            return a == b || a.OrderBy(c => c).SequenceEqual(b.OrderBy(c => c));
        }
    }
}
