using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeGeneratorAPI.Controllers;
using ShapeGeneratorAPI.Utilities;
using ShapeGeneratorAPI.Shapes;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace ShapeGeneratorAPI.Tests
{
    public class ShapeGeneratorController_Test
    {
        private readonly Mock<IsoscelesTriangle> _mockIsoscelesTriangle;
        private readonly Mock<ScaleneTriangle> _mockScaleneTriangle;
        private readonly ShapeGeneratorController _controller;

        public ShapeGeneratorController_Test()
        {
            _mockIsoscelesTriangle = new Mock<IsoscelesTriangle>();
            _mockScaleneTriangle = new Mock<ScaleneTriangle>();
            _controller = new ShapeGeneratorController(
                _mockIsoscelesTriangle.Object,
                _mockScaleneTriangle.Object
                );
        }
        /// <summary>
        /// Test the GetIsoscelesTriangle method
        /// </summary>
        [Fact]
        public async Task GetIsoscelesTriangle()
        {
            // Arrange
            double expectedHeight = 8;
            double expectedArea = 48;
            
            // Act
            var response = _controller.GetIsoscelesTriangle(10, 12).Value;

            // Assert
            Assert.Equal(expectedHeight, response?.Height);
            Assert.Equal(expectedArea, response?.Area);
        }

        /// <summary>
        /// Test the GetScaleneTriangle method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetScaleneTriangle()
        {
            // Arrange
            double expectedPerimeter = 81;
            double expectedArea = 238.87;

            // Act
            var response = _controller.GetScaleneTriangle(15, 32, 34).Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedPerimeter, response?.Perimeter);
        }
    }
}
