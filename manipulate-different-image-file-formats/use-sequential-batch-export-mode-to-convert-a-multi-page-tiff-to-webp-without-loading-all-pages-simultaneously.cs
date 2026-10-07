// HOW-TO: Convert Multi‑Page TIFF to Animated WebP Using Sequential Batch Export in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animated.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                tiff.PageExportingAction = (int pageIndex, Image pageImage) =>
                {
                    // Sequential processing; no custom per-page logic required.
                };

                using (var webpOptions = new WebPOptions())
                {
                    webpOptions.Quality = 80;
                    webpOptions.Lossless = false;
                    tiff.Save(outputPath, webpOptions);
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
 * 1. When you need to generate an animated WebP from a large multi‑page TIFF without exhausting memory.
 * 2. When processing scanned document pages one at a time and delivering them as a single WebP file for web use.
 * 3. When converting medical imaging TIFF stacks to lightweight WebP for fast browser preview.
 * 4. When automating server‑side batch conversion of archival TIFF files to WebP in a .NET service while preserving page order.
 * 5. When creating animated WebP thumbnails from multi‑page TIFFs in a C# application without loading the entire image into RAM.
 */
