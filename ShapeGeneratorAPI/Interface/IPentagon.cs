namespace ShapeGeneratorAPI.Interface
{
    public interface IPentagon
    {
        double CalculateRadius(double sideLength);
        double CalculateArea(double sideLength);
        double CalculatePerimeter(double sideLength);
    }
}
