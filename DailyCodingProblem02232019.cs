using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem02232019
	{
		public void MinUniquePrefix()
		{
			string[] names = { "dog", "cat", "apple", "apricot", "fish", "marcelo", "principal", "micro", "fun", "funny", "mark", "partner" };

			PrefixTrie pTrie = new PrefixTrie();
			foreach (string name in names)
			{
				pTrie.AddWord(name);
			}

			pTrie.PrintMinUniquePrefixes("");
		}
	}

	class PrefixTrie
	{
		public int count = 0;
		private Hashtable children = null;

		public void AddWord(string word)
		{
			if (String.IsNullOrEmpty(word))
			{
				return;
			}
			if (children == null) children = new Hashtable();
			PrefixTrie child = null;
			if (!children.ContainsKey(word[0]))
			{
				child = new PrefixTrie();
				children.Add(word[0], child);
			}
			child = (PrefixTrie)children[word[0]];
			child.count++;
			child.AddWord(word.Substring(1));
		}

		public void PrintMinUniquePrefixes(string prefix)
		{
			if (children == null) return;
			foreach (char c in children.Keys)
			{
				PrefixTrie child = (PrefixTrie)children[c];
				if (child.count == 1)
				{
					Console.WriteLine("{0}", prefix + c.ToString());
				}
				else if (child.count > 1)
				{
					child.PrintMinUniquePrefixes(prefix + c.ToString());
				}
			}
		}
	}

}
