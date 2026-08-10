// HOW-TO: Log CMX to PNG Conversion Parameters with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Log conversion parameters
                Console.WriteLine("Starting CMX to PNG conversion");
                Console.WriteLine($"Input Path: {inputPath}");
                Console.WriteLine($"Output Path: {outputPath}");
                Console.WriteLine($"Image Width: {image.Width}");
                Console.WriteLine($"Image Height: {image.Height}");

                if (image is CmxImage cmxImage)
                {
                    Console.WriteLine($"CMX Page Count: {cmxImage.PageCount}");
                }

                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
                Console.WriteLine("Conversion completed successfully");
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
 * 1. When you need to convert legacy CMX vector drawings to PNG thumbnails while recording input and output details for troubleshooting.
 * 2. When an automated batch process must generate PNG assets from CMX files and keep a log of image dimensions and page count for quality control.
 * 3. When integrating Aspose.Imaging into a C# application that requires audit trails of each conversion operation for compliance reporting.
 * 4. When debugging failures in a document conversion pipeline, you can view logged paths, sizes, and page numbers to pinpoint issues.
 * 5. When building a server‑side service that transforms CMX diagrams to web‑friendly PNGs and needs to capture conversion parameters for performance monitoring.
 */
