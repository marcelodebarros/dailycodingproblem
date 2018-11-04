using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem11022018
	{
		public int MaximunSum(int[] numbers)
		{
			int max = 0;
			int current = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				current = Math.Max(current + numbers[i], 0);
				max = Math.Max(current, max);
			}

			return max;
		}
	}
}
