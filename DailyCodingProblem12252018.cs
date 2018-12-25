using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem12252018
	{
		public void ContiguousElementsSum(int[] numbers, int k)
		{
			Hashtable sumToIndex = new Hashtable();

			int shortestStartIndex = -1;
			int shortestLength = Int32.MaxValue;

			int sum = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				sum += numbers[i];
				if (!sumToIndex.ContainsKey(sum)) sumToIndex.Add(sum, i);
				else sumToIndex[sum] = i;

				int delta = sum - k;
				if (sumToIndex.ContainsKey(delta))
				{
					int startIndex = Math.Min((int)sumToIndex[delta] + 1, i);
					if (i - startIndex + 1 < shortestLength)
					{
						shortestLength = i - startIndex + 1;
						shortestStartIndex = startIndex;
					}
				}
			}

			if (shortestStartIndex >= 0)
			{
				Console.WriteLine("Shortest contiguous sum to {0}: [{1}, {2}]", k, shortestStartIndex, shortestStartIndex + shortestLength - 1);
			}
			else
			{
				Console.WriteLine("Sum not found");
			}
		}
	}
}
