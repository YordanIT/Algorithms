var n = int.Parse(Console.ReadLine());
var m = int.Parse(Console.ReadLine());

var graph = new List<int>[m];
for (int i = 0; i < n; i++)
{
    graph[i] = new List<int>();
}

var visited = new bool[n];
var edges = new List<Edge>();

for (int i = 0; i < m; i++)
{
    var line = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();

    var node1 = line[0];
    var node2 = line[1];

    graph[node1].Add(node2);
    graph[node2].Add(node1);

    edges.Add(new Edge { First = node1, Second = node2 });
}

Console.WriteLine("Important streets:");

foreach (var edge in edges)
{
    graph[edge.First].Remove(edge.Second);
    graph[edge.Second].Remove(edge.First);

    DFS(0);

    if (visited.Contains(false))
    {
        Console.WriteLine(edge.First + ' ' + edge.Second);
    }

    graph[edge.First].Add(edge.Second);
    graph[edge.Second].Add(edge.First);
}

void DFS(int node)
{
    if (visited[node])
    {
        return;
    }

    visited[node] = true;

    foreach (var child in graph[node])
    {
        DFS(child);
    }
}

class Edge
{
    public int First { get; set; }
    public int Second { get; set; }
}