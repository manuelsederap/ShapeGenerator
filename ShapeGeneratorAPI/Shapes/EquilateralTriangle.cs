namespace ShapeGeneratorAPI.Shapes
{
    public class EquilateralTriangle : Shape
    {
        /// <summary>
        /// Length of side of Equilateral Triangle
        /// </summary>
        public double SideLength { get; set; }

        /// <summary>
        /// Method to calculate the height of Equilateral Triangle
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculateHeight(double sideLength)
        {
            double height = (Math.Sqrt(3) / 2) * sideLength;
            return height;
        }
    }
}
