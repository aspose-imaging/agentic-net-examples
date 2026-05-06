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
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Options for the new frame with custom photometric interpretation
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Photometric = TiffPhotometrics.MinIsBlack;
                frameOptions.BitsPerSample = new ushort[] { 8 };

                // Create a new frame (100x100 pixels)
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Fill the new frame with a solid gray color
                Graphics graphics = new Graphics(newFrame);
                SolidBrush brush = new SolidBrush(Color.Gray);
                graphics.FillRectangle(brush, newFrame.Bounds);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the updated TIFF using JPEG compression
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Jpeg;
                saveOptions.CompressedQuality = 75;
                saveOptions.Photometric = TiffPhotometrics.Rgb;

                tiffImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}