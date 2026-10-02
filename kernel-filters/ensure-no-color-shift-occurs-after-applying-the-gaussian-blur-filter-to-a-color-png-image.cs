// HOW-TO: Save PNG without Color Shift After Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.png";
        string outputPath = "Output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

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
 * 1. When a web application needs to apply a Gaussian blur to user‑uploaded PNG photos and then store them without altering the original colors.
 * 2. When an e‑commerce platform generates blurred background images for product thumbnails and must preserve accurate brand colors in the saved PNG files.
 * 3. When a desktop utility processes medical imaging PNG scans with a blur filter and requires the output to retain the exact color information for diagnostic purposes.
 * 4. When a game developer creates soft‑focus textures from PNG assets and wants to ensure the saved textures do not introduce any hue or saturation changes.
 * 5. When an automated batch job converts a series of PNG graphics after applying a blur effect and needs to maintain color consistency across all output files.
 */
