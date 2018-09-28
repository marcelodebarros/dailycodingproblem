using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem09272018
	{
		public string LongestSubstringDistinctK(string str, int k)
		{
			if (String.IsNullOrEmpty(str)) return str;

			Hashtable htChars = new Hashtable();
			int back = 0;
			int front = back;
			int beginSolution = 0;
			int endSolution = 0;

			while (front < str.Length)
			{
				if ( (htChars.Count < k && !htChars.ContainsKey(str[front])) ||
					 (htChars.Count <= k && htChars.ContainsKey(str[front])) )
				{
					if (front - back > endSolution - beginSolution)
					{
						beginSolution = back;
						endSolution = front;
					}
					if (!htChars.ContainsKey(str[front]))
					{
						htChars.Add(str[front], 1);
					}
					else
					{
						htChars[str[front]] = (int)htChars[str[front]] + 1;
					}
					front++;
				}
				else
				{
					//Remove the back and move it
					htChars[str[back]] = (int)htChars[str[back]] - 1;
					if ((int)htChars[str[back]] == 0) htChars.Remove(str[back]);
					back++;
				}
			}

			return str.Substring(beginSolution, endSolution - beginSolution + 1);
		}
	}
}
