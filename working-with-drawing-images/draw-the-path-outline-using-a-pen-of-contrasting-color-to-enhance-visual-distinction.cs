using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 300f, 300f)));
                path.AddFigure(figure);

                // Draw the path outline with a contrasting pen
                graphics.DrawPath(new Pen(Color.Black, 3), path);

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a 500 × 500 PNG thumbnail that clearly outlines a rectangle‑and‑ellipse composite using a black Pen to improve visual distinction on a white canvas.
 * 2. When creating printable reports in C# where Aspose.Imaging draws a contrasting path outline on a PNG image to meet accessibility standards for shape borders.
 * 3. When building a watermarking utility that first draws a high‑contrast black outline around a vector logo (GraphicsPath) before compositing it onto other images.
 * 4. When implementing a CAD‑style preview in a .NET application that uses Aspose.Imaging’s GraphicsPath and Pen to render distinct outlines of overlapping shapes for better user guidance.
 * 5. When automating UI mockup generation where the outline of UI elements is drawn with a thick black Pen on a white PNG background to make component boundaries obvious.
 */