using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem11112018
	{
		public bool PartitionTwoSubsets(int[] set)
		{
			if (set == null) return true;
			int sum2 = 0;
			for (int i = 0; i < set.Length; i++) sum2 += set[i];
			return PartitionTwoSubsets(0, sum2, 0, set);
		}

		private bool PartitionTwoSubsets(int sum1,
										 int sum2,
										 int index,
										 int[] set)
		{
			if (index >= set.Length) return sum1 == sum2;
			return PartitionTwoSubsets(sum1 + set[index], sum2 - set[index], index + 1, set) ||
				   PartitionTwoSubsets(sum1, sum2, index + 1, set);
		}
	}
}
