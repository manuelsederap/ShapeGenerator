namespace ShapeGeneratorAPI.ViewResult
{
    public class CircleResult : ShapeResult
    {
        /// <summary>
        /// the return diameter of a circle
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// the return radius of a circle
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// the return circumference of a circle
        /// </summary>
        public double Circumference { get; set; }
    }
}
