using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\temp\input";
            string outputDir = @"C:\temp\output";

            // Get all JPEG2000 files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.jp2");

            // Process files in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (convert to PNG)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load JPEG2000 image with memory limit (BufferSizeHint in MB)
                var loadOptions = new Jpeg2000LoadOptions
                {
                    BufferSizeHint = 50 // limit internal buffers to 50 MB
                };

                using (Image image = Image.Load(inputPath, loadOptions))
                {
                    // Save as PNG
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a large archive of high‑resolution JPEG2000 satellite images to PNG for web preview while keeping memory usage low by limiting internal buffers.
 * 2. When a medical imaging application must process thousands of JPEG2000 DICOM scans in parallel on a server and store them as lossless PNG files without exhausting RAM.
 * 3. When an e‑commerce platform wants to generate thumbnail PNGs from a collection of JPEG2000 product photos during nightly maintenance, using Aspose.Imaging’s BufferSizeHint to avoid out‑of‑memory errors.
 * 4. When a digital archiving system has to migrate legacy JPEG2000 documents to PNG format on a multi‑core workstation, employing Parallel.ForEach and a 50 MB buffer limit for efficient CPU and memory utilization.
 * 5. When a GIS tool needs to quickly render multiple JPEG2000 map tiles as PNG overlays for a web map service, ensuring each load operation respects a predefined memory budget.
 */