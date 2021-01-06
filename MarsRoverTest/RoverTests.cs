using MarsRover;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace MarsRoverTest
{
    public class RoverTests
    {
        private Plateau _plateau;
        private Rover _rover;
        public RoverTests()
        {
            _plateau = new Plateau(5, 5);


        }
        [Fact]
        public void SetInvalidCoordinateShouldBeThrowEx()
        {
            Assert.Throws<Exception>(() => _rover = new Rover("6 6 E", _plateau));
        }
        [Fact]
        public void SetSize_ValidCoordinate_ShouldBeSuccess()
        {
            _rover = new Rover("1 2 E", _plateau);

            _rover.X.Should().Be(1);
            _rover.Y.Should().Be(2);
        }
        [Fact]
        public void RoverMoveValidInstruction()
        {
            _rover = new Rover("1 2 N", _plateau);

            string commands = "LMLMLMLMM";
            _rover.Execute(commands);

            var result = _rover.X + " " + _rover.Y + " " + _rover.Direction;
            result.Should().Be("1 3 N");

        }
    }
}
