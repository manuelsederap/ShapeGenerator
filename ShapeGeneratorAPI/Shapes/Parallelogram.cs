using ShapeGeneratorAPI.Interface;

namespace ShapeGeneratorAPI.Shapes
{
    public class Parallelogram : Shape, IParallelogram
    {
        /// <summary>
        /// Angle each sides of Parallelogram shape
        /// </summary>
        public double Angle {  get; set; }

        /// <summary>
        /// Method to calculate angle of Parallelogram shape
        /// </summary>
        /// <param name="height"></param>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public double CalculateAngle(double height, double sideLength)
        {
            // if height is greater than sidelenght, error on getting the angle
            if (height < sideLength )
            {
                var radians = Math.Asin(height / sideLength);

                // Convert radians into degress
                var degree = radians * 180 / Math.PI;

                return degree;
            }

            return 0.0;
        }
    }
}
