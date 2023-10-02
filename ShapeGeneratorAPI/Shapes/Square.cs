using ShapeGeneratorAPI.Interface;

namespace ShapeGeneratorAPI.Shapes
{
    public class Square : Shape, ISquare
    {
        /// <summary>
        /// Length of Sides of Square shape
        /// </summary>
        public double SideLength { get; set; }
    }
}
