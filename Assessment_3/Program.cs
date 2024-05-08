namespace Assessmenyt_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new Graph to represent a social network.
            Graph socialNetwork = new Graph();

            // Add nodes to the graph representing individuals in the social network.
            string[] names = { "Anwar", "Dave", "Haniya", "Rob", "Peggy", "Rabia" };
            foreach (var name in names)
            {
                socialNetwork.AddNode(name);
            }

            // Establish directed edges between nodes to represent one-way friendships.
            socialNetwork.AddEdge("Anwar", "Dave");
            socialNetwork.AddEdge("Dave", "Haniya");
            socialNetwork.AddEdge("Haniya", "Anwar");
            socialNetwork.AddEdge("Rob", "Haniya");
            socialNetwork.AddEdge("Peggy", "Rob");
            socialNetwork.AddEdge("Rabia", "Peggy");

            // Print the graph to the console for verification of structure.
            socialNetwork.PrintGraph();

            // Output the number of nodes and edges in the graph.
            Console.WriteLine("Number of nodes: " + socialNetwork.NumberOfNodes());
            Console.WriteLine("Number of edges: " + socialNetwork.NumberOfEdges());

            // Perform a Breadth-First Search (BFS) starting from 'Anwar' and print the visited nodes.
            GraphNode startNode = socialNetwork.GetNodeByName("Anwar");
            BreadthFirstSearcher bfs = new BreadthFirstSearcher();
            List<string> visitedNames = bfs.ExecuteBFS(startNode);

            Console.WriteLine("BFS starting from 'Anwar':");
            foreach (string name in visitedNames)
            {
                Console.WriteLine(name);
            }
            
            // Check if it is possible to traverse from 'Anwar' to 'Rabia' within the network.
            bool canTraverse = socialNetwork.IsTraversalPossible("Anwar", "Rabia");
            Console.WriteLine("Can traverse from Anwar to Rabia: " + canTraverse);

            // Prompt the user to press any key to exit the program.
            Console.WriteLine("Press any key to exit...");
            Console.Read(); // Changed from Console.ReadKey() to ensure cross-platform compatibility.
        }
    }
}
