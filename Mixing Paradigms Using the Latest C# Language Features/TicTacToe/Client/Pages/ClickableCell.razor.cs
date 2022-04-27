using System;
using Microsoft.AspNetCore.Components;

namespace TicTacToe.Client.Pages
{
    public partial class ClickableCell
    {
        [Parameter] public EventCallback OnClicked { get; set; }

        private void Clicked()
        {
            this.OnClicked.InvokeAsync(this);
        }
    }
}