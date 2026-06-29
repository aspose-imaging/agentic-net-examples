using System;
using System.IO;
using System.Threading.Tasks;
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
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");

            // Limit parallelism to avoid excessive memory consumption
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 2 };

            Parallel.ForEach(tiffFiles, parallelOptions, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same name with .webp extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // If the image is a multipage TIFF, set a page exporting action to free resources per page
                    if (image is TiffImage tiffImage)
                    {
                        tiffImage.PageExportingAction = (index, page) =>
                        {
                            // Force garbage collection to keep memory usage low
                            GC.Collect();
                        };
                    }

                    // Configure WebP export options (adjust as needed)
                    var webpOptions = new WebPOptions
                    {
                        Lossless = false,
                        Quality = 80 // Example quality setting
                    };

                    // Save as WebP
                    image.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert a large collection of high‑resolution TIFF scans into smaller WebP files for faster web delivery while keeping memory usage low.
 * 2. When an e‑commerce platform must generate WebP thumbnails from multi‑page product catalog TIFFs in parallel to speed up the publishing pipeline without exhausting server RAM.
 * 3. When a digital archiving system requires automated nightly batch processing of TIFF documents into WebP format for storage optimization, using controlled parallelism to avoid out‑of‑memory errors.
 * 4. When a photo‑editing application wants to provide users with a one‑click batch export feature that transforms TIFF portfolios into WebP images while ensuring the process runs efficiently on modest hardware.
 * 5. When a content‑management workflow needs to migrate legacy TIFF assets to WebP for modern browsers, employing parallel tasks with a max degree of parallelism to balance performance and resource consumption.
 */