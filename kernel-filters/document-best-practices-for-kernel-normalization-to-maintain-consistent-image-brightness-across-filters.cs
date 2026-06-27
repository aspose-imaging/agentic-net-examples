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
            // Hard‑coded input and output paths.
            string inputPath = "c:\\temp\\sample.png";
            string outputPath = "c:\\temp\\sample_normalized.png";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filter methods.
                RasterImage raster = (RasterImage)image;

                // ------------------------------------------------------------
                // Kernel Normalization Best Practice:
                // 1. Apply the desired convolution filter (e.g., sharpen).
                // 2. Convolution kernels can shift overall brightness or contrast.
                // 3. Immediately follow with adaptive brightness/contrast correction.
                // 4. Optionally normalize the histogram to stretch pixel values
                //    across the full dynamic range.
                // ------------------------------------------------------------

                // Apply a sharpen filter with a 5×5 kernel and sigma = 4.0.
                var sharpenOptions = new SharpenFilterOptions(5, 4.0);
                raster.Filter(raster.Bounds, sharpenOptions);

                // Adaptive brightness and contrast normalization restores consistent
                // visual appearance after the kernel operation.
                raster.AutoBrightnessContrast();

                // Histogram normalization ensures the full range of pixel intensities
                // is utilized, preventing washed‑out or overly dark results.
                raster.NormalizeHistogram();

                // Save the processed image.
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
 * 1. When a developer needs to sharpen PNG photos for an online gallery while preserving the original brightness, they can load the image with Aspose.Imaging, apply a 5×5 SharpenFilterOptions kernel, and immediately call AutoBrightnessContrast to normalize the result.
 * 2. When processing scanned documents for OCR, a developer can use this code to enhance edge definition with a convolution filter and then automatically adjust brightness and contrast so the text remains legible across varying scan qualities.
 * 3. When preparing product images for an e‑commerce platform, a developer can apply the sharpen filter to JPEG files and rely on the built‑in histogram normalization to ensure consistent visual appearance across all catalog thumbnails.
 * 4. When building a medical imaging viewer that highlights subtle details in X‑ray PNGs, a developer can use the kernel‑based sharpening followed by AutoBrightnessContrast to avoid unintended darkening or overexposure of diagnostic regions.
 * 5. When creating a batch image‑processing pipeline that normalizes lighting conditions after applying custom convolution kernels, a developer can employ this pattern to guarantee each output image maintains a uniform dynamic range regardless of the original exposure.
 */