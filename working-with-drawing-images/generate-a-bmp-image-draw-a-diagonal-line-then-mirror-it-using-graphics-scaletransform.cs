// HOW-TO: Create BMP With Diagonal Line And Horizontal Mirror In C# (Aspose.Imaging for .NET)
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
            // Output BMP file path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Image dimensions
            int width = 200;
            int height = 200;

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Create graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Draw a diagonal line from top-left to bottom-right
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

                // Apply horizontal mirror transformation
                graphics.TranslateTransform(width, 0);
                graphics.ScaleTransform(-1, 1);

                // Draw the mirrored diagonal line
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When you need to programmatically generate a BMP icon that contains a diagonal line and its mirrored counterpart for UI elements.
 * 2. When creating test images to verify image processing pipelines that require both original and horizontally flipped graphics.
 * 3. When producing simple patterned textures for games or simulations where a mirrored diagonal line adds visual symmetry.
 * 4. When automating the creation of printable diagrams that must include a line and its mirror without manually editing the file.
 * 5. When building a batch tool that adds a mirrored watermark line to existing BMP files using Aspose.Imaging in C#.
 */
