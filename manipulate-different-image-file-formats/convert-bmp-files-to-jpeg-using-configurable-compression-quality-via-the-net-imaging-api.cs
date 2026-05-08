using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try/catch to handle unexpected errors gracefully.
        try
        {
            // Hardcoded input BMP file path.
            string inputPath = @"C:\temp\input.bmp";

            // Hardcoded output JPEG file path.
            string outputPath = @"C:\temp\output.jpg";

            // Desired JPEG quality (1-100).
            int quality = 85;

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure JPEG save options.
            JpegOptions saveOptions = new JpegOptions
            {
                Quality = quality,
                BitsPerChannel = 8,
                CompressionType = JpegCompressionMode.Progressive,
                ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Load the BMP image and save it as JPEG using the configured options.
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected error message.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}