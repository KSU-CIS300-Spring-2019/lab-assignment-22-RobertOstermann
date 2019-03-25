﻿/* TrieWithNoChildren.cs
 * Author: Robert Ostermann
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie contains the empty string.
        /// </summary>
        private bool _hasEmptyString = false;


        /// <summary>
        /// Adds the string.
        /// </summary>
        /// <param name="s">The string to add.</param>
        /// <returns>The ITrie to return.</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else
            {
                ITrie t = new TrieWithOneChild(s, _hasEmptyString);
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
            return false;
        }
    }
}
