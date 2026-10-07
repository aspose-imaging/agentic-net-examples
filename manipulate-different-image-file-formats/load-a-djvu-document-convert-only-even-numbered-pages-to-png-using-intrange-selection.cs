// HOW-TO: Convert Even Pages of DjVu to PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;

                for (int i = 0; i < pageCount; i++)
                {
                    // Convert only even-numbered pages (1-based indexing)
                    if ((i + 1) % 2 != 0)
                        continue;

                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        IntRange range = new IntRange(i, i);
                        pngOptions.MultiPageOptions = new DjvuMultiPageOptions(range);
                        djvu.Save(outputPath, pngOptions);
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
 * 1. When you need to extract only the even-numbered pages from a multi‑page DjVu file and save them as high‑quality PNG images for web publishing.
 * 2. When automating a workflow that processes scanned books in DjVu format but only the even pages contain the content you want to archive as PNG.
 * 3. When generating thumbnails for every second page of a DjVu document to reduce storage while preserving visual fidelity.
 * 4. When creating a batch conversion tool that skips odd pages to speed up processing of large DjVu archives and outputs PNG files for downstream image analysis.
 * 5. When integrating Aspose.Imaging into a C# application to selectively export specific pages (e.g., even pages) from DjVu to PNG for printing or OCR pipelines.
 */
