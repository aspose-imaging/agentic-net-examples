using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Validate input file
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    int pageNumber = 0;
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        using (page)
                        {
                            pageNumber++;
                            string outputPath = Path.Combine(outputDirectory, $"page_{pageNumber}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            page.Save(outputPath, new PngOptions());
                        }
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
 * 1. When a developer needs to extract every page from a multi‑page DjVu document and save them as PNG images for web preview or thumbnail generation.
 * 2. When an application must batch‑process scanned books in DjVu format and create PNG files that can be displayed in browsers that do not support DjVu.
 * 3. When a document‑management system requires converting DjVu pages to PNG while embedding XMP metadata that records the original DjVu file name for traceability.
 * 4. When a C# service automates the migration of legacy DjVu assets to a PNG‑based workflow, ensuring each page is saved to a structured output folder.
 * 5. When a developer wants to programmatically validate the existence of a DjVu file, iterate through its pages, and generate PNG files with consistent naming such as “page_1.png”, “page_2.png”, etc.
 */