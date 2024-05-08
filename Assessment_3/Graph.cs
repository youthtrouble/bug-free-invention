namespace Assessmenyt_3
{
    // Represents a graph data structure with directed edges between named nodes.
    public class Graph
    {
        private LinkedList<GraphNode> nodes; // Holds all the nodes in the graph.

        // Initializes a new empty graph.
        public Graph()
        {
            nodes = new LinkedList<GraphNode>();
        }

        // Adds a new node with the specified name to the graph.
        // Time complexity: O(1), as LinkedList.AddLast operation is constant time.
        public void AddNode(string name)
        {
            nodes.AddLast(new GraphNode(name));
        }

        // Retrieves a node by its name from the graph.
        // Time complexity: O(n), where n is the number of nodes, since it may scan all nodes.
        public GraphNode GetNodeByName(string name)
        {
            foreach (GraphNode node in nodes)
            {
                if (node.Name == name)
                {
                    return node;
                }
            }
            return null; // Returns null if no node found with the given name.
        }

        // Adds a directed edge from one named node to another.
        // If either node is not found, no edge is added.
        // Time complexity: O(n) due to GetNodeByName.
        public void AddEdge(string from, string to)
        {
            GraphNode n1 = GetNodeByName(from);
            GraphNode n2 = GetNodeByName(to);
            n1?.AddEdge(n2); // Adds an edge if both nodes exist.
        }
        
        // Returns the total number of nodes in the graph.
        // Time complexity: O(1) as LinkedList.Count is a property access.
        public int NumberOfNodes()
        {
            return nodes.Count;
        }

        // Calculates the total number of directed edges in the graph.
        // Time complexity: O(n), where n is the number of nodes, as it aggregates edges from each node.
        public int NumberOfEdges()
        {
            int edgeCount = 0;
            foreach (GraphNode node in nodes)
            {
                edgeCount += node.AdjList.Count;
            }
            return edgeCount;
        }

        // Determines if there is a path from one node to another using BFS.
        // Time complexity: O(V + E), where V is the number of vertices and E is the number of edges.
        public bool IsTraversalPossible(string from, string to)
        {
            GraphNode startNode = GetNodeByName(from);
            if (startNode == null) return false; // No traversal possible if starting node doesn't exist.

            BreadthFirstSearcher bfs = new BreadthFirstSearcher();
            List<string> visited = bfs.ExecuteBFS(startNode);

            return visited.Contains(to);
        }
        
        // Prints each node and its direct connections in the graph.
        // Useful for debugging and visualizing the graph structure.
        public void PrintGraph()
        {
            foreach (GraphNode node in nodes)
            {
                Console.Write(node.Name + " -> ");
                foreach (GraphNode adj in node.AdjList)
                {
                    Console.Write(adj.Name + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
