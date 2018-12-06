using System;
using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /**
     * You start at any tree of your choice, then repeatedly perform the following steps:
     * 1. Add one piece of fruit from this tree to your baskets.  If you cannot, stop.
     * 2. Move to the next tree to the right of the current tree.  If there is no tree to the right, stop.
     * Note that you do not have any choice after the initial choice of starting tree: you must perform step 1, then step 2, then back to step 1, then step 2, and so on until you stop.
     * You have two baskets, and each basket can carry any quantity of fruit, but you want each basket to only carry one type of fruit each.
     * What is the total amount of fruit you can collect with this procedure?
    */
    public class FruitIntoBaskets
    {

        public int TotalFruit(int[] tree)
        {
            // Create a list to store the index in tree whose value is different to its left
            List<int> distinctIndex = new List<int>();
            for (int i = 0; i < tree.Length; i++)
            {
                if (i == 0 || tree[i - 1] != tree[i])
                {
                    distinctIndex.Add(i);
                }
            }

            // Add the length of tree to the end of the list
            distinctIndex.Add(tree.Length);

            // Use a hash set to keep track of the number of types so far
            HashSet<int> type = new HashSet<int>();
            int weight = 0, maxWeight = 0;

            // Iterate through the index list from the beginning to the one before the last one, 
            // since the last one only represent the length of tree
            for (int i = 0; i < distinctIndex.Count - 1; i++)
            {
                type.Add(tree[distinctIndex[i]]);

                // If type exceeds 2, stop and update the max weight. Move the pointer 2 steps backward 
                // The for loop then moves the pointer one step forward, therefore it's one step backward in total
                if (type.Count > 2)
                {
                    maxWeight = Math.Max(weight, maxWeight);
                    weight = 0;
                    type.Clear();
                    i -= 2;
                    continue;
                }

                // Update the weight by caculating the length between the current distinct index and the next distinct index
                // When we reach the last tree, we can still easily calculate using the length of the tree to subtract
                weight += distinctIndex[i + 1] - distinctIndex[i];
            }

            // Update the max weight in case there are only two types of tree
            maxWeight = Math.Max(weight, maxWeight);
            return maxWeight;
        }
    }
}
