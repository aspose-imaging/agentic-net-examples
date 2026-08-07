using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directory paths
            string inputPath = "input.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output file paths
            List<string> outputPaths = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                string outputPath = $"output_{i}.png";
                outputPaths.Add(outputPath);
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            }

            // Apply Sharpen filter concurrently using separate filter instances per thread
            System.Threading.Tasks.Parallel.For(0, outputPaths.Count, i =>
            {
                // Load the source image for each parallel iteration
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Each thread gets its own SharpenFilterOptions instance (thread‑safe)
                    var filterOptions = new SharpenFilterOptions(5, 4.0);
                    image.Filter(image.Bounds, filterOptions);

                    // Save the processed image
                    var saveOptions = new PngOptions();
                    image.Save(outputPaths[i], saveOptions);
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
 * 1. When a web service needs to generate multiple sharpened thumbnails of a PNG image simultaneously to serve high‑traffic requests.
 * 2. When a desktop batch‑processing tool must apply a sharpening filter to a large collection of PNG files in parallel to reduce overall processing time.
 * 3. When an automated image‑analysis pipeline runs on a multi‑core server and requires thread‑safe convolution filters to preprocess PNG scans before feature extraction.
 * 4. When a cloud function processes user‑uploaded PNG pictures concurrently, applying a sharpen filter to each image without risking shared‑state corruption.
 * 5. When a real‑time video‑frame renderer extracts individual PNG frames and applies a convolution filter in parallel threads to maintain smooth playback.
 */