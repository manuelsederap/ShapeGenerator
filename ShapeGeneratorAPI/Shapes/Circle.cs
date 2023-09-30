namespace ShapeGeneratorAPI.Shapes
{
    public class Circle : Shape
    {
        /// <summary>
        /// Diameter of a circle
        /// </summary>
        public double Diameter {  get; set; }

        /// <summary>
        /// Radius of a circle
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Circumference of a circle
        /// </summary>
        public double Circumference { get; set; }

        /// <summary>
        /// Calculate the area of the circle
        /// </summary>
        /// <param name="diameter"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public double CalculateArea(double radius) 
        {
            double area = Math.PI * Math.Pow(radius, 2);

            return area;
        }

        /// <summary>
        /// Calculate the radius of the circle
        /// </summary>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public double CalculateRadius(double diameter) 
        {
            double radius = diameter / 2;

            return radius;
        }

        /// <summary>
        /// Calculate the circumference of the circle
        /// </summary>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public double CalculateCircumference(double diameter)
        {
            double circumference = Math.PI * diameter;

            return circumference;
        }

    }
}
