int n = int.Parse(Console.ReadLine());
var arr = new int[n];

Generate(0);

void Generate(int idx)
{
    if (idx >= arr.Length)
    {
        Console.WriteLine(string.Join(' ', arr));
        return;
    }

    for (int i = 1; i <= arr.Length; i++)
    {
        arr[idx] = i;
        Generate(idx+1);
    }
}