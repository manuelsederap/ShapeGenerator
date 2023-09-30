namespace ShapeGeneratorAPI.Shapes
{
    public class Heptagon : Shape
    {
        /// <summary>
        /// Length of sides of heptagon shape
        /// </summary>
        public double SideLength { get; set; }

        /// <summary>
        /// Calculate the area of heptagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculateArea(double sideLength)
        {
            double area = (7 / 4.0) * Math.Pow(sideLength, 2) * (1 / Math.Tan(Math.PI / 7));

            return area;
        }

        /// <summary>
        /// Calculate the perimeter of heptagon
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculatePerimeter(double sideLength)
        {
            /// heptagon has 7 sides
            int numberOfSides = 7;
            double perimeter = numberOfSides * sideLength;
            return perimeter;
        }
    }
}
