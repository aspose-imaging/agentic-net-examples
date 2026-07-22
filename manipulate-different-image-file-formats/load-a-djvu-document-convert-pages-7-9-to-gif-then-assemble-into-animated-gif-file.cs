using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 7, 8, 9 });
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
 * 1. When a developer needs to extract pages 7‑9 from a multi‑page DjVu document and generate an animated GIF for web preview using C# and Aspose.Imaging.
 * 2. When a digital archiving solution must convert selected DjVu pages into a lightweight GIF animation to embed in email newsletters or reports.
 * 3. When a mobile application requires turning specific DjVu pages into a GIF slideshow to display on low‑bandwidth devices.
 * 4. When an e‑learning platform wants to transform tutorial sections stored as DjVu pages into animated GIFs for interactive course material.
 * 5. When an automated document workflow creates quick visual indexes by converting particular DjVu pages into an animated GIF file.
 */