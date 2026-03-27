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
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\sample_baseline.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG save options with Baseline compression
            JpegOptions saveOptions = new JpegOptions
            {
                // Baseline compression is widely supported by older JPEG viewers
                CompressionType = JpegCompressionMode.Baseline,
                // Set quality to a typical high value (adjust as needed)
                Quality = 90
            };

            // Save the image as JPEG using the configured options
            image.Save(outputPath, saveOptions);
        }

        Console.WriteLine($"Image saved with Baseline compression to: {outputPath}");
    }
}