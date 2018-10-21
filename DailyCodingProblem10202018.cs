using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given the root to a binary search tree, find the second largest node in the tree.
 */

namespace DailyCodingProblem
{
	class DailyCodingProblem10202018
	{
		public Tree CreateBST()
		{
			Tree tree = new Tree(10);
			tree.left = new Tree(5);
			tree.right = new Tree(15);
			tree.left.right = new Tree(8);
			tree.left.left = new Tree(3);
			tree.right.left = new Tree(12);
			return tree;
		}

		public int SecondLargest(Tree tree)
		{
			int index = 0;
			int lookingFor = 2;
			int val = 0;
			SecondLargest(tree, lookingFor, ref index, ref val);
			return val;
		}
		private bool SecondLargest(Tree tree, int lookingFor, ref int index, ref int val)
		{
			if (tree == null) return false; //Done

			bool found = SecondLargest(tree.right, lookingFor, ref index, ref val);
			if (found) return true;

			index++;
			if (index == lookingFor)
			{
				val = tree.val;
				return true;
			}

			return SecondLargest(tree.left, lookingFor, ref index, ref val);
		}
	}
}
