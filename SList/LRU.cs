using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Collections.Generic;

namespace CSharpAlgorithm.SList
{
    public class LRUCache
    {
        private struct CacheNode{
            public int key;
            public int val;
            // public CacheNode(int k,int v){this.key = k;this.val = v;}
        }

        private Dictionary<int,CacheNode> cahceMap = new Dictionary<int, CacheNode>();
        private int capacity;
        private LinkedList<CacheNode> cacheList = new LinkedList<CacheNode>();

        public LRUCache(int _capacity){this.capacity = _capacity;}

        public void Set(int k,int v){
            CacheNode node;
            if (!cahceMap.TryGetValue(k, out node))
            {
                if (this.capacity == cacheList.Count()){
                    cahceMap.Remove(cacheList.Last.Value.key);
                    cacheList.Remove(cacheList.Last());
                }

                CacheNode newNode; // = new CacheNode(k,v);
                newNode.key = k;
                newNode.val = v;
                cacheList.AddFirst(newNode);
                cahceMap.Add(k,newNode);
            }
            else
            {
                node.val = v;
                cacheList.Remove(node);
                cacheList.AddFirst(node);
            }
        }

        public int Get(int k)
        {
            CacheNode node;
            if (!cahceMap.TryGetValue(k, out node))
            {
                return -1;
            }
            else
            {
                cacheList.Remove(node);
                cacheList.AddFirst(node);

                return node.val;
            }
        }

        static public void Test()
            {
                LRUCache cache = new LRUCache(5);
                for(int i=0;i<8;i++)
                {
                    cache.Set(i,i*5);
                }

                cache.Get(5);

                cache.Get(6);
            }
    }
}