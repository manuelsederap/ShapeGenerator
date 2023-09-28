namespace ShapeGeneratorAPI.ViewResult
{
    public class ShapeResult
    {
        /// <summary>
        ///  Name of Shape
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// status of response if valid or not
        /// </summary>
        public bool isValidResponse { get; set; }

        /// <summary>
        /// response message
        /// </summary>
        public string? message { get; set; }

        /// <summary>
        /// return Area of a Shape
        /// </summary>
        public double Area { get; set; } = 0;

        /// <summary>
        /// return Height of a Shape
        /// </summary>
        public double Height { get; set; } = 0;

        /// <summary>
        /// return Width of a Shape
        /// </summary>
        public double Width { get; set; } = 0;

        /// <summary>
        /// return Length of a Shape
        /// </summary>
        public double Length { get; set; } = 0;

        /// <summary>
        /// return perimeter of a Shape
        /// </summary>
        public double Perimeter { get; set; } = 0;
    }
}
