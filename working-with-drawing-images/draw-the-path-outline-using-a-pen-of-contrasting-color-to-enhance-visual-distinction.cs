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
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a FileCreateSource bound to the output file
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500) bound to the output file
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White); // Clear background

                // Build a graphics path with a rectangle and an ellipse
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 100f)));
                path.AddFigure(figure);

                // Draw the path outline using a contrasting black pen
                Pen outlinePen = new Pen(Color.Black, 3);
                graphics.DrawPath(outlinePen, path);

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
 * 1. When generating a PNG thumbnail that highlights selected UI components by drawing a black outline around combined rectangle and ellipse shapes using Aspose.Imaging in C#.
 * 2. When creating a printable report image where a contrasting pen is used to emphasize diagram boundaries on a white canvas for better visual distinction.
 * 3. When building a custom badge or logo generator that needs to overlay a bold black contour around vector shapes before saving the result as a PNG file.
 * 4. When developing an automated testing tool that captures screenshots of UI elements and draws a high‑contrast outline around the detected region to verify detection accuracy.
 * 5. When producing educational graphics that illustrate geometric concepts, using a Pen with a contrasting color to draw the outline of a composite path and export it as a PNG image.
 */