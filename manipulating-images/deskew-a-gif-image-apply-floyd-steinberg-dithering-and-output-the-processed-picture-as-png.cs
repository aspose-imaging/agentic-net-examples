// HOW-TO: Deskew GIF and Apply Floyd Steinberg Dithering Then Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string inputPath = "input.gif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in GIF.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];

                using (RasterImage raster = (RasterImage)gif.ActiveFrame)
                {
                    raster.NormalizeAngle(false, Aspose.Imaging.Color.White);
                    raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                    PngOptions pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
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
 * 1. When you need to correct the rotation of scanned animated GIF frames and convert them to high‑quality PNGs for web display.
 * 2. When you want to reduce banding artifacts in a GIF by applying Floyd‑Steinberg dithering before saving as a lossless PNG.
 * 3. When an application processes user‑uploaded GIF stickers, deskews them, and stores the result as PNG thumbnails.
 * 4. When you are building a batch conversion tool that normalizes the angle of each GIF image and outputs PNGs with consistent color depth.
 * 5. When you need to integrate Aspose.Imaging in a C# service to transform legacy GIF graphics into PNG assets with proper orientation and dithering for printing.
 */
