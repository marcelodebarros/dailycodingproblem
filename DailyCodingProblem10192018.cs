using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *
 * This problem was asked by Google.

Given an array of strictly the characters 'R', 'G', and 'B', segregate the values of the array so that all the Rs come first, the Gs come second, and the Bs come last. You can only swap elements of the array.

Do this in linear time and in-place.

For example, given the array ['G', 'B', 'R', 'R', 'B', 'R', 'G'], it should become ['R', 'R', 'R', 'G', 'G', 'B', 'B'].
 */

namespace DailyCodingProblem
{
	class DailyCodingProblem10192018
	{
		public string SortRGB(StringBuilder str)
		{
			if (str == null) return null;
			int nextIndex = 0;
			str = Sort(str, nextIndex, 'R', out nextIndex);
			Console.WriteLine(str);
			str = Sort(str, nextIndex, 'G', out nextIndex);
			return str.ToString();
		}

		private StringBuilder Sort(StringBuilder str, int startIndex, char anchor, out int nextIndex)
		{
			int indexMoveTo = startIndex;
			for (int i = startIndex; i < str.Length; i++)
			{
				if (str[i] == anchor)
				{
					char temp = str[indexMoveTo];
					str[indexMoveTo] = str[i];
					str[i] = temp;
					indexMoveTo++;
				}
			}
			nextIndex = indexMoveTo;
			return str;
		}
	}
}