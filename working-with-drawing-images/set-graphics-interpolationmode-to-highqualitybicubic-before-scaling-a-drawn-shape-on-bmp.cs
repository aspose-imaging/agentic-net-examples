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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 300x300 BMP image
            using (Image image = Image.Create(bmpOptions, 300, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Set high-quality bicubic interpolation before scaling
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Draw a blue rectangle
                graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(50, 50, 100, 100));

                // Apply scaling transform (2x)
                graphics.ScaleTransform(2.0f, 2.0f);

                // Draw a red rectangle (will be scaled)
                graphics.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(50, 50, 100, 100));

                // Save the image (bound to the file source)
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
 * 1. When generating high‑resolution product labels in BMP format, a developer can use Aspose.Imaging to draw vector shapes and apply HighQualityBicubic interpolation before scaling them to ensure crisp edges and accurate dimensions.
 * 2. When creating printable floor‑plan diagrams that require zoom‑in functionality, setting Graphics.InterpolationMode to HighQualityBicubic in C# guarantees that scaled rectangles retain smooth lines without pixelation.
 * 3. When producing thumbnail previews of scanned documents where the original BMP image contains drawn annotations, using HighQualityBicubic interpolation before scaling preserves the visual quality of the annotation shapes.
 * 4. When developing a custom charting component that renders BMP charts with resizable bars, applying HighQualityBicubic interpolation ensures that the bars remain sharp after the graphics are scaled for different screen resolutions.
 * 5. When automating the generation of BMP‑based game sprites that need to be enlarged for high‑DPI displays, setting the interpolation mode to HighQualityBicubic before scaling the sprite shapes prevents jagged edges and maintains visual fidelity.
 */