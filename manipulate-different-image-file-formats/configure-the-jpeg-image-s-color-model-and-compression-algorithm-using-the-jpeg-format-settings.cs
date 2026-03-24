using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional call)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options
            JpegOptions saveOptions = new JpegOptions
            {
                // Set desired color model (e.g., YCbCr)
                ColorType = JpegCompressionColorMode.YCbCr,
                // Set compression algorithm (e.g., Progressive)
                CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                // Optional: set quality (1-100)
                Quality = 90,
                // Optional: set bits per channel
                BitsPerChannel = 8,
                // Optional: set resolution
                ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Save the image as JPEG with the configured options
            image.Save(outputPath, saveOptions);
        }
    }
}