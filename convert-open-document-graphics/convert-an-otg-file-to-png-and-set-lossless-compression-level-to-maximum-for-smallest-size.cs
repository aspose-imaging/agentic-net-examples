// HOW-TO: Convert OTG to PNG with Maximum Lossless Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9
                };
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
 * 1. When you need to shrink OTG vector graphics for web delivery without losing quality, you can convert them to PNG with maximum lossless compression.
 * 2. When integrating legacy OTG assets into a .NET application that only supports raster images, you can programmatically transform them to PNG.
 * 3. When preparing print‑ready OTG files for inclusion in a PDF, converting to PNG ensures consistent rendering across platforms.
 * 4. When automating a batch process that archives design files, converting OTG to highly compressed PNG reduces storage space.
 * 5. When building an image‑processing pipeline that receives OTG uploads, converting to PNG with ZipLevel9 allows downstream components to handle a standard format efficiently.
 */
