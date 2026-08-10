// HOW-TO: Count Shapes In Each Figure Of A GraphicsPath Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create a graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Create a GraphicsPath and add some figures
                GraphicsPath path = new GraphicsPath();

                // First figure with two shapes
                Figure fig1 = new Figure();
                fig1.AddShape(new EllipseShape(new RectangleF(50, 50, 300, 300)));
                fig1.AddShape(new PieShape(new Rectangle(110, 110, 200, 200), 0, 90));
                path.AddFigure(fig1);

                // Second figure with three shapes
                Figure fig2 = new Figure();
                fig2.AddShape(new ArcShape(new RectangleF(10, 10, 300, 300), 0, 45));
                fig2.AddShape(new PolygonShape(
                    new[] {
                        new PointF(150, 10),
                        new PointF(150, 200),
                        new PointF(250, 300),
                        new PointF(350, 400)
                    }, true));
                fig2.AddShape(new RectangleShape(new RectangleF(new Point(250, 250), new Size(200, 200))));
                path.AddFigure(fig2);

                // Iterate over each figure and log the number of shapes it contains
                foreach (var figure in path.Figures)
                {
                    int shapeCount = figure.Shapes?.Length ?? 0;
                    Console.WriteLine($"Figure contains {shapeCount} shape(s).");
                }

                // Draw the path onto the image
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the modified image
                image.Save(outputPath);
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
 * 1. When generating a composite image you need to verify how many individual shapes each figure contributes before exporting to BMP.
 * 2. When debugging a drawing routine you want to log the shape count per figure to ensure all expected elements were added to the GraphicsPath.
 * 3. When performing image analytics you may need to enumerate figures and count their shapes to calculate complexity metrics for a bitmap.
 * 4. When creating a dynamic diagram editor you can use the shape counts to display a summary of each layer’s content to the user.
 * 5. When converting vector‑like drawings to raster formats you might need to validate that each figure contains the correct number of shapes to meet design specifications.
 */
