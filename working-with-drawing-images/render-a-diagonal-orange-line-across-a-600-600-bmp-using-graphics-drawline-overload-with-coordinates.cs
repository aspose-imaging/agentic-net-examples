// HOW-TO: Draw Diagonal Orange Line on 600x600 BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = "output\\diagonal.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 600×600 image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 600, 600))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Draw a diagonal orange line from (0,0) to (600,600)
                graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Orange, 2), 0, 0, 600, 600);

                // Save the image (output is already bound to the file source)
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
 * 1. When you need to generate a simple placeholder image with a visible diagonal marker for testing image pipelines in C#.
 * 2. When you want to programmatically add a colored guide line to a BMP file for visual debugging of coordinate systems.
 * 3. When creating custom graphics for a game UI where a diagonal orange line indicates direction or progress on a 600 × 600 bitmap.
 * 4. When automating the production of sample BMP assets that require a consistent diagonal stroke for documentation or tutorials.
 * 5. When integrating Aspose.Imaging into a .NET service that must draw basic shapes, such as an orange line, onto newly created bitmap images.
 */
