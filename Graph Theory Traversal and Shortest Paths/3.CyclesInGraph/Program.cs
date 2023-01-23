var graph = new Dictionary<string, List<string>>();
var visited = new HashSet<string>();
var cycles = new HashSet<string>();

while (true)
{
    var line = Console.ReadLine();
    if (line == "End")
    {
        break;
    }

    var edge = line.Split('-');
    var from = edge[0];
    var to = edge[1];

    if (!graph.ContainsKey(from))
    {
        graph.Add(from, new List<string>());
    }

    if (!graph.ContainsKey(to))
    {
        graph.Add(to, new List<string>());
    }

    graph[from].Add(to);
}
try
{
    foreach (var node in graph.Keys)
    {
        DFS(node);
    }
    Console.WriteLine("Acyclic: Yes");
}
catch (InvalidOperationException)
{
    Console.WriteLine("Acyclic: No");
}

void DFS(string node)
{
    if (cycles.Contains(node))
    {
        throw new InvalidOperationException();
    }

    if (visited.Contains(node))
    {
        return;
    }

    visited.Add(node);
    cycles.Add(node);

    foreach (var child in graph[node])
    {
        DFS(child);
    }

    cycles.Remove(node);
}