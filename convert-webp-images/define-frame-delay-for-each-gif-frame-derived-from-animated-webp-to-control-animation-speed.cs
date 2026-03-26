using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/animation.webp";
        string outputPath = "Output/animation.gif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the animated WebP image
        using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
        {
            // Ensure there is at least one frame
            if (webpImage.Pages.Length == 0)
            {
                Console.Error.WriteLine("No frames found in the WebP image.");
                return;
            }

            // Create the first GIF frame from the first WebP page
            using (GifImage gifImage = new GifImage(new GifFrameBlock((RasterImage)webpImage.Pages[0])))
            {
                // Add remaining frames
                for (int i = 1; i < webpImage.Pages.Length; i++)
                {
                    gifImage.AddPage(new GifFrameBlock((RasterImage)webpImage.Pages[i]));
                }

                // Define uniform frame delay (in milliseconds) for all frames
                gifImage.SetFrameTime(100); // 100 ms per frame

                // Save the GIF with default options
                gifImage.Save(outputPath, new GifOptions());
            }
        }
    }
}