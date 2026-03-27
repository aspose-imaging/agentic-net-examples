using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image (animated)
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF options with infinite loop
            GifOptions gifOptions = new GifOptions
            {
                LoopsCount = 0 // 0 means infinite looping
            };

            // Save as animated GIF preserving frames
            image.Save(outputPath, gifOptions);
        }
    }
}