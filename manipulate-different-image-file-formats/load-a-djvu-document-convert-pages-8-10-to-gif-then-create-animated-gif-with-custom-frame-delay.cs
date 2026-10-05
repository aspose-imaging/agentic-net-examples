// HOW-TO: Convert DjVu Pages 8 to 10 to Animated GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\document.djvu";
        string outputPath = "Output\\pages_8_10.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                using (GifOptions gifOptions = new GifOptions())
                {
                    gifOptions.MultiPageOptions = new MultiPageOptions(new IntRange(8, 10));
                    gifOptions.LoopsCount = 0; // infinite loop

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
 * 1. When you need to extract a specific range of pages from a DjVu document and display them as an animated GIF on a website.
 * 2. When creating a preview animation of selected DjVu pages for a digital library or e‑book catalog.
 * 3. When generating a looping GIF slideshow of particular pages for a presentation or marketing material.
 * 4. When converting scanned multi‑page DjVu files into lightweight GIF animations for mobile apps with limited bandwidth.
 * 5. When automating batch processing to produce animated GIFs of specific DjVu pages for archival or documentation purposes.
 */
