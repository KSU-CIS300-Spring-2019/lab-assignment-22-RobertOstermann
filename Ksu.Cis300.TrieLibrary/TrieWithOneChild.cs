/* TrieWithOneChild.cs
 * Author: Robert Ostermann
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Indicates whether the trie contains the empty string.
        /// </summary>
        private bool _hasEmptyString;
        /// <summary>
        /// Stores the only child as an ITrie.
        /// </summary>
        private ITrie _child;
        /// <summary>
        /// Stores the only child's label.
        /// </summary>
        private char _label;

        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if(s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            _label = s[0];
            ITrie t = new TrieWithNoChildren();
            _child = t.Add(s.Substring(1));
        }


        /// <summary>
        /// Adds the string
        /// </summary>
        /// <param name="s">The string to add</param>
        /// <returns>The ITrie to return</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if(s[0] == _label)
            {
                _child = _child.Add(s.Substring(1));
            }
            else
            {
                ITrie t = new TrieWithManyChildren(s, _hasEmptyString, _label, _child);
                return t;
            }
            return this;
            
        }

        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else if (s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
