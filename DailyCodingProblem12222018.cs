using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem12222018
	{
		public int LongestConsecutiveElementSequence(int[] numbers)
		{
			if (numbers == null) return 0;

			//O(n)-time and O(n)-space
			Hashtable count = new Hashtable();
			for (int i = 0; i < numbers.Length; i++) if (!count.ContainsKey(numbers[i])) count.Add(numbers[i], true);

			//O(n)-time and O(n)-space
			//Each cell is only visited at most twice for a total of 2n-time and 2n-space, hence O(n) for both
			int longestSequenceLength = 0;
			Hashtable visited = new Hashtable();
			foreach(int n in count.Keys)
			{
				if (!visited.ContainsKey(n))
				{
					visited.Add(n, true);
					int current = 1;

					//Left
					int left = n - 1;
					while (!visited.ContainsKey(left) && count.ContainsKey(left))
					{
						visited.Add(left, true);
						left--;
						current++;
					}

					//Right
					int right = n + 1;
					while (!visited.ContainsKey(right) && count.ContainsKey(right))
					{
						visited.Add(right, true);
						right++;
						current++;
					}

					longestSequenceLength = Math.Max(longestSequenceLength, current);
				}
			}

			return longestSequenceLength;
		}
	}
}
