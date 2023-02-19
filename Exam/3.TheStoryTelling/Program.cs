var graph = new Dictionary<string, List<string>>();
var passedNodes = new HashSet<string>();

FillGraph();

foreach (var parentNode in graph.Keys)
{
    DFS(parentNode);
}

Console.WriteLine(string.Join(' ', passedNodes.Reverse()));

void FillGraph()
{
    string command;

    while ((command = Console.ReadLine()) != "End")
    {
        string[] args = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
        var preStory = args[0].Trim();

        if (!graph.ContainsKey(preStory))
            graph.Add(preStory, new List<string>());
        if (args.Length < 2)
            continue;

        var postStory = args[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        graph[preStory].AddRange(postStory);
    }
}

void DFS(string parentNode)
{
    if (passedNodes.Contains(parentNode))
        return;

    foreach (var child in graph[parentNode])
    {
        DFS(child);
    }

    passedNodes.Add(parentNode);
}