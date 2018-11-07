using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem11062018
	{
		private Stack[] stack = null;

		public DailyCodingProblem11062018()
		{
			stack = new Stack[2];
			stack[0] = new Stack();
			stack[1] = new Stack();
		}

		public void Enqueue(string item)
		{
			stack[0].Push(item);
		}

		public string Dequeue()
		{
			if (stack[0].Count == 0) return null;

			//Get, swap, remove
			string retVal = SwapStacksReturnLast(stack[0], stack[1], true);
			//Swap back, don't remove, ignore the result
			SwapStacksReturnLast(stack[1], stack[0], false);
			return retVal;

		}

		private string SwapStacksReturnLast(Stack from, Stack to, bool remove)
		{
			string retVal = "";
			while (from.Count > 0)
			{
				retVal = (string)from.Pop();
				if (!remove || from.Count > 0)
					to.Push(retVal);
			}
			return retVal;
		}
	}
}
