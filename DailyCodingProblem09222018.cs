using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem09222018
	{
		private readonly Tree tree = null;
		public DailyCodingProblem09222018()
		{
			tree = BuildTree();
		}
		public int Unival()
		{
			int count = 0;
			_UniVal(tree, ref count);
			return count;
		}

		private bool _UniVal(Tree tree, ref int count)
		{
			//Base case
			if (tree == null)
			{
				count = 0;
				return true; //Axiom: null tree is unival
			}

			//Post-order L and then R
			int leftCount = 0;
			bool isLeftUnival = _UniVal(tree.left, ref leftCount);
			int rightCount = 0;
			bool isRightUnival = _UniVal(tree.right, ref rightCount);

			//Process current 
			count += leftCount + rightCount;
			if ((tree.left == null || (isLeftUnival && tree.left.val == tree.val)) &&
				(tree.right == null || (isRightUnival && tree.right.val == tree.val)))
			{
				count++;
				return true;
			}
			return false;
		}

		private Tree BuildTree()
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
					},
					right = new Tree(0)
				}
			};

			return tree;
		}
	}

	internal class Tree
	{
		public int val = 0;
		public Tree left = null;
		public Tree right = null;

		public Tree(int val)
		{
			this.val = val;
			this.left = null;
			this.right = null;
		}
	}
}
