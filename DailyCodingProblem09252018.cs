using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem09252018
	{
		private SimpleTrie simpleTrie = new SimpleTrie();
		public void CreateTrie(string[] listWords)
		{
			foreach (string word in listWords) simpleTrie.AddWord(word);
		}

		public void PrintMatches(string prefix)
		{
			List<string> matches = simpleTrie.MatchPrefixes(prefix);
			foreach (string match in matches)
			{
				Console.WriteLine(match);
			}
		}
	}

	class SimpleTrie
	{
		public bool isLeaf = false;
		private Hashtable children = null;

		public SimpleTrie() { }

		public SimpleTrie(bool isLeaf)
		{
			this.isLeaf = isLeaf;
		}

		public void AddWord(string word)
		{
			if (String.IsNullOrEmpty(word)) return;
			if (children == null) children = new Hashtable();
			SimpleTrie child = null;
			if (!children.ContainsKey(word[0]))
			{
				child = new SimpleTrie(word.Length == 1);
				children.Add(word[0], child);
			}
			child = (SimpleTrie)children[word[0]];
			child.AddWord(word.Substring(1));
		}

		public bool IsWordPresent(string word)
		{
			if (String.IsNullOrEmpty(word) || children == null || !children.ContainsKey(word[0])) return false;
			if (word.Length == 1 && ((SimpleTrie)children[word[0]]).isLeaf) return true;
			return ((SimpleTrie)children[word[0]]).IsWordPresent(word.Substring(1));
		}

		public List<string> MatchPrefixes(string prefix)
		{
			List<string> matches = new List<string>();
			_MatchPrefixes(prefix, "", ref matches);
			return matches;
		}

		private void _MatchPrefixes(string prefix, string currentWord, ref List<string> matches)
		{
			if (String.IsNullOrEmpty(prefix))
			{
				_AllWords(currentWord, ref matches);
				return;
			}
			if (children == null || !children.ContainsKey(prefix[0])) return;
			((SimpleTrie)children[prefix[0]])._MatchPrefixes(prefix.Substring(1), currentWord + prefix[0].ToString(), ref matches);
		}

		private void _AllWords(string currentWord, ref List<string> matches)
		{
			if (isLeaf) matches.Add(currentWord);
			if (children != null)
				foreach (char letter in children.Keys)
					((SimpleTrie)children[letter])._AllWords(currentWord + letter.ToString(), ref matches);
		}
	}
}
