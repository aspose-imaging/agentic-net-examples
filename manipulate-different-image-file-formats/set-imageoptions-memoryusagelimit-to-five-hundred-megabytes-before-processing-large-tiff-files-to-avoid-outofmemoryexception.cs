using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\large.tif";
            string outputPath = @"C:\Images\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image with a memory usage limit of 500 MB
            var loadOptions = new LoadOptions
            {
                BufferSizeHint = 500 // limit internal buffers to 500 MB
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Prepare save options with the same memory limit
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BufferSizeHint = 500 // limit internal buffers during save
                };

                // Save the processed image
                image.Save(outputPath, saveOptions);
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
 * 1. When a C# web service loads multi‑gigapixel medical TIFF scans and sets ImageOptions.MemoryUsageLimit to 500 MB before processing to prevent OutOfMemoryException during format conversion.
 * 2. When a desktop batch‑processing application reads high‑resolution satellite TIFF images and applies ImageOptions.MemoryUsageLimit of 500 MB to keep memory consumption within the limits of machines with 8 GB RAM.
 * 3. When an automated document‑archiving system extracts pages from large multi‑page TIFF files and uses ImageOptions.MemoryUsageLimit set to 500 MB to safely save new TIFF files without crashing.
 * 4. When a cloud‑based image‑conversion microservice receives massive user‑uploaded TIFFs and configures ImageOptions.MemoryUsageLimit to 500 MB to stay under container memory quotas while re‑encoding.
 * 5. When a GIS desktop tool loads extensive geospatial TIFF layers and specifies ImageOptions.MemoryUsageLimit of 500 MB to avoid exhausting system memory during load and save operations.
 */