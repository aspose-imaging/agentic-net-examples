using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Measure conversion time
            Stopwatch sw = Stopwatch.StartNew();

            // Load SVG image and rasterize to PNG
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                // Configure PNG save options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save rasterized PNG
                image.Save(outputPath, pngOptions);
            }

            sw.Stop();

            // Log duration and output file size
            long fileSize = new FileInfo(outputPath).Length;
            Console.WriteLine($"Conversion duration: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Output file size: {fileSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web service converts user‑uploaded SVG icons to PNG thumbnails and needs to log conversion duration in milliseconds and output file size to monitor performance and bandwidth usage.
 * 2. When a batch job processes thousands of SVG diagrams for a reporting system and records each rasterization’s elapsed time and resulting PNG size to detect bottlenecks.
 * 3. When an e‑commerce platform generates product image previews from SVG assets and must ensure the rasterized PNG files stay within size limits for fast page loads, logging both duration and file size.
 * 4. When a desktop application offers a “Save as PNG” feature for vector drawings and wants to display the conversion time and final file size to the end user after each SVG rasterization.
 * 5. When a CI/CD pipeline validates that automated SVG‑to‑PNG rasterization meets SLA requirements by capturing the elapsed milliseconds and output file size after each build step.
 */