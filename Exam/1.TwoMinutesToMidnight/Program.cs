var cache = new Dictionary<string,ulong>();

var row = int.Parse(Console.ReadLine());
var col = int.Parse(Console.ReadLine());

var coeff = GetBinomalCoefficient(row,col);
Console.WriteLine(coeff);

ulong GetBinomalCoefficient(int row, int col)
{
    if (col == 0 || col == row)
    {
        return 1;
    }

    var id = $"{row}->{col}";
    if (cache.ContainsKey(id))
    {
        return cache[id];
    }

    var result = GetBinomalCoefficient(row - 1, col - 1) + GetBinomalCoefficient(row - 1, col);
    cache[id] = result;
    
    return result;
}