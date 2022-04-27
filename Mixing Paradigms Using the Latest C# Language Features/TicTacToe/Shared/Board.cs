using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace TicTacToe.Shared
{
    public class Board
    {
        public static Board Initialize() =>
            new Board(ImmutableList<Cell>.Empty);

        private Board(ImmutableList<Cell> moves)
        {
            this.Moves = moves;
        }

        public IEnumerable<Cell> HomeMoves =>
            this.Moves.WhereEvenOffset();

        public IEnumerable<Cell> AwayMoves =>
            this.Moves.WhereOddOffset();

        public IEnumerable<Line> WinningLines =>
            Line.FullLines(this.HomeMoves)
                .Concat(Line.FullLines(this.AwayMoves));

        public IEnumerable<Cell> PlayableCells =>
            this.WinningLines.Any() ? Enumerable.Empty<Cell>()
            : Cell.FullBoard().Except(this.Moves);

        private ImmutableList<Cell> Moves { get; }

        public Board Restart() =>
            new Board(ImmutableList<Cell>.Empty);

        public Board Play(int row, int col) => 
            this.Play(new Cell(row, col));
            
        private Board Play(Cell at) =>
            this.PlayableCells
                .Where(at.Equals)
                .Select(empty => new Board(this.Moves.Add(empty)))
                .DefaultIfEmpty(this)
                .First();
    }
}
