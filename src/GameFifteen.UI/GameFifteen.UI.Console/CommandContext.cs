using GameFifteen.Logic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFifteen.Logic;
using GameFifteen.Logic.Games.Contracts;
using GameFifteen.Logic.Tiles.Contracts;

namespace GameFifteen.UI.Console
{
    public class CommandContext : ICommandContext
    {
        public CommandContext(IGame game, Logic.IPrinter printer)
        {
            this.Game = game;
            this.Printer = printer;
        }

        public IGame Game { get; set; }

        public Logic.IPrinter Printer { get; set; }

        public string SelectedTileLabel { get; set; }
    }
}
