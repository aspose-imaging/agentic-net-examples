using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up BMP creation options with bound source
            BmpOptions options = new BmpOptions();
            Source src = new FileCreateSource(outputPath, false);
            options.Source = src;

            int width = 200;
            int height = 200;

            // Create canvas bound to the output file
            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                // Draw a thick red border around the canvas
                Graphics graphics = new Graphics(canvas);
                int thickness = 10;
                graphics.DrawRectangle(new Pen(Color.Red, thickness), 0, 0, width, height);

                // Save the bound image
                canvas.Save();
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
 * 1. When a developer needs to generate a BMP placeholder image with a thick red frame for UI mock‑ups using Aspose.Imaging in C#.
 * 2. When an automated testing suite requires a simple bitmap file with a visible red border to validate image‑processing algorithms.
 * 3. When a reporting tool must create printable BMP charts that are highlighted by a bold red outline to draw attention to the entire canvas.
 * 4. When a batch job prepares sample images for a computer‑vision dataset, adding a uniform red border to each BMP to indicate the region of interest.
 * 5. When a legacy system expects BMP assets with a decorative red edge, and the developer uses Aspose.Imaging’s RasterImage and Graphics classes to produce them programmatically.
 */