using ShapeGeneratorAPI.Interface;

namespace ShapeGeneratorAPI.Shapes
{
    public class Pentagon : Shape, IPentagon
    {
        /// <summary>
        /// Length of sides of pentagon shape
        /// </summary>
        public double SideLength { get; set; }
        /// <summary>
        /// Radius of pentagon shape
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Calculate the radius of pentagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculateRadius(double sideLength)
        {
            double radius = sideLength / (2 * Math.Sin(Math.PI / 5));
            return radius;
        }

        /// <summary>
        /// Calculate the area of pentagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculateArea(double sideLength) 
        { 
            double area = (5 * Math.Pow(sideLength, 2)) / (4 * Math.Tan(Math.PI / 5));

            return area;
        }

        /// <summary>
        /// Calculate the perimeter of pentagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculatePerimeter(double sideLength)
        {
            // 5 is number of sides
            double perimeter = 5 * sideLength;
            return perimeter;
        }
    }
}
