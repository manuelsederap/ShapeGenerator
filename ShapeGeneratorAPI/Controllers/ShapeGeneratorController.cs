﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShapeGeneratorAPI.Shapes;
using ShapeGeneratorAPI.ViewResult;

namespace ShapeGeneratorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShapeGeneratorController : ControllerBase
    {
        private readonly IsoscelesTriangle _isoscelesTriangle;
        private readonly ScaleneTriangle _scalenTriangle;
        private readonly EquilateralTriangle _equilateralTriangle;
        private readonly Rectangle _rectangle;
        private readonly Square _square;
        private readonly Parallelogram _parallelogram;
        private readonly Pentagon _pentagon;
        private readonly Hexagon _hexagon;
        private readonly Heptagon _heptagon;
        private readonly Octagon _octagon;
        private readonly Circle _circle;

        public ShapeGeneratorController(
            IsoscelesTriangle isoscelesTriangle,
            ScaleneTriangle scaleneTriangle,
            EquilateralTriangle equilateralTriangle,
            Rectangle rectangle,
            Square square,
            Parallelogram parallelogram,
            Pentagon pentagon,
            Hexagon hexagon,
            Heptagon heptagon,
            Octagon octagon,
            Circle circle)
        {
            _isoscelesTriangle = isoscelesTriangle;
            _scalenTriangle = scaleneTriangle;
            _equilateralTriangle = equilateralTriangle;
            _rectangle = rectangle;
            _square = square;
            _parallelogram = parallelogram;
            _pentagon = pentagon;
            _hexagon = hexagon;
            _heptagon = heptagon;
            _octagon = octagon;
            _circle = circle;
        }

        /// <summary>
        /// Retrieves the properties of an isosceles triangle based on provided side and base lengths.
        /// </summary>
        /// <param name="sideLength">The length of the equal sides of the triangle.</param>
        /// <param name="baseLength">The length of the base of the triangle.</param>
        /// <returns>An ActionResult containing the properties of the isosceles triangle.</returns>
        [HttpGet]
        public ActionResult<IsoscelesTriangleResult> GetIsoscelesTriangle(string sideLength, string baseLength)
        {
            var sLength = Double.Parse(sideLength);
            var bLength = Double.Parse(baseLength);
            var height = _isoscelesTriangle.CalculateHeight(sLength, bLength);

            IsoscelesTriangleResult isoscelesTriangleResult = new()
            {
                Name = "IsoscelesTriangle",
                IsValidResponse = true,
                Height = height,
                BaseLength = sLength,
                SideLength = bLength,
            };

            return isoscelesTriangleResult;
        }

        /// <summary>
        /// Retrieves the properties of a scalene triangle based on provided side lengths.
        /// </summary>
        /// <param name="aSide">The length of side A of the triangle.</param>
        /// <param name="bSide">The length of side B of the triangle.</param>
        /// <param name="cSide">The length of side C of the triangle.</param>
        /// <returns>An ActionResult containing the properties of the scalene triangle.</returns>
        [HttpGet]
        public ActionResult<ScaleneTriangleResult> GetScaleneTriangle(string aSide, string bSide, string cSide)
        {
            var ASide = Double.Parse(aSide);
            var BSide = Double.Parse(bSide);
            var CSide = Double.Parse(cSide);

            var aAngle = _scalenTriangle.CalculateAAngle(ASide, BSide, CSide);
            var bAngle = _scalenTriangle.CalculateBAngle(ASide, BSide, CSide);
            var cAngle = _scalenTriangle.CalculateCAngle(aAngle, bAngle);

            ScaleneTriangleResult scaleneTriangleResult = new()
            {
                Name = "ScaleneTriangle",
                IsValidResponse = true,
                ASide = ASide,
                BSide = BSide,
                CSide = CSide,
                AAngle = aAngle,
                BAngle = bAngle,
                CAngle = cAngle
            };

            return scaleneTriangleResult;
        }

        /// <summary>
        /// Retrieves the properties of an equilateral triangle based on the provided side length.
        /// </summary>
        /// <param name="sideLength">The length of the sides of the equilateral triangle.</param>
        /// <returns>An ActionResult containing the properties of the equilateral triangle.</returns>
        [HttpGet]
        public ActionResult<EquilateralTriangleResult> GetEquilateralTriangle(string sideLength)
        {
            var sLength = Double.Parse(sideLength);

            var height = _equilateralTriangle.CalculateHeight(sLength);

            EquilateralTriangleResult equilateralTriangleResult = new()
            {
                Name = "EquilateralTriangle",
                IsValidResponse = true,
                Height = height,
                SideLength = sLength
            };

            return equilateralTriangleResult;
        }

        /// <summary>
        /// Retrieves the properties of a rectangle based on the provided length and width.
        /// </summary>
        /// <param name="length">The length of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <returns>An ActionResult containing the properties of the rectangle.</returns>
        [HttpGet]
        public ActionResult<ShapeResult> GetRectangle(string length, string width)
        {
            var dLength = Double.Parse(length);
            var dWidth = Double.Parse(width);

            var area = _rectangle.CalculateArea(dLength, dWidth);

            ShapeResult rectangleResult = new()
            {
                Name = "rectangle",
                IsValidResponse = true,
                Width = dWidth,
                Length = dLength,
                Area = area
            };

            return rectangleResult;
        }

        /// <summary>
        /// Retrieves the properties of a square based on the provided side length.
        /// </summary>
        /// <param name="sideLength">The length of the sides of the square.</param>
        /// <returns>An ActionResult containing the properties of the square.</returns>
        [HttpGet]
        public ActionResult<SquareResult> GetSquare(string sideLength)
        {
            var sLength = Double.Parse(sideLength);

            var area = _square.CalculateArea(sLength, sLength);

            SquareResult squareResult = new()
            {
                Name = "square",
                IsValidResponse = true,
                SideLength = sLength,
                Area = area
            };

            return squareResult;
        }

        /// <summary>
        /// Retrieves the properties of a parallelogram based on the provided height and side length.
        /// </summary>
        /// <param name="height">The height of the parallelogram.</param>
        /// <param name="sideLength">The length of one side of the parallelogram.</param>
        /// <returns>An ActionResult containing the properties of the parallelogram.</returns>
        [HttpGet]
        public ActionResult<ParallelogramResult> GetParallelogram(string height, string sideLength)
        {
            var dHeight = Double.Parse(height);
            var dSideLength = Double.Parse(sideLength);

            var area = _square.CalculateArea(dHeight, dSideLength);
            var angle = _parallelogram.CalculateAngle(dHeight, dSideLength);

            ParallelogramResult parallelogramResult = new()
            {
                Name = "parallelogram",
                IsValidResponse = true,
                Height = dHeight,
                SideLength= dSideLength,
                Area= area,
                Angle = angle
            };

            return parallelogramResult;
        }

        /// <summary>
        /// Retrieves the properties of a pentagon based on the provided side length.
        /// </summary>
        /// <param name="sideLength">The length of the sides of the pentagon.</param>
        /// <returns>An ActionResult containing the properties of the pentagon.</returns>
        [HttpGet]
        public ActionResult<PentagonResult> GetPentagon(string sideLength)
        {
            var dSideLength = Double.Parse(sideLength);

            var radius = _pentagon.CalculateRadius(dSideLength);
            var area = _pentagon.CalculateArea(dSideLength);
            var perimeter = _pentagon.CalculatePerimeter(dSideLength);

            PentagonResult pentagonResult = new()
            {
                Name = "pentagon",
                IsValidResponse = true,
                SideLength = dSideLength,
                Area= area, 
                Radius = radius,
                Perimeter= perimeter
            };

            return pentagonResult;
        }

        /// <summary>
        /// Retrieves the properties of a hexagon based on the provided side length.
        /// </summary>
        /// <param name="sideLength">The length of the sides of the hexagon.</param>
        /// <returns>An ActionResult containing the properties of the hexagon.</returns>
        [HttpGet]
        public ActionResult<HexagonResult> GetHexagon(string sideLength)
        {
            var dSideLength = Double.Parse(sideLength);

            var sumOfAngles = _hexagon.CalculateInternalAngles();
            var area = _hexagon.CalculateArea(dSideLength);
            var perimeter = _hexagon.CalculatePerimeter(dSideLength);

            HexagonResult hexagonResult = new()
            {
                Name = "Hexagon",
                IsValidResponse = true,
                SideLength = dSideLength,
                SumOfAllInternalAngles= sumOfAngles,
                Area= area,
                Perimeter= perimeter
            };

            return hexagonResult;
        }

        /// <summary>
        /// Retrieves the properties of a heptagon based on the provided side length.
        /// </summary>
        /// <param name="sideLength">The length of the sides of the heptagon.</param>
        /// <returns>An ActionResult containing the properties of the heptagon.</returns>
        [HttpGet]
        public ActionResult<HeptagonResult> GetHeptagon(string sideLength)
        {
            var dSideLength = Double.Parse(sideLength);

            var area = _heptagon.CalculateArea(dSideLength);
            var perimeter = _heptagon.CalculatePerimeter(dSideLength);

            HeptagonResult hexagonResult = new()
            {
                Name = "Heptagon",
                IsValidResponse = true,
                SideLength = dSideLength,
                Area= area,
                Perimeter= perimeter
            };

            return hexagonResult;
        }

        /// <summary>
        /// Retrieves the properties of an octagon based on the provided side length.
        /// </summary>
        /// <param name="sideLength">The length of the sides of the octagon.</param>
        /// <returns>An ActionResult containing the properties of the octagon.</returns>
        [HttpGet]
        public ActionResult<OctagonResult> GetOctagon(string sideLength)
        {
            var dSideLength = Double.Parse(sideLength);

            var area = _octagon.CalculateArea(dSideLength);
            var perimeter = _octagon.CalculatePerimeter(dSideLength);

            OctagonResult octagonResult = new()
            {
                Name = "Octagon",
                IsValidResponse= true,
                SideLength = dSideLength,
                Area = area,
                Perimeter= perimeter
            };

            return octagonResult;
        }

        /// <summary>
        /// Retrieves the properties of a circle based on the provided diameter.
        /// </summary>
        /// <param name="diameter">The diameter of the circle.</param>
        /// <returns>An ActionResult containing the properties of the circle.</returns>
        [HttpGet]
        public ActionResult<CircleResult> GetCircle(string diameter) 
        { 
            var dDiameter = Double.Parse(diameter);

            var radius = _circle.CalculateRadius(dDiameter);
            var area = _circle.CalculateArea(radius);
            var circumference = _circle.CalculateCircumference(dDiameter);

            CircleResult circleResult = new()
            {
                Name = "Circle",
                IsValidResponse = true,
                Radius = radius,
                Area = area,
                Circumference = circumference
            };

            return circleResult;
        }

    }
}
