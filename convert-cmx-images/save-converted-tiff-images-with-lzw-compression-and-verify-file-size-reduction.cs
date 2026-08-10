// HOW-TO: Convert JPEG to TIFF with LZW Compression and Check Size Reduction in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output_lzw.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF save options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    // Optional: use predictor to improve LZW compression for continuous-tone images
                    Predictor = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPredictor.Horizontal,
                    // Preserve color model (let Aspose infer appropriate settings)
                };

                // Save the image as TIFF with LZW compression
                image.Save(outputPath, tiffOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");

            if (compressedSize < originalSize)
                Console.WriteLine("File size reduced after LZW compression.");
            else
                Console.WriteLine("No size reduction observed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to archive high‑resolution photos as TIFF files while minimizing storage space, you can use LZW compression and verify the size savings with Aspose.Imaging in C#.
 * 2. When a document‑management system requires TIFF images with lossless compression for reliable printing, this code converts incoming JPEGs to LZW‑compressed TIFFs and confirms the compression benefit.
 * 3. When preparing image assets for a GIS or remote‑sensing application that only accepts TIFF format, you can compress them with LZW and ensure the files are smaller than the originals.
 * 4. When building a batch‑processing tool that reduces bandwidth for image transfer by converting JPEGs to compressed TIFFs, the size comparison helps decide if the conversion is worthwhile.
 * 5. When implementing a compliance workflow that stores medical scans as TIFF with lossless compression, the code validates that the LZW‑compressed files occupy less disk space than the source images.
 */
