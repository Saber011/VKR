using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.NewApplogic
{

    public class Graph
    {
		private Node[] nodes;
		public Graph(int nodesCount)
		{
			nodes = Enumerable.Range(0, nodesCount).Select(z => new Node(z,0)).ToArray();
		}

		public int Length { get; set; }

		public Node this[int index] { get { return nodes[index]; } }

		public IEnumerable<Node> Nodes
		{
			get
			{
				foreach (var node in nodes)
					yield return node;
			}
		}
	}
}
