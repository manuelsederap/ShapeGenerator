﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeGeneratorAPI.Controllers;
using ShapeGeneratorAPI.Shapes;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace ShapeGeneratorAPI.Tests
{
    public class ShapeGeneratorController_Test
    {
        private readonly ShapeGeneratorController _controller;
        private readonly Mock<IsoscelesTriangle> _mockIsoscelesTriangle;
        private readonly Mock<ScaleneTriangle> _mockScaleneTriangle;
        private readonly Mock<EquilateralTriangle> _mockEquilateralTriangle;
        private readonly Mock<Rectangle> _mockRectangle;
        private readonly Mock<Square> _mockSquare;
        private readonly Mock<Parallelogram> _mockParallelogram;
        private readonly Mock<Pentagon> _mockPentagon;
        private readonly Mock<Hexagon> _mockHexagon;
        private readonly Mock<Heptagon> _mockHeptagon;
        private readonly Mock<Octagon> _mockOctagon;
        private readonly Mock<Circle> _mockCircle;

        public ShapeGeneratorController_Test()
        {
            _mockIsoscelesTriangle = new Mock<IsoscelesTriangle>();
            _mockScaleneTriangle = new Mock<ScaleneTriangle>();
            _mockEquilateralTriangle = new Mock<EquilateralTriangle>();
            _mockRectangle = new Mock<Rectangle>();
            _mockSquare = new Mock<Square>();
            _mockParallelogram = new Mock<Parallelogram>();
            _mockPentagon = new Mock<Pentagon>();
            _mockHexagon = new Mock<Hexagon>();
            _mockHeptagon = new Mock<Heptagon>();
            _mockOctagon = new Mock<Octagon>();
            _mockCircle = new Mock<Circle>();

            _controller = new ShapeGeneratorController(
                _mockIsoscelesTriangle.Object,
                _mockScaleneTriangle.Object,
                _mockEquilateralTriangle.Object,
                _mockRectangle.Object,
                _mockSquare.Object,
                _mockParallelogram.Object,
                _mockPentagon.Object,
                _mockHexagon.Object,
                _mockHeptagon.Object,
                _mockOctagon.Object,
                _mockCircle.Object
                );
        }
        /// <summary>
        /// Test the GetIsoscelesTriangle method
        /// </summary>
        [Fact]
        public void GetIsoscelesTriangle()
        {
            // Arrange
            double expectedHeight = 8;
            
            // Act
            var response = _controller.GetIsoscelesTriangle("10", "12").Value;

            // Assert
            Assert.Equal(expectedHeight, response?.Height);
        }

        /// <summary>
        /// Test the GetScaleneTriangle method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void GetScaleneTriangle()
        {
            // Arrange
            double expectedAAngle = 0.45;
            double expectedBAngle = 1.21;
            double expectedCAngle = 1.47;

            // Act
            var response = _controller.GetScaleneTriangle("15", "32", "34").Value;

            // Assert
            Assert.Equal(expectedAAngle, Math.Round((double)(response?.AAngle), 2));
            Assert.Equal(expectedBAngle, Math.Round((double)(response?.BAngle), 2));
            Assert.Equal(expectedCAngle, Math.Round((double)(response?.CAngle), 2));
        }

        /// <summary>
        /// Test the GetEquilateralTriangle method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void GetEquilateralTriangle()
        {
            /// Act
            double expectedHeight = 173.21;

            /// Arrange
            var response = _controller.GetEquilateralTriangle("200").Value;

            /// Assert
            Assert.Equal(expectedHeight, Math.Round((double)(response?.Height), 2));
        }

        /// <summary>
        /// Test the GetRectangle method
        /// </summary>
        [Fact]
        public void GetRectangle()
        {
            // Act Area = L x W;
            double expectedArea = 180000;

            // Arrange
            var response = _controller.GetRectangle("600", "300").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
        }

        /// <summary>
        /// Test the GetSquare method
        /// </summary>
        [Fact]
        public void GetSquare()
        {
            // Act Area = L x W;
            double expectedArea = 40000;

            // Arrange
            var response = _controller.GetSquare("200").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
        }

        /// <summary>
        /// Test the GetParallelogram() method
        /// </summary>
        [Fact]
        public void GetParallelogram()
        {
            // Act
            double expectedAngle = 30.00;
            double expectedArea = 180000;

            // Arrange
            var response = _controller.GetParallelogram("300", "600").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedAngle, Math.Round((double)(response?.Angle), 2));
        }

        /// <summary>
        /// Test the GetPentagon() method
        /// </summary>
        [Fact]
        public void GetPentagon()
        {
            //Act
            double expectedRadius = 255.19999999999999;
            double expectedArea = 154842.97;
            double expectedPerimeter = 1500;

            //Arrange
            var response = _controller.GetPentagon("300").Value;

            //Assert
            Assert.Equal(expectedPerimeter, response?.Perimeter);
            Assert.Equal(expectedRadius, Math.Round((double)(response?.Radius), 2));
            Assert.Equal(expectedArea, Math.Round((double)(response?.Area), 2));
        }

        /// <summary>
        /// Test the GetHexagon() Method
        /// </summary>
        [Fact]
        public void GetHexagon()
        {
            //Act
            double expectedSumAngles = 720;
            double expectedPerimeter = 1800;
            double expectedArea = 233826.85999999999;

            //Arrange
            var response = _controller.GetHexagon("300").Value;

            //Assert
            Assert.Equal(expectedSumAngles, response?.SumOfAllInternalAngles);
            Assert.Equal(expectedArea, Math.Round((double)(response?.Area), 2));
            Assert.Equal(expectedPerimeter, response?.Perimeter);
        }

        /// <summary>
        /// Test the GetHeptagon() Method
        /// </summary>
        [Fact]
        public void GetHeptagon()
        {
            // Act
            double expectedPerimeter = 3500;
            double expectedArea = 908478.11100039736;

            // Arrange
            var response = _controller.GetHeptagon("500").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedPerimeter, response?.Perimeter);
        }

        /// <summary>
        /// Test the GetOctagon() Method
        /// </summary>
        [Fact]
        public void GetOctagon()
        {
            // Act
            double expectedPerimeter = 4000;
            double expectedArea = 1207106.7811865474;

            // Arrange
            var response = _controller.GetOctagon("500").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedPerimeter, response?.Perimeter);
        }

        /// <summary>
        /// Test the GetCircle() Method
        /// </summary>
        [Fact]
        public void GetCircle()
        {
            // Act
            double expectedRadius = 150;
            double expectedArea = 70685.83470577035;
            double expectedCircumference = 942.47779607693792;

            // Arrange
            var response = _controller.GetCircle("300").Value;

            // Assert
            Assert.Equal(expectedRadius, response?.Radius);
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedCircumference, response?.Circumference);
        }
    }
}
