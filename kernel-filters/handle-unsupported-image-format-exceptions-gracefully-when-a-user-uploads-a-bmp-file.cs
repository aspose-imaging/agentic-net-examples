// HOW-TO: Convert BMP to PNG in C# with Aspose.Imaging and Error Handling (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.bmp";
        string outputPath = "Output\\sample_converted.png";

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
                using (var options = new PngOptions())
                {
                    image.Save(outputPath, options);
                }
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
 * 1. When a web application receives user‑uploaded BMP files and must convert them to PNG for browser‑compatible display while gracefully handling unsupported format errors.
 * 2. When a batch processing tool needs to read BMP images from a folder, convert them to lossless PNGs, and ensure the process continues even if a file is missing or corrupted.
 * 3. When integrating Aspose.Imaging into a C# service that validates image uploads, converting BMP to PNG and logging any exceptions without crashing the service.
 * 4. When building a desktop utility that transforms legacy BMP assets into PNG for modern UI themes, with automatic directory creation and error reporting.
 * 5. When automating image migration in a .NET backend, converting BMP files to PNG while catching and reporting format‑specific exceptions to maintain data integrity.
 */
