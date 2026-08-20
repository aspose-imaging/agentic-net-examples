// HOW-TO: Draw Off Center Oval on PNG Using Aspose.Imaging Graphics in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";   // not used in this example but shown for rule compliance
        string outputPath = @"C:\temp\offcenter_oval.png";

        try
        {
            // Input path validation (if needed)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                // Continue without loading the input image
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a stream source pointing to the output file
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image of size 500x500
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics object for drawing
                var graphics = new Graphics(image);

                // Clear background with a light color
                graphics.Clear(Color.Wheat);

                // Define a pen for the ellipse (red color, 3-pixel width)
                var pen = new Pen(Color.Red, 3);

                // Draw an off‑center oval using location and size parameters
                // x = 150, y = 100 positions the bounding rectangle away from the image center
                // width = 200, height = 100 defines the oval shape
                graphics.DrawEllipse(pen, 150f, 100f, 200f, 100f);

                // Save the image (the stream source already points to outputPath)
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
 * 1. When you need to generate a PNG badge with a decorative off‑center oval using Aspose.Imaging for a web dashboard.
 * 2. When creating custom report graphics with Aspose.Imaging that require precise placement of ellipses within a 500×500 canvas.
 * 3. When programmatically adding a highlighted oval watermark to product images with the Graphics.DrawEllipse method without loading an existing file.
 * 4. When building a UI mockup that shows an ellipse positioned away from the center to illustrate layout spacing using C# and Aspose.Imaging.
 * 5. When automating the production of game UI assets where ellipses must be drawn at specific coordinates in a PNG file.
 */
