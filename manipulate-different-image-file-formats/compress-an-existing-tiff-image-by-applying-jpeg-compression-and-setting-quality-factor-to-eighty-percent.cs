// HOW-TO: Compress TIFF Image With JPEG Compression At 80% Quality In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\source.tif";
            string outputPath = @"C:\Images\compressed.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF options for JPEG compression with 80% quality
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Jpeg,
                    CompressedQuality = 80,
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Save the image with the specified options
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to reduce the file size of high‑resolution TIFF scans for faster web delivery while preserving acceptable visual quality.
 * 2. When archiving large collections of scanned documents and want to store them as TIFFs with JPEG compression to save disk space.
 * 3. When converting multi‑page TIFFs from a scanner into a compact format for email attachment without changing the image dimensions.
 * 4. When preparing TIFF images for a GIS system that requires JPEG‑compressed TIFFs with a specific quality setting.
 * 5. When integrating image processing into a C# application that must compress existing TIFF files on the fly before uploading them to a cloud storage service.
 */
