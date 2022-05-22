using System;
using System.Linq;

namespace House_Robber
{
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[] { 3, 15, 1, 1, 4 };
      Solution s = new Solution();
      int res = s.Rob(nums);
      Console.WriteLine(res);
    }
  }

  // example = 3, 15, 1, 1, 4
  // answer = 15
  // constraint - two next to next houses can not be rob.
  // Idea here is when we are robbing a house, we have to get the Max(currenthouse index + 2 till end of the houses(max loot can be possible from current
  // + 2 index to tend of the array))
  public class Solution
  {
    public int Rob(int[] nums)
    {
      if (nums.Length == 1) return nums[0];
      int length = nums.Length;
      int lastIndex = length - 1;
      for (int i = lastIndex; i >= 0; i--)
      {
        int nextRobIndex = i + 2;
        int maxRobbedAmount = nums[i];
        // when next rob index in within the boundary
        if (nextRobIndex < length)
        {
          // 
          int tempLength = length - nextRobIndex;
          int[] temp = new int[tempLength];
          // copy all the houses from currentindex + 2 till end.
          Array.Copy(nums, nextRobIndex, temp, 0, tempLength);
          // get the max of temp
          int max = temp.OrderByDescending(x => x).First();
          // so at any house teh max loot is, current loot + Max(temp array)
          maxRobbedAmount += max;
        }
        else
        {
          maxRobbedAmount += 0;
        }
        nums[i] = maxRobbedAmount;
      }

      // answer would be max of if you start from first house or second house
      int result = Math.Max(nums[0], nums[1]);
      return result;
    }
  }
}
