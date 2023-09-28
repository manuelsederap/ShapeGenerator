namespace ShapeGeneratorAPI.Shapes
{
    public class ScaleneTriangle : Shape
    {
        /// <summary>
        /// A Side of Scalene Triangle
        /// </summary>
        public double ASide { get; set; }

        /// <summary>
        /// B Side of Scalene Triangle
        /// </summary>
        public double BSide { get; set; }

        /// <summary>
        /// C Side of Scalene Triangle
        /// </summary>
        public double CSide { get; set; }

        public double calculateArea(double aSide, double bSide, double cSide)
        {
            // Calculate the semi-perimeter
            double semiPerimeter = (aSide + bSide + cSide) / 2;

            // Calculte the Area, using Heron's formula
            double Area = Math.Sqrt(semiPerimeter
                * (semiPerimeter - aSide)
                * (semiPerimeter - bSide)
                * (semiPerimeter - cSide));

            return Math.Round(Area, 2);
         }

        public double calculatePerimeter(double aSide, double bSide, double cSide)
        {
            double perimeter = aSide + bSide + cSide;

            return perimeter;
        }
    }
}
