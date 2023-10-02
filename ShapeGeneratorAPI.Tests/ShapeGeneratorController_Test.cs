using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeGeneratorAPI.Controllers;
using ShapeGeneratorAPI.Shapes;
using Moq;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using ShapeGeneratorAPI.Interface;

namespace ShapeGeneratorAPI.Tests
{
    public class ShapeGeneratorController_Test
    {
        private readonly ShapeGeneratorController _controller;
        private readonly Mock<IIsoscelesTriangle> _mockIIsoscelesTriangle;
        private readonly Mock<IScaleneTriangle> _mockIScaleneTriangle;
        private readonly Mock<IEquilateralTriangle> _mockIEquilateralTriangle;
        private readonly Mock<IRectangle> _mockIRectangle;
        private readonly Mock<ISquare> _mockISquare;
        private readonly Mock<IParallelogram> _mockIParallelogram;
        private readonly Mock<IPentagon> _mockIPentagon;
        private readonly Mock<IHexagon> _mockIHexagon;
        private readonly Mock<IHeptagon> _mockIHeptagon;
        private readonly Mock<IOctagon> _mockIOctagon;
        private readonly Mock<ICircle> _mockICircle;

        public ShapeGeneratorController_Test()
        {
            _mockIIsoscelesTriangle = new Mock<IIsoscelesTriangle>();
            _mockIScaleneTriangle = new Mock<IScaleneTriangle>();
            _mockIEquilateralTriangle = new Mock<IEquilateralTriangle>();
            _mockIRectangle = new Mock<IRectangle>();
            _mockISquare = new Mock<ISquare>();
            _mockIParallelogram = new Mock<IParallelogram>();
            _mockIPentagon = new Mock<IPentagon>();
            _mockIHexagon = new Mock<IHexagon>();
            _mockIHeptagon = new Mock<IHeptagon>();
            _mockIOctagon = new Mock<IOctagon>();
            _mockICircle = new Mock<ICircle>();

            _controller = new ShapeGeneratorController(
                _mockIIsoscelesTriangle.Object,
                _mockIScaleneTriangle.Object,
                _mockIEquilateralTriangle.Object,
                _mockIRectangle.Object,
                _mockISquare.Object,
                _mockIParallelogram.Object,
                _mockIPentagon.Object,
                _mockIHexagon.Object,
                _mockIHeptagon.Object,
                _mockIOctagon.Object,
                _mockICircle.Object
                );
        }
        /// <summary>
        /// Test the GetIsoscelesTriangle method
        /// </summary>
        [Fact]
        public void GetIsoscelesTriangle()
        {
            // Arrange
            double sideLength = 10.0;
            double baseLength = 12.0;
            double expectedHeight = Math.Sqrt(Math.Pow(sideLength, 2) - Math.Pow(baseLength / 2, 2));

            // Act
            _mockIIsoscelesTriangle.Setup(x => x.CalculateHeight(sideLength, baseLength)).Returns(expectedHeight);

            var response = _controller.GetIsoscelesTriangle("10", "12").Value;

            // Assert
            Assert.Equal(expectedHeight, response?.Height);
        }

        [Fact]
        public void GetIsoscelesTriangle_InvalidSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is not a valid double
            // Act
            var response = _controller.GetIsoscelesTriangle("invalid", "12");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetIsoscelesTriangle_InvalidBaseLength_ReturnsBadRequest()
        {
            // Arrange - Base length is not a valid double
            // Act
            var response = _controller.GetIsoscelesTriangle("10", "invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);

        }

        [Fact]
        public void GetIsoscelesTriangle_NegativeSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is negative
            // Act
            var response = _controller.GetIsoscelesTriangle("-10", "12");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetIsoscelesTriangle_exceed1000SideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is 1001
            // Act
            var response = _controller.GetIsoscelesTriangle("1001", "12");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetIsoscelesTriangle_exceed1000BaseLength_ReturnsBadRequest()
        {
            // Arrange - Base length is 1200
            // Act
            var response = _controller.GetIsoscelesTriangle("10", "1200");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);

        }

