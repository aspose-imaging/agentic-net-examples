// HOW-TO: Convert Specific DjVu Pages to Animated GIF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\pages_4_6.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                var gifOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(new int[] { 3, 4, 5 })
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
 * 1. When you need to extract pages 4‑6 from a DjVu file and create an animated GIF for quick web preview.
 * 2. When you want to generate a lightweight GIF animation from selected DjVu pages to embed in documentation or tutorials.
 * 3. When you have a multi‑page DjVu e‑book and must produce a short GIF preview of a chapter for mobile users.
 * 4. When you need to convert scanned DjVu pages into a single GIF file to attach to an email without sending the large original document.
 * 5. When you are building a batch process that converts specific DjVu pages into GIFs for archival or content‑management systems.
 */
