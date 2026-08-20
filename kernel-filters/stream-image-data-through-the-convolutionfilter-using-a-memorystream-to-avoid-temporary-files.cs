// HOW-TO: Apply Gaussian Blur To PNG Using MemoryStream In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input\\sample.png";
            string outputPath = "output\\filtered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read the input image into a memory stream
            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                // Load image from the memory stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a Gaussian blur filter (convolution filter) to the whole image
                    rasterImage.Filter(rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the filtered image to the output path as PNG
                    PngOptions pngOptions = new PngOptions();
                    rasterImage.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to blur a PNG image on the server without creating intermediate files, you can load it into a MemoryStream and apply a Gaussian convolution filter.
 * 2. When processing user‑uploaded photos in a web API, using Aspose.Imaging with a MemoryStream lets you apply smoothing effects while keeping the operation fully in memory.
 * 3. When building a batch image‑processing tool that must preserve original file locations, streaming the image data avoids disk I/O overhead and enables fast Gaussian blur.
 * 4. When integrating image filters into a C# desktop application that works with limited storage, using a MemoryStream and the RasterImage.Filter method applies the blur without temporary files.
 * 5. When converting raw image bytes received from a network service into a filtered PNG, the code demonstrates how to load, filter, and save the image entirely in memory.
 */
