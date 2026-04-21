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
            string outputPath = @"C:\Temp\scanned.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options for the frame
            var frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.Compression = TiffCompressions.CcittFax4; // CCITT Group 4 compression
            frameOptions.Photometric = TiffPhotometrics.MinIsBlack; // 0 = black, 1 = white
            frameOptions.BitsPerSample = new ushort[] { 1 }; // 1‑bit per pixel

            // Custom dimensions (e.g., A4 at 300 DPI)
            int width = 2480;   // 8.27 in × 300 dpi
            int height = 3508;  // 11.69 in × 300 dpi

            // Create the TIFF frame with the specified options and size
            var frame = new TiffFrame(frameOptions, width, height);

            // Create a TIFF image containing the frame
            using (var tiffImage = new TiffImage(frame))
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