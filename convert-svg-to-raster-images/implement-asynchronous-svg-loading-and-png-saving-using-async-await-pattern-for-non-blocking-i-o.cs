// HOW-TO: Asynchronously Load SVG and Save As PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Temp\input.svg";
            string outputPath = @"C:\Temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Asynchronously read the SVG file into a memory stream
            await using (FileStream fileStream = new FileStream(
                inputPath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 81920,
                useAsync: true))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);
                    memoryStream.Position = 0; // Reset for reading

                    // Load SVG image from the memory stream
                    using (SvgImage svgImage = new SvgImage(memoryStream))
                    {
                        // Set rasterization options for PNG output
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            // Example: set desired size; adjust as needed
                            PageWidth = svgImage.Width,
                            PageHeight = svgImage.Height
                        };

                        PngOptions pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Save the rasterized image as PNG
                        svgImage.Save(outputPath, pngOptions);
                    }
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
 * 1. When you need to convert user‑uploaded SVG graphics to PNG thumbnails without blocking the UI thread in a desktop or web application.
 * 2. When a background service processes large batches of SVG files and must keep I/O operations non‑blocking to improve throughput.
 * 3. When you want to read an SVG from a network share or cloud storage asynchronously before rasterizing it to PNG for reporting.
 * 4. When you need to ensure the output directory exists and handle missing input files gracefully while performing async image conversion.
 * 5. When integrating Aspose.Imaging into an ASP.NET Core API that returns PNG images generated from SVG payloads without tying up server threads.
 */
