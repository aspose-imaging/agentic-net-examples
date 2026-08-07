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
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");

            // Parallel options to limit degree of parallelism (memory usage)
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

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

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // If the image is a multipage TIFF, set PageExportingAction to release resources after each page
                    if (image is TiffImage tiffImage)
                    {
                        tiffImage.PageExportingAction = (index, page) =>
                        {
                            // Release resources for the processed page
                            GC.Collect();
                        };
                    }

                    // Configure WebP export options (adjust quality as needed)
                    var webpOptions = new WebPOptions
                    {
                        Lossless = false,
                        Quality = 80
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
 * 1. When a developer needs to convert a large collection of high‑resolution TIFF photographs to lightweight WebP files for faster web delivery while keeping CPU usage in check.
 * 2. When an e‑commerce platform must batch‑process product catalog images stored as multipage TIFFs into WebP thumbnails using parallel threads without exceeding server memory limits.
 * 3. When a digital archiving system requires automated nightly conversion of scanned TIFF documents to WebP format for storage optimization, leveraging Aspose.Imaging’s page‑wise export to free resources.
 * 4. When a mobile app backend has to generate WebP assets from legacy TIFF assets on the fly, processing many files concurrently in C# while controlling the degree of parallelism.
 * 5. When a content management workflow needs to migrate legacy TIFF graphics to WebP for SEO‑friendly web pages, using Aspose.Imaging’s parallel ForEach to speed up the batch export while preventing out‑of‑memory errors.
 */