using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame 
{
    public class Game
    {
        Player player;
        Parser parser;
        bool playing;

        public Game()
        {
            playing = false;
            parser = new Parser(new CommandWords());
            player = new Player(CreateWorld());

        }

        public Room CreateWorld()
        {               
            Random random = new Random();

            Item item = new Item { name = "gold", description = "A pile of gold coins", pickupable = true, weight = random.Next(1, 10) };
            
            Item item1 = new Item { name = "gold", description = "A pile of gold coins", pickupable = true, weight = random.Next(1, 10) };
            Item item2 = new Item { name = "ruby", description = "A shiny ruby", pickupable = true, weight = random.Next(1, 10) };
            Item item3 = new Item { name = "ruby", description = "A shiny ruby", pickupable = true, weight = random.Next(1, 10) };
            Item item4 = new Item { name = "diamond", description = "A valuable diamond", pickupable = true, weight = random.Next(1, 10) };
            Item item5 = new Item { name = "diamond", description = "A valuable diamond", pickupable = true, weight = random.Next(1, 10) };
            Item item6 = new Item { name = "dungbeatle", description = "A pile of gold coins", pickupable = false, weight = random.Next(1, 10) };
            Item item7 = new Item { name = "dungbeatle", description = "A pile of gold coins", pickupable = false, weight = random.Next(1, 10) };
            Item item8 = new Item { name = "sword", description = "Sword of a fallen traveler", pickupable = true, weight = random.Next(1, 10) };
            Item item9 = new Item { name = "skeleton", description = "A skeleton of a past maze wanderer", pickupable = false, weight = random.Next(1, 10) };
            Item item10 = new Item { name = "sword", description = "Sword of a fallen traveler", pickupable = false, weight = random.Next(1, 10) };
            Item item11 = new Item { name = "skeleton", description = "A skeleton of a past maze wanderer", pickupable = false, weight = random.Next(1, 10) };
            Item item12 = new Item { name = "emerald", description = "An emerald", pickupable = true, weight = random.Next(1, 10) };
            Item item13 = new Item { name = "emerald", description = "An emerald", pickupable = true, weight = random.Next(1, 10) };
            Item item14 = new Item { name = "exitMarker", description = "Congratulations, you survived", pickupable = false, weight = random.Next(1, 10) };

            Room outside = new Room("outside the main entrance to the maze");
            outside.AddRoomLoot(item8);
            outside.AddRoomLoot(item5.Clone() as Item);
            Room MazeCorridor = new Room("One of the Maze Corridors");
            Room MazeCenter = new Room("In the center of the maze");
            MazeCenter.AddRoomLoot(item2);
            Room Necropolis = new Room("In the necropolis, home to the dead");
            Necropolis.AddRoomLoot(item9);
            Necropolis.AddRoomLoot(item10);
            Necropolis.AddRoomLoot(item2);
            outside.AddRoomLoot(item7.Clone() as Item);
            Necropolis.AddRoomLoot(item6);
            Room MazeExit = new Room("You have reached the end of the maze, enter quit in order end the game, or continue to explore and find more treasure");
            MazeExit.AddRoomLoot(item14);
            Room MazeWalkway = new Room("One of the many Maze Walkways");
            MazeWalkway.AddRoomLoot(item3);
            MazeWalkway.AddRoomLoot(item6.Clone() as Item);
            Room theGreen = new Room("Maze Garden");
            theGreen.AddRoomLoot(item7);
            outside.AddRoomLoot(item4.Clone() as Item);
            Room PetLounge = new Room("Where the beasts of old were kept");
            Room TreasureRoom = new Room("Treasure Room");
            TreasureRoom.AddRoomLoot(item);
            TreasureRoom.AddRoomLoot(item1);
            TreasureRoom.AddRoomLoot(item4);
            outside.AddRoomLoot(item4.Clone() as Item);
            TreasureRoom.AddRoomLoot(item5);
            TreasureRoom.AddRoomLoot(item12);
            TreasureRoom.AddRoomLoot(item13);

            outside.SetExit("west", MazeCenter);

            MazeCenter.SetExit("east", outside);
            MazeCenter.SetExit("south", MazeCorridor);
            MazeCenter.SetExit("west", theGreen);
            MazeCenter.SetExit("north", Necropolis);

            MazeCorridor.SetExit("west", MazeWalkway);
            MazeCorridor.SetExit("north", MazeCenter);

            MazeWalkway.SetExit("east", MazeCorridor);
            MazeWalkway.SetExit("north", TreasureRoom);

            TreasureRoom.SetExit("south", MazeWalkway);
            TreasureRoom.SetExit("north", PetLounge);
            TreasureRoom.SetExit("east", theGreen);

            theGreen.SetExit("west", TreasureRoom);
            theGreen.SetExit("east", MazeCenter);

            PetLounge.SetExit("south", TreasureRoom);
            PetLounge.SetExit("east", Necropolis);

            Necropolis.SetExit("south", MazeCenter);
            Necropolis.SetExit("west", PetLounge);
            Necropolis.SetExit("north", MazeExit);

            MazeExit.SetExit("south", Necropolis);
            
            
            
            
            return outside;                

        }

        /**
     *  Main play routine.  Loops until end of play.
     */
        public void Play()
        {

            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.

            bool finished = false;
            while (!finished)
            {
                Console.Write("\n>");
                Command command = parser.ParseCommand(Console.ReadLine());
                if (command == null)
                {
                    Console.WriteLine("I don't understand...");
                }
                else
                {
                    finished = command.Execute(player);
                }
            }
        }


        public void Start()
        {
            playing = true;
            player.OutputMessage(Welcome());
        }

        public void End()
        {
            playing = false;
            player.OutputMessage(Goodbye());
        }

        public string Welcome()
        {
            return "Welcome to the Forgotten Maze!\n\nThe Maze, was forgotten throughout the ages, and is filled with mysteries and treasure beyond your wildest dreams. \n\nType 'help' if you need help." + "\n\n" + "You awaken from your slumber to find yourself at the entrance to a maze with only one way to go, your goal is to escape with your life, and maybe fill your pockets on your way out" + "\n\n" + player.CurrentRoom.Description() + "\n\n";
        }

        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