        /// <summary>
        /// Test the GetScaleneTriangle method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void GetScaleneTriangle()
        {
            // Arrange
            double aSide = 15.0;
            double bSide = 32.0;
            double cSide = 34.0;
            double expectedAAngle = Math.Acos((bSide * bSide + cSide * cSide - aSide * aSide) / (2 * bSide * cSide));
            double expectedBAngle = Math.Acos((cSide * cSide + aSide * aSide - bSide * bSide) / (2 * cSide * aSide));
            double expectedCAngle = Math.PI - expectedAAngle - expectedBAngle;

            // Act
            _mockIScaleneTriangle.Setup(x => x.CalculateAAngle(aSide, bSide, cSide)).Returns(expectedAAngle);
            _mockIScaleneTriangle.Setup(x => x.CalculateBAngle(aSide, bSide, cSide)).Returns(expectedBAngle);
            _mockIScaleneTriangle.Setup(x => x.CalculateCAngle(expectedAAngle, expectedBAngle)).Returns(expectedCAngle);

            var response = _controller.GetScaleneTriangle("15", "32", "34").Value;

            // Assert
            Assert.Equal(expectedAAngle, response?.AAngle);
            Assert.Equal(expectedBAngle, response?.BAngle);
            Assert.Equal(expectedCAngle, response?.CAngle);
        }

