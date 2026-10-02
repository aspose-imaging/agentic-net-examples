// HOW-TO: Convert First Fifteen DjVu Pages To BMP Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\document.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = Math.Min(15, djvuImage.Pages.Length);
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image page = djvuImage.Pages[i])
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        page.Save(outputPath, bmpOptions);
                    }
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
 * 1. When you need to extract the first fifteen pages of a multi‑page DjVu file and save them as BMP images for legacy Windows applications.
 * 2. When a document‑management system must generate bitmap thumbnails from DjVu scans without custom dithering settings.
 * 3. When an archival workflow requires converting DjVu pages to BMP format for compatibility with older image‑processing tools.
 * 4. When a batch‑processing service has to automate the conversion of DjVu pages to BMP files for printing pipelines that only accept BMP.
 * 5. When you want to quickly prototype a C# utility that loads a DjVu document and saves up to fifteen pages as BMP using Aspose.Imaging’s default options.
 */
