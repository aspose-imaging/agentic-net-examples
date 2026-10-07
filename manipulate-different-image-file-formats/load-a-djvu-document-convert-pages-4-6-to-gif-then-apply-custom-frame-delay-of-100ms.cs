// HOW-TO: Convert DjVu Pages 4 to 6 Into GIF With Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = Path.Combine("Output", "output.gif");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    gifOptions.MultiPageOptions = new MultiPageOptions(new IntRange(3, 5));
                    djvu.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a specific range of pages from a multi‑page DjVu file and create an animated GIF for quick web preview.
 * 2. When you want to generate a lightweight GIF slideshow from selected DjVu pages to embed in a mobile application.
 * 3. When building a document conversion service that must turn only certain DjVu pages into a single GIF file for email attachments.
 * 4. When automating batch processing of DjVu documents, converting just the required pages to GIF to reduce storage and bandwidth usage.
 * 5. When creating a digital archive and require a fast visual thumbnail animation of particular DjVu pages using C#.
 */
