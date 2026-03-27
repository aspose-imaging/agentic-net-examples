using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample_converted.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configurable JPEG quality (1-100)
        int jpegQuality = 85;

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare JPEG save options
            JpegOptions saveOptions = new JpegOptions
            {
                // Set desired quality
                Quality = jpegQuality,
                // Optional: set progressive compression
                CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                // Optional: set resolution (96 DPI)
                ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Save the image as JPEG using the specified options
            image.Save(outputPath, saveOptions);
        }
    }
}