using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DailyCodingProblem
{
    class DailyCodingProbem05042019
    {
        public void Process()
        {
            PrefixSumTrie pst = new PrefixSumTrie();
            pst.AddWord("foo", 5);
            pst.AddWord("foobar", 15);
            string prefix = "foo";
            Console.WriteLine("Cummulative for {0}: {1}", prefix, pst.Cummulative(prefix));
            pst.AddWord("foo", 15);
            Console.WriteLine("Cummulative for {0}: {1}", prefix, pst.Cummulative(prefix));
            pst.AddWord("foofighters", 100);
            Console.WriteLine("Cummulative for {0}: {1}", prefix, pst.Cummulative(prefix));

        }
    }

    class PrefixSumTrie
    {
        private Hashtable children = null;
        private bool isWord = false;
        private int cummulative = 0;
        private int wordVal = 0;

        public PrefixSumTrie()
        {
            children = new Hashtable();
            isWord = false;
            cummulative = 0;
            wordVal = 0;
        }

        public void AddWord(string word, int val)
        {
            int previousVal = -1;
            AddWord(word, val, ref previousVal);
            if (previousVal > 0)
            {
                RemoveWord(word, previousVal);
            }
        }

        public int Cummulative(string prefix)
        {
            if (String.IsNullOrEmpty(prefix))
            {
                return cummulative;
            }
            if (children.ContainsKey(prefix[0]))
            {
                return ((PrefixSumTrie)children[prefix[0]]).Cummulative(prefix.Substring(1));
            }
            return 0;
        }

        private void AddWord(string word, int val, ref int previousVal)
        {
            cummulative += val;
            if (String.IsNullOrEmpty(word))
            {
                if (isWord)
                {
                    previousVal = wordVal;
                }
                isWord = true;
                wordVal = val;
            }
            else
            {
                if (!children.ContainsKey(word[0]))
                {
                    children.Add(word[0], new PrefixSumTrie());
                }
                PrefixSumTrie child = (PrefixSumTrie)children[word[0]];
                child.AddWord(word.Substring(1), val, ref previousVal);
            }
        }

        private void RemoveWord(string word, int val)
        {
            if (cummulative > 0)
            {
                cummulative -= val;
            }
            if (!String.IsNullOrEmpty(word) && children.ContainsKey(word[0]))
            {
                ((PrefixSumTrie)children[word[0]]).RemoveWord(word.Substring(1), val);
            }
        }
    }
}
