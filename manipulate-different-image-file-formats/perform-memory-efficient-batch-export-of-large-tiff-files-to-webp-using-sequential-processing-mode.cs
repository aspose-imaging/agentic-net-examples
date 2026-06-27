using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\large.tif";
        string outputDirectory = @"C:\Images\WebP";

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

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Enable sequential processing: release resources after each page is handled
                tiffImage.PageExportingAction = (index, page) =>
                {
                    // Force garbage collection to keep memory usage low
                    GC.Collect();
                };

                // Iterate through each page and save it as a separate WebP file
                for (int i = 0; i < tiffImage.PageCount; i++)
                {
                    // Retrieve the current page as an Image
                    Image page = tiffImage.Pages[i];

                    // Build output file path for this page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i}.webp");

                    // Ensure the directory for the output file exists (already created above)
                    // Save the page using WebP format
                    WebPOptions webpOptions = new WebPOptions(); // default options; customize if needed
                    page.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert each page of a multi‑page TIFF archive into separate WebP files while keeping memory usage low for large images.
 * 2. When an application processes high‑resolution scanned documents and must export them to web‑friendly WebP format without loading the entire TIFF into memory.
 * 3. When a batch image‑conversion service must handle thousands of TIFF pages on a server with limited RAM by using sequential processing and explicit garbage collection.
 * 4. When a digital archiving workflow requires extracting individual pages from a large TIFF and saving them as compressed WebP thumbnails for fast web preview.
 * 5. When a C# utility needs to automate the migration of legacy TIFF assets to modern WebP format while ensuring each page is saved independently and resources are released after each export.
 */