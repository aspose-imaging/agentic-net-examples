using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string backgroundPath = "background.png";
            string overlayPath = "overlay.png";
            string outputPath = "result.png";

            // Verify input files exist
            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load background and overlay images
            using (RasterImage background = (RasterImage)Image.Load(backgroundPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                // Apply alpha blending with full opacity (255)
                background.Blend(new Point(0, 0), overlay, 255);

                // Save the blended image as PNG
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                background.Save(outputPath, options);
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
 * 1. When a developer needs to overlay a company logo PNG onto a product photo without losing any transparency, they can use this code to blend the logo at full opacity and save the result as a PNG.
 * 2. When creating a composite map image by placing a semi‑transparent PNG layer of road data over a base satellite PNG, the code ensures the overlay is applied with full opacity and the final PNG retains its alpha channel.
 * 3. When generating marketing banners where a promotional PNG overlay must be merged onto a background image while preserving the original colors, this C# snippet performs alpha blending with 255 opacity and outputs a loss‑less PNG.
 * 4. When automating the preparation of UI assets by programmatically combining a PNG button icon over a dialog background, the code blends the images at full opacity and verifies no transparency is lost during saving.
 * 5. When building a batch process that stamps a watermark PNG onto multiple background PNG files, developers can use this example to apply the watermark with full opacity and keep the resulting PNG’s transparency intact.
 */