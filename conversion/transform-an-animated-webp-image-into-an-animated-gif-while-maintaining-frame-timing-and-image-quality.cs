using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input animated WebP file and output animated GIF file paths
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        // Load the animated WebP image
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            // Cast to multipage interface to access frames
            var multipage = webpImage as Aspose.Imaging.IMultipageImage;
            if (multipage == null || multipage.PageCount == 0)
                return;

            // Collect raster frames from the WebP animation
            var rasterFrames = new List<RasterImage>();
            foreach (var page in multipage.Pages)
            {
                rasterFrames.Add((RasterImage)page);
            }

            // Create a GIF image using the first frame
            using (GifImage gifImage = new GifImage(new GifFrameBlock(rasterFrames[0])))
            {
                // Set default frame duration (in milliseconds)
                gifImage.SetFrameTime(100);

                // Add remaining frames preserving the same duration
                for (int i = 1; i < rasterFrames.Count; i++)
                {
                    gifImage.AddPage(rasterFrames[i]);
                    gifImage.SetFrameTime(100);
                }

                // Prepare GIF export options
                GifOptions gifOptions = new GifOptions
                {
                    FullFrame = true
                };

                // Save the animated GIF
                gifImage.Save(outputPath, gifOptions);
            }

            // Dispose raster frames after use
            foreach (var frame in rasterFrames)
            {
                frame.Dispose();
            }
        }
    }
}