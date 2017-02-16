using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerRunner
{
    class Program
    {

        static MazeRunner.Direction favoriteDirection(MazeRunner.Direction d)
        {
            if (d == MazeRunner.Direction.Down)
                return MazeRunner.Direction.Right;
            if (d == MazeRunner.Direction.Right)
                return MazeRunner.Direction.Up;
            if (d == MazeRunner.Direction.Left)
                return MazeRunner.Direction.Down;
            if (d == MazeRunner.Direction.Up)
                return MazeRunner.Direction.Left;

            return MazeRunner.Direction.Left;
        }

        static MazeRunner.Direction secondFavoriteDirection(MazeRunner.Direction favorite)
        {
            if (favorite == MazeRunner.Direction.Right)
                return MazeRunner.Direction.Right;
            if (favorite == MazeRunner.Direction.Left)
                return MazeRunner.Direction.Left;
            if (favorite == MazeRunner.Direction.Down)
                return MazeRunner.Direction.Down;
            if (favorite == MazeRunner.Direction.Up)
                return MazeRunner.Direction.Up;

            return MazeRunner.Direction.Left;
        }

        static MazeRunner.Direction thirdFavoriteDirection(MazeRunner.Direction favorite)
        {
            if (favorite == MazeRunner.Direction.Right)
                return MazeRunner.Direction.Down;
            if (favorite == MazeRunner.Direction.Left)
                return MazeRunner.Direction.Up;
            if (favorite == MazeRunner.Direction.Down)
                return MazeRunner.Direction.Left;
            if (favorite == MazeRunner.Direction.Up)
                return MazeRunner.Direction.Right;

            return MazeRunner.Direction.Left;
        }

        static MazeRunner.Direction leastFavoriteDirection(MazeRunner.Direction favorite)
        {
            if (favorite == MazeRunner.Direction.Right)
                return MazeRunner.Direction.Left;
            if (favorite == MazeRunner.Direction.Left)
                return MazeRunner.Direction.Right;
            if (favorite == MazeRunner.Direction.Down)
                return MazeRunner.Direction.Up;
            if (favorite == MazeRunner.Direction.Up)
                return MazeRunner.Direction.Down;

            return MazeRunner.Direction.Left;
        }

        static MazeRunner.CellType directionCellType(MazeRunner.Direction direction, MazeRunner.Cell[] cells)
        {
            if (direction == MazeRunner.Direction.Right)
                return cells[2].CellType;
            else if (direction == MazeRunner.Direction.Left)
                return cells[1].CellType;
            else if (direction == MazeRunner.Direction.Down)
                return cells[4].CellType;
            else if (direction == MazeRunner.Direction.Up)
                return cells[3].CellType;

            return 0;
        }





        static void Main(string[] args)
        {
            MazeRunner.PowerGameClient client = new MazeRunner.PowerGameClient();

            MazeRunner.Direction PlayerFace = MazeRunner.Direction.Right;

            Boolean finish = false;


            MazeRunner.UrlPlayerGame game1 = client.CreateGame(MazeRunner.Difficulty.Medium, "Hawksterr", MazeRunner.Power.EagleVision);

            int height = game1.Maze.Height;
            int width = game1.Maze.Width;

            String[][] mazeArray = new String[width][];

            for (int i = 0; i < width; i++)
            {
                mazeArray[i] = new String[height];
            }




            Console.WriteLine("game created : the key is...");
            Console.WriteLine(game1.Key);

            //MazeRunner.Player Player1 = client.AddPlayer(game1.Key, "Hawksterr");
            Console.WriteLine("Player " + game1.Player.Name + " joined the game !");





            MazeRunner.Position p1 = game1.Player.CurrentPosition;

            Console.WriteLine(game1.Player.Name + " is at position : " + p1.X + ":" + p1.Y);

            MazeRunner.Cell[] visibles = game1.Player.VisibleCells;

            foreach (MazeRunner.Cell c in visibles)
            {
                Console.WriteLine(c.CellType + " --> " + c.Position.X + ":" + c.Position.Y);
                mazeArray[c.Position.X][c.Position.Y] = c.CellType.ToString();

            }


            while (!finish)
            {

                System.Threading.Thread.Sleep(1000);


                //Player1 = client.MovePlayer(game1.Key, Player1.Key, MazeRunner.Direction.Right);

                if (directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunner.CellType.Empty || directionCellType(favoriteDirection(PlayerFace), visibles) == MazeRunner.CellType.End)
                {
                    Console.WriteLine("Player moved to the " + favoriteDirection(PlayerFace));
                    game1.Player = client.MovePlayer(game1.Key, game1.Player.Key, favoriteDirection(PlayerFace));
                    Console.WriteLine("player facing " + favoriteDirection(PlayerFace));
                    PlayerFace = favoriteDirection(PlayerFace);

                }

                else if (directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunner.CellType.Empty || directionCellType(secondFavoriteDirection(PlayerFace), visibles) == MazeRunner.CellType.End)
                {
                    Console.WriteLine("Player moved to the " + secondFavoriteDirection(PlayerFace));
                    game1.Player = client.MovePlayer(game1.Key, game1.Player.Key, secondFavoriteDirection(PlayerFace));
                    Console.WriteLine("player facing " + secondFavoriteDirection(PlayerFace));
                    PlayerFace = secondFavoriteDirection(PlayerFace);

                }

                else if (directionCellType(thirdFavoriteDirection(PlayerFace), visibles) == MazeRunner.CellType.Empty || directionCellType(thirdFavoriteDirection(PlayerFace), visibles) == MazeRunner.CellType.End)
                {
                    Console.WriteLine("Player moved to the " + thirdFavoriteDirection(PlayerFace));
                    game1.Player = client.MovePlayer(game1.Key, game1.Player.Key, thirdFavoriteDirection(PlayerFace));
                    Console.WriteLine("player facing " + thirdFavoriteDirection(PlayerFace));
                    PlayerFace = thirdFavoriteDirection(PlayerFace);


                }

                else if (directionCellType(leastFavoriteDirection(PlayerFace), visibles) == MazeRunner.CellType.Empty || directionCellType(leastFavoriteDirection(PlayerFace), visibles) == MazeRunner.CellType.End)
                {
                    Console.WriteLine("Player moved to the " + leastFavoriteDirection(PlayerFace));
                    game1.Player = client.MovePlayer(game1.Key, game1.Player.Key, leastFavoriteDirection(PlayerFace));
                    Console.WriteLine("player facing " + leastFavoriteDirection(PlayerFace));
                    PlayerFace = leastFavoriteDirection(PlayerFace);

                }




                p1 = game1.Player.CurrentPosition;

                Console.WriteLine(game1.Player.Name + " is at position : " + p1.X + ":" + p1.Y);


                visibles = game1.Player.VisibleCells;

                foreach (MazeRunner.Cell c in visibles)
                {
                    Console.WriteLine(c.CellType + " --> " + c.Position.X + ":" + c.Position.Y);
                    mazeArray[c.Position.X][c.Position.Y] = c.CellType.ToString();

                    if (visibles[0].CellType == MazeRunner.CellType.End)
                    {
                        finish = true;
                    }

                }

                Console.WriteLine(game1.Url);
            }

            Console.WriteLine("YOU WIN");
            Console.WriteLine("the secret message is....");
            Console.WriteLine(game1.Player.SecretMessage);

            Console.ReadLine();
            client.Close();


        }
    }
}
