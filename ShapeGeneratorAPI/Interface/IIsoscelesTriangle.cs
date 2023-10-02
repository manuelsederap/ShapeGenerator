namespace ShapeGeneratorAPI.Interface
{
    public interface IIsoscelesTriangle
    {
        double CalculateHeight(double sideLength, double baseLength);

        double CalculateArea(double baseLength, double height);

        double CalculatePerimeter(double sideLength, double baseLength);
    }
}
