// HOW-TO: Convert DjVu Pages 3 To 7 To A Single GIF In C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputPath = @"C:\Temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load options with memory optimization (buffer size hint)
            var loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB buffer
            };

            // Open the DjVu file stream and load the image with the specified options
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
            {
                // Define the page range 3‑7 (DjVu pages are 1‑based)
                int[] pages = new int[] { 3, 4, 5, 6, 7 };

                // Configure GIF save options with multi‑page settings
                var gifOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(pages)
                };

                // Save the selected pages as a single GIF file
                djvuImage.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a specific range of pages from a large DjVu document and create a multi‑frame GIF for web preview.
 * 2. When memory usage is a concern, such as processing high‑resolution DjVu files on a server with limited RAM, and you want to load the file with a buffer hint.
 * 3. When you want to automate the conversion of selected DjVu pages into a GIF to embed in a report or presentation without manual editing.
 * 4. When building a batch job that processes multiple DjVu files and generates GIFs for only the relevant pages, reducing storage and processing time.
 * 5. When integrating DjVu‑to‑GIF conversion into a C# application that must handle page‑specific rendering, like creating thumbnails or previews for a document management system.
 */
