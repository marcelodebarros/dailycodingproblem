using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem09292018
	{
		private string randomElement;
		private int count;
		private Random rd;

		public DailyCodingProblem09292018()
		{
			randomElement = "";
			count = 0;
			rd = new Random((int)(DateTime.Now.Ticks % Int32.MaxValue));
		}

		public string RandomElement
		{
			get
			{
				return randomElement;
			}
		}

		public void IncomingFeed(string element)
		{
			randomElement = rd.Next(0, ++count) == 0 ? element : randomElement;
		}
	}
}
