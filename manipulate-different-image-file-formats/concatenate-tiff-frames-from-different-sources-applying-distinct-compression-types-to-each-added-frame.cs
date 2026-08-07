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
            string inputPath1 = @"c:\temp\source1.tif";
            string inputPath2 = @"c:\temp\source2.tif";
            string outputPath = @"c:\temp\combined.tif";

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
            using (Image srcImg1 = Image.Load(inputPath1))
            {
                // Define compression for first frame (LZW)
                TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                    ByteOrder = TiffByteOrder.BigEndian
                };

                // Create first frame from the loaded image with its options
                TiffFrame frame1 = new TiffFrame(srcImg1 as RasterImage, options1);

                // Load second source image
                using (Image srcImg2 = Image.Load(inputPath2))
                {
                    // Define compression for second frame (CCITT Group 3 Fax)
                    TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.CcittFax3,
                        BitsPerSample = new ushort[] { 1 },
                        Photometric = TiffPhotometrics.MinIsBlack,
                        PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                        ByteOrder = TiffByteOrder.LittleEndian
                    };

                    // Create second frame from the loaded image with its options
                    TiffFrame frame2 = new TiffFrame(srcImg2 as RasterImage, options2);

                    // Create a multi-frame TIFF image using the two frames
                    using (TiffImage tiffImage = new TiffImage(new TiffFrame[] { frame1, frame2 }))
                    {
                        // Save the combined TIFF
                        tiffImage.Save(outputPath);
                    }

                    // Dispose second frame (optional, handled by TiffImage disposal)
                    frame2.Dispose();
                }

                // Dispose first frame (optional, handled by TiffImage disposal)
                frame1.Dispose();
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
 * 1. When a developer needs to merge scanned black‑and‑white documents and color photographs into a single multi‑page TIFF for archival, applying LZW compression to the color frames and CCITT Group 3 compression to the monochrome frames.
 * 2. When building a medical imaging pipeline that combines DICOM‑derived TIFF slices with patient report pages, using distinct TIFF compression types per frame to optimize quality and storage.
 * 3. When creating a printable catalog that mixes high‑resolution product images with low‑resolution barcode pages, and wants each page stored with the most suitable TIFF compression (LZW for images, CCITT Group 3 for barcodes).
 * 4. When automating the assembly of legal case bundles that contain typed text pages and attached color evidence photos, preserving the original compression (CCITT Group 3 for text, LZW for photos) in a single combined TIFF file.
 * 5. When developing a document management system that ingests TIFF files from multiple scanners, each using its own default compression, and needs to concatenate them into one multi‑frame TIFF while retaining the appropriate compression for each source frame.
 */