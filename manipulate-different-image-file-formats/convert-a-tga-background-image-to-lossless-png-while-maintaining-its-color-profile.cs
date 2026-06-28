using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TGA image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Set PNG options to keep metadata (including color profile)
                var pngOptions = new PngOptions
                {
                    KeepMetadata = true
                };

                // Save as lossless PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a game developer needs to convert legacy TGA textures to lossless PNG files while preserving the original color profile for use in modern engines.
 * 2. When a digital archivist wants to migrate TGA screenshots from an old graphics pipeline to PNG format without losing any metadata or color accuracy.
 * 3. When a web application processes user‑uploaded TGA images and must output PNG files that retain the embedded ICC profile for consistent display across browsers.
 * 4. When a batch‑processing tool in C# needs to ensure that converted PNGs remain lossless and keep all EXIF and color profile information for downstream printing workflows.
 * 5. When a scientific imaging system requires converting TGA output from instrumentation into PNG while maintaining precise color calibration for analysis.
 */