using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem09302018
	{
		private int N;
		private Hashtable storage;
		private int min;
		private int max;

		private DailyCodingProblem09302018() { }

		public DailyCodingProblem09302018(int N)
		{
			this.N = N;
			this.min = 1;
			this.max = 0;
			storage = new Hashtable();
		}

		public void Record(int order_id)
		{
			if (max < N)
			{
				max++;
				storage.Add(max, order_id);
			}
			else
			{
				storage.Remove(min);
				min++;
				max++;
				storage.Add(max, order_id);
			}
		}

		public int Get_Last(int i)
		{
			int key = max - i + 1;
			return (int)storage[key];
		}
	}
}
