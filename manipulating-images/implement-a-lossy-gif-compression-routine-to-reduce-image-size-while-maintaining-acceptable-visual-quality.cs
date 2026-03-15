using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Determine input and output file paths (defaults provided)
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output_lossy.gif";

        // Load the source image (any supported format)
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF options for lossy compression
            GifOptions gifOptions = new GifOptions
            {
                // Recommended value for a good balance between size and quality
                MaxDiff = 80,
                // Improves visual quality by optimizing the palette
                DoPaletteCorrection = true,
                // Interlacing is optional; set to false for smaller size
                Interlaced = false
            };

            // Save the image as a lossy GIF using the configured options
            image.Save(outputPath, gifOptions);
        }
    }
}