namespace HackerRankCode
{
    internal class StockPrice
    {
        private readonly Dictionary<int, int> stocksData;
        private readonly PriorityQueue<int, int> maxPrice;
        private readonly PriorityQueue<int, int> minPrice;
        private int latestTimestamp;


        public StockPrice()
        {
            stocksData = new Dictionary<int, int>();
            maxPrice = new PriorityQueue<int, int>(Comparer<int>.Create((i, j) => j - i));
            minPrice = new PriorityQueue<int, int>();
            latestTimestamp = 0;
        }

        public void Update(int timestamp, int price)
        {
            if (timestamp > latestTimestamp) 
            {
                latestTimestamp = timestamp;
            }
            stocksData[timestamp] = price;
            maxPrice.Enqueue(timestamp, price);
            minPrice.Enqueue(timestamp, price);
        }

        public int Current()
        {
            return stocksData[latestTimestamp];
        }

        public int Maximum()
        {
            int time, price;
            maxPrice.TryPeek(out time, out price);
            while (stocksData[time] != price)
            {
                maxPrice.Dequeue();
                maxPrice.TryPeek(out time, out price);
            }
            maxPrice.TryPeek(out time, out price);
            return price;
        }

        public int Minimum()
        {
            int time, price;
            minPrice.TryPeek(out time, out price);
            while (stocksData[time] != price)
            {
                minPrice.Dequeue();
                minPrice.TryPeek(out time, out price);
            }
            minPrice.TryPeek(out time, out price);
            return price;
        }
    }
}
