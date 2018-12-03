using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem12032018
	{
		public int DeepestNodeValue(Tree tree)
		{
			int maxDepth = 0;
			int deepestNode = -1;

			DeepestNodeValue(tree, 0, ref maxDepth, ref deepestNode);

			return deepestNode;
		}

		private void DeepestNodeValue(Tree tree, int currentDepth, ref int maxDepth, ref int deepestNode)
		{
			//Base case
			if (tree == null) return;

			if (tree.left == null && tree.right == null)
			{
				maxDepth = currentDepth;
				deepestNode = tree.val;
				return;
			}

			//Post-order induction
			int maxDepthLeft = -1;
			int deepestNodeLeft = -1;
			DeepestNodeValue(tree.left, currentDepth + 1, ref maxDepthLeft, ref deepestNodeLeft);

			int maxDepthRight = -1;
			int deepestNodeRight = -1;
			DeepestNodeValue(tree.right, currentDepth + 1, ref maxDepthRight, ref deepestNodeRight);

			if (maxDepthLeft > maxDepth)
			{
				maxDepth = maxDepthLeft;
				deepestNode = deepestNodeLeft;
			}
			if (maxDepthRight > maxDepth)
			{
				maxDepth = maxDepthRight;
				deepestNode = deepestNodeRight;
			}
		}
	}
}
