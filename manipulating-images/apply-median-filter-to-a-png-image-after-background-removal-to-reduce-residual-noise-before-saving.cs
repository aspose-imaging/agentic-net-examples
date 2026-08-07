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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Remove background if the image type supports it
                if (image is VectorImage vectorImg)
                {
                    vectorImg.RemoveBackground();
                }

                // Apply median filter to the entire image
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When cleaning up scanned PNG graphics that contain unwanted background before further analysis, a developer can use this code to remove the background and apply a median filter to reduce noise.
 * 2. When preparing product catalog images for web publishing, a developer may need to strip vector backgrounds from PNG files and smooth residual speckles with a median filter before saving the optimized output.
 * 3. When converting vector‑based PNG icons to raster format for a mobile app, a developer can employ this code to eliminate the background and denoise the image to improve visual clarity on high‑resolution screens.
 * 4. When performing pre‑processing on PNG screenshots captured from a UI test suite, a developer can use the median filter after background removal to ensure consistent pixel data for automated image comparison.
 * 5. When building an automated pipeline that ingests PNG files from user uploads, a developer may need to automatically clean the images by removing any embedded background and applying a median filter to suppress compression artifacts before storing them.
 */