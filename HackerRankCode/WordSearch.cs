using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class WordSearch
    {
        public static bool Exist(char[][] board, string word)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0 || string.IsNullOrEmpty(word))
                return false;
            int rows = board.Length;
            int cols = board[0].Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Search(board, word, i, j, 0))
                        return true;
                }
            }
            return false;
        }

        private static bool Search(char[][] board, string word, int i, int j, int v)
        {
            if (v == word.Length)
                return true;
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != word[v])
                return false;
            char temp = board[i][j];
            board[i][j] = '#'; // Mark as visited
            // Explore all four directions
            bool found = Search(board, word, i + 1, j, v + 1) ||
                         Search(board, word, i - 1, j, v + 1) ||
                         Search(board, word, i, j + 1, v + 1) ||
                         Search(board, word, i, j - 1, v + 1);
            board[i][j] = temp; // Restore the original character
            return found;
        }
            
    }
}