        [Fact]
        public void GetScaleneTriangle_InvalidASide_ReturnsBadRequest()
        {
            // Arrange - ASide is not a valid double
            // Act
            var response = _controller.GetScaleneTriangle("invalid", "4", "5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetScaleneTriangle_InvalidBSide_ReturnsBadRequest()
        {
            // Arrange - BSide is not a valid double
            // Act
            var response = _controller.GetScaleneTriangle("3", "invalid", "5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetScaleneTriangle_InvalidCSide_ReturnsBadRequest()
        {
            // Arrange - CSide is not a valid double
            // Act
            var response = _controller.GetScaleneTriangle("3", "4", "invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetScaleneTriangle_NegativeASide_ReturnsBadRequest()
        {
            // Arrange - ASide is negative
            // Act
            var response = _controller.GetScaleneTriangle("-3", "4", "5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetScaleneTriangle_NegativeBSide_ReturnsBadRequest()
        {
            // Arrange - BSide is negative
            // Act
            var response = _controller.GetScaleneTriangle("3", "-4", "5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetScaleneTriangle_NegativeCSide_ReturnsBadRequest()
        {
            // Arrange - CSide is negative
            // Act
            var response = _controller.GetScaleneTriangle("3", "4", "-5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetScaleneTriangle_Exceed1000ASide_ReturnsBadRequest()
        {
            // Arrange - ASide is 1500
            // Act
            var response = _controller.GetScaleneTriangle("1500", "4", "5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetScaleneTriangle_Exceed1000BSide_ReturnsBadRequest()
        {
            // Arrange - BSide is 4000
            // Act
            var response = _controller.GetScaleneTriangle("3", "4000", "5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetScaleneTriangle_Exceed1000CSide_ReturnsBadRequest()
        {
            // Arrange - CSide is 5000
            // Act
            var response = _controller.GetScaleneTriangle("3", "4", "5000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetEquilateralTriangle method
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void GetEquilateralTriangle()
        {
            /// Act
            double expectedHeight = (Math.Sqrt(3) / 2) * 200;

            /// Arrange
            _mockIEquilateralTriangle.Setup(x => x.CalculateHeight(200)).Returns(expectedHeight);
            var response = _controller.GetEquilateralTriangle("200").Value;

            /// Assert
            Assert.Equal(expectedHeight, response?.Height);
        }

        [Fact]
        public void GetEquilateralTriangle_InvalidSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is not a valid double
            // Act
            var response = _controller.GetEquilateralTriangle("invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetEquilateralTriangle_NegativeSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is negative
            // Act
            var response = _controller.GetEquilateralTriangle("-5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetEquilateralTriangle_Exceed1000SideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is 5000
            // Act
            var response = _controller.GetEquilateralTriangle("5000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetRectangle method
        /// </summary>
        [Fact]
        public void GetRectangle()
        {
            // Act Area = L x W;
            double expectedArea = 600 * 300;

            // Arrange
            _mockIRectangle.Setup(x => x.CalculateArea(600, 300)).Returns(expectedArea);
            var response = _controller.GetRectangle("600", "300").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
        }

        [Fact]
        public void GetRectangle_InvalidLength_ReturnsBadRequest()
        {
            // Arrange - Length is not a valid double
            // Act
            var response = _controller.GetRectangle("invalid", "7");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetRectangle_InvalidWidth_ReturnsBadRequest()
        {
            // Arrange - Width is not a valid double
            // Act
            var response = _controller.GetRectangle("5", "invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetRectangle_NegativeLength_ReturnsBadRequest()
        {
            // Arrange - Length is negative
            // Act
            var response = _controller.GetRectangle("-5", "7");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetRectangle_NegativeWidth_ReturnsBadRequest()
        {
            // Arrange - Width is negative
            // Act
            var response = _controller.GetRectangle("5", "-7");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetRectangle_Exceed1000Width_ReturnsBadRequest()
        {
            // Arrange - Width is 7000
            // Act
            var response = _controller.GetRectangle("5", "7000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetRectangle_Exceed1000Length_ReturnsBadRequest()
        {
            // Arrange - Length is 5000
            // Act
            var response = _controller.GetRectangle("5000", "7");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetSquare method
        /// </summary>
        [Fact]
        public void GetSquare()
        {
            // Act Area = L x W;
            double expectedArea = 200 * 200;

            // Arrange
            _mockISquare.Setup(x => x.CalculateArea(200, 200)).Returns(expectedArea);
            var response = _controller.GetSquare("200").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
        }

        [Fact]
        public void GetSquare_InvalidSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is not a valid double
            // Act
            var response = _controller.GetSquare("invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetSquare_NegativeSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is negative
            // Act
            var response = _controller.GetSquare("-5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetSquare_Exceed1000SideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is 5000
            // Act
            var response = _controller.GetSquare("5000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetParallelogram() method
        /// </summary>
        [Fact]
        public void GetParallelogram()
        {
            // Act
            double height = 300.0;
            double sideLength = 600.0;
            double radians = Math.Asin(height / sideLength);
            double expectedAngle = radians * 180 / Math.PI;
            double expectedArea = 180000;

            // Arrange
            _mockIParallelogram.Setup(x => x.CalculateAngle(height, sideLength)).Returns(expectedAngle);
            _mockIParallelogram.Setup(x => x.CalculateArea(height, sideLength)).Returns(expectedArea);
            var response = _controller.GetParallelogram("300", "600").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedAngle, response?.Angle);
        }

        [Fact]
        public void GetParallelogram_InvalidHeight_ReturnsBadRequest()
        {
            // Arrange - Height is not a valid double
            // Act
            var response = _controller.GetParallelogram("invalid", "7");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetParallelogram_InvalidSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is not a valid double
            // Act
            var response = _controller.GetParallelogram("5", "invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetParallelogram_NegativeHeight_ReturnsBadRequest()
        {
            // Arrange - Height is negative
            // Act
            var response = _controller.GetParallelogram("-5", "7");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetParallelogram_NegativeSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is negative
            // Act
            var response = _controller.GetParallelogram("5", "-7");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetParallelogram_Exceed1000Height_ReturnsBadRequest()
        {
            // Arrange - Height is 5000
            // Act
            var response = _controller.GetParallelogram("5000", "7");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetParallelogram_Exceed1000SideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is 7000
            // Act
            var response = _controller.GetParallelogram("5", "7000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetPentagon() method
        /// </summary>
        [Fact]
        public void GetPentagon()
        {
            //Act
            double sideLength = 300.0;
            double expectedRadius = sideLength / (2 * Math.Sin(Math.PI / 5));
            double expectedArea = (5 * Math.Pow(sideLength, 2)) / (4 * Math.Tan(Math.PI / 5));
            double expectedPerimeter = 5 * sideLength;

            //Arrange
            _mockIPentagon.Setup(x => x.CalculateRadius(sideLength)).Returns(expectedRadius);
            _mockIPentagon.Setup(x => x.CalculateArea(sideLength)).Returns(expectedArea);
            _mockIPentagon.Setup(x => x.CalculatePerimeter(sideLength)).Returns(expectedPerimeter);

            var response = _controller.GetPentagon("300").Value;

            //Assert
            Assert.Equal(expectedPerimeter, response?.Perimeter);
            Assert.Equal(expectedRadius, response?.Radius);
            Assert.Equal(expectedArea, response?.Area);
        }

        [Fact]
        public void GetPentagon_InvalidSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is not a valid double
            // Act
            var response = _controller.GetPentagon("invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetPentagon_NegativeSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is negative
            // Act
            var response = _controller.GetPentagon("-5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetPentagon_Exceed1000SideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is 5000
            // Act
            var response = _controller.GetPentagon("5000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetHexagon() Method
        /// </summary>
        [Fact]
        public void GetHexagon()
        {
            //Act
            double sideLength = 300.0;
            double expectedSumAngles = (6 - 2) * 180;
            double expectedPerimeter = 6 * sideLength;
            double expectedArea = (3 * Math.Sqrt(3) / 2) * Math.Pow(sideLength, 2);

            //Arrange
            _mockIHexagon.Setup(x => x.CalculateInternalAngles()).Returns(expectedSumAngles);
            _mockIHexagon.Setup(x => x.CalculatePerimeter(sideLength)).Returns(expectedPerimeter);
            _mockIHexagon.Setup(x => x.CalculateArea(sideLength)).Returns(expectedArea);

            var response = _controller.GetHexagon("300").Value;

            //Assert
            Assert.Equal(expectedSumAngles, response?.SumOfAllInternalAngles);
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedPerimeter, response?.Perimeter);
        }

        [Fact]
        public void GetHexagon_InvalidSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is not a valid double
            // Act
            var response = _controller.GetHexagon("invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetHexagon_NegativeSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is negative
            // Act
            var response = _controller.GetHexagon("-5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetHexagon_Exceed1000SideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is 5000
            // Act
            var response = _controller.GetHexagon("5000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetHeptagon() Method
        /// </summary>
        [Fact]
        public void GetHeptagon()
        {
            // Act
            double sideLength = 500.0;
            double expectedPerimeter = 7 * sideLength;
            double expectedArea = (7 / 4.0) * Math.Pow(sideLength, 2) * (1 / Math.Tan(Math.PI / 7));

            // Arrange
            _mockIHeptagon.Setup(x => x.CalculatePerimeter(sideLength)).Returns(expectedPerimeter);
            _mockIHeptagon.Setup(x => x.CalculateArea(sideLength)).Returns(expectedArea);

            var response = _controller.GetHeptagon("500").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedPerimeter, response?.Perimeter);
        }

        [Fact]
        public void GetHeptagon_InvalidSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is not a valid double
            // Act
            var response = _controller.GetHeptagon("invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetHeptagon_NegativeSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is negative
            // Act
            var response = _controller.GetHeptagon("-5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetHeptagon_Exceed1000SideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is 5000
            // Act
            var response = _controller.GetHeptagon("5000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetOctagon() Method
        /// </summary>
        [Fact]
        public void GetOctagon()
        {
            // Act
            double sideLength = 500.0;
            double expectedPerimeter = 8 * sideLength;
            double expectedArea = 2 * (1 + Math.Sqrt(2)) * Math.Pow(sideLength, 2);

            // Arrange
            _mockIOctagon.Setup(x => x.CalculatePerimeter(sideLength)).Returns(expectedPerimeter);
            _mockIOctagon.Setup(x => x.CalculateArea(sideLength)).Returns(expectedArea);

            var response = _controller.GetOctagon("500").Value;

            // Assert
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedPerimeter, response?.Perimeter);
        }

        [Fact]
        public void GetOctagon_InvalidSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is not a valid double
            // Act
            var response = _controller.GetOctagon("invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetOctagon_NegativeSideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is negative
            // Act
            var response = _controller.GetOctagon("-5");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetOctagon_Exceed1000SideLength_ReturnsBadRequest()
        {
            // Arrange - Side length is 5000
            // Act
            var response = _controller.GetOctagon("5000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        /// <summary>
        /// Test the GetCircle() Method
        /// </summary>
        [Fact]
        public void GetCircle()
        {
            // Act
            double expectedDiameter = 300.0;
            double expectedRadius = expectedDiameter / 2;
            double expectedArea = Math.PI * Math.Pow(expectedRadius, 2);
            double expectedCircumference = Math.PI * expectedDiameter;

            // Arrange
            _mockICircle.Setup(x => x.CalculateRadius(expectedDiameter)).Returns(expectedRadius);
            _mockICircle.Setup(x => x.CalculateArea(expectedRadius)).Returns(expectedArea);
            _mockICircle.Setup(x => x.CalculateCircumference(expectedDiameter)).Returns(expectedCircumference);
            var response = _controller.GetCircle("300").Value;

            // Assert
            Assert.Equal(expectedRadius, response?.Radius);
            Assert.Equal(expectedArea, response?.Area);
            Assert.Equal(expectedCircumference, response?.Circumference);
        }

        [Fact]
        public void GetCircle_InvalidDiameter_ReturnsBadRequest()
        {
            // Arrange - Diameter is not a valid double
            // Act
            var response = _controller.GetCircle("invalid");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetCircle_NegativeDiameter_ReturnsBadRequest()
        {
            // Arrange - Diameter is negative
            // Act
            var response = _controller.GetCircle("-10");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void GetCircle_Exceed1000Diameter_ReturnsBadRequest()
        {
            // Arrange - Diameter is 10000
            // Act
            var response = _controller.GetCircle("10000");

            // Assert
            Assert.IsType<BadRequestObjectResult>(response.Result);
        }
    }
}
