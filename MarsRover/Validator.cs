using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    class Validator
    {
        private static void PlateauSizeInputValid(string coordinate, out int x, out int y)
        {
            if (!coordinate.Contains(" "))
                throw new Exception("Invalid plateau location.");
            else
            {
                var coordinates = coordinate.Split(" ");
                if (coordinates.Length != 2)
                    throw new Exception("Invalid plateau location.");
                else
                {
                    if (int.TryParse(coordinates[0], out x) && int.TryParse(coordinates[1], out y))
                    {
                        if (x <= 0 || y <= 0)
                            throw new Exception("Invalid plateau location.");
                    }

                    else
                    {
                        throw new Exception("Invalid plateau location.");
                    }
                }
            }
        }
        public static (int, int) ParseCoordinate(string coordinate)
        {
            int x, y;
            try
            {
                PlateauSizeInputValid(coordinate, out x, out y);
                return (x, y);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }
       
    }
}
