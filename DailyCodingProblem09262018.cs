using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem09262018
	{
		public long StaircaseUniqueWays(int N, int[] steps)
		{
			long[] stair = new long[N + 1];

			stair[0] = 1;

			for (int i = 1; i <= N; i++)
			{
				long val = 0;
				for (int j = 0; j < steps.Length; j++)
					if (i - steps[j] >= 0)
						val += stair[i - steps[j]];
				stair[i] = val;
			}

			return stair[N];
		}
	}
}
