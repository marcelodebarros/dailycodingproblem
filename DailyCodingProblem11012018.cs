using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem11012018
	{
		public TreeChar BuildTree(string preOrder, string inOrder)
		{
			if (String.IsNullOrEmpty(preOrder) || String.IsNullOrEmpty(inOrder)) return null;
			Hashtable position = new Hashtable();
			for (int i = 0; i < inOrder.Length; i++) position.Add(inOrder[i], i);
			return BuildTree(preOrder, inOrder, 0, 0, inOrder.Length - 1, position);
		}

		private TreeChar BuildTree(string preOrder,
							   string inOrder,
							   int indexPreOrder,
							   int leftInOrder,
							   int rightInOrder,
							   Hashtable position)
		{
			//Base case
			if (String.IsNullOrEmpty(preOrder) ||
			    String.IsNullOrEmpty(inOrder) ||
				indexPreOrder >= preOrder.Length ||
				leftInOrder > rightInOrder)
			{
				return null;
			}

			//Induction
			int indexInOrder = (int)position[preOrder[indexPreOrder]];
			if (indexInOrder < leftInOrder || indexInOrder > rightInOrder)
			{
				return BuildTree(preOrder,
								 inOrder,
								 indexPreOrder + 1,
								 leftInOrder,
								 rightInOrder,
								 position);
			}

			TreeChar tree = new TreeChar(preOrder[indexPreOrder]);
			tree.left = BuildTree(preOrder,
								  inOrder,
								  indexPreOrder + 1,
								  leftInOrder,
								  indexInOrder - 1,
								  position);
			tree.right = BuildTree(preOrder,
								   inOrder,
								   indexPreOrder + 1,
								   indexInOrder + 1,
								   rightInOrder,
								   position);

			return tree;
		}
	}

	internal class TreeChar
	{
		public char val = ' ';
		public TreeChar left = null;
		public TreeChar right = null;

		public TreeChar(char val)
		{
			this.val = val;
			this.left = null;
			this.right = null;
		}
	}
}
