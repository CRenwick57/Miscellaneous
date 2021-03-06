using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//C# command line application that solves the mastermind board game with user input.
//Changing comments to use minimax or guesses[0] means you either use the slower Knuth 5 Guess algorithm or a faster algorithm that usually takes more guesses.
//Methods ending with Alt play the "Bulls and Cows" game that uses 4 unique numbers from 1 to 9 instead of 4 numbers from 1-6 that can repeat.
//Some methods are found in ListExtensions.cs in Extensions repository.

namespace MasterMindSolver
{
    class MasterMindSolver
    {
        private List<int[]> guesses;
        private List<int[]> impossible;

        public MasterMindSolver()
        {
            guesses = new List<int[]>();
            impossible = new List<int[]>();
        }

        public void Reset()
        {
            guesses.Clear();
            impossible.Clear();
            int a = 1, b = 1, c = 1, d = 1;
            while (a <= 6)
            {
                if (a != 1 || b != 1 || c != 2 || d != 2)
                    guesses.Add(new int[] { a, b, c, d });
                d++;
                if (d > 6)
                {
                    d = 1;
                    c++;
                }
                if (c > 6)
                {
                    c = 1;
                    b++;
                }
                if (b > 6)
                {
                    b = 1;
                    a++;
                }
            }
        }

        private bool AreUnique(int a, int b, int c, int d)
        {
            return (a != b && a != c && a != d && b != c && b != d && c != d);
        }

        private void ResetAlt()
        {
            guesses.Clear();
            int a = 1, b = 2, c = 3, d = 4;
            while (a < 10)
            {
                if (AreUnique(a, b, c, d))
                    guesses.Add(new int[] { a, b, c, d });
                d++;
                if (d > 9)
                {
                    d = 1;
                    c++;
                }
                if (c > 9)
                {
                    c = 1;
                    b++;
                }
                if (b > 9)
                {
                    b = 1;
                    a++;
                }
            }
        }

        private int[] Compare(int[] lis1, int[] lis2)
        {
            List<int> paired1 = new List<int>();
            List<int> paired2 = new List<int>();
            int right = 0, close = 0;
            for (int i = 0; i < 4; i++)
            {
                if (lis1[i] == lis2[i])
                {
                    right++;
                    paired1.Add(i);
                    paired2.Add(i);
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (lis2[j] == lis1[i] && !paired2.Contains(j) &&!paired1.Contains(i) && lis2[j] != lis1[j])
                        {
                            close++;
                            paired1.Add(i);
                            paired2.Add(j);
                        }
                    }
                }
            }
            return new int[] { right, close };
        }

        private int[] CompareAlt(int[] lis1, int[] lis2)
        {
            int close = lis1.CountIfIn(lis2);
            int right = 0;
            for (int i = 0; i < 4; i++)
            {
                if (lis1[i] == lis2[i])
                {
                    right++;
                    close--;
                }
            }
            return new int[] { right, close };
        }

        private void WriteGuess(int[] guess)
        {
            Console.Write(guess[0]);
            Console.Write(", ");
            Console.Write(guess[1]);
            Console.Write(", ");
            Console.Write(guess[2]);
            Console.Write(", ");
            Console.WriteLine(guess[3]);
        }

