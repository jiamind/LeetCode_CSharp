using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_CSharp
{
    /// <summary>
    /// 146. LRU Cache
    /// Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and put.
    /// get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    /// put(key, value) - Set or insert the value if the key is not already present.When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.
    /// The cache is initialized with a positive capacity.
    /// Follow up:
    /// Could you do both operations in O(1) time complexity?
    /// Example:
    /// LRUCache cache = new LRUCache(2 /* capacity */ );
    /// cache.put(1, 1);
    /// cache.put(2, 2);
    /// cache.get(1);       // returns 1
    /// cache.put(3, 3);    // evicts key 2
    /// cache.get(2);       // returns -1 (not found)
    /// cache.put(4, 4);    // evicts key 1
    /// cache.get(1);       // returns -1 (not found)
    /// cache.get(3);       // returns 3
    /// cache.get(4);       // returns 4
    /// </summary>
    public class LRUCache
    {
        public class CacheNode
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public CacheNode PrevNode { get; set; }
            public CacheNode NextNode { get; set; }

            public CacheNode(int key, int value)
            {
                this.Key = key;
                this.Value = value;
            }
        }

        public int Capacity { get; set; }

        public Dictionary<int, CacheNode> NodeDict { get; set; }

        public CacheNode Head { get; set; }

        public CacheNode Tail { get; set; }

        public LRUCache(int capacity)
        {
            this.Capacity = capacity;
            this.NodeDict = new Dictionary<int, CacheNode>();
            this.Head = null;
            this.Tail = null;
        }

        public int Get(int key)
        {
            if (!NodeDict.ContainsKey(key))
            {
                return -1;
            }

            int value = NodeDict[key].Value;
            this.RemoveNode(NodeDict[key]);
            this.AddToHead(NodeDict[key]);
            return value;
        }

        public void Put(int key, int value)
        {
            if (NodeDict.ContainsKey(key))
            {
                NodeDict[key].Value = value;
                this.RemoveNode(NodeDict[key]);
            }
            else
            {
                if (NodeDict.Count == this.Capacity)
                {
                    NodeDict.Remove(this.Tail.Key);
                    this.RemoveNode(this.Tail);
                }

                CacheNode node = new CacheNode(key, value);
                NodeDict.Add(key, node);
            }

            this.AddToHead(NodeDict[key]);
        }

        private void RemoveNode(CacheNode node)
        {
            if (node.PrevNode == null && node.NextNode == null)
            {
                this.Head = null;
                this.Tail = null;
            }
            else if (node.PrevNode == null)
            {
                this.Head = node.NextNode;
                this.Head.PrevNode = null;
            }
            else if (node.NextNode == null)
            {
                this.Tail = node.PrevNode;
                node.PrevNode.NextNode = null;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
        }

        private void AddToHead(CacheNode node)
        {
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                node.NextNode = this.Head;
                this.Head.PrevNode = node;
                this.Head = node;
            }

            node.PrevNode = null;
        }
    }
}
