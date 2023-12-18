using Masalah_Petani_Serigala_Bebek_dan_Jagung_BFS;
using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MisionarisKanibal
{
    public static class Program
    {
        public static string PerahuToString(Perahu perahu)
        {
            if (perahu == Perahu.Kiri)
                return "Kiri";
            else
                return "Kanan";
        }

        public static void Main()
        {
            const int maxKedalaman = 100;

            State initialState = new(3, 3, 0, 0, Perahu.Kiri); //Keadaan awal
            State goalState = new(0, 0, 3, 3, Perahu.Kanan); //Keadaan tujuan
            Predicate<State>[] AturanProduksi = new Predicate<State>[]
            {
                Aturan.Aturan1, Aturan.Aturan2, Aturan.Aturan3, Aturan.Aturan4, Aturan.Aturan5,
                Aturan.Aturan6, Aturan.Aturan7, Aturan.Aturan8, Aturan.Aturan9, Aturan.Aturan10,
                (state) =>
                {
                    if(state.perahu == Perahu.Kiri)
                        return true;
                    return false;
                },
                (state) =>
                {
                    if(state.perahu == Perahu.Kanan)
                        return true;
                    return false;
                }
            };

            Func<State, State>[] OperatorProduksi = new Func<State, State>[]
            {
                Operator.Operator1, Operator.Operator2, Operator.Operator3, Operator.Operator4, Operator.Operator5,
                Operator.Operator6, Operator.Operator7, Operator.Operator8, Operator.Operator9, Operator.Operator10,
                (state) => new State(state.MisionarisA, state.KanibalA, state.MisionarisB, state.KanibalB, Perahu.Kanan),
                (state) => new State(state.MisionarisA, state.KanibalA, state.MisionarisB, state.KanibalB, Perahu.Kiri)
            };
            Queue<Simpul> queue = new Queue<Simpul>();
            List<Simpul> visited = new List<Simpul>();
            List<State> path = new List<State>();
            Simpul? solusi = new Simpul(initialState, new State(), 0);
            bool selesai = false;
            int totalCabang = 0;
            Stopwatch timer = Stopwatch.StartNew();

            queue.Enqueue(new Simpul(initialState, new State(), 0));

            while (!selesai && queue.Count > 0) 
            {
                int cabang = 0;
                var state = queue.Dequeue();

                if (visited.Contains(state))
                    continue;

                if (state.Kedalaman > maxKedalaman)
                    continue;

                visited.Add(state);

                if (state.State == goalState)
                {
                    selesai = true;
                    solusi = state;
                    break;
                }

                for (int i = 0; i < AturanProduksi.Length; i++)
                {
                    if (AturanProduksi[i](state.State) && !Aturan.GameOver(OperatorProduksi[i](state.State)))
                    {
                        var succ = new Simpul(OperatorProduksi[i](state.State), parent:state.State, state.Kedalaman + 1);
                        if (!queue.Contains(succ))
                        {
                            queue.Enqueue(succ);
                            cabang++;
                        }
                    }
                }

                totalCabang += cabang;
            }

            double waktu = timer.ElapsedMilliseconds;

            if (!selesai)
            {
                Console.WriteLine("Solusi tidak ditemukan");
                return;
            }

            Simpul current = solusi;

            while(current.State != initialState) 
            {
                path.Add(current.State);
                State parent = current.Parent;
                foreach (var state in visited)
                {
                    if (parent == state.State)
                    {
                        current = state;
                        break;
                    }
                }
            }

            path.Add(initialState);

            for(int i = path.Count - 1; i >= 0; i--)
            {
                DrawState(path[i]);
            }

            int jmlSimpul = visited.Count + queue.Count;
            double faktorPercabangan = (double)totalCabang / visited.Count;
            int kedalamanSolusi = solusi.Kedalaman;
            Console.WriteLine("Jumlah simpul yang dibangkitkan : {0}", jmlSimpul);
            Console.WriteLine("Faktor percabangan : {0}", faktorPercabangan);
            Console.WriteLine("Kedalaman Solusi : {0}", kedalamanSolusi);
            Console.WriteLine("Jumlah waktu yang dibutuhkan : {0} ms", waktu);

            Console.WriteLine("\nAlgoritma versi kedua");
            Algoritm algoritm = new Algoritm();

            var path2 = algoritm.BFS<State>(initialState, goalState, AturanProduksi, OperatorProduksi, Aturan.GameOver);
            if (path2.Count == 0)
                Console.WriteLine("Solusi tidak temukan!");
            else
                foreach (var x in path)
                    DrawState(x);
        }

        public static void PrintState(State state)
        {
            Console.WriteLine($"({state.MisionarisA}, {state.KanibalA}), ({state.MisionarisB}, {state.KanibalB}), {PerahuToString(state.perahu)}");
        }

        public static void DrawState(State state)
        {
            string[] canvas;
            const char Misionaris = 'M';
            const char Kanibal = 'K';

            if (state.perahu == Perahu.Kiri)
            {
                canvas = new string[]
                {
                    "                                        ",
                    "                                        ",
                    "_____                              _____",
                    " A   |                             |  B ",
                    "     |\\______/~~~~~~~~~~~~~~~~~~~~~|    ",
                    "     |                             |    "
                };
            }
            else
            {
                canvas = new string[]
                {
                    "                                        ",
                    "                                        ",
                    "_____                              _____",
                    " A   |                             |  B ",
                    "     |~~~~~~~~~~~~~~~~~~~~~\\______/|    ",
                    "     |                             |    "
                };
            }

            //Menggambar misionaris di sisi A
            StringBuilder stringBuilder = new StringBuilder(canvas[1]);
            for (int i = 0; i < state.MisionarisA; i++)
            {
                stringBuilder[i] = Misionaris;
            }
            canvas[1] = stringBuilder.ToString();

            //Menggambar kanibal di sisi A
            stringBuilder = new StringBuilder(canvas[0]);
            for (int i = 0; i < state.KanibalA; i++)
            {
                stringBuilder[i] = Kanibal;
            }
            canvas[0] = stringBuilder.ToString();

            //Menggambar misionaris di sisi B
            stringBuilder = new StringBuilder(canvas[1]);
            for (int i = 0; i < state.MisionarisB; i++)
            {
                stringBuilder[canvas[1].Length - 1 - i] = Misionaris;
            }
            canvas[1] = stringBuilder.ToString();

            //Menggambar kanibal di sisi B
            stringBuilder = new StringBuilder(canvas[0]);
            for (int i = 0; i < state.KanibalB; i++)
            {
                stringBuilder[canvas[0].Length - 1 - i] = Kanibal;
            }
            canvas[0] = stringBuilder.ToString();

            //Menggambar canvas
            for (int i = 0; i < canvas.Length; i++)
            {
                Console.WriteLine(canvas[i]);
            }
        }
    }

    public class Simpul
    {
        private State? parent;

        public State? Parent { get => parent; set => parent = value; }

        private State state;
        public State State { get => state; set => state = value; }

        public int Kedalaman { get; set; }

        public Simpul(State simpul, State? parent, int kedalaman)
        {
            Parent = parent;
            State = simpul;
            Kedalaman = kedalaman;
        }

        public static bool operator==(Simpul? s1, Simpul? s2)
        {
            if (s1 == null || s2 == null)
                return false;
            return s1.state == s2.state;
        }

        public static bool operator!=(Simpul? s1, Simpul? s2)
        {
            return !(s1.state == s2.state);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }


    public enum Perahu //Posisi Perahu
    {
        Kiri, Kanan,
    }


    public class State
    {

        public int MisionarisA //Jumlah Misioanaris di sisi A
        {
            get;
            set;
        }

        public int KanibalA //Jumlah Kanibal di sisi A
        {
            get;
            set;
        }

        public int MisionarisB //Jumlah Misioanaris di sisi B
        {
            get;
            set;
        }

        public int KanibalB //Jumlah Kanibal di sisi B
        {
            get;
            set;
        }

        public Perahu perahu; //Posisi perahu

        public State()
        {
            MisionarisA = 0;
            KanibalA = 0;
            MisionarisB = 0;
            KanibalB = 0;
            perahu = Perahu.Kiri;
        }

        public State(int mA, int kA, int mB, int kB, Perahu p)
        {
            if (mA < 0 || kA < 0 || mB < 0 || kB < 0)
                throw new Exception("jumlah misionaris atau kanibal negatif!");
            MisionarisA = mA;
            KanibalA = kA;
            MisionarisB = mB;
            KanibalB = kB;
            perahu = p;
        }

        public static bool operator ==(State a, State b)
        {
            return (a.MisionarisA == b.MisionarisA) && (a.KanibalA == b.KanibalA) && (a.MisionarisB == b.MisionarisB) && (a.KanibalB == b.KanibalB) && (a.perahu == b.perahu);
        }

        public static bool operator !=(State a, State b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            State state = (State)obj;
            return state == this;
        }
    }

    public static class Aturan
    {
        public static bool Aturan1(State state)
        //Pindah 1 kanibal dari A ke B
        {
            if ((state.perahu == Perahu.Kiri) && (state.KanibalA > 0))
                return true;
            else
                return false;
        }

        public static bool Aturan2(State state)
        //Pindah 2 kanibal dari A ke B
        {
            if ((state.perahu == Perahu.Kiri) && (state.KanibalA > 1))
                return true;
            else
                return false;
        }

        public static bool Aturan3(State state)
        //Pindah 1 misionaris dan 1 kanibal dari A ke B
        {
            if ((state.perahu == Perahu.Kiri) && (state.KanibalA > 0) && (state.MisionarisA > 0))
                return true;
            else
                return false;
        }

        public static bool Aturan4(State state)
        //Pindah 1 misionaris dari A ke B
        {
            if ((state.perahu == Perahu.Kiri) && (state.MisionarisA > 0))
                return true;
            else
                return false;
        }

        public static bool Aturan5(State state)
        //Pindah 2 misionaris dari A ke B
        {
            if ((state.perahu == Perahu.Kiri) && (state.MisionarisA > 1))
                return true;
            else
                return false;
        }

        public static bool Aturan6(State state)
        //Pindah 1 kanibal dari B ke A
        {
            if ((state.perahu == Perahu.Kanan) && (state.KanibalB > 0))
                return true;
            else
                return false;
        }

        public static bool Aturan7(State state)
        //Pindah 2 kanibal dari N ke A
        {
            if ((state.perahu == Perahu.Kanan) && (state.KanibalB > 1))
                return true;
            else
                return false;
        }

        public static bool Aturan8(State state)
        //Pindah 1 misionaris dan 1 kanibal dari B ke A
        {
            if ((state.perahu == Perahu.Kanan) && (state.KanibalB > 0) && (state.MisionarisB > 0))
                return true;
            else
                return false;
        }

        public static bool Aturan9(State state)
        //Pindah 1 misionaris dari B ke A
        {
            if ((state.perahu == Perahu.Kanan) && (state.MisionarisB > 0))
                return true;
            else
                return false;
        }

        public static bool Aturan10(State state)
        //Pindah 2 misionaris dari B ke A
        {
            if ((state.perahu == Perahu.Kanan) && (state.MisionarisB > 1))
                return true;
            else
                return false;
        }

        public static bool GameOver(State state)
        //Game Over jika saat tidak 0 jumlah misionaris di salah satu sisi lebih kecil dari kanibal
        {
            if (state.MisionarisA != 0 && (state.MisionarisA < state.KanibalA))
                return true;
            if (state.MisionarisB != 0 && (state.MisionarisB < state.KanibalB))
                return true;
            return false;
        }
    }

    public static class Operator
    {
        public static State Operator1(State state)
        //Pindah 1 Kanibal dari A ke B
        {
            return new State(state.MisionarisA, state.KanibalA - 1, state.MisionarisB, state.KanibalB + 1, Perahu.Kanan);
        }

        public static State Operator2(State state)
        //Pindah 2 Kanibal dari A ke B
        {
            return new State(state.MisionarisA, state.KanibalA - 2, state.MisionarisB, state.KanibalB + 2, Perahu.Kanan);
        }

        public static State Operator3(State state)
        //Pindah 1 misionaris dan 1 Kanibal dari A ke B
        {
            return new State(state.MisionarisA - 1, state.KanibalA - 1, state.MisionarisB + 1, state.KanibalB + 1, Perahu.Kanan);
        }

        public static State Operator4(State state)
        //Pindah 1 misionaris dari A ke B
        {
            return new State(state.MisionarisA - 1, state.KanibalA, state.MisionarisB + 1, state.KanibalB, Perahu.Kanan);
        }

        public static State Operator5(State state)
        //Pindah 2 misionaris dari A ke B
        {
            return new State(state.MisionarisA - 2, state.KanibalA, state.MisionarisB + 2, state.KanibalB, Perahu.Kanan);
        }

        public static State Operator6(State state)
        //Pindah 1 Kanibal dari B ke A
        {
            return new State(state.MisionarisA, state.KanibalA + 1, state.MisionarisB, state.KanibalB - 1, Perahu.Kiri);
        }

        public static State Operator7(State state)
        //Pindah 2 Kanibal dari B ke A
        {
            return new State(state.MisionarisA, state.KanibalA + 2, state.MisionarisB, state.KanibalB - 2, Perahu.Kiri);
        }

        public static State Operator8(State state)
        //Pindah 1 misionaris dan 1 Kanibal dari B ke A
        {
            return new State(state.MisionarisA + 1, state.KanibalA + 1, state.MisionarisB - 1, state.KanibalB - 1, Perahu.Kiri);
        }

        public static State Operator9(State state)
        //Pindah 1 misionaris dari B ke A
        {
            return new State(state.MisionarisA + 1, state.KanibalA, state.MisionarisB - 1, state.KanibalB, Perahu.Kiri);
        }

        public static State Operator10(State state)
        //Pindah 2 misionaris dari B ke A
        {
            return new State(state.MisionarisA + 2, state.KanibalA, state.MisionarisB - 2, state.KanibalB, Perahu.Kiri);
        }
    }
}