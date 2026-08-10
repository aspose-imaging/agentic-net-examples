// HOW-TO: Create BMP Image with Thick Black Border Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            // Create the image canvas bound to the output file
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Draw a bold rectangle border around the canvas
                graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 10), 0, 0, width, height);

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
 * 1. When you need to generate a 24‑bit BMP file with a thick black border for printing or UI thumbnails.
 * 2. When you want to add a 10‑pixel rectangle outline to an image canvas to highlight its edges in a report using Aspose.Imaging.
 * 3. When you are programmatically creating placeholder graphics in C# that require a bold rectangular frame for layout testing.
 * 4. When you need to apply a consistent 10‑pixel black border around dynamically sized BMP images in a batch processing pipeline.
 * 5. When you are building a custom branding overlay that surrounds the entire image with a solid rectangle using the Aspose.Imaging Pen class.
 */
