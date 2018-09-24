using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem09232018
	{
		public int SumNonAdjacent(int[] input)
		{
			if (input == null) return 0;
			if (input.Length < 3) return Math.Max(input[0], input[1]);

			int max = Int32.MinValue;
			int pp = input[0];
			int p = Math.Max(pp, input[1]);

			for (int i = 2; i < input.Length; i++)
			{
				int c = input[i];
				if (pp > 0) c += pp;

				if (c > max) max = c;

				pp = Math.Max(p, pp);
				p = c;
			}

			return max;
		}

		public class StackItem
		{
			public Tree tree;
			public int level;

			public StackItem(Tree tree, int level)
			{
				this.tree = tree;
				this.level = level;
			}
		}

		public int DeepestNode(Tree tree)
		{
			if (tree == null) return 0;

			StackItem si = new StackItem(tree, 1);
			Stack stack = new Stack();
			stack.Push(si);
			int deepestLevel = -1;
			int deepestNode = 0;

			while (stack.Count > 0)
			{
				StackItem nsi = (StackItem)stack.Pop();

				if (nsi.level > deepestLevel)
				{
					deepestLevel = nsi.level;
					deepestNode = nsi.tree.val;
				}

				if (nsi.tree.left != null)
				{
					StackItem lsi = new StackItem(nsi.tree.left, nsi.level + 1);
					stack.Push(lsi);
				}
				if (nsi.tree.right != null)
				{
					StackItem rsi = new StackItem(nsi.tree.right, nsi.level + 1);
					stack.Push(rsi);
				}
			}


			return deepestNode;
		}

		public Tree BuildTree()
		{
			Tree tree = new Tree(0)
			{
				left = new Tree(1),
				right = new Tree(0)
				{
					left = new Tree(1)
					{
						left = new Tree(1),
						right = new Tree(1)
						{
							right = new Tree(0)
							{
								left = new Tree(42)
							}
						}
					},
					right = new Tree(0)
				}
			};

			return tree;
		}
	}
}
