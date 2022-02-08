using PizzaPlace.Shared;
using System;
using Xunit;

namespace PizzaPlace.TDD
{
    public class SquareNumberShould
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 4)]
        [InlineData(-1, 1)]
        public void ReturnSquareOfNumber(int number, int square)
        {
            //arrange
            var sut = new Utils();

            //act
            var actual = sut.Square(number);

            //assert
            Assert.Equal(expected: square, actual: actual);
        }

        [Fact]
        public void ThrowOverflowExceptionForBigNumbers()
        {
            var sut = new Utils();

            Assert.Throws<OverflowException>(() =>
            {
                int result = sut.Square(int.MaxValue);
            });
        }
    }
}