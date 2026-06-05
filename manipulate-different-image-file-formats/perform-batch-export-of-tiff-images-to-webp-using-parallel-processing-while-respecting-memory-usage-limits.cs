using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input TIFF files
            string[] inputFiles = new[]
            {
                @"C:\Images\Input1.tif",
                @"C:\Images\Input2.tif",
                @"C:\Images\Input3.tif"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Images\WebPOutput";

            // Ensure the output directory exists once
            Directory.CreateDirectory(outputDir);

            // Limit parallelism to avoid excessive memory consumption
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 2 };

            Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Derive output file path (same name with .webp extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the output directory exists (unconditional as per rules)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Optional: set a page exporting action for multipage TIFFs
                    if (image is TiffImage tiffImage)
                    {
                        tiffImage.PageExportingAction = (index, page) =>
                        {
                            // Release resources after each page is processed
                            GC.Collect();
                        };
                    }

                    // Configure WebP export options
                    var webpOptions = new WebPOptions
                    {
                        // Example settings – adjust as needed
                        Lossless = false,
                        Quality = 80,
                        KeepMetadata = true
                    };

                    // Save as WebP
                    image.Save(outputPath, webpOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When a developer needs to convert a large collection of high‑resolution TIFF scans into smaller WebP files for faster web delivery while keeping CPU usage under control.
 * 2. When an e‑commerce platform must generate WebP thumbnails from multi‑page product catalog TIFFs in parallel without exhausting server memory.
 * 3. When a medical imaging system wants to archive multi‑page DICOM‑derived TIFF reports as WebP images to reduce storage costs while processing several files simultaneously.
 * 4. When a digital asset management tool requires automated batch conversion of TIFF artwork to WebP for mobile apps, using Aspose.Imaging in C# with limited parallel threads to stay within memory quotas.
 * 5. When a cloud‑based image pipeline needs to process incoming TIFF uploads and output WebP versions in a background job, ensuring each page is released promptly to avoid memory leaks.
 */