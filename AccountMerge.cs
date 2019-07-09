using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 721. Accounts Merge
    /// Given a list accounts, each element accounts[i] is a list of strings, where the first element accounts[i][0] is a name, and the rest of the elements are emails representing emails of the account.
    /// Now, we would like to merge these accounts.Two accounts definitely belong to the same person if there is some email that is common to both accounts.Note that even if two accounts have the same name, they may belong to different people as people could have the same name. A person can have any number of accounts initially, but all of their accounts definitely have the same name.
    /// After merging the accounts, return the accounts in the following format: the first element of each account is the name, and the rest of the elements are emails in sorted order. The accounts themselves can be returned in any order.
    /// Example 1:
    /// Input: 
    /// accounts = [["John", "johnsmith@mail.com", "john00@mail.com"], ["John", "johnnybravo@mail.com"], ["John", "johnsmith@mail.com", "john_newyork@mail.com"], ["Mary", "mary@mail.com"]]
    /// Output: [["John", 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com'],  ["John", "johnnybravo@mail.com"], ["Mary", "mary@mail.com"]]
    /// Explanation: 
    /// The first and third John's are the same person as they have the common email "johnsmith@mail.com".
    /// The second John and Mary are different people as none of their email addresses are used by other accounts.
    /// We could return these lists in any order, for example the answer[['Mary', 'mary@mail.com'], ['John', 'johnnybravo@mail.com'],
    /// ['John', 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com']] would still be accepted.
    /// Note:
    /// The length of accounts will be in the range [1, 1000].
    /// The length of accounts[i] will be in the range [1, 10].
    /// The length of accounts[i][j] will be in the range [1, 30].
    /// </summary>
    public class AccountMerge
    {
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<string, string> emailToOwner = new Dictionary<string, string>();
            Dictionary<string, string> emailtoParent = new Dictionary<string, string>();
            Dictionary<string, HashSet<string>> union = new Dictionary<string, HashSet<string>>();

            // Initialize the parent of all emails to itself. Record the owner of the email
            foreach (IList<string> account in accounts)
            {
                for (int i = 1; i < account.Count; i++)
                {
                    emailtoParent[account[i]] = account[i];
                    emailToOwner[account[i]] = account[0];
                }
            }

            // Link the parents of all emails in the same account together
            foreach (IList<string> account in accounts)
            {
                string parent = FindParent(account[1], emailtoParent);
                for (int i = 2; i < account.Count; i++)
                {
                    emailtoParent[FindParent(account[i], emailtoParent)] = parent;
                }
            }

            // Iterate through all emails in all accounts. Now emails in one account will have the same parent. Store the emails in the dictionary
            foreach (IList<string> account in accounts)
            {
                string parent = FindParent(account[1], emailtoParent);
                if (!union.ContainsKey(parent))
                {
                    union[parent] = new HashSet<string>();
                }

                for (int i = 1; i < account.Count; i++)
                {
                    union[parent].Add(account[i]);
                }
            }

            // Add the owner name, sort and populate the result list
            List<IList<string>> result = new List<IList<string>>();
            foreach (string key in union.Keys)
            {
                List<string> list = new List<string>();
                list.AddRange(union[key]);
                list.Sort((a, b) =>
                {
                    int i = 0;
                    while (i < a.Length && i < b.Length)
                    {
                        if (a[i] != b[i])
                        {
                            return a[i] - b[i];
                        }

                        i++;
                    }

                    return a.Length - b.Length;
                });
                list.Insert(0, emailToOwner[key]);
                result.Add(list);
            }

            return result;
        }

        private string FindParent(string email, Dictionary<string, string> emailtoParent)
        {
            return emailtoParent[email] == email ? email : FindParent(emailtoParent[email], emailtoParent);
        }
    }
}
