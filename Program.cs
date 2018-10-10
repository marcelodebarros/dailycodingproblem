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

			DailyCodingProblem10102018 dcp = new DailyCodingProblem10102018(Int32.Parse(args[0]));
			dcp.DeleteK(Int32.Parse(args[1]));
		}
	}
}
