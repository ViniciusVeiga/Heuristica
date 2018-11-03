using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrafos.DataStructure
{
    /// <summary>
    /// Classe que representa um arco.
    /// </summary>
    public class Edge
    {

        #region Propriedades

        /// <summary>
        /// O nó de origem do arco.
        /// </summary>
        public Node From {get; private set;}
        /// <summary>
        /// O nó de destino do arco.
        /// </summary>
        public Node To { get; private set; }
        /// <summary>
        /// O custo associado ao arco.
        /// </summary>
        public double Cost { get; set; }

        #endregion

        #region  Construtores

        /// <summary>
        /// Cria um novo arco entre dois nós.
        /// </summary>
        /// <param name="from">O nó origem do arco.</param>
        /// <param name="to">O nó destino do arco.</param>
        /// <param name="cost">O custo associado ao arco.</param>
        public Edge(Node from, Node to) : this(from, to, 0)
        {
        }

        /// <summary>
        /// Cria um novo arco entre dois nós.
        /// </summary>
        /// <param name="from">O nó origem do arco.</param>
        /// <param name="to">O nó destino do arco.</param>
        /// <param name="cost">O custo associado ao arco.</param>
        public Edge(Node from, Node to, double cost)
        {
            this.From = from;
            this.To = to;
            this.Cost = cost;
        }

        #endregion

        #region Métodos Sobrescritos

        /// <summary>
        /// Apresenta a visualização do objeto em formato texto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0} =({1:F4})=> {2}", this.From, this.Cost, this.To);
        }

        #endregion

    }
}
