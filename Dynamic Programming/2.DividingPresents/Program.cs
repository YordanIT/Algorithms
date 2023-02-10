var presents = Console.ReadLine().Split().Select(int.Parse).ToArray();
var allSums = FindAllSums(presents);
var totalSum = presents.Sum();
var allenSum = totalSum / 2;

while (true)
{
    if (allSums.ContainsKey(allenSum))
    {
        var allenPresents = FindSubset(allSums, allenSum);
        var bobSum = totalSum - allenSum;

        Console.WriteLine($"Difference: {bobSum - allenSum}");
        Console.WriteLine($"Alan: {allenSum} Bob: {bobSum}");
        Console.WriteLine($"Alan takes: {string.Join(' ', allenPresents)}");
        Console.WriteLine("Bob takes the rest.");
        break;
    }

    allenSum -= 1;
}

List<int> FindSubset(Dictionary<int, int> sums, int target)
{
    var subset = new List<int>();

    while (target != 0)
    {
        var el = sums[target];
        subset.Add(el);
        target -= el;
    }

    return subset;
}

Dictionary<int, int> FindAllSums(int[] presents)
{
    var sums = new Dictionary<int, int> { { 0, 0 } };

    foreach (var present in presents)
    {
        var currSums = sums.Keys.ToArray();

        foreach (var sum in currSums)
        {
            var newSum = sum + present;

            if (sums.ContainsKey(newSum))
            {
                continue;
            }
            sums.Add(newSum, present);
        }
    }

    return sums;
}


