using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrix
{
    internal class Node
    {
        public int data {  get; set; }
        public Node right;
        public Node down;
        public Node(int _data)
        {
            right = null;
            down = null;
            data = _data;
        }

    }
}
