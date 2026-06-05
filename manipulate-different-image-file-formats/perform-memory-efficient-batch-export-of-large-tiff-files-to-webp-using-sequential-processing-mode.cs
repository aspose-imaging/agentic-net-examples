using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\large_input.tif";
            string outputDirectory = @"C:\Images\WebP_Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Process each page sequentially to keep memory usage low
                for (int pageIndex = 0; pageIndex < tiffImage.PageCount; pageIndex++)
                {
                    // Retrieve the current page
                    using (Image page = tiffImage.Pages[pageIndex])
                    {
                        // Build the output WebP file path for this page
                        string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.webp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as WebP using default options
                        page.Save(outputPath, new WebPOptions());

                        // Explicitly release resources for the page
                        ((RasterImage)page).Dispose();
                    }

                    // Force garbage collection to free any lingering memory
                    GC.Collect();
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
 * 2. When an application must batch‑export scanned documents stored as a single TIFF into web‑optimized WebP thumbnails on a server with limited RAM.
 * 3. When a photo‑management tool processes high‑resolution TIFF slides and saves each slide as a WebP image for fast web delivery without loading the entire file into memory.
 * 4. When an automated pipeline extracts individual pages from a multi‑page TIFF invoice and stores them as WebP files for inclusion in a web‑based reporting dashboard.
 * 5. When a cloud service needs to sequentially read a massive TIFF map and generate lightweight WebP tiles for an interactive map viewer while preventing out‑of‑memory errors.
 */