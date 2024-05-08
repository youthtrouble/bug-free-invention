namespace Assessmenyt_3
{
    // Represents a node in a graph with a name and a list of directed edges to other nodes.
    public class GraphNode
    {
        public string Name; // Name of the node, replacing the numeric ID.
        public LinkedList<GraphNode> AdjList; // Stores directed edges to adjacent nodes.

        // Constructor initializes a node with a name and an empty list of adjacent nodes.
        public GraphNode(string name)
        {
            this.Name = name;
            this.AdjList = new LinkedList<GraphNode>();
        }

        // Adds a directed edge from this node to another node if not already present.
        // Time complexity: O(n) where n is the number of edges from this node, due to the contains check.
        // Space complexity: O(1) for adding a single edge.
        public void AddEdge(GraphNode to)
        {
            if (!AdjList.Contains(to))
            {
                AdjList.AddLast(to);
            }
        }
    }
}