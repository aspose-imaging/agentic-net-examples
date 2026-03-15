using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input WebP file path (animated)
        string inputPath = args.Length > 0 ? args[0] : "input.webp";
        // Output animated GIF file path
        string outputPath = args.Length > 1 ? args[1] : "output.gif";

        // Load the animated WebP image
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            // Configure GIF options
            GifOptions gifOptions = new GifOptions();
            gifOptions.LoopsCount = 0; // infinite loop
            gifOptions.Source = new FileCreateSource(outputPath, false);
            // Create a GIF canvas with the same dimensions as the WebP image
            using (GifImage gifImage = (GifImage)Image.Create(gifOptions, webpImage.Width, webpImage.Height))
            {
                // Iterate through each frame of the WebP animation
                foreach (var frame in webpImage.Pages)
                {
                    // Each frame is a raster image; cast it accordingly
                    RasterImage rasterFrame = (RasterImage)frame;
                    // Create a GIF frame block from the raster frame
                    GifFrameBlock gifFrame = new GifFrameBlock(rasterFrame);
                    // Add the frame to the GIF image
                    gifImage.AddBlock(gifFrame);
                }
                // Save the animated GIF
                gifImage.Save();
            }
        }
    }
}