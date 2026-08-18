// HOW-TO: Create Scanned TIFF with Custom Size and CCITT Group 4 Compression in C# (Aspose.Imaging for .NET)
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
            // Hardcoded output path
            string outputPath = "C:\\Temp\\scanned.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options for the frame
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 1 };                     // 1‑bit B/W
            frameOptions.Compression = TiffCompressions.CcittFax4;               // CCITT Group 4
            frameOptions.Photometric = TiffPhotometrics.MinIsBlack;             // 0 = black
            frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;    // single plane

            // Custom dimensions (example: A4 at 300 DPI)
            int width = 2480;   // 8.27 in × 300 dpi
            int height = 3508;  // 11.69 in × 300 dpi

            // Create the TIFF frame with the specified options and size
            TiffFrame scanFrame = new TiffFrame(frameOptions, width, height);

            // Create a TIFF image containing the frame
            using (TiffImage tiffImage = new TiffImage(scanFrame))
            {
                // Set DPI values for scanning quality
                tiffImage.HorizontalResolution = 300;
                tiffImage.VerticalResolution = 300;

                // Save the TIFF image
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
 * 1. When you need to generate a high‑resolution black‑and‑white scanned document such as a legal contract as a single‑page TIFF with CCITT Group 4 compression to minimize file size.
 * 2. When you must produce a TIFF image that matches a specific paper size (for example A4) at a defined DPI for archival or printing workflows.
 * 3. When integrating a document‑scanning module that requires setting horizontal and vertical resolution metadata to ensure consistent display across devices.
 * 4. When building a batch‑processing tool that converts raw scan data into a standards‑compliant TIFF with 1‑bit per pixel and contiguous planar configuration.
 * 5. When developing a medical‑imaging application that stores X‑ray or microscope images as compressed black‑and‑white TIFFs with precise dimensions and resolution.
 */
