using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10292018
	{
		public void RndMGivenN(int n, int m)
		{
			Random rd = new Random();
			int N = 1000000;

			int[] buckets = new int[n];
			for (int i = 0; i < N; i++)
			{
				buckets[rd.Next(1, n + 1) - 1]++;
			}
			Console.WriteLine("Distribution for Rnd{0}", n);
			for (int i = 0; i < buckets.Length; i++)
			{
				Console.WriteLine("{0}: {1}%", i + 1, buckets[i] * 100.0 / N);
			}
			Console.WriteLine();

			int[] bm = new int[m];
			for (int i = 0; i < N; i++)
			{
				int sum = 0;
				for (int j = 0; j < n * m; j++)
				{
					sum += rd.Next(1, n + 1);
				}
				bm[sum % m]++;
			}
			Console.WriteLine("Distribution for Rnd{0}", m);
			for (int i = 0; i < bm.Length; i++)
			{
				Console.WriteLine("{0}: {1}%", i + 1, bm[i] * 100.0 / N);
			}
		}
	}
}
