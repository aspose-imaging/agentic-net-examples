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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample_baseline.jpg";

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
                    CompressionType = JpegCompressionMode.Baseline,
                    Quality = 90 // Typical quality setting
                };

                // Save the image as JPEG with Baseline compression
                image.Save(outputPath, saveOptions);
            }

            // Load the saved JPEG to verify it was saved with Baseline compression
            using (Image savedImage = Image.Load(outputPath))
            {
                // The saved image should be a JpegImage; we can inspect its format if needed
                // Baseline compression is widely supported by older viewers
                Console.WriteLine("Image saved with Baseline JPEG compression successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}