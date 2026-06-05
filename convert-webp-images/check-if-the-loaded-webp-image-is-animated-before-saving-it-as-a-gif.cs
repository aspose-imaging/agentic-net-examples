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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.webp";
            string outputPath = @"C:\temp\output.gif";

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
                // Determine if the WebP image is animated (has more than one frame)
                bool isAnimated = false;
                if (webPImage is IMultipageImage multipage && multipage.PageCount > 1)
                {
                    isAnimated = true;
                }

                // Save as GIF. GifOptions will handle multi‑frame if the source is animated.
                GifOptions gifOptions = new GifOptions();
                // (Optional) you could set gifOptions.ColorTableSize, etc., if needed.

                webPImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}