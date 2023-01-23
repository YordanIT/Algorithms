var graph = new Dictionary<int, List<int>>();

var nodes = int.Parse(Console.ReadLine());
var pairs = int.Parse(Console.ReadLine());

for (int i = 0; i < nodes; i++)
{
    var line = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
    var node = int.Parse(line[0]);
    var children = line.Length == 1 ? new List<int>() : line[1].Split().Select(int.Parse).ToList(); 

    graph.Add(node,children);
}

for (int i = 0; i < pairs; i++)
{
    var pair = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
    var start = pair[0];
    var end = pair[1];

    var steps = BFS(start, end);

    Console.WriteLine($"{{{start}, {end}}} -> {steps}");
}

int BFS(int start, int end)
{
    var queue = new Queue<int>();
    queue.Enqueue(start);
    var visited = new HashSet<int>();
    var parents = new Dictionary<int, int> { { start, -1 } };

    while (queue.Count > 0)
    {
        var node = queue.Dequeue();

        if (end == node)
        {
            return 1;
        }

        foreach (var child in graph[node])
        {
            if (visited.Contains(child))
            {
                continue;
            }

            visited.Add(child);
            queue.Enqueue(child);
        }
    }

    return -1;
}

int GetSteps(Dictionary<int,int> parent, int destination)
{
    var steps = 0;
    var node = destination;

    while (node != -1)
    {
        node = parent[node];
        steps += 1;
    }

    return steps - 1;
}