using System.Linq;
using System.Collections.Generic;
using System;

namespace LinkedList.Runner
{
    class Program
    {
        
        public static void Main(String[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();

            Console.WriteLine("first list chars pipe delimited");
            var temp = Console.ReadLine();
            var intList = temp.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var num in intList)
            {
                list1.AddLast(int.Parse(num));
            }

            Console.WriteLine("second list chars pipe delimited");
            var temp2 = Console.ReadLine();
            var intList1 = temp2.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var num in intList1)
            {
                list2.AddLast(int.Parse(num));
            }

            Console.WriteLine(string.Join("->", list1));
            Console.WriteLine(string.Join("->", list2));

            var output = AddList(list1, list2);
            Console.WriteLine("output");
            Console.WriteLine(string.Join("->", output));
        }

        public static LinkedList<int> AddList(LinkedList<int> list1, LinkedList<int> list2)
        {
            var carry = 0;
            LinkedList<int> output = new LinkedList<int>();

            while(list1?.Count >0 || list2?.Count >0 )
            {
                var sum = carry + (list2?.Last?.Value ?? 0) + (list1?.Last?.Value ?? 0);

                carry = (sum >= 10) ? 1 : 0;
                sum = sum % 10;
                
                output.AddFirst(sum);
                
                if (list1?.Count > 0)
                {
                    list1.RemoveLast();
                }
                if (list2?.Count > 0)
                {
                    list2.RemoveLast();
                }
            }

            if(carry !=0)
            {
                output.AddFirst(carry);
            }

            return output;

        }

      
    }
}
