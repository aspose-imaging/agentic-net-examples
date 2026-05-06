using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputWebPPath = @"c:\temp\input.webp";
            string bmpFramesDir = @"c:\temp\bmpframes\";
            string outputGifPath = @"c:\temp\output.gif";

            // Validate input file existence
            if (!File.Exists(inputWebPPath))
            {
                Console.Error.WriteLine($"File not found: {inputWebPPath}");
                return;
            }

            // Ensure directories exist
            Directory.CreateDirectory(bmpFramesDir);
            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            // Load the animated WebP image
            using (WebPImage webPImage = new WebPImage(inputWebPPath))
            {
                // Cast to multipage interface to access frames
                var multipage = webPImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                // Export each frame to a BMP file
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    var frame = (RasterImage)multipage.Pages[i];
                    string bmpPath = Path.Combine(bmpFramesDir, $"frame_{i}.bmp");
                    frame.Save(bmpPath, new BmpOptions());
                }

                // Create GIF animation from the exported BMP frames
                // Load the first BMP as the initial frame block
                string firstBmpPath = Path.Combine(bmpFramesDir, "frame_0.bmp");
                var firstRaster = (RasterImage)Image.Load(firstBmpPath);
                using (var gifImage = new GifImage(new GifFrameBlock(firstRaster)))
                {
                    // Add remaining frames
                    for (int i = 1; i < multipage.PageCount; i++)
                    {
                        string bmpPath = Path.Combine(bmpFramesDir, $"frame_{i}.bmp");
                        var raster = (RasterImage)Image.Load(bmpPath);
                        gifImage.AddPage(raster);
                    }

                    // Save the resulting GIF
                    gifImage.Save(outputGifPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}