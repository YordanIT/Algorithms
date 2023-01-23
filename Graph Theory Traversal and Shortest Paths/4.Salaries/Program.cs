var n = int.Parse(Console.ReadLine());
var graph = new List<int>[n];
var visited = new Dictionary<int,int>();

for (int i = 0; i < n; i++)
{
    graph[i] = new List<int>();
    var children = Console.ReadLine();

    for (int j = 0; j < children.Length; j++)
    {
        if (children[j] == 'Y')
        {
            graph[i].Add(j);
        }
    }
}

var salary = 0;

for (int node = 0; node < n; node++)
{
    salary += DFS(node);
}

Console.WriteLine(salary);

int DFS(int node)
{
    if (visited.ContainsKey(node))
    {
        return visited[node];
    }

    var salary = 0;

    if (graph[node].Count == 0)
    {
        salary = 1;
    }
    else
    {
        foreach (var child in graph[node])
        {
            salary += DFS(child);
        }
    }

    visited[node] = salary;
    return salary;
}