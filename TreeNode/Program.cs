using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace TreeNode
{
    public class TreeNode
    {
        public TreeNode(string name, params TreeNode[] nodes)
        {
            Children = new List<TreeNode>(nodes);
            Name = name;
        }

        public IEnumerable<TreeNode> Children { get; }
        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = BuildTree();
            Console.WriteLine("Обход в ширину:");
            foreach (var node in GetAllNodesWidth(a))
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Обход в глубину:");
            foreach (var node in GetAllNodesDepth(a))
            {
                Console.Write(node + " ");
            }
            Console.ReadKey();
        }

        public static TreeNode BuildTree ()
        {
            var n = new TreeNode("n");
            var k = new TreeNode("k", n);
            var f = new TreeNode("f", k);
            var l = new TreeNode("l");
            var h = new TreeNode("h", l);
            var g = new TreeNode("g");
            var c = new TreeNode("c", g, h);
            var e = new TreeNode("e");
            var m = new TreeNode("m");
            var j = new TreeNode("j", m);
            var i = new TreeNode("i");
            var d = new TreeNode("d", i, j);
            var b = new TreeNode("b", d, e, f);
            return new TreeNode("a", b, c);
        }

        public static IEnumerable<TreeNode> GetAllNodesWidth(TreeNode node)
        {
            Queue<TreeNode> tree = new Queue<TreeNode>();
            List<TreeNode> outList = new List<TreeNode>();
            tree.Enqueue(node);
            while (tree.Count!=0)
            {
                TreeNode cur = tree.Dequeue();
                if (cur.Children != null)
                {
                    foreach (var child in cur.Children)
                    {
                        tree.Enqueue(child);
                    }
                }
                outList.Add(cur);
            }
            return outList;
        }

        public static IEnumerable<TreeNode> GetAllNodesDepth(TreeNode node)
        {
            Stack<TreeNode> tree = new Stack<TreeNode>();
            List<TreeNode> outList = new List<TreeNode>();
            tree.Push(node);
            while (tree.Count != 0)
            {
                TreeNode cur = tree.Pop();
                if (cur.Children != null)
                {
                    foreach (var child in cur.Children.Reverse())
                    {
                        tree.Push(child);
                    }
                }
                outList.Add(cur);
            }
            return outList;
        }
    }
}
