namespace Assessmenyt_3
{
    // Implements the Breadth-First Search algorithm for graphs represented by nodes.
    public class BreadthFirstSearcher
    {
        private HashSet<string> _visited; // Tracks _visited nodes to avoid revisiting.
        private Queue<GraphNode> _queue;  // Queue to manage the nodes during BFS traversal.

        // Initializes the BFS with empty structures for tracking state.
        public BreadthFirstSearcher()
        {
            _visited = new HashSet<string>();
            _queue = new Queue<GraphNode>();
        }

        // Executes BFS starting from a given node and returns a list of names of _visited nodes.
        // Returns an empty list if the start node is null, indicating an invalid start point.
        // Time Complexity: O(V + E) where V is the number of vertices and E is the number of edges,
        // since each node and edge is processed once.
        // Space Complexity: O(V) to store the _visited and _queue data structures.
        public List<string> ExecuteBFS(GraphNode startNode)
        {
            List<string> result = new List<string>();
            if (startNode == null)
            {
                return result; // Early exit if the start node is not valid.
            }

            _queue.Enqueue(startNode);
            _visited.Add(startNode.Name);

            while (_queue.Count > 0)
            {
                GraphNode currentNode = _queue.Dequeue();
                result.Add(currentNode.Name);

                // Explore each adjacent node that has not been _visited.
                foreach (GraphNode neighbor in currentNode.AdjList)
                {
                    if (!_visited.Contains(neighbor.Name))
                    {
                        _visited.Add(neighbor.Name);
                        _queue.Enqueue(neighbor);
                    }
                }
            }
            return result;
        }
    }
}