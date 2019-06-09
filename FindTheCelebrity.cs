using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 277. Find the Celebrity
    /// Suppose you are at a party with n people(labeled from 0 to n - 1) and among them, there may exist one celebrity.The definition of a celebrity is that all the other n - 1 people know him/her but he/she does not know any of them.
    /// Now you want to find out who the celebrity is or verify that there is not one.The only thing you are allowed to do is to ask questions like: "Hi, A. Do you know B?" to get information of whether A knows B. You need to find out the celebrity (or verify there is not one) by asking as few questions as possible(in the asymptotic sense).
    /// You are given a helper function bool knows(a, b) which tells you whether A knows B.Implement a function int findCelebrity(n). There will be exactly one celebrity if he/she is in the party.Return the celebrity's label if there is a celebrity in the party. If there is no celebrity, return -1.
    /// </summary>
    public class FindTheCelebrity
    {
        public bool Knows(int a, int b)
        {
            // Dummy return
            return true;
        }

        public int FindCelebrity(int n)
        {
            //// Pick the first person as the candidate, iterate through people and ask the candidate if he/she know each one
            //// If the candidate knows anyone, he/she can't be the candidate any more. Set the candidate to be that person that he/she knows
            //// This is guaranteed to work since everyone knows the celebrity.
            int candidate = 0;
            for (int i = 1; i < n; i++)
            {
                if (Knows(candidate, i))
                    candidate = i;
            }

            // Rule out the possibility that there's no celebrity
            for (int i = 0; i < n; i++)
            {
                //// If i < candidate, we already checked the previous index person knows the candidate. Only check if the candidate knows i
                //// If i > candidate, we already checked the candidate doesn't know anyone after him/her. Only check if i doesn't know the candidate
                if (i < candidate && Knows(candidate, i))
                    return -1;
                if (i > candidate && !Knows(i, candidate))
                    return -1;
            }

            return candidate;
        }
    }
}
