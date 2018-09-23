using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem09232018
	{
		public int SumNonAdjacent(int[] input)
		{
			if (input == null) return 0;
			if (input.Length < 3) return Math.Max(input[0], input[1]);

			int max = Int32.MinValue;
			int pp = input[0];
			int p = Math.Max(pp, input[1]);

			for (int i = 2; i < input.Length; i++)
			{
				int c = input[i];
				if (pp > 0) c += pp;

				if (c > max) max = c;

				pp = Math.Max(p, pp);
				p = c;
			}

			return max;
		}
	}
}
