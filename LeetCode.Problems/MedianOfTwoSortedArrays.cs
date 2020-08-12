using System;
using Xunit;

namespace LeetCode.Problems
{
    /// <summary>
    /// There are two sorted arrays nums1 and nums2 of size m and n respectively.
    /// Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).
    /// You may assume nums1 and nums2 cannot be both empty.
    /// </summary>
    /// <remarks>Hard</remarks>
    /// <seealso cref="https://leetcode.com/problems/median-of-two-sorted-arrays/"/>
    public sealed class MedianOfTwoSortedArrays
    {
        [Theory]
        [InlineData(new int[] { 1, 3 }, new int[] { 2 }, 2)]
        [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5)]
        public void Test(int[] nums1, int[] nums2, double result)
        {
            Assert.Equal(result, Solution(nums1, nums2));
        }

        private double Solution(int[] nums1, int[] nums2)
        {
            var iterator = new IntegerArrayCollectionIterator(nums1, nums2);
            var center = Math.Ceiling(iterator.Length / 2D);
            
            while (iterator.MoveNext())
            {
                if (iterator.CurrentPosition == center)
                    break;
            }

            double result = iterator.Current;

            if (iterator.Length % 2 == 0)
            {
                iterator.MoveNext();
                result = (result + iterator.Current) / 2;
            }

            return result;
        }

        /// <summary>
        /// Complexity O(log(n+m))
        /// </summary>
        private class IntegerArrayCollectionIterator
        {
            private int _pos1 = 0;
            private readonly int[] _nums1;

            private int _pos2 = 0;
            private readonly int[] _nums2;

            public readonly int Length;

            public int CurrentPosition => (_pos1 + _pos2);

            private int _current = 0;

            public int Current
            {
                get
                {
                    if (CurrentPosition == 0)
                        throw new Exception();

                    return _current;
                }
            }

            public IntegerArrayCollectionIterator(int[] nums1, int[] nums2)
            {
                _nums1 = nums1;
                _nums2 = nums2;
                Length = _nums1.Length + _nums2.Length;
            }

            public bool MoveNext()
            {
                if (CurrentPosition > Length)
                    return false;

                if (_pos2 >= _nums2.Length || (_pos1 < _nums1.Length && _nums1[_pos1] < _nums2[_pos2]))
                {
                    _current = _nums1[_pos1];
                    _pos1++;
                }
                else
                {
                    _current = _nums2[_pos2];
                    _pos2++;
                }

                return true;
            }
        }
    }
}