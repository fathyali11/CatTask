var nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
var target = int.Parse(Console.ReadLine());

Console.WriteLine(FindTarget(nums, target));


static int FindTarget(int[] nums, int target)
{
    int startIndex = 0;
    int endIndex = nums.Length - 1;
    int midIndex = nums.Length / 2;
    while (startIndex <= endIndex)
    {
        if (nums[midIndex] == target)
        {
            return midIndex;
        }
        else if (nums[midIndex] < target)
        {
            startIndex = midIndex + 1;
        }
        else
        {
            endIndex = midIndex - 1;
        }
        midIndex = (startIndex + endIndex) / 2;
    }
    return -1;

}
