using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10242018
	{
		public int FindUnique(int[] numbers)
		{
			long sumXor = 0;

			for (int i = 0; i < numbers.Length; i++)
			{
				sumXor ^= numbers[i];
			}

			for (int i = 0; i < numbers.Length; i++)
			{
				Console.Write("{0} ", numbers[i] ^ sumXor);
			}
			Console.WriteLine();

			return (int)(sumXor);
		}
	}
}
