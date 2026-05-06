using System;
using System.IO;
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
            string outputPath = "output\\custom.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure frame options with CCITT Group 4 compression
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 1 };
            frameOptions.ByteOrder = TiffByteOrder.LittleEndian;
            frameOptions.Compression = TiffCompressions.CcittFax4;
            frameOptions.Photometric = TiffPhotometrics.MinIsBlack;
            frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

            // Create a TIFF frame with custom dimensions
            TiffFrame frame = new TiffFrame(frameOptions, 1024, 768);

            // Create TIFF image from the frame and set DPI values
            using (TiffImage tiffImage = new TiffImage(frame))
            {
                tiffImage.HorizontalResolution = 300; // DPI X
                tiffImage.VerticalResolution = 300;   // DPI Y

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