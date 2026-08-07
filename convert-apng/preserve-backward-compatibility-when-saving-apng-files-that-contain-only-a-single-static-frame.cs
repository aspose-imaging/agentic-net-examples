using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (single-frame raster image)
            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                // Since the source contains only a single static frame,
                // save it using regular PNG options to maintain backward compatibility.
                // The file is still named with .apng extension, but its content is a standard PNG.
                var pngOptions = new PngOptions();
                sourceImage.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to serve images with an .apng extension for legacy browsers but the source file is a single‑frame PNG, this code ensures the file remains a standard PNG while keeping the .apng name for compatibility.
 * 2. When a content management system migrates user‑uploaded PNG assets to an APNG pipeline and must handle cases where the upload contains only one frame, the snippet saves the image using PngOptions to avoid breaking older PNG viewers.
 * 3. When an automated build script generates sprite sheets that sometimes contain only one frame, developers can use this code to output the sprite as a .apng file that older image editors still recognize as a regular PNG.
 * 4. When a mobile app bundles static icons with an .apng extension for consistency with animated assets, this example guarantees that single‑frame icons are saved as standard PNG data, preserving backward compatibility across platforms.
 * 5. When a server‑side image processing service receives PNG files and must return them with an .apng extension for API contracts, the provided C# routine converts single‑frame images to PNG format while retaining the .apng filename to satisfy both new and legacy clients.
 */