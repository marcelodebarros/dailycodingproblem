using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem10102018
	{
		private MyList list = null;

		public DailyCodingProblem10102018(int n)
		{
			Random rd = new Random();

			list = new MyList(rd.Next(0, 100));
			MyList current = list;
			for (int i = 1; i < n; i++)
			{
				current.next = new MyList(rd.Next(0, 100));
				current = current.next;
			}
		}

		public void DeleteK(int k)
		{
			PrintList();

			MyList previousBehind = null;
			MyList currentBehind = null;

			int count = 1;
			for (MyList current = list; current != null; current = current.next)
			{
				if (count >= k)
				{
					if (currentBehind == null)
					{
						currentBehind = list;
					}
					else
					{
						previousBehind = currentBehind;
						currentBehind = currentBehind.next;
					}
				}
				count++;
			}

			if (previousBehind == null)
			{
				list = currentBehind.next;
			}
			else
			{
				previousBehind.next = currentBehind.next;
			}

			PrintList();
		}

		public void PrintList()
		{
			for (MyList l = list; l != null; l = l.next)
			{
				Console.Write("{0} ", l.val);
			}
			Console.WriteLine();
		}
	}
}
