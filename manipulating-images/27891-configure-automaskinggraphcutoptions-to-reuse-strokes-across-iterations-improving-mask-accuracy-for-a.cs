using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to load an existing PNG file, verify its existence, and save it to a new location using Aspose.Imaging’s RasterImage with PngOptions in a C# application.
 * 2. When a batch image processing script must create the output directory automatically before writing processed PNG images to prevent file‑system errors.
 * 3. When an automated workflow requires reading a raster image, applying default PNG compression settings via PngOptions, and exporting the result for downstream consumption.
 * 4. When a .NET service must gracefully handle missing input files by checking File.Exists and logging an error instead of crashing.
 * 5. When a console utility wants to copy or re‑encode a PNG image while preserving image fidelity using Aspose.Imaging’s RasterImage class for future image manipulations.
 */