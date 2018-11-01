using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10312018
	{
		public int MaxProfit(int[] prices)
		{
			if (prices == null) return 0;

			int minSoFar = Int32.MaxValue;
			int maxProfit = Int32.MinValue;

			for (int i = 0; i < prices.Length; i++)
			{
				int currentProfit = prices[i] - minSoFar;
				if (currentProfit > maxProfit) maxProfit = currentProfit;
				minSoFar = Math.Min(minSoFar, prices[i]);
			}

			return maxProfit > 0 ? maxProfit : 0;
		}
	}
}
