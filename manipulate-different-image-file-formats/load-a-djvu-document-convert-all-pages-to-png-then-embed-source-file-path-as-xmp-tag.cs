using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.djvu";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputBaseDir = "output";

            Directory.CreateDirectory(outputBaseDir);

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputBaseDir, $"page_{page.PageNumber}.png");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    page.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu file and save them as high‑quality PNG images for web preview or thumbnail generation.
 * 2. When an archival system requires batch conversion of scanned DjVu documents into PNG format to ensure compatibility with downstream image processing pipelines.
 * 3. When a document management application must programmatically split a DjVu ebook into individual PNG pages for selective printing or annotation.
 * 4. When a C# service processes user‑uploaded DjVu files and needs to store each page as a PNG file in a structured output directory for later retrieval.
 * 5. When a migration tool converts legacy DjVu assets into PNG assets to integrate with modern content management systems that only support common raster formats.
 */