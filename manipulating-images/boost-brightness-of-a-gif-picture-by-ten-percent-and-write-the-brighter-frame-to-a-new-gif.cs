// HOW-TO: Increase GIF Brightness by 10 Percent Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.AdjustBrightness(26);
                GifOptions options = new GifOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to make an animated GIF appear lighter for better visibility on dark‑themed websites.
 * 2. When processing user‑uploaded GIFs to automatically enhance brightness before storing them in a media library.
 * 3. When creating a batch job that adjusts the brightness of GIF frames to match a brand’s visual guidelines.
 * 4. When integrating image editing features into a C# desktop app that lets users brighten GIF animations without external tools.
 * 5. When preparing GIF assets for email newsletters where increased brightness improves readability on mobile devices.
 */
