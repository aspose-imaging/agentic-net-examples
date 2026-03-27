using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hard‑coded)
        string outputPath = "output/output.webp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Default WebP options
        WebPOptions options = new WebPOptions();

        // Create a blank WebP image of 800x600 pixels
        using (WebPImage webPImage = new WebPImage(800, 600, options))
        {
            // Save the image to the specified path
            webPImage.Save(outputPath);
        }
    }
}