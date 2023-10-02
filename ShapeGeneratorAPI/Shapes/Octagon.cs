using ShapeGeneratorAPI.Interface;

namespace ShapeGeneratorAPI.Shapes
{
    public class Octagon : Shape, IOctagon
    {
        /// <summary>
        /// Length of sides of octagon shape
        /// </summary>
        public double SideLength { get; set; }

        public double CalculateArea(double sideLength)
        {
            double area = 2 * (1 + Math.Sqrt(2)) * Math.Pow(sideLength, 2);
            
            return area;
        }

        public double CalculatePerimeter(double sideLength)
        {
            /// Octagon has 8 sides
            int numberOfSides = 8;
            double perimeter = numberOfSides * sideLength;
            return perimeter;
        }
    }
}
