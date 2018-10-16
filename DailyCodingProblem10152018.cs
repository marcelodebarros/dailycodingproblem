using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10152018
	{
		public int EditDistance(string s1, string s2)
		{
			if (String.IsNullOrEmpty(s1)) return String.IsNullOrEmpty(s2) ? 0 : s2.Length;
			if (String.IsNullOrEmpty(s2)) return String.IsNullOrEmpty(s1) ? 0 : s1.Length;

			int[,] cost = new int[s1.Length + 1, s2.Length + 1];
			for (int i = 0; i <= s1.Length; i++) cost[i, 0] = i;
			for (int i = 0; i <= s2.Length; i++) cost[0, i] = i;

			for (int i = 0; i < s1.Length; i++)
			{
				for (int j = 0; j < s2.Length; j++)
				{
					if (s1[i] == s2[j]) cost[i + 1, j + 1] = cost[i, j];
					else cost[i + 1, j + 1] = Math.Min(Math.Min(cost[i + 1, j], cost[i, j + 1]), cost[i, j]) + 1;
				}
			}

			return cost[s1.Length, s2.Length];
		}
	}
}
