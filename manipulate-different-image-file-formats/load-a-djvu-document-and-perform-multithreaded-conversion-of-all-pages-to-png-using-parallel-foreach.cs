using System;
using System.IO;
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
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    System.Threading.Tasks.Parallel.ForEach(djvuImage.Pages, pageObj =>
                    {
                        var djvuPage = (DjvuPage)pageObj;
                        string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        djvuPage.Save(outputPath, new PngOptions());
                    });
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
 * 1. When a developer needs to quickly convert every page of a multi‑page DjVu document into high‑quality PNG images for web preview, using Aspose.Imaging and Parallel.ForEach to speed up the process.
 * 2. When an archival system must extract and store each page of scanned DjVu files as separate PNG files for downstream OCR or indexing pipelines, leveraging C# multithreading for efficiency.
 * 3. When a desktop application has to batch‑process large DjVu manuals into PNG thumbnails for a document viewer’s navigation pane, employing Aspose.Imaging’s DjvuImage and parallel page conversion.
 * 4. When a cloud service receives DjVu uploads and must generate PNG assets for each page on the fly, using the provided code to handle file I/O, page enumeration, and concurrent saving.
 * 5. When a developer wants to integrate DjVu‑to‑PNG conversion into a CI/CD build step that validates visual assets, using the example to read the DjVu stream, iterate pages, and save PNGs in parallel.
 */