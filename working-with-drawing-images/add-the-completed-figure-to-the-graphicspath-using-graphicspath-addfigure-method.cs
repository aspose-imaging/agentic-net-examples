// HOW-TO: Add Rectangle and Ellipse Figure to PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Initialize graphics for the loaded image
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Create a graphics path and a figure
                Aspose.Imaging.GraphicsPath graphicPath = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                // Add shapes to the figure
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(50f, 50f, 150f, 150f)));

                // Add the completed figure to the graphics path
                graphicPath.AddFigure(figure);

                // Draw the path onto the image
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicPath);

                // Save the modified image
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to overlay a rectangle and an ellipse as a single figure onto an existing PNG image in a C# application.
 * 2. When you want to programmatically create a composite figure and draw it on a bitmap for custom graphics or UI elements.
 * 3. When you must clear an image background and then add vector shapes for generating reports or diagrams.
 * 4. When building a server‑side image processing service that annotates uploaded PNG files with combined shapes.
 * 5. When you need to save the modified image with lossless PNG options after drawing complex path figures.
 */
