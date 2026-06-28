using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel operations
                var raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Resize to 1200x1200 pixels
                raster.Resize(1200, 1200);

                // Apply a median filter with a kernel size of 5
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Prepare SVG save options with matching page size
                var svgOptions = new SvgOptions();
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = raster.Size
                };
                svgOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save the processed image as SVG
                raster.Save(outputPath, svgOptions);
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
 * 1. When a web application must generate a high‑resolution 1200×1200 thumbnail from a user‑uploaded JPEG, clean up noise with a median filter, and deliver the result as a scalable SVG for responsive design.
 * 2. When an e‑commerce platform needs to convert product photos into vector‑compatible SVG files after resizing them to a uniform square size and reducing speckle artifacts for faster page loads.
 * 3. When a desktop utility processes scanned documents by resizing them, applying a median filter to remove scanning noise, and saving them as SVG to preserve quality while enabling zoom without pixelation.
 * 4. When a mobile app backend prepares avatar images by standardizing dimensions, smoothing edges with a median filter, and storing them in SVG format for cross‑platform rendering.
 * 5. When a reporting service transforms chart screenshots into scalable SVG graphics, ensuring a consistent 1200×1200 size and applying a median filter to improve visual clarity before embedding in PDFs.
 */