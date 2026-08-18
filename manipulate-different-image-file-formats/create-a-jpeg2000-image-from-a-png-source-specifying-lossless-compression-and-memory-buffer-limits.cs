// HOW-TO: Convert PNG to Lossless JPEG2000 with Buffer Size Hint in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.png";
        string outputPath = @"C:\temp\output.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image pngImage = Image.Load(inputPath))
            {
                // Prepare JPEG2000 options for lossless compression and buffer limit
                Jpeg2000Options jpegOptions = new Jpeg2000Options
                {
                    Irreversible = false,               // lossless DWT 5-3
                    BufferSizeHint = 1024 * 1024        // 1 MB buffer size hint
                };

                // Create a JPEG2000 image from the loaded raster image
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(pngImage as RasterImage))
                {
                    // Save the JPEG2000 image with the specified options
                    jpeg2000Image.Save(outputPath, jpegOptions);
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
 * 1. When an application needs to archive high‑resolution PNG graphics without quality loss, it can convert them to lossless JPEG2000 files while controlling memory usage.
 * 2. When a medical imaging system must store diagnostic images in a format that supports lossless compression and limited RAM, this code creates JPEG2000 files from PNG scans.
 * 3. When a digital publishing workflow requires converting PNG assets to JPEG2000 for efficient storage and streaming, the buffer size hint helps keep the conversion within memory constraints.
 * 4. When a GIS tool processes large PNG map tiles and needs a compact, lossless format for archival, the code generates JPEG2000 images with a 1 MB buffer limit.
 * 5. When a C# service integrates Aspose.Imaging to batch‑convert user‑uploaded PNGs to JPEG2000 for compliance with archival standards, the lossless option ensures no visual degradation.
 */
