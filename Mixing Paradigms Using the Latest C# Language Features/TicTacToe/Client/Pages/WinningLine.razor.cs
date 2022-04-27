using Microsoft.AspNetCore.Components;
using System;

namespace TicTacToe.Client.Pages
{
    public partial class WinningLine
    {
        [Parameter] public int FromRow { get; set; }
        [Parameter] public int FromCol { get; set; }
        [Parameter] public int ToRow { get; set; }
        [Parameter] public int ToColumn { get; set; }

        public int FromX(int padding) => FromCol * 325 + 150 - (105 + padding) * XDirection;
        public int FromY(int padding) => FromRow * 325 + 150 - (105 + padding) * YDirection;
        public int ToX(int padding) => ToColumn * 325 + 150 + (105 + padding) * XDirection;
        public int ToY(int padding) => ToRow * 325 + 150 + (105 + padding) * YDirection;

        private int XDirection =>
            Math.Sign(ToColumn - FromCol);

        private int YDirection =>
            Math.Sign(ToRow - FromRow);
    }
}
