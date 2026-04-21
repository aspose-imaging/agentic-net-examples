using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\sample_converted.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired JPEG quality (1‑100). Adjust as needed.
        int jpegQuality = 85;

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options
            JpegOptions jpegOptions = new JpegOptions
            {
                // Set the compression quality
                Quality = jpegQuality,

                // Optional: set progressive compression
                CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,

                // Optional: keep default resolution (96 DPI) or set explicitly
                ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Save the image as JPEG using the configured options
            image.Save(outputPath, jpegOptions);
        }
    }
}