namespace HackerRankCode
{
    internal class UnionFind
    {
        private int[] parent;
        private int[] size;
        public UnionFind(int n)
        {
            parent = new int[n];
            size = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                size[i] = 1;
            }
        }
        public int Find(int p)
        {
            if (parent[p] != p)
            {
                parent[p] = Find(parent[p]);
            }
            return parent[p];
        }
        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP != rootQ)
            {
                if (size[rootP] < size[rootQ])
                {
                    parent[rootP] = rootQ;
                    size[rootQ] += size[rootP];
                }
                else
                {
                    parent[rootQ] = rootP;
                    size[rootP] += size[rootQ];
                }
            }
        }
        public int GetComponentSize(int p)
        {
            int rootP = Find(p);
            return size[rootP];
        } 
    }
}