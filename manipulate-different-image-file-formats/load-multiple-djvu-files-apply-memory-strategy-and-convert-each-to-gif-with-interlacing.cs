// HOW-TO: Convert Multiple DjVu Pages To Interlaced GIFs With Memory Limit In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu files
            string[] inputFiles = new string[]
            {
                @"C:\Images\sample1.djvu",
                @"C:\Images\sample2.djvu"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Images\Output";

            // Memory strategy: limit internal buffers to 2 MB
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.BufferSizeHint = 2 * 1024 * 1024;

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Load DjVu document with memory options
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                    {
                        // Process each page
                        foreach (DjvuPage page in djvuImage.Pages)
                        {
                            // Build output file name (e.g., sample1_page1.gif)
                            string baseName = Path.GetFileNameWithoutExtension(inputPath);
                            string outputPath = Path.Combine(outputDir, $"{baseName}_page{page.PageNumber}.gif");

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save page as GIF with interlacing enabled
                            GifOptions gifOptions = new GifOptions
                            {
                                Interlaced = true
                            };
                            page.Save(outputPath, gifOptions);
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
 * 1. When you need to batch‑convert scanned DjVu documents into web‑ready interlaced GIF images while keeping RAM usage low.
 * 2. When a server‑side application must process large DjVu files page by page without exhausting memory.
 * 3. When you want to generate separate GIF previews of each DjVu page for a document viewer or archive.
 * 4. When you have to automate the conversion of multiple DjVu files in a folder into individual GIF files for sharing or publishing.
 * 5. When you require GIF output with interlacing to improve progressive loading on slow network connections.
 */
