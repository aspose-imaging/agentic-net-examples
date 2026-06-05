using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Save the image with PNG options
                PngOptions saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to programmatically validate the existence of a PNG file, load it into a RasterImage, and save it to a new location with custom PNG options in a .NET application.
 * 2. When an automated batch‑processing tool must ensure output directories exist before writing processed PNG images using Aspose.Imaging for .NET.
 * 3. When a C# service has to read a user‑uploaded PNG, perform preliminary checks, and store a copy with specific encoding settings without altering the original image.
 * 4. When integrating Aspose.Imaging into a Windows desktop app to reliably open a PNG, cast it to a RasterImage for further manipulation, and persist it using a FileCreateSource.
 * 5. When building a server‑side image pipeline that catches and logs exceptions while loading and saving PNG files to prevent crashes in production environments.
 */