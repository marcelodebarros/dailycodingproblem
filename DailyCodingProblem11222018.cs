using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem11222018
	{
		public int Max3(int[] numbers)
		{
			int top1 = Int32.MinValue;
			int top2 = Int32.MinValue;
			int top3 = Int32.MinValue;
			int bottom1 = Int32.MaxValue;
			int bottom2 = Int32.MaxValue;

			for (int i = 0; i < numbers.Length; i++)
			{
				GetTop3Max(numbers[i], ref top1, ref top2, ref top3);
				GetBottom3Min(numbers[i], ref bottom1, ref bottom2);
			}

			return Math.Max(bottom1 * bottom2 * top1, top1 * top2 * top3);
		}

		private void GetTop3Max(int n,
								ref int top1,
								ref int top2,
								ref int top3)
		{
			if (n >= top1)
			{
				top3 = top2;
				top2 = top1;
				top1 = n;
			}
			else if (n >= top2)
			{
				top3 = top2;
				top2 = n;
			}
			else if (n >= top3)
			{
				top3 = n;
			}
		}

		private void GetBottom3Min(int n,
								   ref int bottom1,
								   ref int bottom2)
		{
			if (n <= bottom1)
			{
				bottom2 = bottom1;
				bottom1 = n;
			}
			else if (n <= bottom2)
			{
				bottom2 = n;
			}
		}
	}
}
