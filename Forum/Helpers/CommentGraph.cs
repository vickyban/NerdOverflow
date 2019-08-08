using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Helpers
{
    /// <summary>
    /// Author: Gia Vien Banh
    /// Create graph from a list of comments 
    /// </summary>
    public static class CommentGraph
    {
        /// <summary>
        /// Extension method to Comment model to insert child comment to the correct position in the comment graph 
        /// </summary>
        /// <param name="cur">starting comment node</param>
        /// <param name="level">level of child comment node from the starting node</param>
        /// <param name="node">child comment node to be inserted</param>
        /// <returns></returns>
        public static bool TryInsert(this Comment cur, int level, Comment node)
        {
            if (cur.Level == level - 1) return cur.TryInsert(node);
            else
            {
                foreach(var child in cur.Children)
                {
                    if (child.TryInsert(level, node)) return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Insert the child node to the children list of the parent node
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static bool TryInsert(this Comment parent, Comment child)
        {
            if(parent.CommentId == child.ParentId)
            {
                child.Parent = parent;
                parent.Children.Add(child);
                return true;
            }
            return false;
        }
    }
}