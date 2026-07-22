using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDir = "output";
            string pngPath2 = Path.Combine(outputDir, "page2.png");
            string pngPath4 = Path.Combine(outputDir, "page4.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(pngPath2));
            Directory.CreateDirectory(Path.GetDirectoryName(pngPath4));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                if (djvu.Pages.Length > 1)
                {
                    djvu.Pages[1].Save(pngPath2, new PngOptions());
                }
                else
                {
                    Console.Error.WriteLine("Page 2 does not exist.");
                }

                if (djvu.Pages.Length > 3)
                {
                    djvu.Pages[3].Save(pngPath4, new PngOptions());
                }
                else
                {
                    Console.Error.WriteLine("Page 4 does not exist.");
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
 * 1. When a developer needs to extract specific pages (e.g., page 2 and page 4) from a multi‑page Djvu document and save them as high‑quality PNG images for further processing or display.
 * 2. When an archival system must convert selected Djvu pages to lossless PNG files before performing OCR or text extraction on those pages.
 * 3. When a web application wants to generate thumbnail previews of particular Djvu pages by converting them to PNG format on the server side.
 * 4. When a document‑management workflow requires isolating individual Djvu pages as PNG assets to embed them into HTML reports or email attachments.
 * 5. When a batch‑processing script needs to validate the existence of certain Djvu pages and export them as PNG files for quality‑control or printing purposes.
 */