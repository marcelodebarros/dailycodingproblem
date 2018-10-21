using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This problem was asked by Google.

The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.

For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.
 */

namespace DailyCodingProblem
{
	class DailyCodingProblem10212018
	{
		public void PrintSubsets(string str)
		{
			if (String.IsNullOrEmpty(str))
			{
				Console.WriteLine("1. ");
				return;
			}

			long max = (long)Math.Pow(2, str.Length);
			for (long i = 0; i < max; i++)
			{
				string subset = "";
				long temp = i;
				int index = 0;
				while (temp > 0)
				{
					if (temp % 2 == 1) subset += str[index].ToString();
					temp /= 2;
					index++;
				}
				Console.WriteLine("{0}. {1}", i + 1, subset);
			}
		}
	}
}
