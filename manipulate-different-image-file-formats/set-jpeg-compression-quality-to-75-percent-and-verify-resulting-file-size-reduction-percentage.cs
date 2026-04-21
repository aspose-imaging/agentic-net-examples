using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample_75.jpg";

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
            // Configure JPEG save options with 75% quality
            JpegOptions saveOptions = new JpegOptions
            {
                Quality = 75
            };

            // Save the image with the specified JPEG options
            image.Save(outputPath, saveOptions);
        }

        // Calculate file size reduction percentage
        long originalSize = new FileInfo(inputPath).Length;
        long compressedSize = new FileInfo(outputPath).Length;

        if (originalSize == 0)
        {
            Console.WriteLine("Original file size is zero, cannot compute reduction.");
            return;
        }

        double reductionPercent = (double)(originalSize - compressedSize) / originalSize * 100.0;

        Console.WriteLine($"Original size: {originalSize} bytes");
        Console.WriteLine($"Compressed size: {compressedSize} bytes");
        Console.WriteLine($"Size reduction: {reductionPercent:F2}%");
    }
}