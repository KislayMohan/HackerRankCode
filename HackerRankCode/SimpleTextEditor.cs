using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class SimpleTextEditor
    {
        public static void PerformSimpleTextEditor()
        {
            var text = string.Empty;
            var printText = new List<char>();
            var editorStack = new Stack<KeyValuePair<string, string>>();
            var inputCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                var query = Console.ReadLine();
                var splitQuery = query.Split(' ');
                switch (Convert.ToInt32(splitQuery[0]))
                {
                    case 1:
                        text += splitQuery[1];
                        editorStack.Push(new KeyValuePair<string, string>("a", splitQuery[1]));
                        break;

                    case 2:
                        var index = Convert.ToInt32(splitQuery[1]);
                        var delString = text.Substring(text.Length - index, index);
                        text = text.Remove(text.Length - index, index);
                        editorStack.Push(new KeyValuePair<string, string>("d", delString));
                        break;

                    case 3:
                        printText.Add(text[Convert.ToInt32(splitQuery[1]) - 1]);
                        break;

                    case 4:
                        var operation = editorStack.Pop();
                        if (operation.Key == "a")
                        {
                            var subStringIndex = text.LastIndexOf(operation.Value);
                            text = text.Remove(subStringIndex, operation.Value.Count());
                        }
                        else
                        {
                            text += operation.Value;
                        }
                        break;

                    default:
                        break;
                }
            }

            foreach (var str in printText)
            {
                Console.WriteLine(str);
            }
        }
    }
}
