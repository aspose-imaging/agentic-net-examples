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
        string outputPath = @"C:\Images\sample_progressive.jpg";

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
            // Configure JPEG save options with progressive compression
            JpegOptions saveOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Progressive,
                Quality = 90 // Adjust quality as needed
            };

            // Save the image using the configured options
            image.Save(outputPath, saveOptions);
        }

        Console.WriteLine($"Image saved with progressive JPEG compression to: {outputPath}");
    }
}