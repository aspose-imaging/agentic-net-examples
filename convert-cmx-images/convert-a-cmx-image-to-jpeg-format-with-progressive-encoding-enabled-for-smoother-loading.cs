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
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG options with progressive compression
            JpegOptions jpegOptions = new JpegOptions
            {
                CompressionType = JpegCompressionMode.Progressive,
                Quality = 90 // optional quality setting
            };

            // Save as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}