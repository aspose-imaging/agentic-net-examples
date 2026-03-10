using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (provide via command line or use defaults)
        string inputPath = args.Length > 0 ? args[0] : "input.webp";
        string outputPath = args.Length > 1 ? args[1] : "output.gif";

        // Load the WebP image
        using (Image webpImage = Image.Load(inputPath))
        {
            // Configure GIF export options with custom settings
            using (GifOptions gifOptions = new GifOptions())
            {
                // Example custom settings
                gifOptions.LoopsCount = 0; // 0 = infinite loop
                gifOptions.BackgroundColor = Color.White; // Set background color
                // Additional settings can be configured here as needed

                // Save as GIF using the configured options
                webpImage.Save(outputPath, gifOptions);
            }
        }
    }
}