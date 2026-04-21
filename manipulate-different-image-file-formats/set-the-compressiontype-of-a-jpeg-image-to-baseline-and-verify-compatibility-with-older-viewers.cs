using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.jpg";

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
            // Configure JPEG options with Baseline compression
            JpegOptions jpegOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Baseline,
                Quality = 90 // optional quality setting
            };

            // Save the image as JPEG using the configured options
            image.Save(outputPath, jpegOptions);
        }
    }
}