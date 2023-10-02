namespace ShapeGeneratorAPI.Interface
{
    public interface IScaleneTriangle
    {
        double CalculateArea(double aSide, double bSide, double cSide);
        double CalculatePerimeter(double aSide, double bSide, double cSide);
        double CalculateAAngle(double aSide, double bSide, double cSide);
        double CalculateBAngle(double aSide, double bSide, double cSide);
        double CalculateCAngle(double aAngle, double bAngle);
    }
}
