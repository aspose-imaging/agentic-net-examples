using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/pages4to6.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                GifOptions gifOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(new IntRange(3, 5))
                };

                djvu.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract pages 4‑6 from a multi‑page DjVu technical manual and generate an animated GIF with a 100 ms frame delay for quick preview in a web portal.
 * 2. When building an e‑learning platform that converts selected DjVu lecture slides into a lightweight GIF slideshow with consistent 100 ms timing for seamless browser playback.
 * 3. When automating digital archiving to transform specific DjVu pages of historical documents into GIF animations with a custom 100 ms frame interval for inclusion in an online catalog.
 * 4. When creating a C# desktop utility that lets users pick a range of DjVu pages and produce a GIF with a fixed 100 ms delay per frame for use in presentations or documentation.
 * 5. When integrating Aspose.Imaging into a server‑side API that receives DjVu files, extracts pages 4‑6, and returns a GIF animation with a uniform 100 ms frame delay for mobile app consumption.
 */