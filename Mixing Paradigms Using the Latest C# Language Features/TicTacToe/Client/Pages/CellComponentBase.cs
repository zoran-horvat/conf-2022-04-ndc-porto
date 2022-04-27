using Microsoft.AspNetCore.Components;

namespace TicTacToe.Client.Pages
{
    public abstract class CellComponentBase : ComponentBase
    {
        [Parameter] public int Row { get; set; }
        [Parameter] public int Column { get; set; }

        protected int X => 325 * Column;
        protected int Y => 325 * Row;
    }
}
