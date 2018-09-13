using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_laf14_1
{
    class Edge
    {
        public int distance;
        public int srcVert;
        public int destVert;
        public Edge(int sv,int dv,int d)
        {
            srcVert = sv;
            destVert = dv;
            distance = d;
        }
    }
}
