using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem12242018
	{
		public void MinGoldbachNumbers(long n)
		{
			if (n < 2 || n % 2 == 1)
			{
				Console.WriteLine("Invalid input");
				return;
			}

			//Sieve, O(n)-time, O(n)-space
			Console.Write("Sieving...");
			bool[] composed = new bool[n + 1];
			composed[0] = composed[1] = true;
			for (long i = 2; i < Math.Sqrt(n); i++)
				for (long j = 2; i * j <= n; j++)
					composed[i * j] = true;
			Console.WriteLine("Done!");

			//Two-pointers, O(n)-time
			long left = 2;
			while (composed[left]) left++;
			long right = n - 2;
			while (composed[right]) right--;
			while (left <= right)
			{
				if (left + right == n)
				{
					Console.WriteLine("{0} + {1} = {2}", left, right, n);
					break; ;
				}
				else if (left + right > n)
				{
					right--;
					while (composed[right]) right--;
				}
				else
				{
					left++;
					while (composed[left]) left++;
				}
			}
		}
	}
}
