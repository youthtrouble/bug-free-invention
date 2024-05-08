namespace Assessment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new Graph to represent a social network.
            Graph linkedInNetwork = new Graph();

            // Add nodes to the graph representing individuals in the social network.
            string[] names = { "Anwar", "Dave", "Haniya", "Rob", "Peggy", "Rabia" };
            foreach (var name in names)
            {
                linkedInNetwork.AddNode(name);
            }

            // Establish directed edges between nodes to represent one-way friendships.
            linkedInNetwork.AddEdge("Anwar", "Dave");
            linkedInNetwork.AddEdge("Dave", "Haniya");
            linkedInNetwork.AddEdge("Haniya", "Anwar");
            linkedInNetwork.AddEdge("Rob", "Haniya");
            linkedInNetwork.AddEdge("Peggy", "Rob");
            linkedInNetwork.AddEdge("Rabia", "Peggy");

            // Print the graph to the console for verification of structure.
            linkedInNetwork.PrintGraph();

            // Output the number of nodes and edges in the graph.
            Console.WriteLine("Number of nodes: " + linkedInNetwork.NumberOfNodes());
            Console.WriteLine("Number of edges: " + linkedInNetwork.NumberOfEdges());

            // Perform a Breadth-First Search (BFS) starting from 'Anwar' and print the visited nodes.
            GraphNode startNode = linkedInNetwork.GetNodeByName("Anwar");
            BreadthFirstSearcher bfs = new BreadthFirstSearcher();
            List<string> visitedNames = bfs.ExecuteBFS(startNode);

            Console.WriteLine("BFS starting from 'Anwar':");
            foreach (string name in visitedNames)
            {
                Console.WriteLine(name);
            }
            
            // Check if it is possible to traverse from 'Anwar' to 'Rabia' within the network.
            bool canTraverse = linkedInNetwork.IsTraversalPossible("Anwar", "Rabia");
            Console.WriteLine("Can traverse from Anwar to Rabia: " + canTraverse);

            // Prompt the user to press any key to exit the program.
            Console.WriteLine("Press any key to exit...");
            Console.Read(); // Changed from Console.ReadKey() to ensure cross-platform compatibility.
        }
    }
}
