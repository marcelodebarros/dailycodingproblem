using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10062018
	{
		private SimpleTrie trie = null;

		public DailyCodingProblem10062018()
		{
			string[] words = {	"mantel",
								"piece",
								"shelf",
								"air",
								"airborne",
								"born",
								"this",
								"is",
								"a",
								"add",
								"addon",
								"on",
								"quick",
								"brown",
								"the",
								"fox",
								"bed",
								"bath",
								"bedbath",
								"beyond",
								"quicker",
								"aftereffect",
								"afternoon",
								"afterthought",
								"airbag",
								"anybody",
								"how",
								"any",
								"anyhow",
								"anywho",
								"ever",
								"however"
							 };
			trie = new SimpleTrie();
			foreach (string word in words) trie.AddWord(word);
		}

		public void PrintMinWords(string input)
		{
			PrintMinWords("", 0, input);
		}

		private bool PrintMinWords(string str, int index, string input)
		{
			//Base case
			if (String.IsNullOrEmpty(input)) return false;
			if (index >= input.Length)
			{
				PrintWords(str);
				return true;
			}

			//Induction, backtracking
			int last = input.Length - 1;
			while (last >= index)
			{
				string substr = input.Substring(index, last - index + 1);
				if (trie.IsWordPresent(substr) && PrintMinWords(str + "@" + substr, last + 1, input)) return true;
				last--;
			}
			return false;
		}

		private void PrintWords(string str)
		{
			if (String.IsNullOrEmpty(str)) return;
			string[] parts = str.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string part in parts) Console.Write("{0} ", part);
			Console.WriteLine();
		}
	}
}
