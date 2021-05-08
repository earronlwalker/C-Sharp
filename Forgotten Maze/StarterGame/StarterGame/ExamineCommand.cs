using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class ExamineCommand : Command
    {
        public ExamineCommand() : base()
        {
            this.Name = "examine";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.Examine(this.SecondWord);
            }
            else
            {
                player.OutputMessage("\nExamine What?");
            }
            return false;
        }
    }
}
