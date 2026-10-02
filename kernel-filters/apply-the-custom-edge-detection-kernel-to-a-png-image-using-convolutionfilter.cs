// HOW-TO: How to Load and Save a PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When you need to programmatically open a PNG file, modify it, and write the result back without changing its format using Aspose.Imaging in a .NET application.
 * 2. When an automated batch job must verify that a PNG image exists and create a copy in a specific output directory with Aspose.Imaging handling the file I/O.
 * 3. When you want to ensure consistent PNG encoding options while saving images from a C# service that processes user‑uploaded graphics.
 * 4. When a server‑side C# API must read a PNG, perform raster‑level operations, and return the processed image to clients without relying on GDI+.
 * 5. When you are building a migration tool that reads legacy PNG assets and rewrites them using Aspose.Imaging to guarantee compatibility with newer .NET platforms.
 */
