// HOW-TO: Measure Magic Wand Memory Usage for 4K PNG vs 1080p JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPng = "input_4k.png";
        string outputPng = "output_4k.png";
        string inputJpeg = "input_1080.jpg";
        string outputJpeg = "output_1080.jpg";

        try
        {
            // Verify input files exist
            if (!File.Exists(inputPng))
            {
                Console.Error.WriteLine($"File not found: {inputPng}");
                return;
            }
            if (!File.Exists(inputJpeg))
            {
                Console.Error.WriteLine($"File not found: {inputJpeg}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPng));
            Directory.CreateDirectory(Path.GetDirectoryName(outputJpeg));

            // Process 4K PNG
            long beforePng = Cache.AllocatedMemoryBytesCount;
            using (RasterImage image = (RasterImage)Image.Load(inputPng))
            {
                // Apply Magic Wand with arbitrary settings
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100) { Threshold = 100 })
                    .Apply();

                // Save result
                image.Save(outputPng, new PngOptions());
            }
            long afterPng = Cache.AllocatedMemoryBytesCount;
            Console.WriteLine($"Memory used for 4K PNG processing: {afterPng - beforePng} bytes");

            // Process 1080p JPEG
            long beforeJpeg = Cache.AllocatedMemoryBytesCount;
            using (RasterImage image = (RasterImage)Image.Load(inputJpeg))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100) { Threshold = 100 })
                    .Apply();

                image.Save(outputJpeg, new JpegOptions());
            }
            long afterJpeg = Cache.AllocatedMemoryBytesCount;
            Console.WriteLine($"Memory used for 1080p JPEG processing: {afterJpeg - beforeJpeg} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to benchmark how much RAM the MagicWandTool consumes while processing high‑resolution 4K PNG files versus standard 1080p JPEGs in a .NET application.
 * 2. When you want to ensure your server can handle large PNG selections without exceeding memory limits by measuring allocated bytes before and after the operation.
 * 3. When optimizing an image‑processing pipeline that uses Aspose.Imaging, you compare memory footprints of different image formats to choose the most efficient one.
 * 4. When diagnosing out‑of‑memory exceptions in a C# service that applies Magic Wand selections to user‑uploaded images of varying resolutions.
 * 5. When creating performance tests to validate that caching and disposal of RasterImage objects correctly release memory after MagicWandTool processing.
 */
