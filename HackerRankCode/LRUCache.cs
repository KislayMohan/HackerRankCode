using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class LRUCache
    {
        private Dictionary<int, LinkedListNode<(int key, int value)>> dict;
        private LinkedList<(int key, int value)> cache;
        private int capacity;
        public LRUCache(int capacity)
        {
            // Initialize the cache with the given capacity
            // This could be implemented using a dictionary and a linked list for O(1) access and updates
            cache = new LinkedList<(int key, int value)>();
            dict = new Dictionary<int, LinkedListNode<(int key, int value)>>();
            this.capacity = capacity;
        }

        public void put(int key, int value)
        {
            // If the key already exists, update the value and move it to the front
            if (dict.ContainsKey(key))
            {
                var node = dict[key];
                node.Value = (key, value);
                cache.Remove(node);
                cache.AddFirst(node);
            }
            else
            {
                // If the cache is full, remove the least recently used item
                if (cache.Count == capacity)
                {
                    var lastNode = cache.Last;
                    dict.Remove(lastNode.Value.key);
                    cache.RemoveLast();
                }
                // Add the new key-value pair to the cache
                var newNode = new LinkedListNode<(int key, int value)>((key, value));
                cache.AddFirst(newNode);
                dict[key] = newNode;
            }
        }

        public int get(int key)
        {
            // If the key exists, return its value and move it to the front
            if (dict.ContainsKey(key))
            {
                var node = dict[key];
                cache.Remove(node);
                cache.AddFirst(node);
                return node.Value.value;
            }
            // If the key does not exist, return -1
            return -1;
        }
    }
}
