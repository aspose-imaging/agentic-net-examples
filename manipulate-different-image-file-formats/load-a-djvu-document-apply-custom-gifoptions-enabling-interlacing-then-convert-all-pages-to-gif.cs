using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the DjVu file as a stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(inputStream))
                {
                    // Prepare GIF save options with interlacing enabled
                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };

                    // Iterate through each page and save as GIF
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.gif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as GIF using the specified options
                        page.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and generate web‑friendly interlaced GIF images for progressive loading.
 * 2. When an archival system must batch‑convert scanned DjVu files into separate GIF files while preserving page order for downstream processing.
 * 3. When a digital publishing workflow requires converting DjVu chapters into individual GIFs with interlacing enabled so they can be embedded in HTML emails.
 * 4. When a document‑management application wants to create thumbnail previews of DjVu pages as interlaced GIFs for quick visual indexing.
 * 5. When a C# utility must read a DjVu stream, apply custom GifOptions, and save each page as a GIF in a specified output folder for offline viewing on devices that only support GIF.
 */