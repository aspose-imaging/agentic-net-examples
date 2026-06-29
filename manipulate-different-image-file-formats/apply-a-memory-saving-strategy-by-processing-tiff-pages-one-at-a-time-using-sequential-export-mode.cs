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
            string inputPath = "input.tif";
            string outputPath = "output.tif";

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
                // Process pages one at a time to save memory
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Example per‑page operation (rotate each page 90°)
                    ((RasterImage)page).Rotate(90);

                    // Force garbage collection to release resources of the processed page
                    GC.Collect();
                };

                // Save the processed image
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
 * 1. When a developer needs to rotate each page of a large multi‑page TIFF document on a server with limited RAM, they can use sequential export to process pages one at a time and avoid out‑of‑memory errors.
 * 2. When an automated document‑archiving system must apply per‑page transformations (e.g., watermarks or orientation fixes) to high‑resolution TIFF scans without loading the entire file into memory, this code provides a memory‑efficient solution.
 * 3. When a desktop application processes gigabyte‑size medical imaging TIFF stacks and must ensure the UI remains responsive, processing pages sequentially with Aspose.Imaging reduces the memory footprint.
 * 4. When a cloud‑based microservice receives multi‑page TIFF uploads and needs to re‑encode them while preserving page order, using the PageExportingAction in sequential mode allows safe, low‑memory conversion.
 * 5. When a batch job converts legacy multi‑page TIFF invoices to a standardized format and must run on a CI/CD agent with strict memory limits, this approach processes each page individually to stay within resource constraints.
 */