using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem11032018
	{
		public double EvaluateTreeExpression(TreeChar expression)
		{
			//Base
			if (expression == null) return 0;

			//Induction
			int leaf = 0;
			if (Int32.TryParse(expression.val.ToString(), out leaf)) return leaf;
			if (expression.val == '+') return EvaluateTreeExpression(expression.left) + EvaluateTreeExpression(expression.right);
			if (expression.val == '-') return EvaluateTreeExpression(expression.left) - EvaluateTreeExpression(expression.right);
			if (expression.val == '*') return EvaluateTreeExpression(expression.left) * EvaluateTreeExpression(expression.right);
			if (expression.val == '/') return EvaluateTreeExpression(expression.left) / EvaluateTreeExpression(expression.right);
			return 0;
		}
	}
}
