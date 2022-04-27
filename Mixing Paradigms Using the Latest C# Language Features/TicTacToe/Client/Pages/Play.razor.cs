using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using TicTacToe.Shared;

namespace TicTacToe.Client.Pages
{
    public partial class Play
    {
        private Board Board { get; set; } = Board.Initialize();

        private void Restart()
        {
            this.Board = this.Board.Restart();
        }

        private void MakeMove(int row, int col)
        {
            this.Board = this.Board.Play(row, col);
        }
    }
}
