using ShapeGeneratorAPI.Interface;

namespace ShapeGeneratorAPI.Shapes
{
    public class Shape : IShape
    {
        /// <summary>
        ///  Area of Shape
        /// </summary>
        public double Area { get; set; }
        /// <summary>
        /// Length of Shape
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Width of Shape
        /// </summary>
        public double Width {  get; set; }

        /// <summary>
        /// Height of Shape
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Perimeter of the Shape
        /// </summary>
        public double Perimeter { get; set; }

        /// <summary>
        /// Calculate the Area of the Shape
        /// </summary>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <returns></returns>
        public double CalculateArea(double Length, double Width)
        {
            double Area = Length * Width;

            return Area;
        }

    }
}
