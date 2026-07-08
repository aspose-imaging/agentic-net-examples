using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputDirectory = "output";
        string outputPattern = Path.Combine(outputDirectory, "page_{0}.webp");
        string dummyOutputPath = Path.Combine(outputDirectory, "dummy.tif");

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create output directory unconditionally
            Directory.CreateDirectory(Path.GetDirectoryName(outputPattern));
            Directory.CreateDirectory(Path.GetDirectoryName(dummyOutputPath));

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Set batch processing action: save each page as a separate WebP file
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Force garbage collection to keep memory usage low
                    GC.Collect();

                    // Cast the page to RasterImage for saving
                    RasterImage rasterPage = (RasterImage)page;

                    // Build the output file name for this page
                    string pageOutputPath = string.Format(outputPattern, index);

                    // Save the current page as WebP
                    rasterPage.Save(pageOutputPath, new WebPOptions());
                };

                // Trigger the batch export by saving to a dummy TIFF file.
                // The dummy file is not needed after conversion.
                tiffImage.Save(dummyOutputPath);
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
 * 1. When a medical imaging system needs to generate lightweight WebP previews of each page in a large multi‑page TIFF without exhausting server memory.
 * 2. When a publishing workflow must convert scanned book chapters stored as a multi‑page TIFF into separate WebP files for fast web delivery while processing pages one at a time.
 * 3. When an archival tool has to extract individual frames from a multi‑page TIFF surveillance video and save them as WebP thumbnails on a low‑memory IoT device.
 * 4. When a GIS application wants to transform each raster layer in a multi‑page TIFF map into compressed WebP tiles for use in a web‑based map viewer without loading the entire dataset.
 * 5. When an e‑commerce platform needs to batch‑export product catalog pages stored in a multi‑page TIFF into WebP images for responsive web pages while keeping the .NET process memory footprint minimal.
 */