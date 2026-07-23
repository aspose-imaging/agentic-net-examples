using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_sharpened.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply a median filter (size = 5) to reduce noise
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Apply a sharpen filter (kernel size = 5, sigma = 4.0) to accentuate edges
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

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
 * 1. When a developer needs to clean up a noisy PNG screenshot and then enhance its edges for clearer visual inspection, they can apply a median filter followed by a sharpen filter using Aspose.Imaging for .NET.
 * 2. When preparing scanned documents in PNG format for OCR, a developer can reduce speckle noise with a median filter and then sharpen the text edges to improve character recognition accuracy.
 * 3. When generating thumbnails of product photos, a developer may first remove background grain with a median filter and then apply a sharpen filter to make the product details stand out in the small image.
 * 4. When processing medical imaging data saved as raster PNG files, a developer can use the median filter to suppress sensor noise and the sharpen filter to highlight anatomical edges for better diagnostic viewing.
 * 5. When creating visual assets for a game UI, a developer can clean up hand‑drawn PNG assets with a median filter and then accentuate outlines with a sharpen filter to ensure crisp edges on different screen resolutions.
 */