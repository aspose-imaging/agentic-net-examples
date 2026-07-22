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
            // Hardcoded input path
            string inputPath = "input.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure GIF options with interlacing enabled
                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };

                    // Iterate through each page in the DjVu document
                    foreach (var page in djvuImage.Pages)
                    {
                        // Cast to DjvuPage to access PageNumber
                        var djvuPage = (Aspose.Imaging.FileFormats.Djvu.DjvuPage)page;

                        // Build output file name for the current page
                        string outputPath = $"output_page_{djvuPage.PageNumber}.gif";

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                        // Save the page as a GIF using the configured options
                        djvuPage.Save(outputPath, gifOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and generate web‑friendly interlaced GIF images for faster progressive loading in browsers.
 * 2. When an archival system must convert scanned DjVu files into GIF format with interlacing enabled to preserve image quality while reducing file size for online viewing.
 * 3. When a C# application processes legacy DjVu manuals and creates separate GIF files per page to integrate with a content management system that only supports GIF assets.
 * 4. When a batch‑processing script has to read DjVu streams, apply custom GifOptions such as Interlaced = true, and save each page as an interlaced GIF for email newsletters.
 * 5. When a developer wants to programmatically verify the existence of DjVu pages, convert them to interlaced GIFs, and store the results in a structured folder hierarchy using Aspose.Imaging for .NET.
 */