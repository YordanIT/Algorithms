var n = int.Parse(Console.ReadLine());
var graph = new Dictionary<string, List<string>>();
var edges = new List<Edge>();

for (int i = 0; i < n; i++)
{
    var line = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
    var node = line[0];
    var children = line[1].Split().ToList();

    graph[node] = children;

    foreach (var child in children)
    {
        edges.Add(new Edge { First = node, Second = child });
    }
}

edges = edges.OrderBy(e => e.First)
             .ThenBy(e => e.Second)
             .ToList();

foreach (var edge in edges)
{
    var removed = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);

    if (!removed)
    {
        continue;
    }

    if (BFS(edge.First, edge.Second))
    {
        Console.WriteLine($"{edge.First} - {edge.Second}");
    }
    else
    {
        graph[edge.First].Add(edge.Second);
        graph[edge.Second].Add(edge.First);
    }
}

bool BFS(string start, string end)
{
    var queue = new Queue<string>();
    queue.Enqueue(start);

    var visited = new HashSet<string> { start };

    while (queue.Count > 0)
    {
        var node = queue.Dequeue();

        if (node == end)
        {
            return true;
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

    return false;
}

class Edge
{
    public string First { get; set; }
    public string Second { get; set; }
}