// HOW-TO: How to Process Multipage TIFF Pages Sequentially to Save Memory in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load the multipage TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Set the page exporting action to process pages one by one
                // This action is called just before each page is saved.
                // It forces garbage collection and performs a sample operation
                // (rotate each page 90 degrees) to illustrate per‑page processing.
                tiffImage.PageExportingAction = delegate (int index, Image page)
                {
                    // Release resources from previous pages
                    GC.Collect();

                    // Example per‑page operation: rotate the page
                    ((RasterImage)page).Rotate(90);
                };

                // Save the processed image; pages are handled sequentially
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
 * 1. When a web service needs to rotate each page of a large multi‑page TIFF without loading the entire file into memory.
 * 2. When a document management system processes high‑resolution scanned TIFFs on a low‑memory server and must apply per‑page transformations.
 * 3. When an automated batch job handles thousands of multi‑page TIFF files and wants to avoid out‑of‑memory exceptions by processing pages one at a time.
 * 4. When a cloud function such as an Azure Function manipulates large TIFF images and must release resources after each page to stay within memory limits.
 * 5. When a developer wants to re‑orient or preview each page of a multi‑page TIFF before archiving it, using Aspose.Imaging’s PageExportingAction for per‑page operations.
 */
