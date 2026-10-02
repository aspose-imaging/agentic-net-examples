// HOW-TO: How To Load And Save A PNG Image Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to read a PNG file, manipulate it in memory, and write it back without losing metadata using Aspose.Imaging in a C# application.
 * 2. When building a batch image processing tool that copies PNG files to a new directory while applying Aspose.Imaging’s default compression settings.
 * 3. When integrating image handling into a web service that validates uploaded PNGs and stores them on the server with the Aspose.Imaging API.
 * 4. When creating a desktop utility that reorganizes image assets by loading each PNG, optionally applying transformations later, and saving them to a structured folder hierarchy.
 * 5. When troubleshooting rendering problems by loading a PNG, confirming it can be opened by Aspose.Imaging, and re‑saving it to verify file integrity.
 */
