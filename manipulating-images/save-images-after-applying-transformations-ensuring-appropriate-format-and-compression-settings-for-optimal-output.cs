using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply a rotation, and save with JPEG options
        using (Image image = Image.Load(inputPath))
        {
            // Rotate the image 90 degrees clockwise
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Configure JPEG save options for optimal quality/compression
            var jpegOptions = new JpegOptions
            {
                Quality = 85, // Quality range 1-100
                CompressionType = JpegCompressionMode.Progressive
            };

            // Save the transformed image
            image.Save(outputPath, jpegOptions);
        }
    }
}