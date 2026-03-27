using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.tif";
        string outputPath = @"c:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
        {
            // Options for the new frame with a custom photometric interpretation
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.Photometric = TiffPhotometrics.MinIsBlack; // custom photometric
            frameOptions.BitsPerSample = new ushort[] { 8 }; // 8 bits per sample

            // Create a simple raster image to serve as the frame content
            using (BmpImage bmp = new BmpImage(100, 100))
            {
                // Fill the bitmap with a solid gray color
                SolidBrush grayBrush = new SolidBrush(Color.Gray);
                using (Graphics gfx = new Graphics(bmp))
                {
                    gfx.FillRectangle(grayBrush, bmp.Bounds);
                }

                // Create a TIFF frame from the bitmap using the custom options
                TiffFrame newFrame = new TiffFrame(bmp, frameOptions);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);
            }

            // Save options: JPEG compression
            TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
            saveOptions.Compression = TiffCompressions.Jpeg;
            saveOptions.CompressedQuality = 80; // quality level (0-100)
            saveOptions.Photometric = TiffPhotometrics.Rgb;
            saveOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Save the updated TIFF image
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}