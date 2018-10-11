using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem10112018
	{
		public bool BracketsBalanced(string str)
		{
			if (String.IsNullOrEmpty(str)) return true;

			string b = "(){}[]";
			Hashtable brackets = new Hashtable();
			for (int i = 0; i < b.Length; i += 2) brackets.Add(b[i], b[i + 1]);

			Stack<char> stack = new Stack<char>();

			for (int i = 0; i < str.Length; i++)
			{
				if (brackets.ContainsKey(str[i])) stack.Push(str[i]);
				else
				{
					if (stack.Count == 0) return false;
					char c = stack.Pop();
					if (!brackets.ContainsKey(c) || (char)brackets[c] != str[i]) return false;
				}
			}
			return stack.Count() == 0;
		}
	}
}
