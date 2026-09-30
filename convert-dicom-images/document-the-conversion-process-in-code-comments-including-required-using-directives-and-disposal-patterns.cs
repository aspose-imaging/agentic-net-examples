// HOW-TO: Convert PNG to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths (relative to the current directory)
            string inputPath = Path.Combine("Input", "sample.png");
            string outputPath = Path.Combine("Output", "sample_converted.jpg");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image and convert it to JPEG format
            using (Image image = Image.Load(inputPath))
            {
                // JpegOptions resides in Aspose.Imaging.ImageOptions
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }

            Console.WriteLine($"Conversion completed: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically convert user‑uploaded PNG screenshots to JPEG for faster web loading.
 * 2. When an automated build process must change PNG assets to JPEG to reduce storage size before archiving.
 * 3. When a C# desktop application creates PNG charts but the reporting tool only accepts JPEG images.
 * 4. When migrating a legacy media library from PNG to JPEG to meet a CMS’s supported image formats.
 * 5. When a server‑side service receives PNG files and must save them as JPEG for inclusion in email attachments.
 */
