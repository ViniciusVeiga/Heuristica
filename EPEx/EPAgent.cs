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
                Queue<Node> nQueue = new Queue<Node>();
                List<Node> nList = new List<Node>();

                Node n = new Node
                {
                    Info = initState,
                    Parent = null,
                    Visited = true
                };

                nQueue.Enqueue(n);

                do
                {
                    n = nQueue.Dequeue();
                    GetSucessors(ref n);

                    if (TargetFound(n))
                    {
                        break;
                    }

                    foreach (Edge e in n.Edges)
                    {
                        if (e.To.Visited != true)
                        {
                            e.To.Visited = true;
                            e.To.Parent = n;
                            nQueue.Enqueue(e.To);
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

        #region GetSucessors

        private void GetSucessors(ref Node n)
        {
            try
            {
                List<Node> nList = new List<Node>();
                int plus = 0,
                    indexFrom = GetIndexOfZero(n),
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

        private int GetIndexOfZero(Node n)
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
        //    foreach (var nHelp in Nodes)
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

