using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            ApplyFilterPipeline(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Reusable pipeline: bilateral smoothing -> sharpen -> median filter
    static void ApplyFilterPipeline(string inputPath, string outputPath)
    {
        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply bilateral smoothing filter (kernel size 5)
            var bilateralOptions = new BilateralSmoothingFilterOptions(5);
            rasterImage.Filter(rasterImage.Bounds, bilateralOptions);

            // Apply sharpen filter (kernel size 5, sigma 4.0)
            var sharpenOptions = new SharpenFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

            // Apply median filter (size 5)
            var medianOptions = new MedianFilterOptions(5);
            rasterImage.Filter(rasterImage.Bounds, medianOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to denoise a scanned PNG document while preserving edges before performing OCR, they can apply the bilateral smoothing → sharpen → median filter pipeline to improve readability.
 * 2. When preparing product photos in JPEG or PNG format for an e‑commerce site, the pipeline smooths color variations, enhances fine details, and removes residual speckles for a cleaner presentation.
 * 3. When cleaning up medical images converted to PNG (e.g., from DICOM) for a research report, the code improves visual clarity without compromising diagnostic features.
 * 4. When processing individual frames extracted from a video (BMP or PNG) to enhance a slideshow, the reusable filter sequence can be applied to each frame for consistent quality.
 * 5. When automating batch enhancement of user‑uploaded avatar PNG files, the pipeline ensures uniform noise reduction and sharpness across all images.
 */