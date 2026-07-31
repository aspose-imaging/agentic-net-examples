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
            // Hardcoded input and output paths
            string inputPath = "input\\source.bmp";
            string outputPath = "output\\scaled.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source BMP image
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Create graphics for the source image
                Graphics graphics = new Graphics(sourceImage);
                // Set high-quality interpolation mode before drawing/scaling
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Draw a rectangle shape onto the source image
                graphics.DrawRectangle(new Pen(Color.Blue, 5), new Rectangle(50, 50, 200, 150));

                // Define scaled dimensions (e.g., 2x scaling)
                int scaledWidth = sourceImage.Width * 2;
                int scaledHeight = sourceImage.Height * 2;

                // Create a new BMP image bound to the output file
                BmpOptions bmpOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                using (Image scaledImage = Image.Create(bmpOptions, scaledWidth, scaledHeight))
                {
                    // Create graphics for the scaled image
                    Graphics scaledGraphics = new Graphics(scaledImage);
                    // Set interpolation mode for scaling operation
                    scaledGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // Draw the source image onto the scaled canvas with scaling
                    scaledGraphics.DrawImage(sourceImage, new Rectangle(0, 0, scaledWidth, scaledHeight));

                    // Save the scaled image (output path already bound)
                    scaledImage.Save();
                }
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
 * 1. When a developer needs to generate high‑resolution printable marketing material by scaling a BMP that contains drawn shapes such as rectangles, using HighQualityBicubic ensures smooth, anti‑aliased edges.
 * 2. When an application creates thumbnail previews of user‑drawn BMP diagrams and wants the scaled preview to retain crisp lines, setting InterpolationMode to HighQualityBicubic before scaling achieves that.
 * 3. When a batch‑processing tool adds watermarks or borders to BMP files and then enlarges the images for large‑format displays, HighQualityBicubic interpolation prevents jagged artifacts on the drawn shapes.
 * 4. When a CAD‑style web service exports technical drawings as BMP and must resize them for different screen densities while preserving line quality, using HighQualityBicubic in the graphics pipeline is essential.
 * 5. When a game asset pipeline programmatically draws UI elements onto BMP textures and later doubles their size for high‑DPI monitors, applying HighQualityBicubic interpolation during scaling keeps the UI edges smooth.
 */