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
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output_compressed.jpg";

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
                // Configure JPEG save options for high compression (low quality)
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 10, // Quality range 1-100, lower means higher compression
                    CompressionType = JpegCompressionMode.Baseline
                };

                // Save the compressed image
                image.Save(outputPath, saveOptions);
            }

            // Estimate quality impact by comparing file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;
            double reductionPercent = 100.0 * (originalSize - compressedSize) / originalSize;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
            Console.WriteLine($"Size reduction: {reductionPercent:F2}%");
            Console.WriteLine($"Applied JPEG quality setting: 10 (high compression)");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}