// HOW-TO: Get GraphicsPath Bounds And Align Shapes Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
            {
                // Create a GraphicsPath with a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                RectangleF rect = new RectangleF(50, 50, 200, 100);
                RectangleShape rectShape = new RectangleShape(rect);
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                // Retrieve bounds of the path
                RectangleF bounds = path.GetBounds(new Matrix());

                // Determine canvas size with margin
                int margin = 20;
                int canvasWidth = (int)Math.Ceiling(bounds.Right) + margin;
                int canvasHeight = (int)Math.Ceiling(bounds.Bottom) + margin;

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Create output image
                PngOptions pngOptions = new PngOptions();
                using (RasterImage outputImage = (RasterImage)Image.Create(pngOptions, canvasWidth, canvasHeight))
                {
                    Graphics graphics = new Graphics(outputImage);
                    graphics.Clear(Color.White);

                    // Draw the original path
                    Pen bluePen = new Pen(Color.Blue);
                    graphics.DrawPath(bluePen, path);

                    // Align additional element: draw a circle at the center of the bounds
                    float centerX = bounds.X + bounds.Width / 2;
                    float centerY = bounds.Y + bounds.Height / 2;
                    float radius = Math.Min(bounds.Width, bounds.Height) / 4;
                    RectangleF circleRect = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
                    EllipseShape ellipse = new EllipseShape(circleRect);
                    Figure circleFigure = new Figure();
                    circleFigure.AddShape(ellipse);
                    GraphicsPath circlePath = new GraphicsPath();
                    circlePath.AddFigure(circleFigure);
                    Pen redPen = new Pen(Color.Red);
                    graphics.DrawPath(redPen, circlePath);

                    // Save the image
                    outputImage.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to calculate the exact size of a drawn rectangle so you can create a PNG canvas that fits the shape with a margin.
 * 2. When you want to position additional graphics, such as circles or text, relative to an existing GraphicsPath without manual coordinate calculations.
 * 3. When generating dynamic images where the dimensions depend on vector shapes defined by Aspose.Imaging’s GraphicsPath.
 * 4. When aligning overlay elements to the bounding box of a shape for consistent layout across different image resolutions.
 * 5. When automating image processing pipelines that require extracting shape bounds to place watermarks or annotations precisely.
 */
