using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrothimGeek {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            Solution64 tt = new Solution64 ();

            int[][] grid = new int[14][];
            grid[0] = new int[17] { 5, 0, 1, 1, 2, 1, 0, 1, 3, 6, 3, 0, 7, 3, 3, 3, 1 };
            grid[1] = new int[17] { 1, 4, 1, 8, 5, 5, 5, 6, 8, 7, 0, 4, 3, 9, 9, 6, 0 };
            grid[2] = new int[17] { 2, 8, 3, 3, 1, 6, 1, 4, 9, 0, 9, 2, 3, 3, 3, 8, 4 };
            grid[3] = new int[17] { 3, 5, 1, 9, 3, 0, 8, 3, 4, 3, 4, 6, 9, 6, 8, 9, 9 };
            grid[4] = new int[17] { 3, 0, 7, 4, 6, 6, 4, 6, 8, 8, 9, 3, 8, 3, 9, 3, 4 };
            grid[5] = new int[17] { 8, 8, 6, 8, 3, 3, 1, 7, 9, 3, 3, 9, 2, 4, 3, 5, 1 };
            grid[6] = new int[17] { 7, 1, 0, 4, 7, 8, 4, 6, 4, 2, 1, 3, 7, 8, 3, 5, 4 };
            grid[7] = new int[17] { 3, 0, 9, 6, 7, 8, 9, 2, 0, 4, 6, 3, 9, 7, 2, 0, 7 };
            grid[8] = new int[17] { 8, 0, 8, 2, 6, 4, 4, 0, 9, 3, 8, 4, 0, 4, 7, 0, 4 };
            grid[9] = new int[17] { 3, 7, 4, 5, 9, 4, 9, 7, 9, 8, 7, 4, 0, 4, 2, 0, 4 };
            grid[10] = new int[17] { 5, 9, 0, 1, 9, 1, 5, 9, 5, 5, 3, 4, 6, 9, 8, 5, 6 };
            grid[11] = new int[17] { 5, 7, 2, 4, 4, 4, 2, 1, 8, 4, 8, 0, 5, 4, 7, 4, 7 };
            grid[12] = new int[17] { 9, 5, 8, 6, 4, 4, 3, 9, 8, 1, 1, 8, 7, 7, 3, 6, 9 };
            grid[13] = new int[17] { 7, 2, 3, 1, 6, 3, 6, 6, 6, 3, 2, 3, 9, 9, 4, 4, 8 };
            tt.MinPathSumCursion (grid.Length - 1, grid[0].Length - 1, grid, new Dictionary<string, int> ());
            Console.ReadLine ();
        }
    }
}