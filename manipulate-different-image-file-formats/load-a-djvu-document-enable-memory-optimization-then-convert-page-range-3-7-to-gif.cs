using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/pages_3_7.gif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Open the DjVu file with memory optimization
            using (FileStream stream = File.OpenRead(inputPath))
            {
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.BufferSizeHint = 1 * 1024 * 1024; // 1 MB buffer

                using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
                {
                    // Define page range 3‑7 (inclusive)
                    int[] pages = new int[] { 3, 4, 5, 6, 7 };
                    DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(pages);

                    // Set GIF save options with the specified page range
                    GifOptions gifOptions = new GifOptions
                    {
                        MultiPageOptions = multiPageOptions
                    };

                    // Save the selected pages as a GIF
                    djvuImage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract pages 3‑7 from a multi‑page DjVu document and save them as an animated GIF for quick web preview.
 * 2. When an application must load a large DjVu file with memory‑optimized buffering before converting a specific page range to a lightweight GIF format.
 * 3. When an automated workflow generates GIF thumbnails of selected DjVu pages (e.g., 3‑7) to embed in email newsletters or reports.
 * 4. When a document management system provides end‑users with a fast GIF preview of a subset of pages from a scanned DjVu archive without loading the entire file into memory.
 * 5. When a C# service programmatically reads a DjVu file, selects pages 3‑7, and saves them as a single GIF to ensure compatibility with browsers that do not support DjVu.
 */