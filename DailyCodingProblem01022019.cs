using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem01022019
	{
		public IList<List<int>> AllPaths(Tree node)
		{
			if (node == null) return new List<List<int>>();

			List<List<int>> retVal = new List<List<int>>();
			Stack<StackItem2> stack = new Stack<StackItem2>();

			stack.Push(new StackItem2(node, new List<int>()));
			while (stack.Count > 0)
			{
				StackItem2 si2 = (StackItem2)stack.Pop();

				//Found leaf, end of path
				if (si2.node.left == null && si2.node.right == null)
				{
					si2.path.Add(si2.node.val);
					retVal.Add(si2.path);

					continue;
				}

				if (si2.node.left != null)
				{
					List<int> leftPath = si2.path.ToList<int>();
					leftPath.Add(si2.node.val);
					StackItem2 lsi2 = new StackItem2(si2.node.left, leftPath);
					stack.Push(lsi2);
				}
				if (si2.node.right != null)
				{
					List<int> rightPath = si2.path.ToList<int>();
					rightPath.Add(si2.node.val);
					StackItem2 rsi2 = new StackItem2(si2.node.right, rightPath);
					stack.Push(rsi2);
				}
			}

			return retVal;
		}
	}

	class StackItem2
	{
		public Tree node;
		public List<int> path;

		public StackItem2(Tree node, List<int> path)
		{
			this.node = node;
			this.path = path;
		}
	}
}
