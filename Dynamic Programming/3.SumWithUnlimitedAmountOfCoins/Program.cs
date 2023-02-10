var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
var target = int.Parse(Console.ReadLine());

Console.WriteLine(CountSum(nums, target));

int CountSum(int[] nums, int target)
{
    var sums = new int[target + 1];
    sums[0] = 1;

    foreach (var number in nums)
    {
        for (int i = number; i <= target; i++)
        {
            sums[i] += sums[i - number];
        }
    }

    return sums[target];
}