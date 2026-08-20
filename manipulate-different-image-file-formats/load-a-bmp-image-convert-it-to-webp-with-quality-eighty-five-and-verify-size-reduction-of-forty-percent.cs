// HOW-TO: Convert BMP to WebP with Quality 85 and Verify 40% Size Reduction in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample_converted.webp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Prepare WebP options with lossy compression and quality 85
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 85f
                };

                // Save as WebP
                bmpImage.Save(outputPath, webpOptions);
            }

            // Verify size reduction of at least 40%
            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;

            if (outputSize <= inputSize * 0.6)
            {
                Console.WriteLine("Size reduction verification passed.");
            }
            else
            {
                Console.WriteLine("Size reduction verification failed.");
                Console.WriteLine($"Input size: {inputSize} bytes, Output size: {outputSize} bytes");
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
 * 1. When you need to shrink large BMP assets for faster web page loading by converting them to WebP with controlled quality.
 * 2. When you want to automate batch processing of legacy BMP files into modern WebP format while ensuring at least a 40% reduction in file size.
 * 3. When you must generate WebP thumbnails from BMP sources for mobile apps and need to confirm the compression meets size constraints.
 * 4. When you are building a CI pipeline that validates image optimization by converting BMP to WebP and checking the size reduction threshold.
 * 5. When you need to replace BMP icons with smaller WebP equivalents in a desktop application without losing visual fidelity, and you want to programmatically verify the size savings.
 */
