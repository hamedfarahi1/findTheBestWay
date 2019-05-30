using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findBestWay
{
    class Node
    {
        public Node left;
        public bool data;
        public Node up;
        public Node right;
        public Node down;
        public bool start = false;
        public bool end = false;
        public String location = "";


        public Node(Node left, bool data, Node up, Node right, Node down)
        {
            this.left = left;
            this.data = data;
            this.up = up;
            this.right = right;
            this.down = down;
        }
        public Node(bool data)
        {
            this.data = data;
        }
    }
}
