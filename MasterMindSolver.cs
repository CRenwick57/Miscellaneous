using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindSolver
{
    class MasterMindSolver
    {
        private List<int[]> guesses;

        public MasterMindSolver()
        {
            guesses = new List<int[]>();
        }

        public void Reset()
        {
            guesses.Clear();
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
                        if (lis2[j] == lis1[i] && !paired2.Contains(j) && !paired1.Contains(i) && lis2[j] != lis1[j])
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

        private int[][] outcomes = new int[][] 
        {
            new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 0, 4 }, new int[]{ 1 , 0 },
            new int[] { 1 , 1 }, new int[] { 1 , 2 }, new int[] { 1 , 3 }, new int[] { 2 , 0 }, new int[] { 2 , 1 }, new int[] { 2 , 2 },
            new int[] { 3 , 0 }, new int[] { 4 , 0 }
        };

        private int[] MiniMax(int game = 0)
        {
            if (guesses.Count > 35)
                Console.WriteLine("Thinking...");
            //create min variable init to the max value of an integer and a mindex variable init to 0
            int min = Int32.MaxValue;
            int mindex = 0;
            //iterate through the possible guesses (as possibility), noting the index of the guess and creating a max variable init to 0
            for (int i = 0; i < guesses.Count; i++)
            {
                int max = 0;
                int[] possibility = guesses[i];
                //in each iteration iterate through every possible outcome and create a count variable init to 0
                foreach (int[] outcome in outcomes)
                {
                    int count = 0;
                    //in each iteration iterate through every guess (this time as solution)
                    foreach (int[] solution in guesses)
                    {
                        //in each iteration compare the possibility to the solution
                        //if the result is the same as the current outcome in iteration count++
                        int[] compare = new int[] { 1, 1, 1, 1 };
                        if (game != 1)
                            compare = Compare(possibility, solution);
                        else
                            compare = CompareAlt(possibility, solution);
                        if (compare[0] == outcome[0] && compare[1] == outcome[1])
                            count++;
                    }
                    //once this is complete, if count > max then max = count
                    if (count > max)
                        max = count;
                }
                //once this is complete, if max < min then min = max, and mindex = current index
                if (max < min)
                {
                    min = max;
                    mindex = i;
                }
            }
            // once this is complete, return guesses[mindex]
            return guesses.Pop(mindex);
        }

        public void Solve()
        {
            Reset();
            int turns = 0;
            bool solved = false;
            int[] guess = {1,1,2,2};
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
                        int[] compare = Compare(guess, guesses[i]);
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
