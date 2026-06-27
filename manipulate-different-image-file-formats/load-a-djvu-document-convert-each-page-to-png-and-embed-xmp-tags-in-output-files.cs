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
        try
        {
            string inputPath = "Input/sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    int pageIndex = 0;
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        string outputPath = $"Output/page_{pageIndex}.png";

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        PngOptions pngOptions = new PngOptions();
                        page.Save(outputPath, pngOptions);

                        pageIndex++;
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
 * 1. When a digital archive needs to convert scanned DjVu manuscripts into high‑resolution PNG images with searchable XMP metadata for each page.
 * 2. When an e‑learning platform wants to extract individual pages from a DjVu textbook and generate PNG thumbnails that include XMP tags for licensing information.
 * 3. When a legal firm must transform multi‑page DjVu case files into PNG evidence images while embedding XMP tags that record the document’s creation date and author.
 * 4. When a publishing workflow requires batch processing of DjVu comic books into PNG pages with XMP metadata for color profile and copyright details.
 * 5. When a content management system automates the ingestion of DjVu technical manuals, converting each page to PNG and adding XMP tags to support image search and categorization.
 */