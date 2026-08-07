using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.tif";
        string outputPath = @"c:\temp\output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multipage TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Set page exporting action to process each page individually
                // This releases page resources after each page is saved, reducing memory usage
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Example operation on each page (rotate 90 degrees)
                    ((RasterImage)page).Rotate(90);
                    // Force garbage collection to free memory from previous pages
                    GC.Collect();
                };

                // Save the image using default sequential export mode
                tiffImage.Save(outputPath);
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
 * 1. When a developer needs to rotate every page of a large multipage TIFF (e.g., scanned contracts) on a server with limited RAM, they can use this code to process pages sequentially and keep memory usage low.
 * 2. When an automated document‑archiving workflow must convert incoming multi‑page TIFF files to a new orientation before storing them in a cloud repository, the sequential export mode prevents out‑of‑memory errors.
 * 3. When a desktop application that previews high‑resolution medical scans must apply a 90‑degree rotation to each frame of a multi‑page TIFF without loading the entire image into memory, this approach is ideal.
 * 4. When a batch‑processing script has to apply the same image operation (such as rotation) to thousands of TIFF pages in a print‑preparation pipeline, processing one page at a time reduces the application's footprint.
 * 5. When a web service receives user‑uploaded multi‑page TIFFs and needs to re‑save them after a transformation while ensuring the service stays responsive on modest hardware, the page‑by‑page export strategy provides the necessary memory efficiency.
 */