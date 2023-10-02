using ShapeGeneratorAPI.Interface;

namespace ShapeGeneratorAPI.Shapes
{
    public class IsoscelesTriangle : Shape, IIsoscelesTriangle
    {
        /// <summary>
        /// Length of both of sides of IsoscelesTriangle
        /// </summary>
        public double Sides { get; set; }
        /// <summary>
        /// Length of the Base of IsoscelesTriangle
        /// </summary>
        public double Base {  get; set; }


        /// <summary>
        /// calculate the height of IsoscelesTriangle
        /// </summary>
        /// <param name="baseLength"></param>
        /// <param name="sidesLength"></param>
        /// <returns></returns>
        public double CalculateHeight(double sideLength, double baseLength)
        {
            // get the distance from the side to center
            // formula a2 + b2 = c2
            double height = Math.Sqrt(Math.Pow(sideLength, 2) 
                - Math.Pow(baseLength / 2, 2));

            return height;
        }

        /// <summary>
        ///  calculate the area of the Isosceles Triangle
        /// </summary>
        /// <param name="baseLength"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public new double CalculateArea(double baseLength, double height)
        {
            double Area = 0.5 * baseLength * height;

            return Area;
        }

        /// <summary>
        /// calculate the perimeter of the Isosceles Triangle
        /// </summary>
        /// <param name="sideLength"></param>
        /// <param name="baseLength"></param>
        /// <returns></returns>
        public double CalculatePerimeter(double sideLength, double baseLength)
        {
            double perimeter = 2 * sideLength + baseLength;

            return perimeter;
        }
    }
}
