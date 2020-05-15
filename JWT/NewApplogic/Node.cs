using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.NewApplogic
{
	public class Node
	{
		private readonly List<Node> incidentNodes = new List<Node>();
		public readonly int NodeNumber;

		public Node(int number)
		{
			NodeNumber = number;
		}

		public IEnumerable<Node> IncidentNodes
		{
			get
			{
				foreach (var node in incidentNodes)
					yield return node;
			}
		}

		public void Connect(Node node)
		{
			incidentNodes.Add(node);
			node.incidentNodes.Add(this);
		}

		public static IEnumerable<Node> DepthSearch(Node startNode)
		{
			var visited = new HashSet<Node>();
			var stack = new Stack<Node>();
			stack.Push(startNode);
			while (stack.Count != 0)
			{
				var node = stack.Pop();
				if (visited.Contains(node))
					continue;
				visited.Add(node);
				yield return node;
				foreach (var incidentNode in node.IncidentNodes)
					stack.Push(incidentNode);
			}
		}
		public static IEnumerable<Node> BreadthSearch(Node startNode)
		{
			var visited = new HashSet<Node>();
			var queue = new Queue<Node>();
			queue.Enqueue(startNode);
			while (queue.Count != 0)
			{
				var node = queue.Dequeue();
				if (visited.Contains(node))
					continue;
				visited.Add(node);
				yield return node;
				foreach (var incidentNode in node.IncidentNodes)
					queue.Enqueue(incidentNode);
			}
		}
	}
}
