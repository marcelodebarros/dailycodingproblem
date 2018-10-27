using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem10262018
	{
		public int[] FindSubsetAddsToTarget(int[] set, int target)
		{
			LinkedList<int> subset = new LinkedList<int>();
			int[] retVal = null;
			FindSubsetAddsToTarget(set, 0, subset, ref retVal, 0, target);
			return retVal;
		}

		private bool FindSubsetAddsToTarget(int[] set,
											int currentIndex,
											LinkedList<int> subset,
											ref int[] retVal,
											int currentSum,
											int target)
		{
			//Base
			if (currentSum == target && subset.Count > 0)
			{
				retVal = subset.ToArray<int>();
				return true;
			}
			if (currentIndex >= set.Length) return false;

			//Don't add
			if (FindSubsetAddsToTarget(set, currentIndex + 1, subset, ref retVal, currentSum, target)) return true;

			//Add
			subset.AddLast(set[currentIndex]);
			if (FindSubsetAddsToTarget(set, currentIndex + 1, subset, ref retVal, currentSum + set[currentIndex], target)) return true;
			subset.RemoveLast();

			return false;
		}
	}
}
