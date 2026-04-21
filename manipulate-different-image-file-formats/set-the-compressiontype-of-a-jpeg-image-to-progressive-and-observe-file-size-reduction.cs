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
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\sample_progressive.jpg";

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
            // Configure JPEG save options with progressive compression
            JpegOptions saveOptions = new JpegOptions
            {
                // Set progressive compression mode
                CompressionType = JpegCompressionMode.Progressive,
                // Preserve original quality (adjust as needed)
                Quality = 90,
                // Keep default resolution settings
                ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Save the image using the configured options
            image.Save(outputPath, saveOptions);
        }

        // Inform the user that processing is complete
        Console.WriteLine($"Image saved with progressive JPEG compression to: {outputPath}");
    }
}