using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    public record Cell(int Row, int Column)
    {
        public static IEnumerable<Cell> FullBoard() =>
            Enumerable.Range(0, Constants.BoardSize)
                .Select(index => new Cell(
                    index / Constants.BoardDimension, 
                    index % Constants.BoardDimension));

        public IEnumerable<Line> Lines
        {
            get
            {
                yield return Line.Row(this.Row);
                yield return Line.Column(this.Column);

                if (this.Row == this.Column)
                    yield return Line.Diagonal();

                if (this.Row + this.Column + 1 == Constants.BoardDimension)
                    yield return Line.Antidiagonal();
            }
        }

        public static implicit operator Cell((int row, int column) tuple) =>
            new(tuple.row, tuple.column);
    }
}