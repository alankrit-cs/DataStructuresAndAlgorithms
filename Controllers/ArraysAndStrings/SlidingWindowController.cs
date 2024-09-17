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

            for (int right = 0; right < nums.Count; right++)
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

            for (int right = 0; right < str.Length; right++)
            {
                if (str[right] == '0')
                {
                    curr = curr + 1;
                }

                while (curr > 1)
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

        [HttpPost("NumSubarrayProductLessThanK")]
        [SwaggerOperation(Summary = "Given an array of positive integers nums and an integer k, return the number of subarrays where the product of all the elements in the subarray is strictly less than k",
        Description = "For example, given the input nums = [10, 5, 2, 6], k = 100, the answer is 8. The subarrays with products less than k are:\r\n\r\n[10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6]")]
        public IActionResult NumSubarrayProductLessThanK([FromBody] List<int> nums, int k)
        {
            if (k <= 1)
            {
                return Ok(0);
            }

            int ans = 0, left = 0, curr = 1;

            for (int right = 0; right < nums.Count; right++)
            {
                curr = curr * nums[right];

                while (curr >= k)
                {
                    curr = curr / nums[left];

                    left++;
                }

                ans = ans + (right - left + 1);
            }

            return Ok(ans);
        }

        [HttpPost("FindBestSubarray")]
        [SwaggerOperation(Summary = "Given an integer array nums and an integer k, find the sum of the subarray with the largest sum whose length is k")]
        public IActionResult FindBestSubarray([FromBody] List<int> nums, int k)
        {
            int curr = 0;

            for(int i = 0; i<k; i++)
            {
                curr = curr + nums[i];
            }

            int ans = curr; 

            for(int i = k; i < nums.Count; i++)
            {
                curr = curr + nums[i] - nums[i - k];

                ans = Math.Max(curr, ans);
            }

            return Ok(ans);
        }
    }
}
