using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_CSharp
{
    public class Master
    {
        public extern int Guess(string word);
    }

    /// <summary>
    /// 843. Guess the Word
    /// This problem is an interactive problem new to the LeetCode platform.
    /// We are given a word list of unique words, each word is 6 letters long, and one word in this list is chosen as secret.
    /// You may call master.guess(word) to guess a word.The guessed word should have type string and must be from the original list with 6 lowercase letters.
    /// This function returns an integer type, representing the number of exact matches (value and position) of your guess to the secret word.  Also, if your guess is not in the given wordlist, it will return -1 instead.
    /// For each test case, you have 10 guesses to guess the word. At the end of any number of calls, if you have made 10 or less calls to master.guess and at least one of these guesses was the secret, you pass the testcase.
    /// Besides the example test case below, there will be 5 additional test cases, each with 100 words in the word list.  The letters of each word in those testcases were chosen independently at random from 'a' to 'z', such that every word in the given word lists is unique.
    /// </summary>
    public class GuessTheWord
    {
        public void FindSecretWord(string[] wordlist, Master master)
        {
            // Create the distance (e.g. the number of exace matches) map between each two words in the list
            int[,] distance = new int[wordlist.Length, wordlist.Length];
            for (int i = 0; i < wordlist.Length; i++)
            {
                for (int j = 1; j < wordlist.Length; j++)
                {
                    int matchCount = 0;
                    for (int k = 0; k < 6; k++)
                    {
                        if (wordlist[i][k] == wordlist[j][k])
                        {
                            matchCount++;
                        }
                    }

                    distance[i, j] = matchCount;
                    distance[j, i] = matchCount;
                }
            }

            // Create a list to hold the secret candidates (the secret must be one of them)
            List<int> possibleWordIndexes = new List<int>();

            // Create a list to hold the words that are already guessed
            List<int> guessedWordIndexes = new List<int>();

            for (int i = 0; i < wordlist.Length; i++)
            {
                possibleWordIndexes.Add(i);
            }

            while (possibleWordIndexes.Any())
            {
                int nextIndex = GuessNextIndex(possibleWordIndexes, guessedWordIndexes, wordlist.Length, distance);
                int result = master.Guess(wordlist[nextIndex]);
                if (result == 6)
                {
                    return;
                }

                // Shrink the secret candidates, because now the secret must also have the returned distance with the guessed word
                possibleWordIndexes = possibleWordIndexes.Where(i => distance[nextIndex, i] == result).ToList();
                guessedWordIndexes.Add(nextIndex);
            }
        }

        private int GuessNextIndex(List<int> possibleWordIndexes, List<int> guessedWordIndexes, int wordListLength, int[,] distance)
        {
            // If there's less than 2 candidates, don't bother go through the logic, just guess one.
            if (possibleWordIndexes.Count <= 2)
            {
                return possibleWordIndexes[0];
            }

            int minDistanceWordIndexesCount = possibleWordIndexes.Count;
            int finalGuess = -1;

            //// The goal here is: we want our next guess to reduce the size of the secret candidates as much as possible
            //// Assume anyone in the secret candidates can be the real secret, we calculate and group by the distance between our next guess and all secret candidates
            //// Then we pick our guess with the minimum possible secret candidate size among all distances between the next guess and any secret candidate
            for (int guess = 0; guess < wordListLength; guess++)
            {
                if (!guessedWordIndexes.Contains(guess))
                {
                    List<int>[] distanceWordIndexes = new List<int>[7];
                    for (int j = 0; j < 7; j++)
                    {
                        distanceWordIndexes[j] = new List<int>();
                    }

                    foreach(int possibleWordIndex in possibleWordIndexes)
                    {
                        if (guess != possibleWordIndex)
                        {
                            distanceWordIndexes[distance[guess, possibleWordIndex]].Add(possibleWordIndex);
                        }
                    }

                    int maxDistanceWordIndexesCount = distanceWordIndexes.Max(indexes => indexes.Count);
                    if (maxDistanceWordIndexesCount < minDistanceWordIndexesCount)
                    {
                        minDistanceWordIndexesCount = maxDistanceWordIndexesCount;
                        finalGuess = guess;
                    }
                }
            }

            return finalGuess;
        }
    }
}
