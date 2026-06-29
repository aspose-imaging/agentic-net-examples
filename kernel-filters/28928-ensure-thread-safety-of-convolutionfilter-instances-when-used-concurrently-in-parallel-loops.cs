using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input files and output directory
            string[] inputFiles = new string[]
            {
                "Input\\image1.png",
                "Input\\image2.png",
                "Input\\image3.png"
            };
            string outputDir = "Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Process files in parallel; each iteration creates its own filter instance
            System.Threading.Tasks.Parallel.ForEach(inputFiles, inputPath =>
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path and ensure its directory exists
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_filtered.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image as a RasterImage inside a using block for disposal
                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    // Create a fresh filter options instance for this thread to guarantee thread safety
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);

                    // Apply the filter to the whole image
                    raster.Filter(raster.Bounds, filterOptions);

                    // Save the result as PNG
                    raster.Save(outputPath, new PngOptions());
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
 * 1. When a batch image‑processing service needs to apply a Gaussian blur filter to hundreds of PNG files in parallel, ensuring thread‑safe execution while generating thumbnails for a web gallery.
 * 2. When an automated document‑scanning pipeline must sharpen or blur scanned PNG images concurrently to improve OCR accuracy without causing race conditions in the filter instances.
 * 3. When a cloud‑based photo‑editing API processes user‑uploaded PNG pictures simultaneously, applying a convolution filter in a Parallel.ForEach loop while guaranteeing thread safety of each filter object.
 * 4. When a desktop application performs bulk cleanup of PNG assets in a background task, using RasterImage and GaussianBlurFilterOptions to keep the UI responsive and avoid cross‑thread conflicts.
 * 5. When a CI/CD build step validates visual assets by applying a Gaussian blur to a set of PNG files in parallel, detecting processing errors early while maintaining thread‑safe filter usage.
 */