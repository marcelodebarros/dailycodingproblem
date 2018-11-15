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
			DailyCodingProblem11142018 dcp = new DailyCodingProblem11142018();
			long x = Int64.Parse(args[0]);
			long y = Int64.Parse(args[1]);
			Console.WriteLine(dcp.Exponentiation(x, y));

			/*
			DailyCodingProblem11112018 dcp = new DailyCodingProblem11112018();
			int[] input = new int[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				input[i] = Int32.Parse(args[i]);
			}
			Console.WriteLine(dcp.PartitionTwoSubsets(input));
			*/

			/*
			DailyCodingProblem11082018 dcp = new DailyCodingProblem11082018();
			dcp.GenerateTokens(args[0]);
			Random rd = new Random();
			for (int i = 0; i < 1000; i++)
			{
				string token = rd.Next(0, 1000).ToString();
				Console.WriteLine("Long {0} => Short {1}", token, dcp.ShortenURL(token));

				if (rd.Next(0, 10) == 7)
				{
					Console.WriteLine("Short {0} => Long {1}", dcp.ShortenURL(token), dcp.RestoreURL(dcp.ShortenURL(token)));
				}
				Console.ReadLine();
			}
			*/

			/*
			DailyCodingProblem11062018 dcp = new DailyCodingProblem11062018();
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("Enqueue: {0}", i);
				dcp.Enqueue(i.ToString());

				if ((new Random()).Next(0, 10) == 7)
				{
					Console.WriteLine("Dequeue: {0}", dcp.Dequeue());
				}
				Console.ReadLine();
			}
			*/

			/*
			DailyCodingProblem11052018 dcp = new DailyCodingProblem11052018(5);

			for (; ; )
			{
				Random rd = new Random();

				string key = "";
				if (rd.Next(0, 10) == 7)
				{
					key = rd.Next(0, 10).ToString();
					string value = dcp.Get(key);
					if (String.IsNullOrEmpty(value))
					{
						Console.WriteLine("GetKey({0}) = null", key);
					}
					else
					{
						Console.WriteLine("GetKey({0}) = {1}", key, value);
					}
				}
				else
				{
					key = rd.Next(0, 10).ToString();
					string value = rd.Next(11, 100).ToString();
					dcp.Set(key, value);
				}

				Console.ReadLine();
			}
			*/

			/*
			TreeChar expression = new TreeChar('*');
			expression.left = new TreeChar('+');
			expression.right = new TreeChar('+');
			expression.left.left = new TreeChar('3');
			expression.left.right = new TreeChar('2');
			expression.right.left = new TreeChar('4');
			expression.right.right = new TreeChar('5');

			DailyCodingProblem11032018 dcp = new DailyCodingProblem11032018();
			Console.WriteLine(dcp.EvaluateTreeExpression(expression));
			*/

			/*
			DailyCodingProblem11022018 dcp = new DailyCodingProblem11022018();

			int[] input = new int[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				input[i] = Int32.Parse(args[i]);
			}

			Console.WriteLine(dcp.MaximunSum(input));
			*/

			/*
			DailyCodingProblem11012018 dcp = new DailyCodingProblem11012018();
			TreeChar tree = dcp.BuildTree("abdecfg", "dbeafcg");
			Console.WriteLine();
			*/

			/*
			DailyCodingProblem10312018 dcp = new DailyCodingProblem10312018();

			int[] input = new int[args.Length];
			for (int i = 0; i < args.Length; i++)
			{
				input[i] = Int32.Parse(args[i]);
			}
			Console.WriteLine(dcp.MaxProfit(input));
			*/

			/*
			DailyCodingProblem10302018 dcp = new DailyCodingProblem10302018();
			Console.WriteLine(dcp.LongestPalindrome(args[0]));
			*/

			/*
			DailyCodingProblem10292018 dcp = new DailyCodingProblem10292018();
			dcp.RndMGivenN(Int32.Parse(args[0]), Int32.Parse(args[1]));
			*/

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
