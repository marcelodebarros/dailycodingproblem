using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem10012018
	{
		public int LenLongestPath(string path)
		{
			string retVal = "";
			string[] parts = path.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
			Stack stack = new Stack();
			StackItem si = new StackItem("", -1);
			stack.Push(si);

			for (int i = 1; i < parts.Length; i++)
			{
				int numberTabs = 0;
				while (parts[i].StartsWith("\t"))
				{
					parts[i] = parts[i].Substring(1);
					numberTabs++;
				}

				if (numberTabs > si.level)
				{
					if (parts[i].Contains("."))
					{
						if ((si.fullName + "/" + parts[i]).Length > retVal.Length)
						{
							retVal = si.fullName + "/" + parts[i];
						}
					}
					else
					{
						si = new StackItem(si.fullName + "/" + parts[i], si.level + 1);
						stack.Push(si);
					}
				}
				else
				{
					si = (StackItem)stack.Pop();
					si = new StackItem(si.fullName + "/" + parts[i], si.level + 1);
					stack.Push(si);
				}
			}

			Console.WriteLine(retVal);
			return retVal.Length;
		}
	}

	class StackItem
	{
		public string fullName;
		public int level;

		public StackItem(string fullName, int level)
		{
			this.fullName = fullName;
			this.level = level;
		}
	}
}