        #region outcomes
        private int[][] outcomes = new int[][] 
        {
            new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 0, 4 }, new int[]{ 1 , 0 },
            new int[] { 1 , 1 }, new int[] { 1 , 2 }, new int[] { 1 , 3 }, new int[] { 2 , 0 }, new int[] { 2 , 1 }, new int[] { 2 , 2 },
            new int[] { 3 , 0 }, new int[] { 4 , 0 }
        };
        #endregion

        private int[] MiniMax(int game = 0)
        {
            if (guesses.Count == 1)
                return guesses[0];
            if (guesses.Count > 45)
                Console.WriteLine("Thinking...");
            //create min variable init to the max value of an integer and a mindex variable init to 0
            int min = Int32.MaxValue;
            int mindex = 0;
            //iterate through the possible guesses (as possibility), noting the index of the guess and creating a max variable init to 0
            for (int i = 0; i < guesses.Count; i++)
            {
                int[] possibility = guesses[i];
                //create an int[] initialised with 14 zeroes (one for each outcome) called outcomeCounts
                int[] outcomeCounts = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                //iterate through every possible guess (this time as solution)
                foreach (int[] solution in guesses)
                {
                    //in each iteration compare the possibility to the solution
                    //increase a value in outcomeCounts corresponding to the outcome by 1
                    int[] compare = new int[] { 1, 1, 1, 1 };
                    if (game != 1)
                        compare = Compare(possibility, solution);
                    else
                        compare = CompareAlt(possibility, solution);
                    #region Hefty If/Else Statement
                    if (compare.SequenceEqual(new int[] { 0, 0 }))
                        outcomeCounts[0]++;
                    else if (compare.SequenceEqual(new int[] { 0, 1 }))
                        outcomeCounts[1]++;
                    else if (compare.SequenceEqual(new int[] { 0, 2 }))
                        outcomeCounts[2]++;
                    else if (compare.SequenceEqual(new int[] { 0, 3 }))
                        outcomeCounts[3]++;
                    else if (compare.SequenceEqual(new int[] { 0, 4 }))
                        outcomeCounts[4]++;
                    else if (compare.SequenceEqual(new int[] { 1, 0 }))
                        outcomeCounts[5]++;
                    else if (compare.SequenceEqual(new int[] { 1, 1 }))
                        outcomeCounts[6]++;
                    else if (compare.SequenceEqual(new int[] { 1, 2 }))
                        outcomeCounts[7]++;
                    else if (compare.SequenceEqual(new int[] { 1, 3 }))
                        outcomeCounts[8]++;
                    else if (compare.SequenceEqual(new int[] { 2, 0 }))
                        outcomeCounts[9]++;
                    else if (compare.SequenceEqual(new int[] { 2, 1 }))
                        outcomeCounts[10]++;
                    else if (compare.SequenceEqual(new int[] { 2, 2 }))
                        outcomeCounts[11]++;
                    else if (compare.SequenceEqual(new int[] { 3, 0 }))
                        outcomeCounts[12]++;
                    else if (compare.SequenceEqual(new int[] { 4, 0 }))
                        outcomeCounts[13]++;
                    #endregion
                }
                //take the largest number in outcomeCounts as max
                int max = outcomeCounts.Max();
                //once this is complete, if max < min then min = max, and mindex = current index
                if (max < min)
                {
                    min = max;
                    mindex = i;
                }
            }
            //repeat the process on guesses that are impossible (ruled out of being the right answer but may result in a faster solve if guessed)
            int mindex2 = -1;
            for (int i = 0; i < impossible.Count; i++)
            {
                int[] possibility = impossible[i];
                int[] outcomeCounts = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                foreach (int[] solution in guesses)
                {
                    int[] compare = new int[] { 1, 1, 1, 1 };
                    if (game != 1)
                        compare = Compare(possibility, solution);
                    else
                        compare = CompareAlt(possibility, solution);
                    #region Hefty If/Else Statement
                    if (compare.SequenceEqual(new int[] { 0, 0 }))
                        outcomeCounts[0]++;
                    else if (compare.SequenceEqual(new int[] { 0, 1 }))
                        outcomeCounts[1]++;
                    else if (compare.SequenceEqual(new int[] { 0, 2 }))
                        outcomeCounts[2]++;
                    else if (compare.SequenceEqual(new int[] { 0, 3 }))
                        outcomeCounts[3]++;
                    else if (compare.SequenceEqual(new int[] { 0, 4 }))
                        outcomeCounts[4]++;
                    else if (compare.SequenceEqual(new int[] { 1, 0 }))
                        outcomeCounts[5]++;
                    else if (compare.SequenceEqual(new int[] { 1, 1 }))
                        outcomeCounts[6]++;
                    else if (compare.SequenceEqual(new int[] { 1, 2 }))
                        outcomeCounts[7]++;
                    else if (compare.SequenceEqual(new int[] { 1, 3 }))
                        outcomeCounts[8]++;
                    else if (compare.SequenceEqual(new int[] { 2, 0 }))
                        outcomeCounts[9]++;
                    else if (compare.SequenceEqual(new int[] { 2, 1 }))
                        outcomeCounts[10]++;
                    else if (compare.SequenceEqual(new int[] { 2, 2 }))
                        outcomeCounts[11]++;
                    else if (compare.SequenceEqual(new int[] { 3, 0 }))
                        outcomeCounts[12]++;
                    else if (compare.SequenceEqual(new int[] { 4, 0 }))
                        outcomeCounts[13]++;
                    #endregion
                }
                int max = outcomeCounts.Max();
                if (max < min)
                {
                    min = max;
                    mindex2 = i;
                }
            }
            // once this is complete, return guesses[mindex]
            return (mindex2 == -1 ? guesses.Pop(mindex) : impossible.Pop(mindex2));
        }
        public void Solve()
        {
            Reset();
            int turns = 0;
            bool solved = false;
            int[] guess = { 1, 1, 2, 2 };
            while (!solved)
            {
                if (guesses.Count == 0)
                {
                    Console.WriteLine("You cheated!");
                    break;
                }
                if (turns != 0)
                {
                    //guess = guesses[0];
                    guess = MiniMax();
                }
                turns++;
                WriteGuess(guess);
                Console.WriteLine("How many are in the right place?");
                int right = 0;
                string z = string.Empty;
                while (z.Length == 0)
                    z = Console.ReadLine();
                right = int.Parse(z);
                if (right >= 4)
                    solved = true;
                else
                {
                    Console.WriteLine("How many are in the wrong place?");
                    int close = 0;
                    z = String.Empty;
                    while (z.Length == 0)
                        z = Console.ReadLine();
                    close = int.Parse(z);
                    int[] score = { right, close };
                    int i = 0;
                    while (i < guesses.Count)
                    {
                        int[] compare = Compare(guess, guesses[i]);
                        if (compare[0] == score[0] && compare[1] == score[1])
                            i++;
                        else
                            impossible.Add(guesses.Pop(i));
                    }
                }
            }
            if (solved)
                Console.Write("Got it in "); Console.Write(turns); Console.WriteLine(" guesses.");
        }

        public void SolveAlt()
        {
            ResetAlt();
            int turns = 0;
            bool solved = false;
            int[] guess = guesses[0];
            while (!solved)
            {
                if (guesses.Count == 0)
                {
                    Console.WriteLine("You cheated!");
                    break;
                }
                //guess = guesses[0];
                if (turns != 0)
                    guess = MiniMax(1);
                turns++;
                WriteGuess(guess);
                Console.WriteLine("How many are in the right place?");
                int right = 0;
                string z = string.Empty;
                while (z.Length == 0)
                {
                    z = Console.ReadLine();
                }
                right = int.Parse(z);
                if (right >= 4)
                    solved = true;
                else
                {
                    Console.WriteLine("How many are in the wrong place?");
                    int close = 0;
                    z = String.Empty;
                    while (z.Length == 0)
                    {
                        z = Console.ReadLine();
                    }
                    close = int.Parse(z);
                    int[] score = { right, close };
                    int i = 0;
                    while (i < guesses.Count)
                    {
                        int[] compare = CompareAlt(guess, guesses[i]);
                        if (compare[0] == score[0] && compare[1] == score[1])
                            i++;
                        else
                            guesses.RemoveAt(i);
                    }
                }

            }
            if (solved)
                Console.Write("Got it in "); Console.Write(turns); Console.WriteLine(" guesses.");
        }

        public void Solve(int i = 0)
        {
            if (i == 1)
                SolveAlt();
            else
                Solve();
        }

    }
}
