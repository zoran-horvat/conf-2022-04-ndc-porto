using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    public static class CustomLinqOperators
    {
        public static IEnumerable<T> WhereEvenOffset<T>(this IEnumerable<T> sequence) =>
            sequence.WithOffsetParity(0);

        public static IEnumerable<T> WhereOddOffset<T>(this IEnumerable<T> sequence) =>
            sequence.WithOffsetParity(1);

        private static IEnumerable<T> WithOffsetParity<T>(this IEnumerable<T> sequence, int parity)
        {
            using IEnumerator<T> enumerator = sequence.GetEnumerator();

            if (parity > 0) enumerator.MoveNext();

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
                enumerator.MoveNext();
            }
        }
    }
}