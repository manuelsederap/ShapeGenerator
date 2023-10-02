using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShapeGeneratorAPI.Interface;
using ShapeGeneratorAPI.Shapes;
using ShapeGeneratorAPI.ViewResult;

namespace ShapeGeneratorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShapeGeneratorController : ControllerBase
    {
        private readonly IIsoscelesTriangle _iIsoscelesTriangle;
        private readonly IScaleneTriangle _iScalenTriangle;
        private readonly IEquilateralTriangle _iEquilateralTriangle;
        private readonly IRectangle _iRectangle;
        private readonly ISquare _iSquare;
        private readonly IParallelogram _iParallelogram;
        private readonly IPentagon _iPentagon;
        private readonly IHexagon _iHexagon;
        private readonly IHeptagon _iHeptagon;
        private readonly IOctagon _iOctagon;
        private readonly ICircle _iCircle;

        public ShapeGeneratorController(
            IIsoscelesTriangle iIsoscelesTriangle,
            IScaleneTriangle iScaleneTriangle,
            IEquilateralTriangle iEquilateralTriangle,
            IRectangle iRectangle,
            ISquare iSquare,
            IParallelogram iParallelogram,
            IPentagon iPentagon,
            IHexagon iHexagon,
            IHeptagon IHeptagon,
            IOctagon IOctagon,
            ICircle iCirle)
        {
            _iIsoscelesTriangle = iIsoscelesTriangle;
            _iScalenTriangle = iScaleneTriangle;
            _iEquilateralTriangle = iEquilateralTriangle;
            _iRectangle = iRectangle;
            _iSquare = iSquare;
            _iParallelogram = iParallelogram;
            _iPentagon = iPentagon;
            _iHexagon = iHexagon;
            _iHeptagon = IHeptagon;
            _iOctagon = IOctagon;
            _iCircle = iCirle;
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
            if (!Double.TryParse(sideLength, out var sLength) || !Double.TryParse(baseLength, out var bLength))
            {
                return BadRequest("Invalid input. Both sideLength and baseLength must be valid numbers.");
            }

            if (sLength < 0 || bLength < 0)
            {
                return BadRequest("Invalid input. Side length and base length must be positive numbers.");
            }

            if (sLength > 1000 || bLength > 1000)
            {
                return BadRequest("Invalid input. Side length and base length must not exceed to 1000.");
            }

            var height = _iIsoscelesTriangle.CalculateHeight(sLength, bLength);

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
            if (
                !Double.TryParse(aSide, out var ASide) 
                || !Double.TryParse(bSide, out var BSide) 
                || !Double.TryParse(cSide, out var CSide)
                )
            {
                return BadRequest("Invalid input. aSide, bSide, and cSide must be valid numbers.");
            }

            if (ASide < 0 || BSide < 0 || CSide < 0)
            {
                return BadRequest("Invalid input. aSide, bSide, and cSide must be positive numbers.");
            }

            if (ASide > 1000 || BSide > 1000 || CSide > 1000)
            {
                return BadRequest("Invalid input. aSide, bSide, and cSide must not exceed to 1000.");
            }

            var aAngle = _iScalenTriangle.CalculateAAngle(ASide, BSide, CSide);
            var bAngle = _iScalenTriangle.CalculateBAngle(ASide, BSide, CSide);
            var cAngle = _iScalenTriangle.CalculateCAngle(aAngle, bAngle);

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
            if (!Double.TryParse(sideLength, out var sLength))
            {
                return BadRequest("Invalid input. sideLength must be valid numbers.");
            }

            if (sLength < 0)
            {
                return BadRequest("Invalid input. sideLength must be positive numbers.");
            }

            if (sLength > 1000)
            {
                return BadRequest("Invalid input. sideLength must not exceed to 1000.");
            }

            var height = _iEquilateralTriangle.CalculateHeight(sLength);

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

            if (!Double.TryParse(length, out var dLength) || !Double.TryParse(width, out var dWidth))
            {
                return BadRequest("Invalid input. Both length and width must be valid numbers.");
            }

            if (dLength < 0 || dWidth < 0)
            {
                return BadRequest("Invalid input. length and width must be positive numbers.");
            }

            if (dLength > 1000 || dWidth > 1000)
            {
                return BadRequest("Invalid input. length and width must not exceed to 1000.");
            }

            var area = _iRectangle.CalculateArea(dLength, dWidth);

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
            if (!Double.TryParse(sideLength, out var sLength))
            {
                return BadRequest("Invalid input. sideLength must be valid numbers.");
            }

            if (sLength < 0)
            {
                return BadRequest("Invalid input. sideLength must be positive numbers.");
            }

            if (sLength > 1000)
            {
                return BadRequest("Invalid input. sideLength must not exceed to 1000.");
            }

            var area = _iSquare.CalculateArea(sLength, sLength);

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
            if (!Double.TryParse(height, out var dHeight) || !Double.TryParse(sideLength, out var dSideLength))
            {
                return BadRequest("Invalid input. Both height and sideLength must be valid numbers.");
            }

            if (dHeight < 0 || dSideLength < 0)
            {
                return BadRequest("Invalid input. height and sideLength must be positive numbers.");
            }

            if (dHeight > 1000 || dSideLength > 1000)
            {
                return BadRequest("Invalid input. height and sideLength must not exceed to 1000.");
            }

            var area = _iParallelogram.CalculateArea(dHeight, dSideLength);
            var angle = _iParallelogram.CalculateAngle(dHeight, dSideLength);

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
            if (!Double.TryParse(sideLength, out var dSideLength))
            {
                return BadRequest("Invalid input. sideLength must be valid numbers.");
            }

            if (dSideLength < 0)
            {
                return BadRequest("Invalid input. sideLength must be positive numbers.");
            }

            if (dSideLength > 1000)
            {
                return BadRequest("Invalid input. sideLength must not exceed to 1000.");
            }

            var radius = _iPentagon.CalculateRadius(dSideLength);
            var area = _iPentagon.CalculateArea(dSideLength);
            var perimeter = _iPentagon.CalculatePerimeter(dSideLength);

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
            if (!Double.TryParse(sideLength, out var dSideLength))
            {
                return BadRequest("Invalid input. sideLength must be valid numbers.");
            }

            if (dSideLength < 0)
            {
                return BadRequest("Invalid input. sideLength must be positive numbers.");
            }

            if (dSideLength > 1000)
            {
                return BadRequest("Invalid input. sideLength must not exceed to 1000.");
            }

            var sumOfAngles = _iHexagon.CalculateInternalAngles();
            var area = _iHexagon.CalculateArea(dSideLength);
            var perimeter = _iHexagon.CalculatePerimeter(dSideLength);

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
            if (!Double.TryParse(sideLength, out var dSideLength))
            {
                return BadRequest("Invalid input. sideLength must be valid numbers.");
            }

            if (dSideLength < 0)
            {
                return BadRequest("Invalid input. sideLength must be positive numbers.");
            }

            if (dSideLength > 1000)
            {
                return BadRequest("Invalid input. sideLength must not exceed to 1000.");
            }

            var area = _iHeptagon.CalculateArea(dSideLength);
            var perimeter = _iHeptagon.CalculatePerimeter(dSideLength);

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
            if (!Double.TryParse(sideLength, out var dSideLength))
            {
                return BadRequest("Invalid input. sideLength must be valid numbers.");
            }

            if (dSideLength < 0)
            {
                return BadRequest("Invalid input. sideLength must be positive numbers.");
            }

            if (dSideLength > 1000)
            {
                return BadRequest("Invalid input. sideLength must not exceed to 1000.");
            }

            var area = _iOctagon.CalculateArea(dSideLength);
            var perimeter = _iOctagon.CalculatePerimeter(dSideLength);

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
            if (!Double.TryParse(diameter, out var dDiameter))
            {
                return BadRequest("Invalid input. diameter must be valid numbers.");
            }

            if (dDiameter < 0)
            {
                return BadRequest("Invalid input. diameter must be positive numbers.");
            }

            if (dDiameter > 1000)
            {
                return BadRequest("Invalid input. diameter must not exceed to 1000.");
            }

            var radius = _iCircle.CalculateRadius(dDiameter);
            var area = _iCircle.CalculateArea(radius);
            var circumference = _iCircle.CalculateCircumference(dDiameter);

            CircleResult circleResult = new()
            {
                Name = "Circle",
                IsValidResponse = true,
                Diameter = dDiameter,
                Radius = radius,
                Area = area,
                Circumference = circumference
            };

            return circleResult;
        }

    }
}
