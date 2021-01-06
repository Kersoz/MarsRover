using System;

namespace MarsRover
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the size of your Plateau exp:  5 5");

            //var plateauSize = Console.ReadLine();
            //var size = Validator.ParseCoordinate(plateauSize);

            Plateau plateau = new Plateau(5, 5);


            //Console.WriteLine("Please enter the lcoation of your Rover and Direction exp:  1 2 N");
            //var roverLocation = Console.ReadLine();
            var roverLocation = "3 3 E";

            Rover rover = new Rover(roverLocation, plateau);


            Console.WriteLine("Please enter the movement commands of your Rover");
            //var roverCommands = Console.ReadLine();
            var roverCommands = "MMRMMRMRRM";
            rover.Execute(roverCommands);

            Console.WriteLine(rover.X + " " + rover.Y + " " + rover.Direction);


        }
    }
}
