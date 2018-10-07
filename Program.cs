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
			DailyCodingProblem10072018 dcp = new DailyCodingProblem10072018(Int32.Parse(args[0]), Int32.Parse(args[1]));
			dcp.Walk(Int32.Parse(args[2]), Int32.Parse(args[3]), Int32.Parse(args[4]), Int32.Parse(args[5]));
		}
	}
}
