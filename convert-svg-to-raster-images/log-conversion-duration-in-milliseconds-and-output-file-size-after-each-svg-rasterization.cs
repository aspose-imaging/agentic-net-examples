// HOW-TO: Measure SVG to PNG Conversion Time and File Size in C# (Aspose.Imaging for .NET)
using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\test.svg";
        string outputPath = @"C:\temp\test.output.png";

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

            // Measure conversion duration
            Stopwatch sw = Stopwatch.StartNew();

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Preserve original size
                    PageSize = image.Size
                };

                // Prepare PNG save options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save rasterized PNG
                image.Save(outputPath, pngOptions);
            }

            sw.Stop();

            // Log duration in milliseconds
            Console.WriteLine($"Conversion duration: {sw.ElapsedMilliseconds} ms");

            // Log output file size
            long fileSize = new FileInfo(outputPath).Length;
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
 * 1. When you need to benchmark how long an SVG rasterization to PNG takes in a .NET application.
 * 2. When you want to verify that the generated PNG meets specific file‑size limits for web deployment.
 * 3. When you are automating batch conversion of SVG assets and must log performance metrics for each file.
 * 4. When you are troubleshooting a slow image‑processing pipeline and require precise conversion duration and output size data.
 * 5. When you integrate Aspose.Imaging into a CI/CD workflow and need to record conversion time and file size for reporting.
 */
