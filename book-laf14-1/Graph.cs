using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_laf14_1
{
    class Graph
    {
        private readonly int MAX_VERTS = 20;
        private readonly int INFINITY = 1000000;
        private Vertex[] vertexList;
        private int[,] adjMat;
        private int nVerts;
        private int CurrentVert;
        private int nTree;
        private PriorityQ thePQ;
        public Graph()
        {
            vertexList = new Vertex[MAX_VERTS];
            adjMat = new int[MAX_VERTS, MAX_VERTS];
            nVerts = 0;
            for (int i = 0; i < MAX_VERTS; i++)
            {
                for (int j = 0; j < MAX_VERTS; j++)
                {
                    adjMat[i, j] = INFINITY;
                }
            }
            thePQ = new PriorityQ();
        }
        public void addVertex(char lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }
        public void addEdge(int start, int end, int weight)
        {
            adjMat[start, end] = weight;
            adjMat[end, start] = weight;
        }
        public void displayVertex(int v)
        {
            Console.Write(vertexList[v].lable);
        }
        public void mstw()
        {
            CurrentVert = 0;
            while (nTree < nVerts - 1)
            {
                vertexList[CurrentVert].isInTree = true;
                nTree++;
                for (int i = 0; i < nVerts; i++)
                {
                    if (i == CurrentVert)
                        continue;
                    if (vertexList[i].isInTree)
                        continue;
                    int distance = adjMat[CurrentVert, i];
                    if (distance == INFINITY)
                        continue;
                    putInPQ(i, distance);
                }
                if (thePQ.getSize() == 0)
                {
                    Console.WriteLine("Grapgh not connected!");
                    return;
                }
                Edge theEdge = thePQ.removeMin();
                int sourceVert = theEdge.srcVert;
                CurrentVert = theEdge.destVert;

                Console.Write(vertexList[sourceVert].lable);
                Console.Write(vertexList[CurrentVert].lable);
                Console.Write(' ');
            }
            for (int i = 0; i < nVerts; i++)
            {
                vertexList[i].isInTree = false;
            }
        }
        public void putInPQ(int newVert, int newDist)
        {
            int queueIndex = thePQ.find(newVert);
            if (queueIndex != -1)
            {
                Edge tempEdge = thePQ.peekN(queueIndex);
                int oldDist = tempEdge.distance;
                if (oldDist > newDist)
                {
                    thePQ.removeN(queueIndex);
                    Edge theEdge = new Edge(CurrentVert, newVert, newDist);
                    thePQ.insert(theEdge);
                }
            }
            else
            {
                Edge theEdge = new Edge(CurrentVert, newVert, newDist);
                thePQ.insert(theEdge);
            }
        }
    }
}

