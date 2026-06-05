using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\ellipse.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Define the bounding rectangle for the ellipse
                Rectangle ellipseRect = new Rectangle(50, 50, 300, 200);

                // Fill the ellipse with a solid blue brush
                SolidBrush fillBrush = new SolidBrush(Color.Blue);
                graphics.FillEllipse(fillBrush, ellipseRect);

                // Outline the ellipse with a contrasting yellow pen
                Pen outlinePen = new Pen(Color.Yellow, 3);
                graphics.DrawEllipse(outlinePen, ellipseRect);

                // Save the image to the specified path
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
 * 1. When a developer needs to generate a BMP file with a colored ellipse for a custom badge or logo in a Windows desktop application using Aspose.Imaging for .NET.
 * 2. When an automated reporting tool must create a simple placeholder image with a filled and outlined ellipse to indicate missing data in a BMP chart overlay.
 * 3. When a game developer wants to programmatically draw a solid blue ellipse with a yellow border as a sprite or UI element and save it as a 24‑bit BMP for fast loading.
 * 4. When a document generation system requires embedding a vector‑style ellipse into a BMP watermark that can be rendered with Aspose.Imaging’s Graphics, SolidBrush, and Pen classes.
 * 5. When a testing framework needs to produce a reproducible BMP image containing a filled ellipse to validate image processing pipelines or compare rendering results.
 */