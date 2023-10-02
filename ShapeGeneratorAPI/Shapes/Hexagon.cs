using ShapeGeneratorAPI.Interface;

namespace ShapeGeneratorAPI.Shapes
{
    public class Hexagon : Shape, IHexagon
    {
        /// <summary>
        /// Lenght of sides of hexagon shape
        /// </summary>
        public double SideLength { get; set; }

        /// <summary>
        /// Total of all internal angles of hexagon
        /// </summary>
        public double SumOfAllInternalAngles {  get; set; }

        /// <summary>
        /// Calculate and Sum all internal angles of hexagon
        /// </summary>
        /// <returns></returns>
        public double CalculateInternalAngles()
        {
            /// hexagon has 6 sides
            int numberOfSides = 6;
            return (numberOfSides - 2) * 180;
        }

        /// <summary>
        /// Calculate perimeter of hexagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculatePerimeter(double sideLength)
        {
            /// hexagon has 6 sides
            int numberOfSides = 6;
            double perimeter = numberOfSides * sideLength;
            return perimeter;
        }

        /// <summary>
        /// calculate area of hexagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculateArea(double sideLength)
        {
            double area = (3 * Math.Sqrt(3) / 2) * Math.Pow(sideLength, 2);
            return area;
        }

    }
}
