// HOW-TO: Batch Convert Drawing Files to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputDirectory = "InputDrawings";
                string outputDirectory = "OutputPng";

                if (!Directory.Exists(inputDirectory))
                {
                    Directory.CreateDirectory(inputDirectory);
                    Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                    return;
                }

                Directory.CreateDirectory(outputDirectory);

                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string inputPath in files)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                    {
                        string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (PngOptions options = new PngOptions())
                        {
                            options.Source = new FileCreateSource(outputPath, false);
                            raster.Save(outputPath, options);
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically convert a folder of CAD or vector drawing files to PNG for web preview.
 * 2. When you want to generate PNG thumbnails from a collection of design assets in a .NET application.
 * 3. When you must integrate batch image conversion into a build pipeline that processes engineering drawings.
 * 4. When you require a simple C# script to export drawings as lossless PNG while preserving original dimensions.
 * 5. When you need to programmatically read unknown image formats and save them as PNG for downstream processing.
 */
