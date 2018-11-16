using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem11152018
	{
		public long NumberWaysDown(int n, int m)
		{
			long[,] matrix = new long[n, m];

			matrix[0, 0] = 1L;

			for (int r = 0; r < n; r++)
			{
				for (int c = 0; c < m; c++)
				{
					if (r - 1 >= 0) matrix[r, c] += matrix[r - 1, c];
					if (c - 1 >= 0) matrix[r, c] += matrix[r, c - 1];
				}
			}

			return matrix[n - 1, m - 1];
		}
	}
}
