using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.jpg";
            string outputPath = @"c:\temp\sample_resized.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Desired width
                int newWidth = 1200;
                // Calculate height to preserve aspect ratio
                int newHeight = (int)((double)jpegImage.Height * newWidth / jpegImage.Width);

                // Resize image
                jpegImage.Resize(newWidth, newHeight);

                // Save as PNG
                jpegImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}