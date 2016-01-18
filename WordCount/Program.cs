using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            TrieNode root = new TrieNode(null, '?');

            Console.WriteLine("FileName:");
            string fileName = Console.ReadLine();

            Book book = new Book(fileName, ref root);

            book.cleanText();

            List<TrieNode> nodes = new List<TrieNode>();

            root.GetTopCounts(ref nodes);

            foreach (TrieNode node in nodes)
            {
                if (node._word_count != 0)
                {
                    if (PrimeCalculator.isPrime(node._word_count))
                    {
                        Console.WriteLine("{0} - {1} times Prime", node.ToString(), node._word_count);
                    }
                    else
                    {
                        Console.WriteLine("{0} - {1} times", node.ToString(), node._word_count);
                    }
                }
                                
            }

            Console.ReadLine();
        }
    }
}
