using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
	class DailyCodingProblem11082018
	{
		private LinkedList<string> tokens = null;
		private LinkedListNode<string> nextAvailable = null;
		private Hashtable shortToLong = null;
		private Hashtable longToShort = null;
		private Random rd = null;

		public DailyCodingProblem11082018()
		{
			shortToLong = new Hashtable();
			longToShort = new Hashtable();
			rd = new Random();
			tokens = null;
			nextAvailable = null;
		}

		private void GenerateShortTokens(string charSet,
										 int currentIndex,
										 int max,
										 string currentString,
										 Hashtable used)
		{
			if (currentIndex >= max)
			{
				int coinFlip = rd.Next(0, 4);
				switch (coinFlip)
				{
					case 0:
						tokens.AddLast(currentString);
						break;
					case 1:
						tokens.AddFirst(currentString);
						break;
					case 2:
						if (nextAvailable == null) tokens.AddLast(currentString);
						else tokens.AddAfter(nextAvailable, currentString);
						break;
					case 3:
						if (nextAvailable == null) tokens.AddLast(currentString);
						else tokens.AddBefore(nextAvailable, currentString);
						break;
				}
				if (nextAvailable == null) nextAvailable = tokens.First;
				return;
			}

			for (int i = 0; i < charSet.Length; i++)
			{
				if (!used.ContainsKey(charSet[i]))
				{
					used.Add(charSet[i], true);
					GenerateShortTokens(charSet,
										currentIndex + 1,
										max,
										currentString + charSet[i].ToString(),
										used);
					used.Remove(charSet[i]);
				}
			}
		}

		public string ShortenURL(string longURL)
		{
			if (longToShort.ContainsKey(longURL)) return (string)longToShort[longURL];

			string shortURL = nextAvailable.Next.Value;
			longToShort.Add(longURL, shortURL);
			shortToLong.Add(shortURL, longURL);
			nextAvailable = nextAvailable.Next;
			return shortURL;
		}

		public string RestoreURL(string shortURL)
		{
			if (shortToLong.ContainsKey(shortURL)) return (string)shortToLong[shortURL];
			return "No mapping found!";
		}

		public void GenerateTokens(string str)
		{
			tokens = new LinkedList<string>();

			StringBuilder alphabet = new StringBuilder(str);

			//Shuffle
			for (int i = 0; i < alphabet.Length; i++)
			{
				int index = rd.Next(i, alphabet.Length);
				char temp = alphabet[i];
				alphabet[i] = alphabet[index];
				alphabet[index] = temp;
			}

			//Generate tokens
			Console.Write("Generating tokens...");
			GenerateShortTokens(alphabet.ToString(),
								0,
								6,
								"",
								new Hashtable());
			Console.WriteLine("Done! {0} tokens created!", tokens.Count);
		}
	}
}
