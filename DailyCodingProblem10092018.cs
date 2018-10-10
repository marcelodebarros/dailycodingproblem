using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10092018
	{
		private bool MatchesEmptyInput(string regex)
		{
			if (String.IsNullOrEmpty(regex)) return true;

			int index = regex.Length;
			while (--index >= 0)
			{
				if (regex[index] == '*') continue;
				if (index + 1 >= regex.Length || regex[index + 1] != '*') return false;
			}
			return true;
		}

		public bool RegEx(string regex, string input)
		{
			//Base case{
			if (String.IsNullOrEmpty(regex)) return String.IsNullOrEmpty(input);
			if (String.IsNullOrEmpty(input)) return MatchesEmptyInput(regex);
			//Base case}

			//Induction{
			//Some easy cases first, like simple chars
			if (regex[regex.Length - 1] != '.' && regex[regex.Length - 1] != '*')
			{
				if (regex[regex.Length - 1] != input[input.Length - 1]) return false;
				return RegEx(regex.Remove(regex.Length - 1), input.Remove(input.Length - 1));
			}
			//Or simple match with '.'
			else if (regex[regex.Length - 1] == '.') return RegEx(regex.Remove(regex.Length - 1), input.Remove(input.Length - 1));
			//This is the interesting and more convoluted one... matches zero or more
			else if (regex[regex.Length - 1] == '*')
				return RegEx(regex.Substring(0, regex.Length - 2), input) ||
					   ((regex[regex.Length - 2] == input[input.Length - 1] || regex[regex.Length - 2] == '.') 
					     && RegEx(regex, input.Substring(0, input.Length - 1)));

			return false;
			//Induction}
		}
	}
}
