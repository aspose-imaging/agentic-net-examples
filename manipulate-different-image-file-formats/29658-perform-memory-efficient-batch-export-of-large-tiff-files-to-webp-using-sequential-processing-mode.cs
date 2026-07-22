using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input TIFF file path
            string inputPath = @"C:\Images\LargeDocument.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for WebP files
            string outputDir = @"C:\Images\WebpOutput";

            // Ensure the output directory exists (rule 3)
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Set up sequential processing: handle each page just before it is saved
                tiffImage.PageExportingAction = (int index, Image page) =>
                {
                    // Force garbage collection to keep memory usage low
                    GC.Collect();

                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{index}.webp");

                    // Ensure the directory for this output file exists (rule 3)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the current page as WebP
                    page.Save(outputPath, new WebPOptions());

                    // After saving, the page resources will be released automatically
                };

                // Trigger processing of all pages by saving the TIFF (no actual file needed)
                // The delegate will be invoked for each page
                tiffImage.Save(Path.Combine(outputDir, "dummy.tif"));
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
 * 1. When a developer needs to convert each page of a multi‑page TIFF document (such as scanned contracts) into separate WebP files while keeping RAM usage low.
 * 2. When a web application must serve high‑resolution scanned images as lightweight WebP thumbnails without loading the entire TIFF into memory.
 * 3. When an archival system processes large TIFF archives overnight and requires sequential page export to WebP to avoid out‑of‑memory crashes.
 * 4. When a digital publishing workflow needs to transform massive TIFF pages into web‑optimized WebP assets on a server with limited resources.
 * 5. When a batch image‑processing script must export every page of a multi‑page TIFF to WebP in a .NET environment using Aspose.Imaging’s sequential processing mode.
 */