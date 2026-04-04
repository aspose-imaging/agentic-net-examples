using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input/animation.gif";
        string outputPath = "output/animated_gamma.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            GifImage gif = (GifImage)image;

            // Adjust gamma to balance luminance (example gamma value)
            gif.AdjustGamma(1.2f);

            // Prepare GIF save options (e.g., infinite looping)
            GifOptions options = new GifOptions
            {
                LoopsCount = 0 // 0 means infinite loop
            };

            // Save the adjusted animated GIF
            gif.Save(outputPath, options);
        }
    }
}