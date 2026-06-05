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
            // Define output BMP file path (hardcoded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with white background
                graphics.Clear(Color.White);

                // Create a pen for the ellipse
                Pen pen = new Pen(Color.Blue, 3);

                // Draw an ellipse within the specified rectangle
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 300, 200));

                // Reset any transformations applied to the graphics object
                graphics.ResetTransform();

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
 * 1. When a developer needs to programmatically generate a 24‑bit BMP file with a blue ellipse for a printable report or dashboard using C# and Aspose.Imaging.
 * 2. When an application must create placeholder thumbnail images in BMP format for a document management system and requires resetting graphics transformations to ensure consistent positioning.
 * 3. When automated test data for image‑processing algorithms is needed, such as a simple BMP canvas with a known ellipse shape to validate shape detection routines.
 * 4. When a Windows desktop utility builds custom icons or UI assets on the fly, drawing vector shapes like ellipses onto a BMP before saving them to disk.
 * 5. When a batch job produces printable certificates or labels that include an elliptical seal, using Aspose.Imaging’s Graphics.ResetTransform to return to the default coordinate system before adding additional elements.
 */