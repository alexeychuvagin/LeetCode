using System;
using System.Collections.Generic;

namespace LeetCode.Problems.Medium;

/// <summary>
/// 46. Given an array nums of distinct integers, return all the possible permutations.
/// You can return the answer in any order.
/// </summary>
/// <remarks>Medium</remarks>
/// <seealso cref="https://leetcode.com/problems/permutations/"/>
public sealed class Permutations
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var queue = new Queue<int>(nums);
        return Backtraking(queue);
    }

    private IList<IList<int>> Backtraking(Queue<int> queue)
    {
        var result = new List<IList<int>>();

        if (queue.Count == 1)
        {
            var num = queue.Dequeue();
            result.Add(new List<int> { num });
            queue.Enqueue(num);
            return result;
        }

        for (var i = 0; i < queue.Count; i++)
        {
            var num = queue.Dequeue();
            var solutions = Backtraking(queue);

            foreach (var solution in solutions)
            {
                solution.Add(num);
                result.Add(solution);
            }

            queue.Enqueue(num);
        }

        return result;
    }
}