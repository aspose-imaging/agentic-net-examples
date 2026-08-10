// HOW-TO: Scale BMP Shapes with High Quality Bicubic Interpolation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP image bound to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (BmpImage image = (BmpImage)Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Set high-quality bicubic interpolation before scaling
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Apply scaling transform (e.g., 2x)
                graphics.ScaleTransform(2.0f, 2.0f);

                // Draw a rectangle (will be scaled by the transform)
                graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(20, 20, 50, 50));

                // Save the image (output path already bound)
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
 * 1. When you need to generate a BMP thumbnail where vector shapes are enlarged without jagged edges, you can set Graphics.InterpolationMode to HighQualityBicubic before scaling.
 * 2. When creating custom BMP icons for a Windows application and want smooth edges on scaled rectangles, using high‑quality bicubic interpolation ensures visual fidelity.
 * 3. When processing scanned BMP documents and drawing overlay graphics that must be resized, applying HighQualityBicubic interpolation prevents pixelation.
 * 4. When building a server‑side C# service that produces BMP charts and requires crisp, scaled shapes for print‑ready output, this code provides the needed quality.
 * 5. When automating batch conversion of BMP assets and need to preserve shape quality after applying a 2× transform, setting the interpolation mode achieves professional results.
 */
