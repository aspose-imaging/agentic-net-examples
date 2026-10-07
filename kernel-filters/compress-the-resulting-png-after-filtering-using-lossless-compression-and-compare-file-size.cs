// HOW-TO: Compress PNG with Maximum Lossless Zip Level and Compare File Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PngImage png = (PngImage)image)
                {
                    PngOptions options = new PngOptions
                    {
                        PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                        Source = new FileCreateSource(outputPath, false)
                    };
                    png.Save(outputPath, options);
                }
            }

            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
            Console.WriteLine($"Difference: {originalSize - compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the storage footprint of PNG assets for a web application without sacrificing image quality, you can use this code to apply lossless Zip level 9 compression and see the size savings.
 * 2. When preparing PNG images for email attachments or API responses, the snippet lets you compress them efficiently and verify that the compressed file meets size limits.
 * 3. When building an automated image‑processing pipeline that must retain exact pixel data, you can employ this routine to apply maximum lossless compression and log the byte‑difference for reporting.
 * 4. When migrating a large collection of PNG files to a cloud storage bucket, the code helps you compress each file on the fly and compare original versus compressed sizes to estimate cost reductions.
 * 5. When debugging or benchmarking different PNG compression settings in a C# project, this example provides a quick way to apply the highest Zip level, save the result, and output the size comparison for analysis.
 */
