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
			/*
			DailyCodingProblem09252018 dcp = new DailyCodingProblem09252018();
			dcp.CreateTrie(new string[] { "dog", "deer", "deal", "doggy", "derail", "abs" });
			dcp.PrintMatches(args[0]);
			*/

			DailyCodingProblem09262018 dcp = new DailyCodingProblem09262018();
			int N = 432;
			int[] steps = { 2, 3, 5 };
			Console.WriteLine(dcp.StaircaseUniqueWays(N, steps));
		}
	}
}
