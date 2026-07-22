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
        string inputPath = "Input/sample.gif";
        string outputPath = "Output/frame3.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = image as GifImage;
                if (gif == null)
                {
                    Console.Error.WriteLine("The input file is not a GIF image.");
                    return;
                }

                if (gif.PageCount <= 2)
                {
                    Console.Error.WriteLine("The GIF does not contain a third frame.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[2];

                WebPOptions options = new WebPOptions
                {
                    Lossless = true
                };

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
 * 1. When creating a thumbnail gallery that extracts the third frame from an animated GIF and saves it as a lossless WebP image to improve web page load speed.
 * 2. When converting a specific frame of a marketing GIF into a high‑quality WebP file for use in responsive email campaigns that require sharp visuals.
 * 3. When processing user‑uploaded GIFs in a .NET web application to isolate the third frame as a preview image and store it in WebP format to reduce bandwidth consumption.
 * 4. When generating product‑detail visuals by extracting the third frame of a GIF demo and exporting it as a lossless WebP to maintain clarity on high‑resolution screens.
 * 5. When building an automated pipeline that extracts the third frame from a GIF animation and archives it in lossless WebP for future reuse without quality loss.
 */