using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupByOwner
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, string>()
            { {"Input.txt", "Randy"}, { "Code.py", "Stan"},{ "Output.txt","Randy"},{ "Bit.txt","Randy"},{ "Sum.txt","Sam"} };

            Dictionary<string,List<string>> gro=group_by_owners(data);

            foreach (var n in gro)
            {
                Console.Write(n.Key+":");
                foreach (var c in n.Value)
                {
                    Console.Write(c+",");
                    
                }
                Console.WriteLine();
            }


        }
        /// <summary>
        /// Accepts and returns a dictionary of group_by_owners.
        /// </summary>
        /// <param name="dummy"></param>
        /// <returns></returns>
        public static Dictionary<string,List<string>> group_by_owners(Dictionary<string,string> dummy)
        {
            //contains repeated owners
            var value = dummy.GroupBy(x => x.Value).Where(x => x.Count() > 1).ToList();
            //contains single owners
            var y = new List<string>();
            foreach (var p in dummy)
            {
                foreach (var o in value)
                {
                    if (p.Value != o.Key)
                    {
                        y.Add(p.Value);
                    }
                }
            }
            var m = new Dictionary<string, List<string>>();


            foreach (var v in value)
            {
                List<string> s = new List<string>();
                foreach (var d in dummy)
                {

                    if (d.Value == v.Key)
                    {
                        s.Add(d.Key);
                    }


                }
                m.Add(v.Key, s);

            }
            foreach (var q in y)
            {
                List<string> j = new List<string>();
                foreach (var d in dummy)
                {

                    if (q == d.Value)
                    {
                        j.Add(d.Key);
                    }


                }
                m.Add(q, j);
            }
            
            return m;
        }
    }
}
