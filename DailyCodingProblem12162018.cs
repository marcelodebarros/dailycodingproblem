using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem12162018
	{
		public Tree BuildTree()
		{
			Tree tree = new Tree(20);
			tree.left = new Tree(21);
			tree.left.left = new Tree(17);
			tree.left.right = new Tree(22);
			tree.right = new Tree(19);
			tree.right.right = new Tree(14);
			tree.right.right.left = new Tree(3);
			tree.right.right.right = new Tree(200);
			tree.right.left = new Tree(17);
			tree.right.left.left = new Tree(15);
			tree.right.left.right = new Tree(18);
			tree.right.left.left.left = new Tree(7);
			tree.right.left.left.right = new Tree(1);

			return tree;
		}

		public int LargestBST(Tree tree)
		{
			int max = 0;
			LargestBST(tree, ref max);
			return max;
		}

		private int LargestBST(Tree tree, ref int max)
		{
			if (tree == null) return 0;

			int maxLeft = LargestBST(tree.left, ref max);
			int maxRight = LargestBST(tree.right, ref max);

			int current = 1;
			if (tree.left != null && tree.val > tree.left.val)
				current += maxLeft;
			if (tree.right != null && tree.val <= tree.right.val)
				current += maxRight;

			max = (current > max) ? current : max;
			return current;
		}

		public int LargestBSTInOrder(Tree tree) /*Wrong!!!*/
		{
			LinkedList<int> sortedList = new LinkedList<int>();
			InOrderTraversal(tree, sortedList);

			//DP-like O(n)-time
			int currentSequence = 1;
			int maxSequence = 0;
			for (LinkedListNode<int> previous = null, current = sortedList.First; current != null; previous = current, current = current.Next)
			{
				currentSequence = (previous != null && current.Value > previous.Value) ? currentSequence + 1 : 1;
				maxSequence = (currentSequence > maxSequence) ? currentSequence : maxSequence;
			}

			return maxSequence;

		}

		private void InOrderTraversal(Tree tree, LinkedList<int> sortedList)
		{
			if (tree == null) return;
			InOrderTraversal(tree.left, sortedList);
			sortedList.AddLast(tree.val);
			InOrderTraversal(tree.right, sortedList);
		}
	}
}
