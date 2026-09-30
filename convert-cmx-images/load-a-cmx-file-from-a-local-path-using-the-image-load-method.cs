// HOW-TO: Load CMX File and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace CmXLoader
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cmx";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
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
}

/*
 * Real-World Use Cases:
 * 1. When a CAD application exports drawings as CMX and you need to generate PNG previews for web display.
 * 2. When an automated workflow must validate that a CMX file exists before converting it to a raster format for reporting.
 * 3. When integrating Aspose.Imaging into a C# service that transforms legacy CMX assets into PNG thumbnails for a digital asset management system.
 * 4. When a desktop utility needs to batch‑process multiple CMX files, loading each with Image.Load and saving them as PNGs for archival.
 * 5. When a client requests a simple console program that reads a CMX diagram from disk and outputs a high‑quality PNG using Aspose.Imaging.
 */
