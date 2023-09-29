using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShapeGeneratorAPI.Shapes;
using ShapeGeneratorAPI.Utilities;
using ShapeGeneratorAPI.ViewResult;

namespace ShapeGeneratorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public ActionResult<IsoscelesTriangleResult> GetIsoscelesTriangle(string sideLength, string baseLength)
        {
            var sLength = Double.Parse(sideLength);
            var bLength = Double.Parse(baseLength);
            var height = _isoscelesTriangle.calculateHeight(sLength, bLength);

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

            var aAngle = _scalenTriangle.calculateAAngle(ASide, BSide, CSide);
            var bAngle = _scalenTriangle.calculateBAngle(ASide, BSide, CSide);
            var cAngle = _scalenTriangle.calculateCAngle(aAngle, bAngle);

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
    }
}
