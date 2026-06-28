using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "Output/output.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure frame options: 1-bit B/W, CCITT Group 4 compression
            var frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 1 };
            frameOptions.Compression = TiffCompressions.CcittFax4;
            frameOptions.Photometric = TiffPhotometrics.MinIsBlack;

            // Create a TIFF frame with custom dimensions
            int frameWidth = 200;
            int frameHeight = 200;
            using (var frame = new TiffFrame(frameOptions, frameWidth, frameHeight))
            {
                // Create a TIFF image from the frame
                using (var tiffImage = new TiffImage(frame))
                {
                    // Set DPI values for scanning quality
                    tiffImage.HorizontalResolution = 300;
                    tiffImage.VerticalResolution = 300;

                    // Save the TIFF image
                    tiffImage.Save(outputPath);
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
 * 1. When a developer needs to generate a high‑resolution black‑and‑white scanned document in TIFF format with CCITT Group 4 compression for archival storage, they can use this code to create a 200 × 200 pixel frame with 300 dpi resolution.
 * 2. When building a document‑management system that must produce compact, searchable fax‑style images, this snippet shows how to create a 1‑bit TIFF page with custom dimensions and set the DPI to match typical scanner output.
 * 3. When integrating Aspose.Imaging into a C# application that exports medical imaging reports as lossless, 1‑bit TIFF files, the example demonstrates setting the photometric interpretation, compression, and resolution for compliance with DICOM standards.
 * 4. When a developer wants to programmatically generate thumbnail previews of large scanned maps in TIFF format while preserving scan quality, the code illustrates creating a small‑size frame with CCITT Group 4 compression and explicit horizontal and vertical resolution values.
 * 5. When automating the creation of batch‑processed legal documents that require exact DPI settings for court‑accepted TIFF files, this example provides the steps to define frame size, compression, and resolution using Aspose.Imaging for .NET.
 */