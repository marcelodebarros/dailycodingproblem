using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem11182018
	{
		public void PrintSpiral(int[,] matrix, int n, int m)
		{
			int nCols = m;
			int nRows = n;

			for (int i = 0; i <= n / 2; i++)
			{
				//LR
				for (int j = i; j < nCols; j++) Console.WriteLine(matrix[i, j]);
				//UD
				for (int j = i + 1; j < nRows; j++) Console.WriteLine(matrix[j, nCols - 1]);
				//RL
				for (int j = nCols - 2; j >= i && nRows - 1 > i; j--) Console.WriteLine(matrix[nRows - 1, j]);
				//DU
				for (int j = nRows - 2; j > i; j--) Console.WriteLine(matrix[j, i]);
				nCols--;
				nRows--;
			}
		}
	}
}
