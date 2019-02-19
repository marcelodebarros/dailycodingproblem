using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem02172019
	{
		public int MinimumPowerSum(int n, int power, bool printSum = false)
		{
			if (n == 0)
			{
				if (printSum)
				{
					Console.WriteLine("MinimPowerSum({0}, {1}) = {2} ({3} = {4})", n, power, 1, 0, "0^" + power.ToString());
				}
				return 1;
			}

			MapItem[] map = new MapItem[n + 1];

			map[0] = new MapItem();
			map[0].steps = 0;
			map[0].list = "";
			for (int i = 1; i <= n; i++)
			{
				map[i] = new MapItem();
				map[i].steps = Int32.MaxValue;
				map[i].list = "";
				for (int j = 1; Math.Pow(j, power) <= i; j++)
				{
					if (1 + map[i - (int)Math.Pow(j, power)].steps < map[i].steps)
					{
						map[i].steps = 1 + map[i - (int)Math.Pow(j, power)].steps;
						map[i].list = String.IsNullOrEmpty(map[i - (int)Math.Pow(j, power)].list) ? j.ToString() + "^" + power.ToString() : map[i - (int)Math.Pow(j, power)].list + " + " + j.ToString() + "^" + power.ToString();
					}
				}
			}

			if (printSum)
			{
				Console.WriteLine("MinimPowerSum({0}, {1}) = {2} ({3} = {4})", n, power, map[n].steps, n, map[n].list);
			}
			return map[n].steps;
		}

	}

	class MapItem
	{
		public int steps = 0;
		public string list = "";
	}
}
