using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EP;

namespace EPTests
{
    [TestClass]
    public class UnitTest1
    {

        private bool CompareVector(int[] v1, int[] v2)
        {
            if (v1.Length != v2.Length) return false;
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] != v2[i]) return false;
            }
            return true;
        }


        [TestMethod]
        public void TesteFacinho()
        {
            // teste 1
            EightPuzzle ComputerAgent = new EightPuzzle(new int[] { 1, 0, 2, 3, 4, 5, 6, 7, 8 },
                new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            int[] sol = ComputerAgent.GetSolution();
            Assert.AreEqual(true, CompareVector(new int[] { 1 }, sol));
        }

        [TestMethod]
        public void TesteMedio()
        {
            // teste 2
            EightPuzzle ComputerAgent = new EightPuzzle(new int[] { 1, 2, 5, 7, 0, 4, 3, 6, 8 },
                new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            int[] sol = ComputerAgent.GetSolution();
            Assert.AreEqual(true, resolveProblem(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 5, 7, 0, 4, 3, 6, 8 }, sol));
        }

        [TestMethod]
        public void TesteNinja()
        {
            /*// teste 3
            EightPuzzle ComputerAgent = new EightPuzzle(new int[] { 8, 0, 6, 5, 4, 7, 2, 3, 1 },
                new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            int[] sol = ComputerAgent.GetSolution();
            Assert.AreEqual(true, resolveProblem(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 8, 0, 6, 5, 4, 7, 2, 3, 1 }, sol));*/
        }

        private bool resolveProblem(int[] target, int[] initial, int[] solution)
        {
            int[] resolving = (int[])initial.Clone();
            for (int i = 0; i < solution.Length; i++)
            {
                int de = FindSpace(resolving);
                int para = FindNumber(resolving, solution[i]);

                resolving = GeraFilhos(resolving, de, para);
            }

            return CompareVector(target, resolving);
        }

        private int[] GeraFilhos(int[] estado, int antes, int depois)
        {
            int[] aux = (int[])estado.Clone();
            aux[antes] = aux[depois];
            aux[depois] = 0;
            return aux;
        }


        private int FindSpace(int[] state)
        {
            for (int i = 0; i < 9; i++)
            {
                if (state[i] == 0)
                    return i;
            }
            return -1;
        }


        private int FindNumber(int[] state, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (state[i] == number)
                    return i;
            }
            return -1;
        }


    }
}
