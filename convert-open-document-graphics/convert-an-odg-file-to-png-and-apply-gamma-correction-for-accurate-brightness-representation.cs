using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.odg";
            string outputPath = "sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Save the ODG as PNG (rasterization occurs internally)
                odgImage.Save(outputPath, new PngOptions());

                // Load the newly created PNG to apply gamma correction
                using (Image pngImage = Image.Load(outputPath))
                {
                    // Cast to RasterImage to access AdjustGamma
                    var raster = pngImage as RasterImage;
                    if (raster != null)
                    {
                        // Apply gamma correction (example gamma value)
                        raster.AdjustGamma(2.2f);

                        // Overwrite the PNG with the gamma‑corrected image
                        raster.Save(outputPath, new PngOptions());
                    }
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
 * 1. When a developer needs to convert an OpenDocument Graphics (ODG) illustration to a PNG thumbnail for web preview while preserving visual fidelity.
 * 2. When an application must batch‑process ODG files from a legacy design system and output PNGs with gamma correction to match monitor brightness.
 * 3. When a reporting tool generates charts in ODG format and the final PDF requires raster PNG images with adjusted gamma for accurate color reproduction.
 * 4. When a mobile app downloads ODG assets and needs to convert them to PNG on the server side, applying gamma correction to ensure consistent appearance across devices.
 * 5. When a content management system imports user‑uploaded ODG diagrams and stores them as gamma‑corrected PNGs for fast rendering in browsers.
 */