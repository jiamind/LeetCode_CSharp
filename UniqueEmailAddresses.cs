using System.Collections.Generic;
using System.Text;

namespace LeetCode_CSharp
{
    /*
     * Every email consists of a local name and a domain name, separated by the @ sign.
     * For example, in alice@leetcode.com, alice is the local name, and leetcode.com is the domain name.
     * Besides lowercase letters, these emails may contain '.'s or '+'s.
     * If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.  For example, "alice.z@leetcode.com" and "alicez@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
     * If you add a plus ('+') in the local name, everything after the first plus sign will be ignored. This allows certain emails to be filtered, for example m.y+name@email.com will be forwarded to my@email.com.  (Again, this rule does not apply for domain names.)
     * It is possible to use both of these rules at the same time.
     * Given a list of emails, we send one email to each address in the list.  How many different addresses actually receive mails? 
    */
    public class UniqueEmailAddresses
    {
        public int NumUniqueEmails(string[] emails)
        {
            // Create hashset to store distinct emails
            HashSet<string> distinctEmails = new HashSet<string>();
            foreach (string email in emails)
            {
                string[] emailParts = email.Split('@');
                distinctEmails.Add(this.UnifyEmailLoalName(emailParts[0]) + emailParts[1]);
            }

            return distinctEmails.Count;
        }

        private string UnifyEmailLoalName(string localName)
        {
            StringBuilder sb = new StringBuilder();
            string name = localName.Split('+')[0];
            foreach(char c in name)
            {
                if (c != '.')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
