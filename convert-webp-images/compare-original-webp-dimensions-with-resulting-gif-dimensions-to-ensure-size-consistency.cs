using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputWebPPath = "input.webp";
        string outputGifPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputWebPPath))
        {
            Console.Error.WriteLine($"File not found: {inputWebPPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

        // Load the WebP image
        using (Image webpImage = Image.Load(inputWebPPath))
        {
            int webpWidth = webpImage.Width;
            int webpHeight = webpImage.Height;

            // Save as GIF using default options
            GifOptions gifOptions = new GifOptions();
            webpImage.Save(outputGifPath, gifOptions);
            
            // Load the resulting GIF image
            using (Image gifImage = Image.Load(outputGifPath))
            {
                int gifWidth = gifImage.Width;
                int gifHeight = gifImage.Height;

                // Output dimensions and comparison result
                Console.WriteLine($"WebP dimensions: {webpWidth}x{webpHeight}");
                Console.WriteLine($"GIF dimensions: {gifWidth}x{gifHeight}");

                if (webpWidth == gifWidth && webpHeight == gifHeight)
                {
                    Console.WriteLine("Dimensions match.");
                }
                else
                {
                    Console.WriteLine("Dimensions do NOT match.");
                }
            }
        }
    }
}