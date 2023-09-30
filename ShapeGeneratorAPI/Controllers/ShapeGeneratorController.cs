using Microsoft.AspNetCore.Http;
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


        [HttpGet]
        public ActionResult<IsoscelesTriangleResult> GetIsoscelesTriangle(string sideLength, string baseLength)
        {
            var sLength = Double.Parse(sideLength);
            var bLength = Double.Parse(baseLength);
            var height = _isoscelesTriangle.CalculateHeight(sLength, bLength);

            IsoscelesTriangleResult isoscelesTriangleResult = new()
            {
                Name = "IsoscelesTriangle",
                isValidResponse = true,
                Height = height,
                BaseLength = sLength,
                SideLength = bLength,
            };

            return isoscelesTriangleResult;
        }

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
                isValidResponse = true,
                ASide = ASide,
                BSide = BSide,
                CSide = CSide,
                AAngle = aAngle,
                BAngle = bAngle,
                CAngle = cAngle
            };

            return scaleneTriangleResult;
        }

        [HttpGet]
        public ActionResult<EquilateralTriangleResult> GetEquilateralTriangle(string sideLength)
        {
            var sLength = Double.Parse(sideLength);

            var height = _equilateralTriangle.CalculateHeight(sLength);

            EquilateralTriangleResult equilateralTriangleResult = new()
            {
                Name = "EquilateralTriangle",
                isValidResponse = true,
                Height = height,
                SideLength = sLength
            };

            return equilateralTriangleResult;
        }

        [HttpGet]
        public ActionResult<ShapeResult> GetRectangle(string length, string width)
        {
            var dLength = Double.Parse(length);
            var dWidth = Double.Parse(width);

            var area = _rectangle.CalculateArea(dLength, dWidth);

            ShapeResult rectangleResult = new()
            {
                Name = "rectangle",
                isValidResponse = true,
                Width = dWidth,
                Length = dLength,
                Area = area
            };

            return rectangleResult;
        }

        [HttpGet]
        public ActionResult<SquareResult> GetSquare(string sideLength)
        {
            var sLength = Double.Parse(sideLength);

            var area = _square.CalculateArea(sLength, sLength);

            SquareResult squareResult = new()
            {
                Name = "square",
                isValidResponse = true,
                SideLength = sLength,
                Area = area
            };

            return squareResult;
        }

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
                isValidResponse = true,
                Height = dHeight,
                SideLength= dSideLength,
                Area= area,
                Angle = angle
            };

            return parallelogramResult;
        }

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
                isValidResponse = true,
                SideLength = dSideLength,
                Area= area, 
                Radius = radius,
                Perimeter= perimeter
            };

            return pentagonResult;
        }

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
                isValidResponse = true,
                SideLength = dSideLength,
                SumOfAllInternalAngles= sumOfAngles,
                Area= area,
                Perimeter= perimeter
            };

            return hexagonResult;
        }

        [HttpGet]
        public ActionResult<HeptagonResult> GetHeptagon(string sideLength)
        {
            var dSideLength = Double.Parse(sideLength);

            var area = _heptagon.CalculateArea(dSideLength);
            var perimeter = _heptagon.CalculatePerimeter(dSideLength);

            HeptagonResult hexagonResult = new()
            {
                Name = "Heptagon",
                isValidResponse = true,
                SideLength = dSideLength,
                Area= area,
                Perimeter= perimeter
            };

            return hexagonResult;
        }

        [HttpGet]
        public ActionResult<OctagonResult> GetOctagon(string sideLength)
        {
            var dSideLength = Double.Parse(sideLength);

            var area = _octagon.CalculateArea(dSideLength);
            var perimeter = _octagon.CalculatePerimeter(dSideLength);

            OctagonResult octagonResult = new()
            {
                Name = "Octagon",
                isValidResponse= true,
                SideLength = dSideLength,
                Area = area,
                Perimeter= perimeter
            };

            return octagonResult;
        }

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
                isValidResponse = true,
                Radius = radius,
                Area = area,
                Circumference = circumference
            };

            return circleResult;
        }

    }
}
