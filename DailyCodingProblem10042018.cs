using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10042018
	{
		public void FindCommonNode()
		{
			MyList list1 = CreateList(new int[] {1, 2, 3, 4, 10 });
			MyList list2 = CreateList(new int[] { 99, 7, 8, 10 });

			//Revert, O(n)
			MyList r1 = RevertList(list1);
			MyList r2 = RevertList(list2);

			//Process, O(n)
			MyList i1 = r1;
			MyList i2 = r2;
			MyList commonNode = null;
			while (i1 != null && i2 != null && i1.val == i2.val)
			{
				commonNode = i1;
				i1 = i1.next;
				i2 = i2.next;
			}

			Console.WriteLine("Solution: {0}", commonNode == null ? "NULL" : commonNode.val.ToString());

			//Revert back, O(n)
			list1 = RevertList(r1);
			list2 = RevertList(r2);
		}
		private void PrintList(MyList head)
		{
			for (MyList list = head; list != null; list = list.next)
			{
				Console.WriteLine(list.val);
			}
		}
		private MyList RevertList(MyList head)
		{
			if (head == null) return null;

			MyList next = null;
			MyList current = head;
			MyList hold = null;

			while (current.next != null)
			{
				hold = current.next;
				current.next = next;
				next = current;
				current = hold;
			}
			current.next = next;

			return current;
		}
		private MyList CreateList(int[] arr)
		{
			if (arr == null || arr.Length == 0) return null;
			MyList head = new MyList(arr[0]);
			MyList list = head;

			for (int i = 1; i < arr.Length; i++)
			{
				list.next = new MyList(arr[i]);
				list = list.next;
			}

			return head;
		}
	}

	class MyList
	{
		public int val;
		public MyList next;

		public MyList(int val)
		{
			this.val = val;
			next = null;
		}
	}
}
