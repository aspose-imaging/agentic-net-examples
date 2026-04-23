using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.webp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the WebP image
            using (WebPImage image = new WebPImage(inputPath))
            {
                // Determine central 200x200 crop rectangle
                int cropSize = 200;
                int left = (image.Width - cropSize) / 2;
                int top = (image.Height - cropSize) / 2;
                Rectangle rect = new Rectangle(left, top, cropSize, cropSize);

                // Perform cropping
                image.Crop(rect);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save with default options
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}