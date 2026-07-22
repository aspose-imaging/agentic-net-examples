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
            string outputPath = "Output/animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                if (djvuImage.PageCount < 3)
                {
                    Console.Error.WriteLine("DjVu document does not contain at least 3 pages.");
                    return;
                }

                var gifOptions = new GifOptions
                {
                    MultiPageOptions = new MultiPageOptions(new IntRange(0, 2))
                };

                djvuImage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract the first three pages of a multi‑page DjVu document and create a lightweight animated GIF for embedding in a web page.
 * 2. When an application must convert scanned DjVu pages of a technical manual into a GIF animation to provide a quick preview in a mobile app.
 * 3. When a document‑management system requires generating a GIF slideshow from the initial pages of a DjVu file for email attachment previews.
 * 4. When a digital publishing workflow automates the transformation of DjVu e‑books into animated GIFs to showcase sample content on a product catalog.
 * 5. When a C# utility needs to validate the presence of at least three pages in a DjVu file and then save those pages as a GIF animation for archival or sharing purposes.
 */