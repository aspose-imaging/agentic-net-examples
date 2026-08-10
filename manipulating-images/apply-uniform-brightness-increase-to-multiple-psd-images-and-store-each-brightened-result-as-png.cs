// HOW-TO: Increase Brightness of Multiple PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input PSD files
            string[] inputPaths = {
                @"C:\Images\image1.psd",
                @"C:\Images\image2.psd"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\Output";

            foreach (string inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to adjust brightness
                    RasterImage raster = image as RasterImage;
                    if (raster != null)
                    {
                        // Increase brightness uniformly (value range -255 to 255)
                        raster.AdjustBrightness(50);

                        // Save the brightened image as PNG
                        raster.Save(outputPath, new PngOptions());
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image type (not raster): {inputPath}");
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
 * 1. When you need to batch‑process Photoshop PSD layers to make them uniformly brighter before publishing them as web‑ready PNGs.
 * 2. When an automated build script must convert a set of design assets from PSD to PNG while applying a fixed brightness boost for consistent visual appearance.
 * 3. When a photo‑editing application requires programmatic adjustment of image exposure across multiple PSD files without manual Photoshop interaction.
 * 4. When a digital asset pipeline needs to ensure all PSD source files meet a minimum brightness level before being uploaded to a content management system as PNG.
 * 5. When you want to integrate Aspose.Imaging into a C# service that validates and enhances incoming PSD uploads by increasing brightness and saving them in PNG format.
 */
