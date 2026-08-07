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
            string inputPath = "Input\\sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                Image[] pages = djvuImage.Pages;

                System.Threading.Tasks.Parallel.ForEach(pages, pageObj =>
                {
                    DjvuPage page = (DjvuPage)pageObj;
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    page.Save(outputPath, new PngOptions());
                });
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
 * 1. When a developer needs to batch‑convert a multi‑page DjVu document into individual PNG images for web preview, using C# and Aspose.Imaging to speed up the process with Parallel.ForEach.
 * 2. When an archival system must extract each page of scanned DjVu files and store them as high‑quality PNG thumbnails for quick indexing, leveraging multithreaded conversion in .NET.
 * 3. When a document‑management application requires on‑the‑fly transformation of DjVu pages to PNG format for compatibility with browsers that do not support DjVu, using Aspose.Imaging’s parallel processing capabilities.
 * 4. When a digital publishing workflow needs to generate PNG assets from large DjVu ebooks to feed into a content‑delivery network, employing C# parallel loops to reduce conversion time.
 * 5. When a batch‑processing script must automate the extraction of every page from a DjVu file and save them as separate PNG files for downstream OCR or image analysis, utilizing Aspose.Imaging and Parallel.ForEach for efficiency.
 */