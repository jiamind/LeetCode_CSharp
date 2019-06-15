using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 460. LFU Cache
    /// Design and implement a data structure for Least Frequently Used (LFU) cache. It should support the following operations: get and put.
    /// get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    /// put(key, value) - Set or insert the value if the key is not already present.When the cache reaches its capacity, it should invalidate the least frequently used item before inserting a new item.For the purpose of this problem, when there is a tie (i.e., two or more keys that have the same frequency), the least recently used key would be evicted.
    /// Follow up:
    /// Could you do both operations in O(1) time complexity?
    /// Example:
    /// LFUCache cache = new LFUCache( 2 /* capacity */ );
    /// cache.put(1, 1);
    /// cache.put(2, 2);
    /// cache.get(1);       // returns 1
    /// cache.put(3, 3);    // evicts key 2
    /// cache.get(2);       // returns -1 (not found)
    /// cache.get(3);       // returns 3.
    /// cache.put(4, 4);    // evicts key 1.
    /// cache.get(1);       // returns -1 (not found)
    /// cache.get(3);       // returns 3
    /// cache.get(4);       // returns 4
    /// </summary>
    public class LFUCache
    {
        private Dictionary<int, int> keyValueDict;

        private Dictionary<int, LFUCacheBucket> keyNodeDict;

        private int capacity;

        private LFUCacheBucket head;

        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            this.keyValueDict = new Dictionary<int, int>();
            this.keyNodeDict = new Dictionary<int, LFUCacheBucket>();
        }

        public int Get(int key)
        {
            if (keyValueDict.ContainsKey(key))
            {
                this.IncreaseAccessCount(key);
                return keyValueDict[key];
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (this.capacity == 0)
            {
                return;
            }

            if (keyValueDict.ContainsKey(key))
            {
                keyValueDict[key] = value;
            }
            else
            {
                if (keyValueDict.Count >= this.capacity)
                {
                    this.RemoveLFUKey();
                }

                this.AddNewKeyToNode(key);
                keyValueDict[key] = value;
            }

            this.IncreaseAccessCount(key);
        }

        private void IncreaseAccessCount(int key)
        {
            LFUCacheBucket node = keyNodeDict[key];
            node.Keys.Remove(key);

            if (node.NextBucket == null)
            {
                LFUCacheBucket temp = new LFUCacheBucket(node.AccessCount + 1);
                temp.Keys.Add(key);
                temp.PrevBucket = node;
                node.NextBucket = temp;
                keyNodeDict[key] = temp;
            }
            else if (node.NextBucket.AccessCount == node.AccessCount + 1)
            {
                node.NextBucket.Keys.Add(key);
                keyNodeDict[key] = node.NextBucket;
            }
            else
            {
                LFUCacheBucket temp = new LFUCacheBucket(node.AccessCount + 1);
                temp.Keys.Add(key);
                temp.NextBucket = node.NextBucket;
                if (node.NextBucket != null)
                {
                    node.NextBucket.PrevBucket = temp;
                }

                node.NextBucket = temp;
                temp.PrevBucket = node;

                keyNodeDict[key] = temp;
            }

            if (!node.Keys.Any())
            {
                this.RemoveNode(node);
            }
        }

        private void AddNewKeyToNode(int key)
        {
            if (head == null)
            {
                head = new LFUCacheBucket();
                head.Keys.Add(key);
            }
            else if (head.AccessCount == 0)
            {
                head.Keys.Add(key);
            }
            else
            {
                LFUCacheBucket node = new LFUCacheBucket();
                node.Keys.Add(key);
                head.PrevBucket = node;
                node.NextBucket = head;
                head = node;
            }

            keyNodeDict[key] = head;
        }

        private void RemoveLFUKey()
        {
            if (head == null || !head.Keys.Any())
            {
                return;
            }

            int lfuKey = head.Keys[0];
            head.Keys.Remove(lfuKey);
            keyValueDict.Remove(lfuKey);
            keyNodeDict.Remove(lfuKey);

            if (!head.Keys.Any())
            {
                this.RemoveNode(head);
            }
        }

        private void RemoveNode(LFUCacheBucket node)
        {
            if (head == node)
            {
                head = node.NextBucket;
            }
            else
            {
                node.PrevBucket.NextBucket = node.NextBucket;
            }

            if (node.NextBucket != null)
            {
                node.NextBucket.PrevBucket = node.PrevBucket;
            }
        }

        private class LFUCacheBucket
        {
            /// <summary>
            /// The access count of the bucket (keys in this bucket has been accessed this number of times)
            /// </summary>
            public int AccessCount { get; set; }

            /// <summary>
            /// The previous bucket
            /// </summary>
            public LFUCacheBucket PrevBucket { get; set; }

            /// <summary>
            /// The next bucket
            /// </summary>
            public LFUCacheBucket NextBucket { get; set; }

            /// <summary>
            /// The keys in this bucket
            /// </summary>
            public List<int> Keys { get; set; }

            public LFUCacheBucket()
            {
                this.Keys = new List<int>();
            }

            public LFUCacheBucket(int accessCount) : this()
            {
                this.AccessCount = accessCount;
            }
        }
    }
}
