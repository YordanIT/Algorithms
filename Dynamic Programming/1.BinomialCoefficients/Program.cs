var cache = new Dictionary<string, long>();
var row = int.Parse(Console.ReadLine());
var col = int.Parse(Console.ReadLine());

Console.WriteLine(GetBinom(row,col));

long GetBinom(int row, int col)
{
    if (col == 0 || col == row)
    {
        return 1;
    }

    var key = $"{row}-{col}";

    if (cache.ContainsKey(key))
    {
        return cache[key];
    }

    var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
    cache[key] = result;

    return result;
}