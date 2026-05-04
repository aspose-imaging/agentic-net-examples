using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\input.webp";
            string outputPath = "c:\\temp\\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                int originalWidth = webPImage.Width;
                int originalHeight = webPImage.Height;

                // Save as GIF
                webPImage.Save(outputPath, new GifOptions());

                // Load the resulting GIF image
                using (GifImage gifImage = (GifImage)Image.Load(outputPath))
                {
                    int gifWidth = gifImage.Width;
                    int gifHeight = gifImage.Height;

                    // Compare dimensions
                    if (originalWidth == gifWidth && originalHeight == gifHeight)
                    {
                        Console.WriteLine($"Dimensions match: {gifWidth}x{gifHeight}");
                    }
                    else
                    {
                        Console.WriteLine($"Dimension mismatch. WebP: {originalWidth}x{originalHeight}, GIF: {gifWidth}x{gifHeight}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}