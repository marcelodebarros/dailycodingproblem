using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem11142018
	{
		public long Exponentiation(long x, long y)
		{
			long result = 1;

			while (y > 0)
			{
				long exp = x;
				long count = 1;
				while (count * 2 <= y)
				{
					exp *= exp;
					count *= 2;
				}
				y -= count;
				result *= exp;
			}

			return result;
		}
	}
}
