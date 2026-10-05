// HOW-TO: Load PNG and Save to Different Folder Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

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
 * 1. When you need to move or copy a PNG file to a new directory while preserving its original format in a C# application.
 * 2. When you want to programmatically ensure a PNG image is saved with Aspose.Imaging settings before further processing or archiving.
 * 3. When building an automated pipeline that reads PNG assets from one location and writes them to a structured output folder for downstream tasks.
 * 4. When you must validate that a PNG file exists and create the target folder on the fly to avoid runtime errors in image handling code.
 * 5. When integrating Aspose.Imaging into a .NET service that stores uploaded PNG images into a separate storage path for security or organization purposes.
 */
