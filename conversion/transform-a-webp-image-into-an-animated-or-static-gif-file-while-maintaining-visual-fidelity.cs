using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input WebP file and output GIF file paths
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        // Load the WebP image (supports both static and animated WebP)
        using (Image webpImage = Image.Load(inputPath))
        {
            // Prepare GIF export options
            GifOptions gifOptions = new GifOptions();
            // Uncomment the following line to set infinite loop for animated GIFs
            // gifOptions.LoopsCount = 0;

            // Save the image as GIF, preserving animation if present
            webpImage.Save(outputPath, gifOptions);
        }
    }
}