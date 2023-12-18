using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masalah_Petani_Serigala_Bebek_dan_Jagung_BFS
{
    public class Algoritm
    {
        public List<T> BFS<T>(T initial, T goal, IList<Predicate<T>> aturan, IList<Func<T, T>> operation, Predicate<T> gameOver)
        {
            var queue = new Queue<T>();
            var previous = new Dictionary<T, T>();
            queue.Enqueue(initial);
            previous[initial] = initial;

            while(queue.Count > 0) 
            {
                T current = queue.Dequeue();

                if (current.Equals(goal))
                    break;

                for (int i = 0; i < aturan.Count(); i++)
                {
                    T succ;
                    if (aturan[i](current) && !gameOver(operation[i](current)))
                    {
                        succ = operation[i](current);
                        if (!previous.ContainsKey(succ))
                        {
                            previous[succ] = current;
                            queue.Enqueue(succ);
                        }
                    }
                }

                Console.WriteLine();
            }

            List<T> path = new List<T>();

            if(previous.ContainsKey(goal))
            {
                T current = goal;
                while (!current.Equals(initial))
                {
                    path.Add(current);
                    current = previous[current];
                }
                path.Add(initial);
                path.Reverse();
            }

            return path;
        }
    }
}
