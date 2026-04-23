using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\sample.bmp";
            string outputPath = @"c:\temp\sample_progressive.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set up JPEG save options with progressive compression
                JpegOptions saveOptions = new JpegOptions
                {
                    BitsPerChannel = 8,
                    CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                    Quality = 90, // Adjust quality as needed
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the image using the configured options
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}