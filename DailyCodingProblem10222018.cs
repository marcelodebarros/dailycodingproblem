using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem10222018
	{
		private int n = 0;
		private bool[,] board = null;
		public void QueensOnChessBoard(int n)
		{
			if (n <= 0) return;

			this.n = n;
			board = new bool[n, n];

			Hashtable[] queensPosition = new Hashtable[4];
			for (int i = 0; i < queensPosition.Length; i++) queensPosition[i] = new Hashtable();
			int solutions = 0;
			QueensOnChessBoard(0, queensPosition, ref solutions);
			Console.WriteLine("Number of solutions for N={0}: {1}", n, solutions);
		}

		private void QueensOnChessBoard(int r, Hashtable[] queensPosition, ref int solutions)
		{
			if (r >= n)
			{
				//PrintBoard();
				solutions++;
				return;
			}

			for (int c = 0; c < n; c++)
			{
				if (!queensPosition[0].ContainsKey(r) &&
					!queensPosition[1].ContainsKey(c) &&
					!queensPosition[2].ContainsKey(r + c) &&
					!queensPosition[3].ContainsKey(r - c))
				{
					queensPosition[0].Add(r, true);
					queensPosition[1].Add(c, true);
					queensPosition[2].Add(r + c, true);
					queensPosition[3].Add(r - c, true);

					board[r, c] = true;
					QueensOnChessBoard(r + 1, queensPosition, ref solutions);
					board[r, c] = false;

					queensPosition[0].Remove(r);
					queensPosition[1].Remove(c);
					queensPosition[2].Remove(r + c);
					queensPosition[3].Remove(r - c);
				}
			}
		}

		private void PrintBoard()
		{
			if (board == null) return;

			for (int r = 0; r < n; r++)
			{
				for (int c = 0; c < n; c++)
				{
					Console.Write("{0} ", board[r, c] ? 'Q' : '.');
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
