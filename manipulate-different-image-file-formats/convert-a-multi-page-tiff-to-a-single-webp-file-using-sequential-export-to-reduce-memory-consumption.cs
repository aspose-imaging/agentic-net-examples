using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.webp";

        // Path safety checks
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
                // Prepare WebP export options (export all pages as animated frames)
                var exportOptions = new WebPOptions();

                // If the source is a raster‑cached multipage image, release each page after it is saved
                if (image is RasterCachedMultipageImage rasterImage)
                {
                    rasterImage.PageExportingAction = (index, page) =>
                    {
                        // Force garbage collection to keep memory usage low
                        GC.Collect();
                        // Release the page resources
                        ((RasterImage)page).Dispose();
                    };
                }

                // Export the TIFF pages to a single WebP file
                image.Save(outputPath, exportOptions);
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
 * 1. When a web application must display a multi‑page scanned document as an animated WebP image to reduce bandwidth while keeping server memory usage low, this code converts the TIFF to a single WebP file using sequential export.
 * 2. When a mobile backend service processes large multi‑page TIFF invoices and needs to deliver them as compact WebP files for faster download on low‑memory devices, the code performs the conversion efficiently.
 * 3. When an e‑learning platform batches multi‑page diagram TIFFs into animated WebP slideshows, it uses this code to export pages sequentially and avoid loading the entire TIFF into memory.
 * 4. When a digital archiving tool migrates legacy TIFF archives to modern WebP format on a Windows server with limited RAM, the code ensures the conversion stays within memory constraints.
 * 5. When a cloud‑based image processing pipeline generates a single WebP animation from a multi‑page TIFF without triggering out‑of‑memory exceptions in a C# application, this code provides the required solution.
 */