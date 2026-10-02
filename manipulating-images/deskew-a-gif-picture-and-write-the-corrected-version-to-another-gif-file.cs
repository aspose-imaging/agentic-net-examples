// HOW-TO: How To Deskew A GIF Image And Save As New GIF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\sample.gif";
            string outputPath = "output\\deskewed.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.Pages.Count() == 0)
                {
                    Console.Error.WriteLine("No frames found in the GIF.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];
                RasterImage raster = (RasterImage)gif.ActiveFrame;

                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.NormalizeAngle(false, Aspose.Imaging.Color.White);

                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive scanned animated GIFs that are slightly rotated and need to be straightened before displaying on a website.
 * 2. When an application must automatically correct the orientation of user‑uploaded GIF stickers for a messaging app.
 * 3. When a batch job processes legacy GIF assets and requires deskewing each file to improve OCR accuracy.
 * 4. When you need to normalize the angle of the first frame of a multi‑frame GIF while preserving the original animation.
 * 5. When a .NET service generates thumbnails from rotated GIF screenshots and must save the corrected image as a new GIF file.
 */
