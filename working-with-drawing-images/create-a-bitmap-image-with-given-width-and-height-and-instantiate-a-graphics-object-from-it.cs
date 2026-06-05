using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Define image dimensions
            int width = 200;
            int height = 100;

            // Create a new BMP image with the specified size
            using (BmpImage bmpImage = new BmpImage(width, height))
            {
                // Instantiate a Graphics object for drawing on the image
                Graphics graphics = new Graphics(bmpImage);

                // Example drawing: fill the entire image with white color
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, bmpImage.Bounds);

                // Hardcoded output path
                string outputPath = @"c:\temp\output.bmp";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image to the specified path
                bmpImage.Save(outputPath);
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
 * 1. When a developer needs to generate a blank BMP canvas of a specific width and height in C# to serve as a base layer for drawing graphics with Aspose.Imaging’s Graphics object.
 * 2. When an automated reporting tool must create a bitmap image of exact dimensions, fill it with a solid color, and save it as a BMP file for inclusion in PDF or HTML reports.
 * 3. When a game or simulation engine requires a temporary texture bitmap, initialized with a white background, to be saved to disk for debugging or asset pipeline purposes.
 * 4. When a server‑side .NET service has to produce a placeholder image of known size for missing user uploads, using Aspose.Imaging to create and store the BMP file.
 * 5. When a batch image‑processing script needs to programmatically create a white‑filled BMP image of predetermined dimensions before applying further raster operations.
 */