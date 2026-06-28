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
            // Hardcoded input DjVu files
            string[] inputFiles = {
                @"C:\temp\file1.djvu",
                @"C:\temp\file2.djvu"
            };

            // Hardcoded output directory
            string outputDir = @"C:\temp\output";

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the DjVu file as a stream
                using (Stream stream = File.OpenRead(inputPath))
                {
                    // Apply memory strategy: limit internal buffers to 1 MB
                    LoadOptions loadOptions = new LoadOptions
                    {
                        BufferSizeHint = 1 * 1024 * 1024 // 1 MB
                    };

                    // Load DjVu document with the specified load options
                    using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream, loadOptions))
                    {
                        // Iterate through each page in the DjVu document
                        foreach (DjvuPage djvuPage in djvuImage.Pages)
                        {
                            // Build output file name (e.g., file1_page1.gif)
                            string outputPath = Path.Combine(
                                outputDir,
                                $"{Path.GetFileNameWithoutExtension(inputPath)}_page{djvuPage.PageNumber}.gif");

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Configure GIF options with interlacing enabled
                            GifOptions gifOptions = new GifOptions
                            {
                                Interlaced = true
                            };

                            // Save the page as an interlaced GIF
                            djvuPage.Save(outputPath, gifOptions);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch convert scanned DjVu archives of historical newspapers into interlaced GIFs for faster web page loading while keeping the application’s memory footprint low.
 * 2. When an e‑learning platform must transform multi‑page DjVu lecture notes into GIF images that can be displayed on browsers that do not support DjVu, using a 1 MB buffer limit to run on low‑memory servers.
 * 3. When a document management system processes user‑uploaded DjVu files and creates GIF thumbnails for each page, applying a memory strategy to avoid out‑of‑memory exceptions during high‑volume processing.
 * 4. When a mobile‑first application downloads DjVu files, extracts each page, and saves them as interlaced GIFs to reduce bandwidth usage while ensuring the conversion runs within the device’s limited RAM.
 * 5. When a batch‑processing script needs to automate the conversion of multiple DjVu files stored in a folder to GIF format with interlacing, while controlling buffer size to keep the .NET process stable on shared hosting environments.
 */