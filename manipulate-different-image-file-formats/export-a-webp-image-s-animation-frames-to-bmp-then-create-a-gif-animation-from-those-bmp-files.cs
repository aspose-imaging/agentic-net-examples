using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded paths
            string inputWebPPath = @"C:\temp\input.webp";
            string bmpFramesDir = @"C:\temp\bmpFrames";
            string outputGifPath = @"C:\temp\output.gif";

            // Validate input file
            if (!File.Exists(inputWebPPath))
            {
                Console.Error.WriteLine($"File not found: {inputWebPPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(bmpFramesDir);
            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            // Load the animated WebP image
            using (WebPImage webPImage = new WebPImage(inputWebPPath))
            {
                // Cast to multipage interface to access frames
                IMultipageImage multipage = webPImage as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP image.");
                    return;
                }

                // Extract each frame to a BMP file
                List<string> bmpPaths = new List<string>();
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Each page is a RasterImage
                    RasterImage frame = (RasterImage)multipage.Pages[i];
                    string bmpPath = Path.Combine(bmpFramesDir, $"frame_{i}.bmp");

                    // Ensure directory for this BMP (already created above, but keep rule)
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                    // Save frame as BMP
                    frame.Save(bmpPath, new BmpOptions());
                    bmpPaths.Add(bmpPath);
                }

                // Create GIF from the extracted BMP frames
                // Load the first frame to initialize the GIF image
                using (RasterImage firstFrame = (RasterImage)Image.Load(bmpPaths[0]))
                using (GifImage gifImage = new GifImage(new GifFrameBlock(firstFrame)))
                {
                    // Add remaining frames
                    for (int i = 1; i < bmpPaths.Count; i++)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(bmpPaths[i]))
                        {
                            gifImage.AddPage(frame);
                        }
                    }

                    // Save the GIF animation
                    gifImage.Save(outputGifPath, new GifOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}