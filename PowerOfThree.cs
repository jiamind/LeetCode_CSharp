namespace LeetCode_CSharp
{
    /// <summary>
    /// Given an integer, write a function to determine if it is a power of three.
    /// </summary>
    class PowerOfThree
    {
        public bool IsPowerOfThree(int n)
        {
            if (n < 1)
            {
                return false;
            }

            while (n % 3 == 0)
            {
                n /= 3;
            }

            return n == 1;
        }
    }
}
