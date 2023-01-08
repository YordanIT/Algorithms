var arr = Console.ReadLine().Split(' ');

Reverse(arr, 0);

Console.WriteLine(string.Join(' ', arr));

void Reverse(string[] arr, int index)
{
    if (index == arr.Length / 2)
        return;

    var curr = arr[index];
    arr[index] = arr[arr.Length - 1 - index];
    arr[arr.Length - 1 - index] = curr;

    Reverse(arr, index + 1);
}