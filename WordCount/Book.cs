using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class Book
    {
        private TrieNode _root;
        private string _filePath;

        public Book(string path, ref TrieNode root)
        {
            _filePath = path;
            _root = root;
        }

        public void cleanText()
        {
            using (FileStream fStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader bookStream = new StreamReader(fStream))
                {
                    string line;
                    while ((line = bookStream.ReadLine()) != null)
                    {
                        string cleanLine = Regex.Replace(line, "\\.|;|:|,|[0-9]|'", "");

                        string[] words = cleanLine.Split();

                        foreach(string word in words)
                        {
                            if (String.IsNullOrEmpty(word))
                            { continue; }

                            string lowerWord = word.ToLower();
                            _root.AddWord(lowerWord.Trim());
                        }
                    }
                }

            }
        }
        
    }
}
