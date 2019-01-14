using System;
using System.Collections.Generic;

namespace LeetCode_CSharp
{
    /// <summary>
    /// Suppose we abstract our file system by a string in the following manner:
    /// The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:
    /// dir
    ///     subdir1
    ///     subdir2
    ///         file.ext
    /// The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.
    /// The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:
    /// dir
    ///     subdir1
    ///         file1.ext
    ///         subsubdir1
    ///     subdir2
    ///         subsubdir2
    ///             file2.ext
    /// The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.
    /// We are interested in finding the longest (number of characters) absolute path to a file within our file system.For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).
    /// Given a string representing the file system in the above format, return the length of the longest absolute path to file in the abstracted file system.If there is no file in the system, return 0.
    /// </summary>
    class LongestAbsoluteFilePath
    {
        /// <summary>
        /// Split the input by '\n'. For each splited string, check the depth of the string with '\t', calculate the length of the current path and push to a stack. 
        /// Check for file names and update the max length
        /// </summary>
        /// <param name="input">the input path string</param>
        /// <returns>the max length of the path to a file</returns>
        public int LengthLongestPath(string input)
        {
            Stack<int> lengthToDepth = new Stack<int>();

            string[] names = input.Split('\n');
            int maxLength = 0;

            foreach (string name in names)
            {
                int depth = name.LastIndexOf('\t') + 1;
                while (lengthToDepth.Count > depth)
                {
                    lengthToDepth.Pop();
                }

                string realName = name.Replace("\t",string.Empty);
                int length = lengthToDepth.Count == 0 ? realName.Length : lengthToDepth.Peek() + realName.Length + 1;
                lengthToDepth.Push(length);
                if (realName.Contains(".") && realName.LastIndexOf(".") != realName.Length - 1)
                {
                    maxLength = Math.Max(maxLength, length);
                }
            }

            return maxLength;
        }
    }
}
