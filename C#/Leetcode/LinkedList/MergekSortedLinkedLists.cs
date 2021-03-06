﻿using LeetcodeSolutions.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeSolutions.LinkedList
{
    // Leetcode 23 - https://leetcode.com/problems/merge-k-sorted-lists/
    // Submission Detail - Approach 5 in https://leetcode.com/problems/merge-k-sorted-lists/solution/
    // Divide and conquer method - Tweak of Merge Sort
    
    public class MergekSortedLinkedLists
    {
        // Tx = O(Nlogk)
        // Sx = O(k) for the call stack

        public ListNode MergeKListsOptimized(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;
            else
                return Merge(lists, 0, lists.Length - 1);
        }

        public ListNode Merge(ListNode[] lists, int start, int end)
        {
            if (start == end)       // Base condition of the recursive method.
            {
                return lists[start];    // Single node
            }
            else if (start < end)
            {
                int mid = start + (end - start) / 2;

                ListNode left = Merge(lists, start, mid);
                ListNode right = Merge(lists, mid + 1, end);

                // Reusing the solution for Merge 2 sorted linked lists problem.
                return Merge2SortedLinkedLists.Merge(left, right);  
            }

            return null;
        }

        // TO DO: Fails for lists.Length > 2.
        public ListNode MergeKLists(ListNode[] lists)
        {
            // edge cases
            if (lists == null)
                return null;
            else if (lists.Length == 1)
                return lists[0];

            ListNode mergedNode = new ListNode(0);
            ListNode current = mergedNode;

            for(int i = 1; i< lists.Length; i++)
            {
                //mergedNode = new ListNode(0);
                ListNode node1 = i == 1 ? lists[0] : mergedNode;
                ListNode node2 = lists[i];

                current = mergedNode;

                while (node1 != null || node2 != null)
                {
                    if ((node2 == null && node1 != null)
                            || node1.Val <= node2.Val)
                    {
                        current.Next = node1;   
                        node1 = node1.Next;
                    }
                    else if ((node1 == null && node2 != null)
                                || node1.Val > node2.Val)
                    {
                        current.Next = node2;
                        node2 = node2.Next;
                    }

                    current = current.Next;
                }
            }

            return mergedNode.Next;
        }
    }
}
