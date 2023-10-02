namespace ShapeGeneratorAPI.Interface
{
    public interface IHexagon
    {
        double CalculateInternalAngles();
        double CalculatePerimeter(double sideLength);
        double CalculateArea(double sideLength);
    }
}
