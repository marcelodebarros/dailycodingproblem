using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem12262018
	{
		public string MinCoveringSubstring(string str, string letters)
		{
			if (String.IsNullOrEmpty(str) || String.IsNullOrEmpty(letters)) return "";

			Hashtable ht = new Hashtable();
			Hashtable count = new Hashtable();
			foreach (char l in letters)
			{
				if (!ht.ContainsKey(l)) ht.Add(l, 0);
				ht[l] = (int)ht[l] + 1;
				if (!count.ContainsKey(l)) count.Add(l, 0);
			}

			int shortestStartIndex = -1;
			int shortestDistance = Int32.MaxValue;
			int tally = 0;

			int behind = 0;
			int ahead = -1;
			while (behind < str.Length)
			{
				if (tally == ht.Count)
				{
					//Found "a" solution
					if (ahead - behind + 1 < shortestDistance)
					{
						shortestDistance = ahead - behind + 1;
						shortestStartIndex = behind;
					}

					//Increment behind pointer
					if (count.ContainsKey(str[behind]))
					{
						count[str[behind]] = (int)count[str[behind]] - 1;
						if ((int)count[str[behind]] == (int)ht[str[behind]] - 1) tally--;
					}
					behind++;
				}
				else
				{
					//Increment ahead pointer
					ahead++;
					if (ahead < str.Length && count.ContainsKey(str[ahead]))
					{
						count[str[ahead]] = (int)count[str[ahead]] + 1;
						if ((int)count[str[ahead]] == (int)ht[str[ahead]]) tally++;
					}
					else if (ahead >= str.Length) //End of string? Increment behind pointer
					{
						ahead = str.Length;
						if (count.ContainsKey(str[behind]))
						{
							count[str[behind]] = (int)count[str[behind]] - 1;
							if ((int)count[str[behind]] == (int)ht[str[behind]] - 1) tally--;
						}
						behind++;
					}
				}
			}

			return (shortestStartIndex == -1) ? "" : str.Substring(shortestStartIndex, shortestDistance);
		}
	}
}
