using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using ProjetoGrafos.DataStructure;
using System.Linq;

namespace EP
{
    /// <summary>
    /// EPAgent - searchs solution for the eight puzzle problem
    /// </summary>
    public class EightPuzzle : Graph
    {
        private int[] initState;
        private int[] target;

        public EightPuzzle(int[] InitialState, int[] Target)
        {
            initState = InitialState;
            target = Target;
        }

        public int[] GetSolution()
        {
            return FindSolution();
        }

        #region FindSolution

        private int[] FindSolution()
        {
            try
            {
                List<Node> nQueue = new List<Node>();
                List<Node> nList = new List<Node>();
                Node n = new Node
                {
                    Info = initState,
                    Parent = null,
                    Visited = true
                };

                nQueue.Add(n);

                do
                {
                    nQueue = nQueue.OrderBy(x => x.Nivel).ToList();
                    n = nQueue[0];
                    nQueue.Remove(n);
                    GetSucessors(ref n);

                    if (TargetFound(n))
                    {
                        break;
                    }

                    foreach (Edge e in n.Edges)
                    {
                        if (e.To.Visited != true)
                        {
                            e.To.Nivel = Heuristic((int[])n.Info);
                            e.To.Visited = true;
                            e.To.Parent = n;
                            
                            nQueue.Add(e.To);
                        }
                    }

                } while (nQueue.Count > 0);

                return BuildAnswer(n);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Heuristic
    
        private double Heuristic(int[] array)
        {
            int indexTarget,
                square = Convert.ToInt32(Math.Sqrt(array.Length));

            double pythagoras = 0;

            int?[] position, positionTarget;


            for (int i = 0; i < array.Length; i++)
            {
                indexTarget = GetIndexOf(target, array[i]);

                position = GetPosition(i, square);
                positionTarget = GetPosition(indexTarget, square);

                pythagoras += Pythagoras(position, positionTarget);
            }

            return pythagoras;
        }

        private double Pythagoras(int?[] p, int?[] pT)
        {
            int a = 0, b = 0, i = 1;
            double c = 0;

            a = (int)(p[0] - pT[0]);
            b = (int)(p[1] - pT[1]);

            a = (a < 0) ? a * -1 : a;
            b = (b < 0) ? b * -1 : b;

            if (a == 0)
                return b;
            if (b == 0)
                return a;

            a = a * a;
            b = b * b;

            c = Math.Sqrt(a + b);

            return c;
        }

        private int?[] GetPosition(int index, int square)
        {
            int?[] position = { null, null };
            int count = 0, start = 0;

            position[0] = index / square;
            do
            {
                for (int i = start; i < square + start; i++)
                {

                    if (count == index)
                    {
                        position[1] = count;
                        break;
                    }
                    count++;
                }

                start += square;
            } while (position[1] == null);

            return position;
        }

        #endregion

        #region ShortestPath

        public List<Node> ShortestPath(string begin, string end)
        {
            List<Node> nQueue = new List<Node>();
            List<Node> nList = new List<Node>();

            Node node = Find(begin);
            node.Nivel = 0;
            nQueue.Add(node);

            while (nQueue.Count > 0)
            {
                nQueue = nQueue.OrderBy(x => x.Nivel).ToList();
                node = nQueue[0];
                nQueue.Remove(node);
                if (node.Visited != true)
                {
                    node.Visited = true;
                    nList.Add(node);

                    if (node.Name == end)
                    {
                        return nList;
                    }

                    foreach (Edge e in node.Edges)
                    {
                        if (e.To.Visited != true)
                        {
                            e.To.Parent = node;
                            e.To.Nivel = node.Nivel + e.Cost;

                            nQueue.Add(e.To);
                        }
                    }
                }
            }

            return nList;
        }

        #endregion

        #region GetSucessors

        private void GetSucessors(ref Node n)
        {
            try
            {
                List<Node> nList = new List<Node>();
                int plus = 0,
                    indexFrom = GetIndexOf(n),
                    square = Convert.ToInt32(Math.Sqrt(((int[])(n.Info)).Length));

                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            plus = (!ExistBoard(indexFrom, square, 1)) ? 1 : 0;
                            break;

                        case 1:
                            plus = square;
                            break;

                        case 2:
                            plus = (!ExistBoard(indexFrom, square, 0)) ? -1 : 0;
                            break;

                        case 3:
                            plus = -square;
                            break;
                    }

                    if (plus != 0)
                    {
                        int indexTo = indexFrom + plus;

                        if (indexTo >= 0 && indexTo < ((int[])(n.Info)).Length)
                        {
                            Node nAdd = new Node
                            {
                                Info = ((int[])(n.Info)).Clone()
                            };

                            Switch(ref nAdd, indexTo, indexFrom);

                            n.AddEdge(nAdd);

                            //if (!ExistNode(nAdd))
                            //{
                            //    n.AddEdge(nAdd);
                            //}
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region BuildAnswer

        private int[] BuildAnswer(Node n)
        {
            List<Node> nList = new List<Node> { n };
            List<int> iList = new List<int>();

            while (n.Parent != null)
            {  
                n = n.Parent;
                nList.Add(n);
            }

            for (int i = 0; i < nList.Count; i++)
            {
                if (nList.Count > (i + 1))
                {
                    iList.Add(GetDifferenceSequence(nList[i], nList[i + 1]));
                }
            }

            iList.Reverse();
            return iList.ToArray();
        }

        #endregion

        #region TargetFound

        private bool TargetFound(Node n)
        {
            if (((int[])(n.Info)).SequenceEqual(this.target))
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Métodos Ajudantes

        private int GetDifferenceSequence(Node n1, Node n2)
        {
            for (int i = 0; i < ((int[])(n1.Info)).Length; i++)
            {
                if (((int[])(n1.Info))[i] == 0)
                {
                    return ((int[])(n2.Info))[i];
                }
            }
            return 0;
        }

        private void Switch(ref Node n, int index1, int index2)
        {
            var help = ((int[])(n.Info))[index1];
            ((int[])(n.Info))[index1] = ((int[])(n.Info))[index2];
            ((int[])(n.Info))[index2] = help;
        }

        #region GetIndex

        private int GetIndexOf(Node n)
        {
            for (int i = 0; i < ((int[])(n.Info)).Length; i++)
            {
                if (((int[])(n.Info))[i] == 0)
                {
                    return i;
                }
            }

            return 0;
        }

        private int GetIndexOf(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }

            return 0;
        }

        #endregion

        private bool ExistBoard(int index, int square, int board)
        {
            for (int i = 1; i < square; i++)
            {
                if (index == (square - board) * i)
                {
                    return true;
                }
            }

            return false;
        }

        //private bool ExistNode(Node n)
        //{
        //    foreach (var nHelp in this.nodes)
        //    {
        //        if (nHelp.Info == n.Info)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        #endregion
    }
}

