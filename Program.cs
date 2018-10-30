using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class Program
	{
		static void Main(string[] args)
		{
			DailyCodingProblem10292018 dcp = new DailyCodingProblem10292018();
			dcp.RndMGivenN(Int32.Parse(args[0]), Int32.Parse(args[1]));

			/*
			DailyCodingProblem10262018 dcp = new DailyCodingProblem10262018();

			int[] input = new int[args.Length - 1];
			for (int i = 0; i < args.Length - 1; i++)
			{
				input[i] = Int32.Parse(args[i]);
			}
			int target = Int32.Parse(args[args.Length - 1]);

			int[] retVal = dcp.FindSubsetAddsToTarget(input, target);
			if (retVal != null)
			{
				Console.Write("Solution:");
				for (int i = 0; i < retVal.Length; i++)
				{
					Console.Write(" {0}", retVal[i]);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("No Solution");
			}
			*/

			/*
			int[] numbers = { 3, 3, 3, 4, 4, 4, 6 };
			DailyCodingProblem10242018 dcp = new DailyCodingProblem10242018();
			Console.WriteLine(dcp.FindUnique(numbers));
			*/

			/*
			DailyCodingProblem10222018 dcp = new DailyCodingProblem10222018();
			int max = Int32.Parse(args[0]);
			for (int i = 1; i <= max; i++)
			{
				dcp.QueensOnChessBoard(i);
			}
			*/

			/*
			DailyCodingProblem10212018 dcp = new DailyCodingProblem10212018();
			dcp.PrintSubsets(args[0]);
			*/

			/*
			DailyCodingProblem10202018 dcp = new DailyCodingProblem10202018();
			Console.WriteLine(dcp.SecondLargest(dcp.CreateBST()));
			*/

			/*
			StringBuilder input = new StringBuilder(args[0]);
			DailyCodingProblem10192018 dcp = new DailyCodingProblem10192018();
			Console.WriteLine(dcp.SortRGB(input));
			*/

			/*
			DailyCodingProblem10152018 dcp = new DailyCodingProblem10152018();
			Console.WriteLine(dcp.EditDistance(args[0], args[1]));
			*/

			/*
			DailyCodingProblem10132018 dcp = new DailyCodingProblem10132018();
			Console.WriteLine(dcp.RunLengthEncode(args[0]));
			*/

			/*
			DailyCodingProblem10112018 dcp = new DailyCodingProblem10112018();
			Console.WriteLine(dcp.BracketsBalanced(args[0]));
			*/

			/*
			DailyCodingProblem10082018 dcp = new DailyCodingProblem10082018();
			LockTree tree = dcp.BuildTree();
			dcp.LockUnlock(22, true, tree);
			dcp.LockUnlock(10, true, tree);
			dcp.LockUnlock(10, false, tree);
			dcp.LockUnlock(22, false, tree);
			dcp.LockUnlock(10, true, tree);
			dcp.LockUnlock(10, false, tree);
			*/

			/*
			DailyCodingProblem10092018 dcp = new DailyCodingProblem10092018();
			string regex = args[0];
			string input = args[1];
			Console.WriteLine(dcp.RegEx(regex, input));
			*/

			/*
			DailyCodingProblem10102018 dcp = new DailyCodingProblem10102018(Int32.Parse(args[0]));
			dcp.DeleteK(Int32.Parse(args[1]));
			*/
		}
	}
}
