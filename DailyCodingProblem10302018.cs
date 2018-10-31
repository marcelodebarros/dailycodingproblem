using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10302018
	{
		public string LongestPalindrome(string str)
		{
			if (String.IsNullOrEmpty(str)) return str;

			string longest = "";
			for (int i = 0; i < str.Length; i++)
			{
				//Odd
				int l = i;
				int r = i;
				string current = "";
				while (l >= 0 && r < str.Length)
				{
					if (str[l] != str[r]) break;
					if (l == r) current += str[l].ToString();
					else current = str[l].ToString() + current + str[r].ToString();
					l--;
					r++;
				}
				if (current.Length > longest.Length) longest = current;

				//Even
				l = i;
				r = i + 1;
				current = "";
				while (l >= 0 && r < str.Length)
				{
					if (str[l] != str[r]) break;
					if (l == r) current += str[l].ToString();
					else current = str[l].ToString() + current + str[r].ToString();
					l--;
					r++;
				}
				if (current.Length > longest.Length) longest = current;
			}

			return longest;
		}
	}
}
