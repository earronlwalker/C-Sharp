using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class InventoryCommand : Command
    {
        public InventoryCommand() : base()
        {
            this.Name = "inventory";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.OutputMessage("\nInvalid Command?");
            }
            else
            {
                player.Inventory();
            }
            return false;
        }
    }
}
