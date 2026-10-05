// HOW-TO: Create Animated GIF from Multiple TIFF Frames Using AddPage in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string tiffPath1 = "frame1.tif";
            string tiffPath2 = "frame2.tif";
            string tiffPath3 = "frame3.tif";
            string outputPath = "output/animated.gif";

            if (!File.Exists(tiffPath1))
            {
                Console.Error.WriteLine($"File not found: {tiffPath1}");
                return;
            }
            if (!File.Exists(tiffPath2))
            {
                Console.Error.WriteLine($"File not found: {tiffPath2}");
                return;
            }
            if (!File.Exists(tiffPath3))
            {
                Console.Error.WriteLine($"File not found: {tiffPath3}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image firstImg = Image.Load(tiffPath1))
            {
                int width = firstImg.Width;
                int height = firstImg.Height;

                GifOptions gifOptions = new GifOptions();

                using (GifImage gif = (GifImage)Image.Create(gifOptions, width, height))
                {
                    gif.SavePixels(gif.Bounds, ((RasterImage)firstImg).LoadPixels(firstImg.Bounds));

                    string[] additionalPaths = new string[] { tiffPath2, tiffPath3 };
                    foreach (string path in additionalPaths)
                    {
                        using (Image img = Image.Load(path))
                        {
                            gif.AddPage((RasterImage)img);
                        }
                    }

                    gif.Save(outputPath, gifOptions);
                }
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
 * 1. When you need to combine scanned document pages saved as TIFF files into a single animated GIF for quick web preview.
 * 2. When you want to generate a looping animation from a series of medical imaging TIFF slices for a diagnostic dashboard.
 * 3. When you have a collection of RAW camera TIFF images and must create a lightweight GIF slideshow for an email newsletter.
 * 4. When you must programmatically assemble TIFF frames into an animated GIF to display step‑by‑step changes in a reporting UI.
 * 5. When you are building a desktop utility that converts multi‑page TIFF invoices into an animated GIF for easier visual inspection.
 */
