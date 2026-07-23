using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.BilateralSharpen.png";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply bilateral smoothing filter (kernel size = 5)
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Apply sharpen filter (kernel size = 5, sigma = 4.0)
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
 * 1. When a developer needs to clean up noisy PNG screenshots from a web application while preserving sharp edges for UI testing, they can use this code to apply bilateral smoothing followed by sharpening.
 * 2. When processing scanned JPEG receipts for OCR, the code reduces grainy background noise and enhances text edges, improving recognition accuracy.
 * 3. When preparing product photos for an e‑commerce catalog, the code removes camera sensor noise and then sharpens product outlines to make details pop in the final PNG thumbnails.
 * 4. When enhancing low‑light security camera footage saved as BMP, the bilateral filter smooths color speckles and the subsequent sharpen filter restores edge definition for better visual analysis.
 * 5. When pre‑processing medical X‑ray images in DICOM converted to raster format, the code suppresses random noise while sharpening bone edges to aid radiologists in diagnosis.
 */