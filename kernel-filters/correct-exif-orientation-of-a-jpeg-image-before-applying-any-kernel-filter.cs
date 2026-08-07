using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access raster-specific methods
                RasterImage raster = (RasterImage)image;

                // Correct orientation based on EXIF data
                raster.AutoRotate();

                // Apply a sharpen filter to the entire image
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the processed image
                image.Save(outputPath, jpegOptions);
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
 * 1. When processing user‑uploaded photos for a web gallery, a developer must auto‑rotate JPEGs based on EXIF orientation before sharpening them to ensure thumbnails display correctly.
 * 2. When building a desktop photo‑editing tool that applies kernel filters, a developer needs to correct the image’s orientation first so the filter aligns with the visual content.
 * 3. When generating print‑ready images from mobile camera shots, a developer uses this code to normalize EXIF rotation and then enhance edge detail with a sharpen filter.
 * 4. When creating an automated batch‑processing pipeline for product catalog images, a developer employs the routine to fix orientation and improve clarity before saving high‑quality JPEGs.
 * 5. When integrating image preprocessing into a machine‑learning data pipeline, a developer applies AutoRotate and a sharpen filter to JPEG inputs to provide consistently oriented and sharpened training data.
 */