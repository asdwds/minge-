using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    /// <summary>
    /// Tuple型がなぜかUnityにないので作った
    /// </summary>
    /// 
    [System.Serializable]
    public static class Tuple
    {
        public static Tuple<T1, T2> Create<T1, T2>(T1 first, T2 second)
        {
            var tuple = new Tuple<T1, T2>(first, second);
            return tuple;
        }

        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 first, T2 second, T3 third)
        {
            var tuple = new Tuple<T1, T2, T3>(first, second, third);
            return tuple;
        }

        public static Tuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 first, T2 second, T3 third, T4 fourth)
        {
            var tuple = new Tuple<T1, T2, T3, T4>(first, second, third, fourth);
            return tuple;
        }
    }

    [System.Serializable]
    public class Tuple<T1, T2>
    {
        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        internal Tuple(T1 first, T2 second)
        {
            Item1 = first;
            Item2 = second;
        }
    }

    public class Tuple<T1, T2, T3>
    {
        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        public T3 Item3 { get; private set; }
        internal Tuple(T1 first, T2 second, T3 third)
        {
            Item1 = first;
            Item2 = second;
            Item3 = third;
        }
    }


    public class Tuple<T1, T2, T3, T4>
    {
        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        public T3 Item3 { get; private set; }
        public T4 Item4 { get; private set; }
        internal Tuple(T1 first, T2 second, T3 third, T4 fourth)
        {
            Item1 = first;
            Item2 = second;
            Item3 = third;
            Item4 = fourth;
        }
    }
}
