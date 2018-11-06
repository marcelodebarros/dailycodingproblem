using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem11052018
	{
		private LinkedList<LRUCacheItem> cache = null;
		private Hashtable pointerToItem = null;
		private int N = 0;

		public DailyCodingProblem11052018(int n)
		{
			this.N = n;
			cache = new LinkedList<LRUCacheItem>();
			pointerToItem = new Hashtable();
		}

		public void Set(string key, string value)
		{
			Console.WriteLine("Adding key = {0}, value = {1}", key, value);
			if (pointerToItem.ContainsKey(key))
			{
				//Reset the value
				LinkedListNode<LRUCacheItem> node = (LinkedListNode<LRUCacheItem>)pointerToItem[key];
				node.Value.value = value;

				//Move node up since it just got "used"
				cache.Remove(node);
				LRUCacheItem newItem = new LRUCacheItem(key, value);
				cache.AddFirst(newItem);
				pointerToItem[key] = cache.First;
			}
			else
			{
				//Add first
				LRUCacheItem newItem = new LRUCacheItem(key, value);
				cache.AddFirst(newItem);
				pointerToItem.Add(key, cache.First);

				//Remove last if needed
				if (cache.Count > N)
				{
					Console.WriteLine("Debugging: removing from cache!");
					string keyToRemove = cache.Last.Value.key;
					cache.RemoveLast();
					pointerToItem.Remove(keyToRemove);
				}
			}
		}

		public string Get(string key)
		{
			if (!pointerToItem.ContainsKey(key)) return null;

			//Get the return val
			string value = ((LinkedListNode<LRUCacheItem>)pointerToItem[key]).Value.value;

			//Move it up since it just got "used"
			cache.Remove((LinkedListNode<LRUCacheItem>)pointerToItem[key]);
			LRUCacheItem newItem = new LRUCacheItem(key, value);
			cache.AddFirst(newItem);
			pointerToItem[key] = cache.First;

			return value;
		}
	}

	public class LRUCacheItem
	{
		public string key;
		public string value;

		public LRUCacheItem(string key, string value)
		{
			this.key = key;
			this.value = value;
		}
	}
}
