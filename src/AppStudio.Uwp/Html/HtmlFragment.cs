﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudio.Uwp.Html
{
    public abstract class HtmlFragment
    {
        public string Name { get; set; }
        public List<HtmlFragment> Fragments { get; } = new List<HtmlFragment>();

        public HtmlNode AsNode()
        {
            return this as HtmlNode;
        }

        public HtmlText AsText()
        {
            return this as HtmlText;
        }

        public IEnumerable<HtmlFragment> Descendants()
        {
            foreach (var descendant in Fragments)
            {
                yield return descendant;
                foreach (var innerDescendant in descendant.Descendants())
                {
                    yield return innerDescendant;
                }
            }
        }

        internal HtmlNode AddNode(HtmlTag tag)
        {
            var node = new HtmlNode(tag);
            Fragments.Add(node);

            return node;
        }

        internal void TryToAddText(HtmlText text)
        {
            if (text != null)
            {
                Fragments.Add(text);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}