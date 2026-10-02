// HOW-TO: Check WebP File Exists Before Converting to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        const string inputPath = "input.webp";
        const string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new PngOptions();
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
 * 1. When an application processes user‑uploaded WebP images and must verify the file is present before converting it to PNG to avoid runtime errors.
 * 2. When a batch job generates thumbnails from WebP assets and needs to ensure each source file exists before saving the PNG output to a specific folder.
 * 3. When integrating Aspose.Imaging into a .NET service that converts WebP graphics to PNG for compatibility with browsers that do not support WebP.
 * 4. When building a file‑conversion utility that creates the destination directory automatically and handles missing WebP files gracefully.
 * 5. When troubleshooting image pipelines and want to log a clear error message instead of an unhandled FileNotFoundException during WebP‑to‑PNG conversion.
 */
