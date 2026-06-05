using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path
            string inputPath = @"C:\Temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory
            string outputDir = @"C:\Temp\GifOutput";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Enable memory optimization by setting a buffer size hint
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 2 * 1024 * 1024 // 2 MB
            };

            // Load DjVu document from stream with the specified load options
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
            {
                // Convert pages 3‑7 (inclusive) to GIF
                for (int pageIndex = 3; pageIndex <= 7 && pageIndex <= djvuImage.PageCount; pageIndex++)
                {
                    // DjvuPages array is zero‑based, page numbers are 1‑based
                    DjvuPage page = djvuImage.DjvuPages[pageIndex - 1];

                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.gif");

                    // Ensure the directory for the output file exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as a GIF image
                    page.Save(outputPath, new GifOptions());
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
 * 1. When a .NET application must extract a subset of pages (e.g., pages 3‑7) from a large DjVu document and save them as lightweight GIF files while minimizing memory usage with Aspose.Imaging’s BufferSizeHint.
 * 2. When an archival system needs to generate preview thumbnails in GIF format for specific DjVu pages to display in a web portal without loading the entire document into memory.
 * 3. When a document‑processing pipeline converts selected DjVu pages to GIF for inclusion in email newsletters, using C# and Aspose.Imaging’s memory‑optimized loading.
 * 4. When a digital publishing tool batch‑converts a range of DjVu pages to GIF for faster client‑side rendering on low‑bandwidth devices, leveraging the LoadOptions buffer size hint.
 * 5. When a forensic analyst extracts only the relevant pages from a multi‑page DjVu file and saves them as GIF images for evidence review, ensuring efficient memory consumption in a C# environment.
 */