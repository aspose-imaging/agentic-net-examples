// HOW-TO: Convert DjVu Document Pages To PNG Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

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

            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    int pageIndex = 0;
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        page.Save(outputPath, new PngOptions());

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
 * 1. When you need to extract every page of a DjVu file and save them as high‑quality PNG images for web preview or further processing in a .NET application.
 * 2. When a document management system must batch‑convert DjVu archives into separate PNG files to create thumbnails for each page.
 * 3. When an OCR pipeline requires individual PNG pages from a multi‑page DjVu document to feed into a text‑recognition engine.
 * 4. When you want to archive each page of a DjVu manuscript as lossless PNG files while preserving the original page order using Aspose.Imaging for .NET.
 * 5. When a digital publishing workflow needs to split a DjVu e‑book into PNG assets that can be easily edited or annotated in downstream tools.
 */
