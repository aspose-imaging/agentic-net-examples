// HOW-TO: Draw Rectangle and Ellipse Outlines to TIFF with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Tiff.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output/output.tiff";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up TIFF options with a file source bound to the output path
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(tiffOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with a rectangle and an ellipse
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 150f, 150f)));
                path.AddFigure(figure);

                // Draw the outline of the path using a black pen of width 2
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the image (output file is already bound via FileCreateSource)
                image.Save();
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
 * 1. When you need to programmatically create a TIFF diagram that highlights geometric shapes with a thin black outline for technical documentation.
 * 2. When generating placeholder graphics for a PDF report and you want precise rectangle and ellipse outlines drawn using Aspose.Imaging in C#.
 * 3. When building a custom watermark or border overlay on scanned images and require drawing vector paths onto a blank TIFF canvas.
 * 4. When creating test images for computer‑vision algorithms that need clear, high‑contrast shape outlines in a lossless TIFF format.
 * 5. When automating the production of UI mock‑ups where simple shape outlines are rendered directly to a TIFF file without using external design tools.
 */
