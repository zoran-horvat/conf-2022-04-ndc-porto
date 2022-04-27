using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    public record Line
    {
        private Line(Cell from, Cell to)
        {
            this.From = from;
            this.To = to;
        }

        public void Deconstruct(out Cell from, out Cell to)
        {
            from = this.From;
            to = this.To;
        }

        public Cell From { get; }
        public Cell To { get; }

        public static Line Row(int index) =>
            new((index, 0), (index, Constants.LastCellOffset));

        public static Line Column(int index) =>
            new((0, index), (Constants.LastCellOffset, index));

        public static Line Diagonal() =>
            new((0, 0), (Constants.LastCellOffset, Constants.LastCellOffset));

        public static Line Antidiagonal() =>
            new((0, Constants.LastCellOffset), (Constants.LastCellOffset, 0));

        public static IEnumerable<Line> FullLines(IEnumerable<Cell> formedBy) =>
            formedBy.SelectMany(cell => cell.Lines)
                .GroupBy(line => line)
                .Where(group => group.Count() == Constants.BoardDimension)
                .Select(group => group.Key);
    }
}