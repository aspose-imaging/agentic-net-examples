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
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.gif";

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

            if (isAnimated)
            {
                // Save as GIF preserving all frames
                var gifOptions = new GifOptions
                {
                    // Export all frames; FullFrame ensures each frame is saved as a full image
                    FullFrame = true
                };
                webPImage.Save(outputPath, gifOptions);
                Console.WriteLine("Animated WebP detected and saved as GIF.");
            }
            else
            {
                Console.WriteLine("The WebP image is not animated; no GIF was created.");
            }
        }
    }
}