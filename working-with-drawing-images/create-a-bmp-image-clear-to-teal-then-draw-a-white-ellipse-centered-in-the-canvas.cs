using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 500x500 BMP image
            using (BmpImage bmp = new BmpImage(500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(bmp);

                // Clear the canvas to teal
                graphics.Clear(Color.Teal);

                // Calculate ellipse bounds to be centered
                int ellipseWidth = 300;
                int ellipseHeight = 300;
                int x = (bmp.Width - ellipseWidth) / 2;
                int y = (bmp.Height - ellipseHeight) / 2;

                // Draw a white ellipse
                Pen whitePen = new Pen(Color.White, 2);
                graphics.DrawEllipse(whitePen, x, y, ellipseWidth, ellipseHeight);

                // Save the image to the specified path
                bmp.Save(outputPath);
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
 * 1. When a developer needs to generate a BMP thumbnail with a teal background and a centered white ellipse for a custom UI icon.
 * 2. When an automated reporting tool must create a simple BMP chart element that highlights data points using a white ellipse on a teal canvas.
 * 3. When a game asset pipeline requires programmatically producing BMP textures with a teal base color and a white circular mask for sprite masking.
 * 4. When a document generation system has to embed a BMP placeholder image containing a centered white ellipse to indicate where user‑uploaded photos will appear.
 * 5. When a testing framework needs to create a deterministic BMP image with known colors and shapes (teal background and white ellipse) to validate image processing algorithms.
 */