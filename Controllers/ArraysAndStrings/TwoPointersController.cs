using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DataStructuresAndAlgorithms.Controllers.ArraysAndStrings
{
    [ApiController]
    [Route("api/ArraysAndStrings/[controller]")]
    public class TwoPointersController : ControllerBase
    {
        [HttpGet("IsPalindrome")]
        [SwaggerOperation(
            Summary = "Given a string s, return true if it is a palindrome, false otherwise.",
            Description = "A string is a palindrome if it reads the same forward as backward. That means, after reversing it, it is still the same string. For example: \"abcdcba\", or \"racecar\"."
        )]
        public IActionResult IsPalindrome(string value)
        {
            int leftPointer = 0;
            int rightPointer = value.Length - 1;

            while (leftPointer < rightPointer)
            {
                if (value[leftPointer] != value[rightPointer])
                {
                    return Ok("Not a Palindrome");
                }
                leftPointer++;
                rightPointer--;
            }

            return Ok("Palindrome");
        }

        [HttpPost("CheckForTarget")]
        [SwaggerOperation(
            Summary = "Given a sorted array of unique integers and a target integer, return true if there exists a pair of numbers that sum to target, false otherwise.",
            Description = "This problem is similar to Two Sum. (In Two Sum, the input is not sorted). For example, given nums = [1, 2, 4, 6, 8, 9, 14, 15] and target = 13, return true because 4 + 9 = 13."
        )]
        public IActionResult CheckForTarget([FromBody]List<int> nums, int target)
        {
            int left = 0;
            int right = nums.Count - 1;

            while(left < right){
                int value = nums[left] + nums[right];

                if (value == target)
                {
                    return Ok(true);
                }

                if (value > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return Ok(false);
        }
    }
}
