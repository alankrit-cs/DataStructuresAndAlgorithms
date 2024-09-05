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
        public IActionResult CheckForTarget([FromBody] List<int> nums, int target)
        {
            int left = 0;
            int right = nums.Count - 1;

            while (left < right)
            {
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

        [HttpPost("SortCombined")]
        [SwaggerOperation(
            Summary = "Given two sorted integer arrays arr1 and arr2, return a new array that combines both of them and is also sorted"
        )]
        public IActionResult SortCombined([FromQuery] List<int> arr1, [FromQuery] List<int> arr2)
        {
            int i = 0, j = 0;
            var sortedArray = new List<int>();

            while (i < arr1.Count && j < arr2.Count)
            {
                if (arr1[i] < arr2[j])
                {
                    sortedArray.Add(arr1[i]);
                    i++;
                }
                else
                {
                    sortedArray.Add(arr2[j]);
                    j++;
                }
            }

            while (i < arr1.Count)
            {
                sortedArray.Add(arr1[i]);
                i++;
            }

            while (j < arr2.Count)
            {
                sortedArray.Add(arr2[j]);
                j++;
            }

            return Ok(sortedArray);
        }

        [HttpPost("IsSubsequence.")]
        [SwaggerOperation(
            Summary = "Given two strings s and t, return true if s is a subsequence of t, or false otherwise.",
            Description = "A subsequence of a string is a sequence of characters that can be obtained by deleting some (or none) of the characters from the original string, while maintaining the relative order of the remaining characters. For example, \"ace\" is a subsequence of \"abcde\" while \"aec\" is not."
        )]
        public IActionResult IsSubsequence([FromQuery] string s,[FromQuery] string t)
        {
            int i = 0, j = 0;

            while(i < s.Length && j < t.Length)
            {
                if (s[i] == t[j])
                {
                    i++;
                }

                j++;
            }

            if(i == s.Length)
            {
                return Ok(true);
            }

            return Ok(false);
        }
    }
}
