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
            string inputPath = "C:\\temp\\input.jpg";
            string outputPath = "C:\\temp\\output_lzw.tif";

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
                // Configure TIFF options for LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Lzw;
                tiffOptions.Predictor = TiffPredictor.Horizontal; // improves LZW compression
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Save the image as TIFF with the specified options
                image.Save(outputPath, tiffOptions);
            }

            // Verify file size reduction
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");

            if (compressedSize < originalSize)
            {
                Console.WriteLine("File size reduced after LZW compression.");
            }
            else
            {
                Console.WriteLine("No size reduction observed.");
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
 * 1. When a developer needs to convert high‑resolution JPEG photographs to TIFF files with LZW compression to reduce storage space for archival in a digital asset management system.
 * 2. When building a C# application that processes scanned documents and must save them as compressed TIFF images to meet email attachment size limits.
 * 3. When creating a medical imaging workflow that stores patient X‑ray images as TIFF with lossless LZW compression to ensure image integrity while minimizing disk usage.
 * 4. When developing a batch image‑conversion tool that verifies the file size reduction after saving PNG or JPEG files as LZW‑compressed TIFF for long‑term backup.
 * 5. When optimizing web‑ready image assets by converting source images to TIFF with LZW compression and programmatically confirming the compressed file is smaller before uploading to a content delivery network.
 */