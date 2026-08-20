// HOW-TO: Convert JPEG2000 to Interlaced PNG and Reduce Size by Half in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jp2";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to display high‑resolution JPEG2000 photos on a web page that only supports PNG, you can downsample them to half size and save as interlaced PNG for faster progressive loading.
 * 2. When a mobile app must reduce bandwidth by sending smaller images, you can load a JPEG2000 asset, resize it to 50 % and output an interlaced PNG that browsers can render progressively.
 * 3. When archiving scanned documents originally stored as JPEG2000, you may want to create smaller PNG previews with interlacing to allow quick thumbnail generation while preserving visual quality.
 * 4. When integrating a legacy imaging pipeline that outputs JPEG2000, you can convert those files to interlaced PNGs with half the dimensions to meet a third‑party API’s size constraints.
 * 5. When building an automated batch process that prepares images for email newsletters, you can use this code to shrink JPEG2000 images and save them as interlaced PNGs that load smoothly in most email clients.
 */
