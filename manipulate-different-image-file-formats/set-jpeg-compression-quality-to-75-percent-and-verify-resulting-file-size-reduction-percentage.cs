using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\output_75.jpg";

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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with 75% quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 75
                };

                // Save the image with the specified JPEG options
                image.Save(outputPath, jpegOptions);
            }

            // Get new file size
            long newSize = new FileInfo(outputPath).Length;

            // Calculate reduction percentage
            double reduction = 0;
            if (originalSize > 0)
            {
                reduction = ((double)(originalSize - newSize) / originalSize) * 100;
            }

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {newSize} bytes");
            Console.WriteLine($"Size reduction: {reduction:F2}%");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}