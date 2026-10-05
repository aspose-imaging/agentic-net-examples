// HOW-TO: Load PNG from File and Save as PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to read a PNG file from disk, verify it exists, and create a copy in another folder using Aspose.Imaging.
 * 2. When an application must ensure the target directory is created before writing a processed PNG image to prevent runtime errors.
 * 3. When a service processes uploaded PNG images and saves them with standardized PngOptions for consistent quality and metadata handling.
 * 4. When migrating image assets from one storage location to another while preserving the original PNG format and pixel data.
 * 5. When a batch job validates PNG files and rewrites them to normalize metadata using Aspose.Imaging in C#.
 */
