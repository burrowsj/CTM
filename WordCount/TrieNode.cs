using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class TrieNode : IComparable<TrieNode>
    {
        private char _char;
        public int _word_count;
        private TrieNode _parent = null;
        private Dictionary<char, TrieNode> _children = null;

        public TrieNode(TrieNode parent, char c)
        {
            _char = c;
            _word_count = 0;
            _parent = parent;
            _children = new Dictionary<char, TrieNode>();
        }

        public void AddWord(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (char.IsLetter(key))
                {
                    if (!_children.ContainsKey(key))
                    {
                        _children.Add(key, new TrieNode(this, key));
                    }
                    _children[key].AddWord(word, index + 1);
                }
                else
                {
                    AddWord(word, index + 1);
                }
            }
            else
            {
                if (_parent != null)
                {
                    lock (this)
                    {
                        _word_count++;
                    }
                }
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (!_children.ContainsKey(key))
                {
                    return -1;
                }
                return _children[key].GetCount(word, index + 1);
            }
            else
            {
                return _word_count;
            }
        }

        public void GetTopCounts(ref List<TrieNode> most_counted)
        {
            most_counted.Add(this);

            if (_word_count > most_counted[0]._word_count)
            {                
                most_counted.Sort();
            }
            foreach (char key in _children.Keys)
            {
                _children[key].GetTopCounts(ref most_counted);
            }
        }

        public override string ToString()
        {
            if (_parent == null) return "";
            else return _parent.ToString() + _char;
        }

        public int CompareTo(TrieNode other)
        {
            return this._word_count.CompareTo(other._word_count);
        }
    }
}
