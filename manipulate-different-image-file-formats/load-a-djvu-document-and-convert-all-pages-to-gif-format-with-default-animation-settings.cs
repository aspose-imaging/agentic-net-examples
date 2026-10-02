// HOW-TO: Convert Multi‑Page DjVu to Animated GIF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\document.djvu";
            string outputPath = "Output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                gifOptions.MultiPageOptions = new MultiPageOptions(new IntRange(0, djvu.Pages.Length - 1));
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
 * 1. When you need to display a multi‑page DjVu document as an animated GIF on a web page without installing a DjVu viewer.
 * 2. When you want to generate lightweight GIF previews of scanned books stored in DjVu format for mobile applications.
 * 3. When an e‑learning platform requires converting lecture notes in DjVu to looping GIFs for slide‑show playback.
 * 4. When a document‑management system must archive DjVu files as GIF animations to ensure compatibility with legacy image viewers.
 * 5. When you are building a batch‑processing tool that automatically transforms all pages of a DjVu file into a single animated GIF using default settings.
 */
