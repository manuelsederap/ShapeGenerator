namespace ShapeGeneratorAPI.Shapes
{
    public class ScaleneTriangle
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

        /// <summary>
        /// A side angle of Scalene Triangle
        /// </summary>
        public double AAngle {  get; set; }

        /// <summary>
        /// B side angle of Scalene Triangle
        /// </summary>
        public double BAngle { get; set; }

        /// <summary>
        /// C side Angle of Scalene Triangle
        /// </summary>
        public double CAngle {  get; set; }

        /// <summary>
        /// Method to Calculate the area of scalene triangle
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        /// <param name="cSide"></param>
        /// <returns></returns>
        public double CalculateArea(double aSide, double bSide, double cSide)
        {
            // Calculate the semi-perimeter
            double semiPerimeter = (aSide + bSide + cSide) / 2;

            // Calculte the Area, using Heron's formula
            double Area = Math.Sqrt(semiPerimeter
                * (semiPerimeter - aSide)
                * (semiPerimeter - bSide)
                * (semiPerimeter - cSide));

            return Area;
        }

        /// <summary>
        /// Method to calculate the perimeter of scalene triangle
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        /// <param name="cSide"></param>
        /// <returns></returns>
        public double CalculatePerimeter(double aSide, double bSide, double cSide)
        {
            double perimeter = aSide + bSide + cSide;

            return perimeter;
        }

        /// <summary>
        /// Method to calculate the A-Angle Side of Scalene Triangle
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        /// <param name="cSide"></param>
        /// <returns></returns>
        public double CalculateAAngle(double aSide, double bSide, double cSide)
        {
            double aAngle = Math.Acos((bSide * bSide + cSide * cSide - aSide * aSide) / (2 * bSide * cSide));
            return aAngle;
        }

        /// <summary>
        /// Method to calculate the B-Angle Side of Scalene Triangle
        /// </summary>
        /// <param name="aSide"></param>
        /// <param name="bSide"></param>
        /// <param name="cSide"></param>
        /// <returns></returns>
        public double CalculateBAngle(double aSide, double bSide, double cSide)
        {
            double bAngle = Math.Acos((cSide * cSide + aSide * aSide - bSide * bSide) / (2 * cSide * aSide));
            return bAngle;
        }

        /// <summary>
        /// Method to calculate the C-Angle side of scalene triangle
        /// </summary>
        /// <param name="aAngle"></param>
        /// <param name="bAngle"></param>
        /// <returns></returns>
        public double CalculateCAngle(double aAngle, double bAngle)
        {
            double cAngle = Math.PI - aAngle - bAngle;
            return cAngle;
        }
    }
}
