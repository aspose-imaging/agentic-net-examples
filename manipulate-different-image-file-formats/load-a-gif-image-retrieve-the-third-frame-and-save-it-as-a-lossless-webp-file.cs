using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the GIF image
        using (Image img = Image.Load(inputPath))
        {
            GifImage gif = img as GifImage;
            if (gif == null)
            {
                Console.Error.WriteLine("The loaded file is not a GIF image.");
                return;
            }

            // Ensure the GIF has at least three frames (zero‑based index 2)
            if (gif.PageCount < 3)
            {
                Console.Error.WriteLine("The GIF does not contain a third frame.");
                return;
            }

            // Set the active frame to the third frame
            gif.ActiveFrame = (GifFrameBlock)gif.Pages[2];

            // Cast the active frame to RasterImage
            RasterImage frameRaster = (RasterImage)gif.ActiveFrame;

            // Create a WebP image from the raster frame
            using (WebPImage webp = new WebPImage(frameRaster))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure lossless WebP options
                WebPOptions options = new WebPOptions
                {
                    Lossless = true
                };

                // Save the frame as a lossless WebP file
                webp.Save(outputPath, options);
            }
        }
    }
}