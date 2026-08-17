// HOW-TO: Use Aspose.Imaging to Median Filter and Sharpen PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\sample.png";
            string medianOutputPath = @"C:\Images\sample.MedianFilter.png";
            string sharpenOutputPath = @"C:\Images\sample.Sharpened.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(medianOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(sharpenOutputPath));

            // Load the original image and apply a median filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply median filter with a kernel size of 5
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the median‑filtered result
                rasterImage.Save(medianOutputPath);
            }

            // Load the median‑filtered image and apply a sharpen filter
            using (Image image = Image.Load(medianOutputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply sharpen filter with kernel size 5 and sigma 4.0
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the final sharpened image
                rasterImage.Save(sharpenOutputPath);
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
 * 1. When you need to remove noise from a scanned PNG before enhancing edges for OCR preprocessing.
 * 2. When preparing product photos for an e‑commerce site, you can clean up speckles and then sharpen details using Aspose.Imaging in C#.
 * 3. When converting raw camera captures to a cleaner PNG for a medical imaging application, applying median then sharpen filters improves visual clarity.
 * 4. When automating a batch process that cleans up scanned documents and accentuates text edges before archiving, this code provides the needed filters.
 * 5. When developing a desktop utility that lets users improve low‑quality screenshots by denoising and sharpening them programmatically.
 */
