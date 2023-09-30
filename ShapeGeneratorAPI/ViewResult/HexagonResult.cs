namespace ShapeGeneratorAPI.ViewResult
{
    public class HexagonResult : ShapeResult
    {
        /// <summary>
        /// Result Length of Sides of Hexagon shape
        /// </summary>
        public double SideLength { get; set; }

        /// <summary>
        /// Result of Sum of all angles of hexagon shape
        /// </summary>
        public double SumOfAllInternalAngles { get; set; }
    }
}
