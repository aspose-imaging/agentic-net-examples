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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Retry logic for transient I/O errors during loading
            const int maxRetries = 3;
            int attempt = 0;
            Image loadedImage = null;

            while (true)
            {
                try
                {
                    loadedImage = Image.Load(inputPath);
                    break; // Success
                }
                catch (IOException)
                {
                    attempt++;
                    if (attempt >= maxRetries)
                    {
                        Console.Error.WriteLine($"Failed to load image after {maxRetries} attempts.");
                        return;
                    }
                    // Optionally, could log retry attempt here
                }
            }

            // Use using block for proper disposal
            using (loadedImage)
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)loadedImage;

                // Apply a Gaussian blur filter to the entire image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the filtered image as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a desktop application processes PNG files from a removable USB drive that may experience temporary read errors, this code retries loading the image before applying a Gaussian blur filter.
 * 2. When a server‑side batch job reads images stored on a network file share and must handle intermittent I/O timeouts, the retry logic ensures the image is loaded before filtering and saving as PNG.
 * 3. When an automated image‑processing pipeline ingests user‑uploaded photos from a cloud‑synced folder that can momentarily be unavailable, the code retries the load to avoid aborting the Gaussian blur operation.
 * 4. When a Windows service monitors a directory for new images and needs to gracefully handle occasional file‑locking issues caused by other processes, the retry mechanism loads the image safely before applying the filter.
 * 5. When a C# utility converts scanned PNG documents to blurred versions for privacy compliance and must tolerate sporadic disk read glitches, this code retries the load and then saves the filtered result.
 */