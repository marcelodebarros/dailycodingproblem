using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem12092018
	{
		public int BracketsMistakes(string brackets)
		{
			if (String.IsNullOrEmpty(brackets)) return 0;

			int errors = 0;
			int countOpen = 0;
			for (int i = 0; i < brackets.Length; i++)
			{
				if (brackets[i] == '(') countOpen++;
				else
					if (countOpen == 0) errors++;
					else countOpen--;
			}
			errors += countOpen;
			return errors;
		}
	}
}
