using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Release each page after it is processed to keep memory usage low
                tiffImage.PageExportingAction = (index, page) =>
                {
                    // Force garbage collection for the just‑processed page
                    GC.Collect();
                };

                // Prepare WebP export options (adjust as needed)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80 // example quality setting
                };

                // Save all pages as an animated WebP (single file)
                tiffImage.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert scanned multi‑page TIFF documents into a compact animated WebP file for faster web delivery while keeping memory usage low.
 * 2. When an application must process large multi‑page TIFF medical images on a server with limited RAM and output a single WebP for integration into a web‑based viewer.
 * 3. When a batch job has to transform archival TIFF image stacks into lossily compressed WebP animations for mobile apps without loading all pages into memory at once.
 * 4. When a document management system requires on‑the‑fly conversion of multi‑page TIFF invoices to a single WebP file to reduce storage size and improve loading speed in C#.
 * 5. When a cloud service needs to generate a single WebP preview from a multi‑page TIFF blueprint while using Aspose.Imaging’s page‑exporting action to release each page and avoid out‑of‑memory errors.
 */