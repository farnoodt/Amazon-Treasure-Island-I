using System;
using System.Collections.Generic;

namespace Treasure_Island_I
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            char[][] arr = new char[][] {  new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'D', 'O', 'D', 'O' },
                    new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'X', 'D', 'D', 'O' }};



            Console.WriteLine(treasureIsland(arr));
        }

        public static int treasureIsland(char[][] island)
        {

            int steps;
            bool[,] visited = new bool[island.Length, island[0].Length];
            int[][] dirs = new int[][]
            { new int[] { 1, 0 },
            new int[] { 0, 1 },
            new int[] { -1, 0 },
            new int[] { 0, -1 }
            };

            visited[0, 0] = true;
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(Tuple.Create(0, 0, 0));
            int x = 0;
            int y = 0;

            while (queue.Count > 0)
            {
                for (int i = 0; i < queue.Count; i++)
                {
                    x = queue.Peek().Item1;
                    y = queue.Peek().Item2;
                    steps = queue.Peek().Item3;
                    queue.Dequeue();
                    if (island[x][y] == 'X')
                    {
                        return steps;
                    }

                    //Console.WriteLine("Dequeue: " + x + "    " + y + "  Steps: " + steps);
                    foreach (int[] dir in dirs)
                    {
                        int newX = x + dir[0];
                        int newY = y + dir[1];

                        if (isSafe(island, newX, newY) && !visited[newX, newY])
                        {
                            //    if(island[newX][newY] == 'X')
                            //    {
                            //        return steps;
                            //    }

                            //Console.WriteLine("Enqueue: " + newX + "    " + newY + "  Steps: " + steps);
                            queue.Enqueue(Tuple.Create(newX, newY, steps + 1));
                            visited[newX, newY] = true;
                        }
                    }
                }
            }
            return -1;
        }

        public static bool isSafe(char[][] island, int x, int y)
        {
            return (x >= 0 && x < island.Length && y < island[0].Length && y >= 0 && island[x][y] != 'D');
        }


        public static void treasureIslandTests()
        {
            int[] testCount = { 0, 0 };
            Console.WriteLine("Treasure Island Tests");
            runTest(treasureIslandTests1, "should work for example case", testCount);
            runTest(treasureIslandTests2, "should work for example case", testCount);
            runTest(treasureIslandTests3, "should work for example case", testCount);

            runTest(treasureIslandTests4, "should work for example case", testCount);

            runTest(treasureIslandTests5, "should work for example case", testCount);

            runTest(treasureIslandTests6, "should work for example case", testCount);
            Console.WriteLine("PASSED: " + testCount[0] + " / " + testCount[1] + "\n\n");
        }


        private static bool treasureIslandTests1()
        {
            int solution = treasureIsland(
                new char[][] {  new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'D', 'O', 'D', 'O' },
                    new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'X', 'D', 'D', 'O' }});
            return solution.Equals(5);
        }


        private static bool treasureIslandTests2()
        {
            int solution = treasureIsland(
                new char[][] {  new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'X', 'D', 'D', 'O' }});
            return solution.Equals(1);
        }

        private static bool treasureIslandTests3()
        {
            int solution = treasureIsland(
                new char[][] {  new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'D', 'O', 'D', 'O' },
                    new char[] { 'D', 'O', 'O', 'O' },
                    new char[] { 'X', 'O', 'D', 'O' }});
            return solution.Equals(5);
        }
        private static bool treasureIslandTests4()
        {
            int solution = treasureIsland(
                new char[][] {  new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'D', 'O', 'D', 'O' },
                    new char[] { 'D', 'O', 'D', 'O' },
                    new char[] { 'X', 'O', 'D', 'O' }});
            return solution.Equals(5);
        }

        private static bool treasureIslandTests5()
        {
            int solution = treasureIsland(
                new char[][] {  new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'D', 'O', 'D', 'O' },
                    new char[] { 'D', 'O', 'D', 'O' },
                    new char[] { 'O', 'O', 'O', 'X' }});
            return solution.Equals(6);
        }

        private static bool treasureIslandTests6()
        {
            int solution = treasureIsland(
                new char[][] {  new char[] { 'O', 'O', 'O', 'O' },
                    new char[] { 'D', 'O', 'D', 'O' },
                    new char[] { 'D', 'O', 'D', 'X' },
                    new char[] { 'O', 'O', 'O', 'O' }});
            return solution.Equals(5);
        }

        private static void runTest(Func<bool> test, string testName, int[] testCount)
        {
            testCount[1]++;
            bool testPassed = false;
            // Attempt to run test and suppress exceptions on failure
            try
            {
                testPassed = test();
                if (testPassed) testCount[0]++;
            }
            catch (Exception e) { Console.WriteLine(e); }
            string result = "  " + (testCount[1] + ")   ") + testPassed + " : " + testName;
            Console.WriteLine(result);
        }
    }
}

