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
            string outputPath = @"C:\temp\sample_high_compression.jpg";

            // Verify input file exists
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
                // Configure JPEG options for high compression (low quality)
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 10, // Low quality value for strong compression (1-100)
                    CompressionType = JpegCompressionMode.Baseline
                };

                // Save the image with the specified JPEG options
                image.Save(outputPath, jpegOptions);
            }

            // Estimate: we set quality to 10, which represents high compression
            Console.WriteLine("Estimated saved JPEG quality: 10 (high compression).");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}