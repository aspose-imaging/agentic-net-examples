using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            Source src = new FileCreateSource(outputPath, false);
            bmpOptions.Source = src;

            // Create a BMP canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Apply a shear transform (skew)
                Matrix shear = new Matrix(1, 0.5f, 0, 1, 0, 0);
                graphics.MultiplyTransform(shear);

                // Draw an ellipse
                graphics.DrawEllipse(new Pen(Color.Black, 2), new RectangleF(50, 50, 300, 300));

                // Save the image (bound to the source)
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
 * 1. When a developer needs to generate a 24‑bit BMP file with a skewed ellipse for a custom report or printable diagram using C# and Aspose.Imaging.
 * 2. When an application must create a BMP canvas and apply a shear transformation to simulate perspective distortion of geometric shapes.
 * 3. When a game or UI tool requires programmatic drawing of an ellipse that is slanted to represent motion blur or artistic effect, saved as a BMP image.
 * 4. When a batch image‑processing script has to produce placeholder graphics with transformed ellipses for testing rendering pipelines.
 * 5. When a developer wants to demonstrate basic graphics operations—canvas creation, matrix transforms, and shape drawing—in a tutorial on Aspose.Imaging for .NET.
 */