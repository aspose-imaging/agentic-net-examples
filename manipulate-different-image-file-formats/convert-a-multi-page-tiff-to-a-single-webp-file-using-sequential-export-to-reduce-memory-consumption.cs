using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.tif";
        string outputPath = @"C:\temp\output.webp";

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
            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // If the image supports page exporting, release resources after each page
                if (image is RasterCachedMultipageImage cachedMultipage)
                {
                    cachedMultipage.PageExportingAction = (index, page) =>
                    {
                        // Force garbage collection to keep memory usage low
                        GC.Collect();
                    };
                }

                // Prepare WebP export options – export all pages as animation frames
                var webpOptions = new WebPOptions
                {
                    MultiPageOptions = null // null means all pages are exported
                };

                // Save as a single WebP file
                image.Save(outputPath, webpOptions);
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
 * 1. When a medical imaging application must convert large multi‑page TIFF scans into a compact animated WebP for web‑based patient portals while keeping memory usage low.
 * 2. When a document management system needs to archive multi‑page scanned contracts as a single WebP animation to reduce storage costs and avoid loading all pages into memory at once.
 * 3. When a GIS tool processes high‑resolution multi‑layer TIFF maps and wants to deliver them as an animated WebP preview on a mobile app without exhausting server RAM.
 * 4. When an e‑commerce platform transforms multi‑page product catalog TIFFs into a single WebP file for fast loading on product pages while ensuring the conversion runs sequentially to stay within limited cloud instance memory.
 * 5. When a digital publishing workflow converts multi‑page TIFF illustrations into an animated WebP for online magazines, using Aspose.Imaging’s page‑exporting action to trigger garbage collection after each page and prevent out‑of‑memory errors.
 */