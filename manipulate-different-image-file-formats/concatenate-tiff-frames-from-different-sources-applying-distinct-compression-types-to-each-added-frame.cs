// HOW-TO: Create Multi‑Page TIFF from PNG and JPEG with Different Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath1 = @"c:\temp\input1.png";
            string inputPath2 = @"c:\temp\input2.jpg";
            string outputPath = @"c:\temp\output.tif";

            // Verify that the source files exist
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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first source image
            using (RasterImage srcImg1 = (RasterImage)Image.Load(inputPath1))
            {
                // Define TIFF options for the first frame (LZW compression, RGB)
                TiffOptions tiffOpts1 = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.BigEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };

                // Create a TIFF frame from the first image with the above options
                TiffFrame frame1 = new TiffFrame(srcImg1, tiffOpts1);

                // Load the second source image
                using (RasterImage srcImg2 = (RasterImage)Image.Load(inputPath2))
                {
                    // Define TIFF options for the second frame (CCITT Group 3, 1‑bit B/W)
                    TiffOptions tiffOpts2 = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        BitsPerSample = new ushort[] { 1 },
                        ByteOrder = TiffByteOrder.LittleEndian,
                        Compression = TiffCompressions.CcittFax3,
                        Photometric = TiffPhotometrics.MinIsBlack,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous
                    };

                    // Create a TIFF frame from the second image with the above options
                    TiffFrame frame2 = new TiffFrame(srcImg2, tiffOpts2);

                    // Assemble the multi‑frame TIFF image
                    using (TiffImage tiffImage = new TiffImage(new TiffFrame[] { frame1, frame2 }))
                    {
                        // Save the combined TIFF to the output path
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
 * 1. When you need to generate a multi‑page TIFF document that combines color PNG graphics and black‑and‑white JPEG scans, applying LZW compression to the color page and CCITT Group 3 compression to the monochrome page.
 * 2. When you are building a fax‑compatible archive where each page must use the appropriate compression method to minimize file size while preserving readability.
 * 3. When you want to bundle images from different sources into a single TIFF for medical imaging, using lossless compression for diagnostic images and bitonal compression for annotation pages.
 * 4. When you create a printable booklet that mixes high‑resolution photographs and line‑art, requiring separate compression settings for each page to meet publishing standards.
 * 5. When you develop a document‑management system that stores mixed‑format images as a single multi‑frame TIFF, assigning optimal compression per frame to reduce storage costs.
 */
