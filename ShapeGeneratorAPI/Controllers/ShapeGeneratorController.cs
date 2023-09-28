using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShapeGeneratorAPI.Shapes;
using ShapeGeneratorAPI.Utilities;
using ShapeGeneratorAPI.ViewResult;

namespace ShapeGeneratorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapeGeneratorController : ControllerBase
    {
        private readonly IsoscelesTriangle _isoscelesTriangle;
        private readonly ScaleneTriangle _scalenTriangle;

        public ShapeGeneratorController(
            IsoscelesTriangle isoscelesTriangle,
            ScaleneTriangle scaleneTriangle)
        {
            _isoscelesTriangle = isoscelesTriangle;
            _scalenTriangle = scaleneTriangle;
        }


        [HttpGet]
        public ActionResult<ShapeResult> GetIsoscelesTriangle(double sideLength, double baseLength)
        {
            _isoscelesTriangle.Height = _isoscelesTriangle.calculateHeight(sideLength, baseLength);
            _isoscelesTriangle.Area = _isoscelesTriangle.calculateArea(baseLength, _isoscelesTriangle.Height);
            _isoscelesTriangle.Perimeter = _isoscelesTriangle.calculatePerimeter(sideLength, baseLength);

            IsoscelesTriangleResult isoscelesTriangleResult = new()
            {
                Name = "IsoscelesTriangle",
                isValidResponse = true,
                message = "Ok",
                Area = _isoscelesTriangle.Area,
                Height = _isoscelesTriangle.Height,
                BaseLength = baseLength,
                SideLength = sideLength,
                Perimeter = _isoscelesTriangle.Perimeter
            };

            return isoscelesTriangleResult;
        }

        [HttpGet]
        public ActionResult<ShapeResult> GetScaleneTriangle(double aSide, double bSide, double cSide)
        {
            _scalenTriangle.Area = _scalenTriangle.calculateArea(aSide, bSide, cSide);
            _scalenTriangle.Perimeter = _scalenTriangle.calculatePerimeter(aSide, bSide, cSide);

            ScaleneTriangleResult scaleneTriangleResult = new()
            {
                Name = "ScaleneTriangle",
                isValidResponse = true,
                message = "Ok",
                Area = _scalenTriangle.Area,
                Perimeter = _scalenTriangle.Perimeter,
                ASide = aSide,
                BSide = bSide,
                CSide = cSide
            };

            return scaleneTriangleResult;
        }
    }
}
