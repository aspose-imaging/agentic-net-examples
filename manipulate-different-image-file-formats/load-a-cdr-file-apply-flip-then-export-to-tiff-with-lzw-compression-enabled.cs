using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff;
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Apply a horizontal flip
                if (image is CdrImage cdrImage)
                {
                    cdrImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                // Configure TIFF save options with LZW compression
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    Photometric = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPhotometrics.Rgb,
                    PlanarConfiguration = Aspose.Imaging.FileFormats.Tiff.Enums.TiffPlanarConfigs.Contiguous,
                    ByteOrder = Aspose.Imaging.FileFormats.Tiff.Enums.TiffByteOrder.BigEndian
                };

                // Save the image as TIFF with the specified options
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
 * 1. When a graphic designer needs to convert a CorelDRAW (CDR) illustration to a high‑resolution TIFF file for printing while applying a horizontal flip to correct the layout.
 * 2. When an archival system must ingest legacy CDR artwork, flip it for proper orientation, and store it as a TIFF with LZW compression to preserve quality and reduce storage space.
 * 3. When a web service processes user‑uploaded CDR files, applies a flip for correct display, and returns a TIFF image optimized with LZW compression for faster download.
 * 4. When a batch‑processing tool automates the migration of CDR assets to TIFF format for Photoshop compatibility, ensuring each image is flipped and compressed using LZW.
 * 5. When a document‑management workflow requires converting CDR files to TIFF with LZW compression and a horizontal flip to meet publishing standards for print‑ready PDFs.
 */