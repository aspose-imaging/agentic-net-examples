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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\output.tif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access RotateFlip
                if (image is CdrImage cdrImage)
                {
                    // Apply a horizontal flip (you can change the type as needed)
                    cdrImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                // Prepare TIFF save options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw
                };

                // Save the image as TIFF using the specified options
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
 * 1. When a graphic designer needs to convert a CorelDRAW (.cdr) illustration to a loss‑less TIFF for archival, applying a horizontal flip to correct orientation before saving with LZW compression.
 * 2. When an automated batch‑processing service must read CDR files, mirror the artwork, and generate compressed TIFF files for downstream printing workflows.
 * 3. When a document management system imports CDR assets, flips them to match page layout conventions, and stores them as TIFF images with LZW to reduce file size while preserving quality.
 * 4. When a C# application integrates Aspose.Imaging to transform vector CDR drawings into TIFF for compatibility with legacy GIS software, using RotateFlip and LZW compression.
 * 5. When a web API receives user‑uploaded CDR files, needs to programmatically flip the image and return a TIFF response optimized with LZW compression for faster download.
 */