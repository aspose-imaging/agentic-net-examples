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
            long newSize = new FileInfo(outputPath).Length;
            double reductionPercent = (double)(originalSize - newSize) / originalSize * 100.0;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {newSize} bytes");
            Console.WriteLine($"File size reduced by {reductionPercent:F2}%");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}