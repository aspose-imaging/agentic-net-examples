using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WebP file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.webp";
        // Output GIF file path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.gif";

        // Load the WebP image (static or animated)
        using (Image image = Image.Load(inputPath))
        {
            // Configure GIF options (default settings)
            GifOptions gifOptions = new GifOptions();

            // Save the image as GIF, preserving animation if present
            image.Save(outputPath, gifOptions);
        }
    }
}