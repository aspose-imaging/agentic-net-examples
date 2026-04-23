using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the existing TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create options for the new frame with a custom photometric interpretation
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.BitsPerSample = new ushort[] { 1 }; // 1-bit per sample for B/W
                frameOptions.Photometric = TiffPhotometrics.MinIsBlack; // Custom photometric
                frameOptions.Compression = TiffCompressions.None; // No compression for the frame

                // Create a new 100x100 frame using the above options
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Fill the new frame with solid black
                SolidBrush brush = new SolidBrush(Color.Black);
                Graphics graphics = new Graphics(newFrame);
                graphics.FillRectangle(brush, newFrame.Bounds);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Prepare save options to use JPEG compression
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                saveOptions.CompressedQuality = 80; // JPEG quality
                saveOptions.Photometric = TiffPhotometrics.Rgb; // Photometric for saved image
                saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 }; // 8 bits per channel

                // Save the updated TIFF image
                tiffImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}