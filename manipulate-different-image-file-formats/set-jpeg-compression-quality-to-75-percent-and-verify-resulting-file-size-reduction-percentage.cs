using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output_75.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Get original file size
        long originalSize = new FileInfo(inputPath).Length;

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Configure JPEG options with 75% quality
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 75
            };

            // Save the image using the JPEG options
            image.Save(outputPath, jpegOptions);
        }

        // Get compressed file size
        long compressedSize = new FileInfo(outputPath).Length;

        // Calculate reduction percentage
        double reduction = 0;
        if (originalSize > 0)
        {
            reduction = (double)(originalSize - compressedSize) / originalSize * 100;
        }

        // Output results
        Console.WriteLine($"Original size: {originalSize} bytes");
        Console.WriteLine($"Compressed size: {compressedSize} bytes");
        Console.WriteLine($"Size reduction: {reduction:F2}%");
    }
}