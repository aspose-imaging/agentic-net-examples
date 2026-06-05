using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(inputStream))
            {
                // Prepare GIF save options with interlacing enabled
                GifOptions gifOptions = new GifOptions
                {
                    Interlaced = true
                };

                // Iterate through each page and save as an individual GIF file
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.gif");

                    // Ensure the directory for the output file exists (covers nested paths)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page using the configured GIF options
                    page.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and create web‑friendly interlaced GIFs for faster progressive loading in browsers.
 * 2. When an archival system must convert scanned DjVu files into GIF images while preserving page order for inclusion in an online catalog.
 * 3. When a document‑management application wants to generate thumbnail previews of DjVu pages as interlaced GIFs to reduce bandwidth for mobile users.
 * 4. When a batch‑processing script has to automate the transformation of DjVu lecture notes into GIF images that support progressive rendering for e‑learning platforms.
 * 5. When a digital publishing workflow requires converting DjVu pages to interlaced GIFs so they can be embedded in HTML emails without relying on external plugins.
 */