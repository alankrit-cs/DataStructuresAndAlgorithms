using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DataStructuresAndAlgorithms.Controllers.ArraysAndStrings
{
    [ApiController]
    [Route("api/ArraysAndStrings/[controller]")]
    public class SlidingWindowController : Controller
    {
        [HttpPost("LongestSubarraySumIsLessThanK")]
        [SwaggerOperation(
            Summary = "Given an array of positive integers nums and an integer k, find the length of the longest subarray whose sum is less than or equal to k")]
        public IActionResult FindLength([FromBody] List<int> nums, int target)
        {
            int left = 0, ans = 0, curr = 0;

            for(int right = 0; right < nums.Count; right++)
            {
                curr = curr + nums[right];

                while (curr > target)
                {
                    curr = curr - nums[left];
                    left++;
                }

                ans = Math.Max(ans, right - left + 1);
            }

            return Ok(ans);
        }

        [HttpPost("LongestSubstringOfOnes")]
        [SwaggerOperation(Summary = "You are given a binary string s (a string containing only \"0\" and \"1\"). You may choose up to one \"0\" and flip it to a \"1\". What is the length of the longest substring achievable that contains only \"1\"",
            Description = "For example, given s = \"1101100111\", the answer is 5. If you perform the flip at index 2, the string becomes 1111100111")]
        public IActionResult LongestSubstringOfOnes(string str)
        {
            int left = 0, curr = 0, ans = 0;

            for(int right = 0; right<str.Length; right++)
            {
                if (str[right] == '0')
                {
                    curr = curr + 1;
                }

                while(curr > 1)
                {
                    if (str[left] == '0')
                    {
                        curr = curr - 1;
                    }
                    left++;
                }

                ans = Math.Max(ans, right - left + 1);
            }
            return Ok(ans);
        }
    }
}
