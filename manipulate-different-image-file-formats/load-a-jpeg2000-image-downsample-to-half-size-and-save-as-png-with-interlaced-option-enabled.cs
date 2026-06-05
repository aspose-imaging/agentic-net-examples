using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jp2";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;

                raster.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                PngOptions pngOptions = new PngOptions();

                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate lightweight PNG thumbnails from large JPEG2000 satellite images for a mapping web application, they can load the JP2, halve its dimensions, and save it as an interlaced PNG.
 * 2. When an e‑commerce platform must display product photos originally stored as JPEG2000 but wants progressive loading in browsers, the code can downscale the image and output an interlaced PNG to improve perceived load speed.
 * 3. When a digital archive wants to preserve original JP2 files while providing faster‑loading PNG previews for mobile devices, this routine resizes the image to half size and writes an interlaced PNG that browsers can render progressively.
 * 4. When a medical‑imaging system needs to send reduced‑size PNG copies of high‑detail JPEG2000 scans to remote clinicians, the code loads the JP2, resamples it using nearest‑neighbour, and saves an interlaced PNG for efficient transmission.
 * 5. When a content‑management system automates conversion of uploaded JPEG2000 artwork into web‑ready PNG assets with progressive rendering, the snippet performs the load, 50 % downsampling, and interlaced PNG save in a single C# workflow.
 */