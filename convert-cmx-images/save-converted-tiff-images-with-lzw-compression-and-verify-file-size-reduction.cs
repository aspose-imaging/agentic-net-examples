// HOW-TO: Compress TIFF Image With LZW And Verify Size Reduction In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.tif";
            string outputPath = "Output/output_lzw.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new TiffOptions(TiffExpectedFormat.Default);
                options.Compression = TiffCompressions.Lzw;
                image.Save(outputPath, options);
            }

            long originalSize = new FileInfo(inputPath).Length;
            long newSize = new FileInfo(outputPath).Length;

            if (newSize < originalSize)
            {
                Console.WriteLine($"File size reduced from {originalSize} to {newSize} bytes.");
            }
            else
            {
                Console.WriteLine($"File size not reduced. Original: {originalSize}, New: {newSize} bytes.");
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
 * 1. When you need to shrink large multi‑page TIFF documents for faster web delivery while preserving image quality.
 * 2. When archiving scanned medical records and want to reduce storage costs by applying LZW compression to TIFF files.
 * 3. When generating printable PDFs from TIFF sources and must ensure the TIFFs are optimally compressed before conversion.
 * 4. When building a batch image‑processing pipeline that must verify each TIFF’s file size decreased after compression.
 * 5. When integrating Aspose.Imaging into a C# application to replace uncompressed TIFFs with smaller LZW‑compressed versions for mobile apps.
 */
