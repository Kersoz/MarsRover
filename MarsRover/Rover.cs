using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        Plateau Plateau;

        public Rover(string location, Plateau plateau)
        {
            Plateau = plateau;
            CheckLocation(location);
        }

        private void CheckLocation(string location)
        {
            int x, y;
            if (!location.Contains(" "))
                throw new Exception("Invalid rover location.");
            else
            {
                var locationAndDirection = location.Split(" ");
                if (locationAndDirection.Length != 3)
                    throw new Exception("Invalid rover location.");
                else
                {
                    if (int.TryParse(locationAndDirection[0], out x) && int.TryParse(locationAndDirection[1], out y))
                    {
                        if (x <= 0 || y <= 0)
                            throw new Exception("Invalid rover location.");
                        if (!Enum.TryParse(locationAndDirection[2], out Direction direction))
                        {
                            throw new Exception("Invalid rover location.");
                        }
                        SetLocation(x, y, direction);
                    }
                    else
                    {
                        throw new Exception("Invalid rover location.");
                    }
                }
            }
        }

        public (int, int) GetLocation()
        {
            return (X,Y);
        }

        public void SetLocation(int x, int y, Direction direction)
        {
            Y = y;
            X = x;
            Direction = direction;

            if (x < 0 || y < 0)
                throw new Exception("You haven't dropped your rover into the plateau.");
            if (x > this.Plateau.MaxWidth || y > this.Plateau.MaxHeight)
                throw new Exception("You haven't dropped your rover into the plateau.");
        }
        public void Execute(string commands)
        {
            try
            {
                ValidateCommand(commands);
                ExecuteCommands(commands);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
        private void ValidateCommand(string commands)
        {
            string validCommands = "LRM";

            foreach (char c in commands)
            {
                if (!validCommands.Contains(c.ToString()))
                    throw new Exception("You have entered a wrong command for your rover");
            }

        }
        private void ExecuteCommands(string commands)
        {
            var commandList = commands.ToCharArray();
            foreach (var command in commandList)
            {
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;

                    case 'R':
                        TurnRight();
                        break;

                    case 'M':
                        Move();
                        break;

                }

            }
        }
        private void TurnLeft()
        {
            Direction = (int)this.Direction - 1 == 0 ? Direction.W : this.Direction - 1;
        }
        private void TurnRight()
        {
            Direction = (int)this.Direction + 1 == 5 ? Direction.N : this.Direction + 1;
        }
        private void Move()
        {
            switch (Direction)
            {
                case Direction.N:
                    if (Y + 1 <= Plateau.MaxHeight)
                    {
                        Y++;
                    }
                    break;
                case Direction.E:
                    if (X + 1 <= Plateau.MaxWidth)
                    {
                        X++;
                    }
                    break;
                case Direction.W:
                    if (Plateau.MinWidth <= X - 1)
                    {
                        X--;
                    }
                    break;
                case Direction.S:
                    if (Plateau.MinHeight <= Y - 1)
                    {
                        Y--;
                    }
                    break;

            }
        }
    }
}
