var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
var target = int.Parse(Console.ReadLine());

Console.WriteLine(CountSum(nums, target));

int CountSum(int[] nums, int target)
{
    var count = 0;
    var sums = new HashSet<int>{ 0 };

    foreach (var number in nums)
    {
        var newSums = new HashSet<int>();
        
        foreach (var sum in sums)
        {
            var newSum = sum + number;

            if (newSum == target)
            {
                count++;
            }

            newSums.Add(newSum);
        }

        sums.UnionWith(newSums);
    }

    return count;
}