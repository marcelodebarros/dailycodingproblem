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
			DailyCodingProblem09232018 dcp = new DailyCodingProblem09232018();
			Console.WriteLine(dcp.SumNonAdjacent(new int[] {1, 2, 3, 4, 5}));
		}
	}
}
