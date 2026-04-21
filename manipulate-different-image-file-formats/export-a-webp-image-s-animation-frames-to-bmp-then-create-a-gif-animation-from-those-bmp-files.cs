using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputWebPPath = @"C:\temp\input.webp";
            string bmpFramesDir = @"C:\temp\bmp_frames\";
            string outputGifPath = @"C:\temp\output.gif";

            // Input file existence check
            if (!File.Exists(inputWebPPath))
            {
                Console.Error.WriteLine($"File not found: {inputWebPPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(bmpFramesDir);
            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            // List to hold BMP file paths
            List<string> bmpPaths = new List<string>();

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

                // Extract each frame and save as BMP
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    // Each page is a RasterImage
                    var frame = (RasterImage)multipage.Pages[i];
                    string bmpPath = Path.Combine(bmpFramesDir, $"frame_{i}.bmp");

                    // Ensure directory for this BMP exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

                    // Save frame as BMP
                    frame.Save(bmpPath, new BmpOptions());

                    bmpPaths.Add(bmpPath);
                }
            }

            if (bmpPaths.Count == 0)
            {
                Console.Error.WriteLine("No BMP frames were created.");
                return;
            }

            // Create GIF animation from BMP frames
            // Load the first frame
            using (RasterImage firstFrame = (RasterImage)Image.Load(bmpPaths[0]))
            {
                // Initialize GIF with the first frame
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