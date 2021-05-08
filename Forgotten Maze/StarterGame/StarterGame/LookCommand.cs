using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class LookCommand : Command
    {
        public LookCommand() : base()
        {
            this.Name = "look";
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
                player.Look();
            }
            return false;
        }
    }
}
