using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Helpers
{
    public static class CommentGraph
    {
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