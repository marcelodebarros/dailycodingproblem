using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem01142019
	{
		public int MaxNumberCoins(int[,] matrix)
		{
			if (matrix == null) return 0;

			int R = matrix.GetLength(0);
			int C = matrix.GetLength(1);
			int[,] dp = new int[R, C];

			//Base
			dp[0, 0] = matrix[0, 0];
			for (int c = 1; c < C; c++) dp[0, c] = dp[0, c - 1] + matrix[0, c];
			for (int r = 1; r < R; r++) dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];

			//Construction
			for (int r = 1; r < R; r++)
				for (int c = 1; c < C; c++)
					dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]) + matrix[r, c];

			return dp[R - 1, C - 1];
		}
	}
}
