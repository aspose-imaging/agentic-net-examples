// HOW-TO: Create Animated GIF From Specific DjVu Pages in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(6, 8));
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
 * 1. When you need to extract a range of pages from a DjVu document and combine them into a single animated GIF for web preview or documentation.
 * 2. When you want to generate lightweight animated previews of selected DjVu pages for mobile apps without converting the entire file.
 * 3. When you are building a batch process that converts scanned DjVu manuals into animated GIFs to embed in e‑learning platforms.
 * 4. When you need to programmatically create an animated GIF from pages 7‑9 of a DjVu file for a slide‑show or marketing material.
 * 5. When you must automate the conversion of specific DjVu pages to an animated GIF to meet accessibility guidelines for screen readers.
 */
