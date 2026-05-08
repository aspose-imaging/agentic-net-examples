using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\input.webp";
            string outputPath = @"c:\temp\output_resized.webp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image from the file
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Calculate new dimensions (half of the original size)
                int newWidth = webPImage.Width / 2;
                int newHeight = webPImage.Height / 2;

                // Resize using bilinear resampling for good quality
                webPImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Prepare save options with high quality (100)
                var saveOptions = new WebPOptions
                {
                    Lossless = false,   // lossy compression with high quality
                    Quality = 100f
                };

                // Save the resized image
                webPImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}