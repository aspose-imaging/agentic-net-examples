// HOW-TO: Deskew CorelDRAW CDR and Save as TIFF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Input\sample.cdr";
        string outputPath = @"C:\Output\sample.tif";

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

            // Load the CDR document as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image (do not resize, use white background)
                image.NormalizeAngle(false, Color.White);

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    // Example settings – can be adjusted as needed
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.LittleEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Save the deskewed image as TIFF
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
 * 1. When you need to automatically correct the rotation of scanned CorelDRAW (.cdr) files before archiving them as lossless TIFF images in a .NET batch process.
 * 2. When a document management system must convert user‑uploaded CDR drawings to deskewed, LZW‑compressed TIFFs for consistent viewing across platforms.
 * 3. When integrating Aspose.Imaging into a C# application to preprocess vector graphics by normalizing angle and preserving color depth for high‑quality print output.
 * 4. When generating searchable digital archives that require deskewed TIFF files from legacy CorelDRAW designs without manual editing.
 * 5. When building an automated workflow that validates input files, creates output directories, and saves deskewed images with specific TIFF options such as little‑endian byte order and RGB photometric.
 */
