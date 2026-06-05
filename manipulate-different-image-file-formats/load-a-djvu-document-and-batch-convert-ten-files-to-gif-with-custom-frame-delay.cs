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
            string inputPath = "Input/sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                int pagesToConvert = Math.Min(10, djvu.PageCount);

                for (int i = 0; i < pagesToConvert; i++)
                {
                    using (DjvuPage page = (DjvuPage)djvu.Pages[i])
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.gif");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var gifOptions = new GifOptions();
                        page.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract the first ten pages of a DjVu document and generate GIF images for a web gallery preview.
 * 2. When an application must batch convert DjVu pages to GIF files with a custom frame delay for inclusion in an e‑learning module.
 * 3. When a document management system requires converting DjVu scans into lightweight GIF thumbnails to improve browsing performance.
 * 4. When a legacy workflow reads a DjVu file stream in C# and saves up to ten pages as GIFs for archival in a .NET environment.
 * 5. When a developer wants to automate the conversion of DjVu pages to GIF format to embed them in email newsletters without using external tools.
 */