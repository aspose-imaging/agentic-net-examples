// HOW-TO: Save PNG Image with Custom Filter and Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "templates/image.png";
            string outputPath = "templates/image.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    FilterType = PngFilterType.Avg,
                    ColorType = PngColorType.TruecolorWithAlpha,
                    CompressionLevel = 9
                };
                image.Save(outputPath, options);
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
 * 1. When you need to apply a specific PNG filter and maximum compression to a template image while keeping the original file name unchanged.
 * 2. When an automated build process must overwrite existing PNG assets in a templates directory with optimized versions using Aspose.Imaging.
 * 3. When a web application generates thumbnails and wants to save the processed PNG back to the source folder without creating duplicate files.
 * 4. When a batch script processes multiple PNG files and must preserve their original filenames after applying truecolor with alpha and high compression.
 * 5. When you want to ensure a PNG file exists before applying image options and safely handle missing files in a C# project.
 */
