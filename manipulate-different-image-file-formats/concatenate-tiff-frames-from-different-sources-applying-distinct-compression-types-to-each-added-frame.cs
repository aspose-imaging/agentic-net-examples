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
            string inputPath1 = @"C:\temp\input1.tif";
            string inputPath2 = @"C:\temp\input2.tif";
            string outputPath = @"C:\temp\output.tif";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load first source image
            using (RasterImage srcImage1 = (RasterImage)Image.Load(inputPath1))
            {
                // Create TiffOptions for the first frame (LZW compression)
                TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.BigEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Create a TiffFrame from the first source image with its options
                TiffFrame frame1 = new TiffFrame(srcImage1, options1);

                // Load second source image
                using (RasterImage srcImage2 = (RasterImage)Image.Load(inputPath2))
                {
                    // Create TiffOptions for the second frame (CCITT Group 3 Fax compression)
                    TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        BitsPerSample = new ushort[] { 1 },
                        ByteOrder = TiffByteOrder.LittleEndian,
                        Compression = TiffCompressions.CcittFax3,
                        Photometric = TiffPhotometrics.MinIsBlack,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous
                    };

                    // Create a TiffFrame from the second source image with its options
                    TiffFrame frame2 = new TiffFrame(srcImage2, options2);

                    // Create a new multi‑frame TIFF image using the first frame
                    using (TiffImage tiffImage = new TiffImage(frame1))
                    {
                        // Add the second frame with its distinct compression
                        tiffImage.AddFrame(frame2);

                        // Save the combined TIFF
                        tiffImage.Save(outputPath);
                    }
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
 * 1. When a developer needs to combine scanned documents from two different scanners into a single multi‑page TIFF where the first pages use LZW compression for color images and the later pages use CCITT Group 3 compression for black‑and‑white fax pages.
 * 2. When building a medical imaging archive that merges patient X‑ray TIFF files with accompanying color photographs, applying LZW to the photos and CCITT Group 3 to the X‑rays to minimize storage while preserving quality.
 * 3. When creating a legal e‑discovery bundle that merges high‑resolution TIFF evidence with low‑resolution faxed copies, using different compression settings per frame to meet court‑mandated file size limits.
 * 4. When developing a document management system that assembles multi‑page TIFF reports from separate source files, assigning LZW compression to the first color chart pages and CCITT Group 3 to the subsequent text‑only pages for optimal file size.
 * 5. When automating the generation of archival TIFF files that combine satellite imagery (color) and scanned map overlays (black‑and‑white), applying distinct compression types per frame to balance image fidelity and archival storage constraints.
 */