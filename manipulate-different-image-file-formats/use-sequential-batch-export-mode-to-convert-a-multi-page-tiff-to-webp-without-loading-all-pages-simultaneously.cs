// HOW-TO: Convert Multi‑Page TIFF to Animated WebP Using Sequential Export in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output/output.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                // Enable sequential batch export mode
                tiff.PageExportingAction = delegate (int index, Image page)
                {
                    // Release resources for each page
                    GC.Collect();
                };

                // Configure WebP export options
                WebPOptions options = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80f
                };

                // Save as animated WebP (each TIFF page becomes a frame)
                tiff.Save(outputPath, options);
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
 * 1. When you need to generate a lightweight animated WebP preview from a large multi‑page scanned document without exhausting memory.
 * 2. When a web application must serve high‑resolution TIFF archives as animated WebP to improve page load speed on browsers.
 * 3. When processing satellite imagery stored as multi‑page TIFFs and you want to create compact WebP animations for quick visual analysis.
 * 4. When converting multi‑page medical imaging files to WebP for integration into a mobile health app while keeping the device’s RAM usage low.
 * 5. When automating batch conversion of archival TIFF slides into animated WebP files on a server that handles many files concurrently.
 */
