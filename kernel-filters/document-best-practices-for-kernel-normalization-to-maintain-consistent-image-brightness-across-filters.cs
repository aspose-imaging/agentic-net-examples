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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output\normalized.png";

            // Verify that the source file exists
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
                // Work with a raster image to access filter methods
                RasterImage raster = (RasterImage)image;

                // 1. Apply automatic adaptive brightness/contrast.
                // This runs a pipeline (CLAHE, adaptive white stretch, auto white balance)
                // that equalizes local contrast while preserving overall brightness.
                raster.AutoBrightnessContrast();

                // 2. Normalize the histogram so the full dynamic range is used.
                // This step guarantees that subsequent filters start from a consistent brightness level.
                raster.NormalizeHistogram();

                // 3. Apply a sharpen filter.
                // SharpenFilterOptions provides a pre‑normalized kernel, but if you create a custom kernel,
                // ensure its sum equals 1 (or 0 for edge‑enhancement kernels) to keep overall brightness unchanged.
                var sharpenOptions = new SharpenFilterOptions(5, 4.0);
                raster.Filter(raster.Bounds, sharpenOptions);

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a desktop application needs to automatically improve the visual quality of user‑uploaded PNG photos before storing them, this code can apply adaptive brightness/contrast, histogram normalization, and sharpening in one pipeline.
 * 2. When a batch‑processing service must ensure that scanned documents have consistent brightness across varying lighting conditions, the AutoBrightnessContrast and NormalizeHistogram calls guarantee uniform exposure before OCR.
 * 3. When an e‑commerce platform wants to generate product thumbnails with the same perceived brightness regardless of the original image’s lighting, the code normalizes the histogram and applies a pre‑normalized sharpen kernel to keep colors stable.
 * 4. When a medical imaging tool processes radiology images in PNG format and needs to preserve diagnostic brightness while enhancing edges, the kernel normalization step prevents artificial brightening after sharpening.
 * 5. When a content‑management system automatically resizes and enhances uploaded images for web delivery, using Aspose.Imaging’s RasterImage with AutoBrightnessContrast, NormalizeHistogram, and SharpenFilterOptions ensures consistent brightness across all filtered images.
 */