using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply MagicWandTool with default settings (reference point at (0,0))
                MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                    .Apply();

                // Save the masked result as PNG with alpha channel
                image.Save(outputPath, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
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
 * 1. When a web application needs to automatically remove the background of user‑uploaded JPEG photos and store the result as a PNG with transparency for further compositing.
 * 2. When an e‑commerce platform wants to generate product thumbnails by selecting the foreground of a JPEG image using the MagicWandTool and saving it as a PNG with an alpha channel for overlay on promotional banners.
 * 3. When a desktop C# utility processes scanned JPEG documents, isolates the main content with the default MagicWand settings, and outputs a transparent PNG for inclusion in PDF reports.
 * 4. When a mobile backend service converts customer‑submitted JPEG avatars into masked PNG avatars with transparent backgrounds to be displayed in a social‑media feed.
 * 5. When a batch‑processing script needs to apply a quick region‑selection mask to a folder of JPEG images and export them as PNG files that preserve the original colors and add an alpha channel for graphic designers.
 */