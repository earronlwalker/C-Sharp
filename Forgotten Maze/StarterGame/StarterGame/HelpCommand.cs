using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class HelpCommand : Command
    {
        CommandWords words;

        public HelpCommand() : this(new CommandWords())
        {
        }

        public HelpCommand(CommandWords commands) : base()
        {
            words = commands;
            this.Name = "help";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.OutputMessage("\nI cannot help you with " + this.SecondWord);
            }
            else
            {
                player.OutputMessage("\nYou are lost. You are alone. You wander around through the maze searching for a way out, \n\nYour available commands are: ");
                player.OutputMessage("go X:                Attemps to go in the given direction.");
                player.OutputMessage("back:                Returns the player back to the previous location.");
                player.OutputMessage("look:                Shows you the room, its exits, and any items it contains.");
                player.OutputMessage("examine X:           Gives you information about a specific item in your \n                     inventory, where X is the items name.");
                player.OutputMessage("pickup X:            Attempts to pick up an item, where X is the items name.");
                player.OutputMessage("drop X:              Attempts to drop an item, where X is the items name.");
                player.OutputMessage("inventory:           Allows you to see the items in your inventory.");
                player.OutputMessage("quit:                Quits the game.");
            }
            return false;
        }
    }
}
