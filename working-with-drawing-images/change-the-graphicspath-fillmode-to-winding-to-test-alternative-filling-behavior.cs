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
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create GraphicsPath with Winding fill mode
                GraphicsPath path = new GraphicsPath(FillMode.Winding);

                // Create a figure and add a rectangle shape
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                path.AddFigure(figure);

                // Draw the path
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the modified image
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to generate a PNG thumbnail with a precise rectangular outline and wants to ensure overlapping shapes are filled using the Winding rule for accurate area calculation.
 * 2. When creating a C# image processing pipeline that clears the background, draws vector‑based graphics, and must test alternative filling behavior to compare visual results between EvenOdd and Winding fill modes.
 * 3. When implementing a custom report generator that overlays a black border on a white canvas and requires the Winding fill mode to correctly render complex nested rectangles in the final PNG output.
 * 4. When debugging a raster image manipulation routine that loads an existing PNG, applies a GraphicsPath with FillMode.Winding, and saves the modified image to verify that the fill algorithm handles self‑intersecting paths as expected.
 * 5. When building a Windows service that processes batches of PNG files, draws shapes using Aspose.Imaging’s Graphics and GraphicsPath classes, and needs the Winding fill mode to maintain consistent fill behavior across different image resolutions.
 */