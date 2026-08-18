// HOW-TO: Convert CorelDRAW CDR to LZW Compressed TIFF with Horizontal Flip in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access RotateFlip
                var cdrImage = image as CdrImage;
                if (cdrImage != null)
                {
                    // Apply a horizontal flip
                    cdrImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                // Configure TIFF options with LZW compression
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                    ByteOrder = TiffByteOrder.LittleEndian
                };

                // Save the image as TIFF using the configured options
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
 * 1. When a developer needs to generate a lossless, LZW‑compressed TIFF from a CorelDRAW CDR file for archival or printing workflows.
 * 2. When an application must programmatically mirror a CDR image horizontally before saving it in a format supported by downstream systems.
 * 3. When integrating Aspose.Imaging into a batch‑processing pipeline that converts legacy CDR graphics to TIFF for compatibility with document management platforms.
 * 4. When a web service receives CDR uploads and must return a TIFF with LZW compression to reduce file size while preserving image quality.
 * 5. When automating the preparation of CDR assets for GIS or medical imaging applications that require TIFF with specific photometric and planar settings.
 */
