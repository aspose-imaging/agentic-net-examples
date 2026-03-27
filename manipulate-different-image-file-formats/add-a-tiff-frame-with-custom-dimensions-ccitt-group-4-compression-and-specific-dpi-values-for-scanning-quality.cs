using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load existing TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Create options for the new frame
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.BitsPerSample = new ushort[] { 1 }; // 1 bit per pixel (B/W)
            frameOptions.ByteOrder = TiffByteOrder.LittleEndian;
            frameOptions.Compression = TiffCompressions.CcittFax4; // CCITT Group 4
            frameOptions.Photometric = TiffPhotometrics.MinIsBlack; // 0 = black, 1 = white

            // Define custom dimensions for the new frame
            int frameWidth = 1200;
            int frameHeight = 1800;

            // Create the new TIFF frame
            TiffFrame newFrame = new TiffFrame(frameOptions, frameWidth, frameHeight);

            // Add the new frame to the TIFF image
            tiffImage.AddFrame(newFrame);

            // Set DPI values for scanning quality
            tiffImage.HorizontalResolution = 300f; // 300 DPI horizontal
            tiffImage.VerticalResolution = 300f;   // 300 DPI vertical

            // Save the modified TIFF image
            tiffImage.Save(outputPath);
        }
    }
}