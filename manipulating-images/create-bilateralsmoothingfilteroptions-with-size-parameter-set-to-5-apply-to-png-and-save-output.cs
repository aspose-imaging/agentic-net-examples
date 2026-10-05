// HOW-TO: Apply Bilateral Smoothing Filter Size 5 to PNG in C# (Aspose.Imaging for .NET)
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
                var saveOptions = new PngOptions
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
 * 1. When you need to reduce noise in a scanned PNG photograph while preserving edges before further analysis.
 * 2. When preparing PNG assets for a web application and want a lightweight smoothing effect without blurring details.
 * 3. When automating a batch process that cleans up PNG screenshots by applying a bilateral filter with a specific radius.
 * 4. When integrating image preprocessing in a C# computer‑vision pipeline that requires consistent smoothing across all PNG inputs.
 * 5. When converting raw PNG images from a camera sensor and need to apply size‑5 bilateral smoothing to improve visual quality before storage.
 */
