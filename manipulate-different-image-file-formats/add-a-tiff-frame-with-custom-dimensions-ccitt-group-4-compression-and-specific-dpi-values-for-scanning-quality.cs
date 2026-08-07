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
        // Hardcoded paths
        string outputPath = @"c:\temp\custom_scanned.tif";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options for a 1‑bit B/W image with CCITT Group 4 compression
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 1 };                     // 1 bit per pixel
            tiffOptions.Compression = TiffCompressions.CcittFax4;               // CCITT Group 4
            tiffOptions.Photometric = TiffPhotometrics.MinIsBlack;             // 0 = black, 1 = white
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;    // single plane

            // Create a frame with custom dimensions (e.g., 2480 × 3508 for A4 at 300 dpi)
            int frameWidth = 2480;   // width in pixels
            int frameHeight = 3508;  // height in pixels
            TiffFrame frame = new TiffFrame(tiffOptions, frameWidth, frameHeight);

            // Set DPI (resolution) for scanning quality
            frame.HorizontalResolution = 300; // 300 dpi horizontal
            frame.VerticalResolution = 300;   // 300 dpi vertical

            // Optionally fill the frame with white (background) – not required for B/W
            // using (Graphics g = new Graphics(frame))
            // {
            //     g.Clear(Color.White);
            // }

            // Create a TIFF image containing the single frame
            using (TiffImage tiffImage = new TiffImage(frame))
            {
                // Save the TIFF image to the specified path
                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to generate a high‑resolution black‑and‑white scanned document (e.g., an A4 page at 300 dpi) in TIFF format with CCITT Group 4 compression for efficient storage or fax transmission.
 * 2. When a C# application must create a custom‑sized TIFF frame (e.g., 2480 × 3508 pixels) that matches a specific paper size and embeds exact horizontal and vertical DPI values for downstream printing or OCR pipelines.
 * 3. When a developer is building a document‑management system that stores scanned images as 1‑bit B/W TIFF files with MinIsBlack photometric interpretation to ensure consistent rendering across different viewers.
 * 4. When an imaging service needs to programmatically produce single‑frame TIFF files with contiguous planar configuration and CCITT Fax 4 compression to meet archival standards for legal or medical records.
 * 5. When a .NET solution integrates Aspose.Imaging to automate the creation of scan‑quality TIFF images that can be directly saved to a file system, preserving precise resolution metadata for later image analysis.
 */