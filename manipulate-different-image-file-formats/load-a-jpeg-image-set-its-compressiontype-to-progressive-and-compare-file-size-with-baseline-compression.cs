// HOW-TO: How To Save JPEG As Progressive And Compare File Size In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string baselinePath = @"C:\Images\output_baseline.jpg";
            string progressivePath = @"C:\Images\output_progressive.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(baselinePath));
            Directory.CreateDirectory(Path.GetDirectoryName(progressivePath));

            // Load the original JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Save with default (baseline) compression
                image.Save(baselinePath);

                // Prepare JPEG options for progressive compression
                JpegOptions progressiveOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Progressive,
                    Quality = 100 // optional: keep high quality for comparison
                };

                // Save with progressive compression
                image.Save(progressivePath, progressiveOptions);
            }

            // Compare file sizes
            long baselineSize = new FileInfo(baselinePath).Length;
            long progressiveSize = new FileInfo(progressivePath).Length;

            Console.WriteLine($"Baseline file size: {baselineSize} bytes");
            Console.WriteLine($"Progressive file size: {progressiveSize} bytes");
            Console.WriteLine($"Size difference: {baselineSize - progressiveSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a progressive JPEG for faster web page loading while preserving the original image quality.
 * 2. When you want to measure whether progressive compression reduces file size compared to baseline JPEG to optimize bandwidth usage.
 * 3. When building an image pipeline that must output both baseline and progressive JPEGs for A/B testing of visual loading performance.
 * 4. When creating a batch conversion utility that logs size differences to decide which JPEG compression mode is best for archival storage.
 * 5. When developing a photo‑sharing app that compares progressive and baseline JPEG sizes to select the most efficient format for mobile devices.
 */
