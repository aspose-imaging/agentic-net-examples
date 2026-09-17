// HOW-TO: Batch Convert TIFF Files to Animated PNG with Loop Count in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var file in files)
            {
                if (!file.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) &&
                    !file.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string inputPath = file;
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".apng");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image tiffImage = Image.Load(inputPath))
                {
                    RasterImage raster = tiffImage as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image type: {inputPath}");
                        continue;
                    }

                    ApngOptions options = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        NumPlays = 3,
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(options, raster.Width, raster.Height))
                    {
                        apng.RemoveAllFrames();
                        apng.AddFrame(raster);
                        apng.Save();
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
 * 1. When you need to transform a collection of multi‑page TIFF scans into looping animated PNGs for web galleries using C#.
 * 2. When an automated build process must generate lightweight APNG assets from high‑resolution TIFF source files for mobile apps.
 * 3. When a server‑side service has to convert uploaded TIFF images to APNG with a preset three‑loop animation for email newsletters.
 * 4. When migrating legacy TIFF documentation to modern animated PNG format while preserving a consistent loop count across all files.
 * 5. When creating a batch script that processes a folder of TIFF files and outputs APNGs ready for inclusion in HTML5 canvases.
 */
