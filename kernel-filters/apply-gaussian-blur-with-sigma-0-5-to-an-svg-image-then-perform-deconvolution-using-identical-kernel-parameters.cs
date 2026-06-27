using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string blurredOutputPath = "output_blur.png";
        string deconvolvedOutputPath = "output_deconvolution.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(blurredOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(deconvolvedOutputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize the SVG to a raster image (default size)
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 3 and sigma 0.5
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(3, 0.5));
                rasterImage.Save(blurredOutputPath);

                // Apply Gaussian deconvolution (Gauss-Wiener) with same kernel parameters
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(3, 0.5));
                rasterImage.Save(deconvolvedOutputPath);
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
 * 1. When creating a low‑resolution blurred thumbnail of an SVG icon for a mobile app’s loading screen and then using the same Gaussian kernel to deconvolve the image for a high‑quality version displayed after loading.
 * 2. When preprocessing SVG diagrams for a scientific report by applying a Gaussian blur to reduce visual noise before printing, and subsequently applying a Gauss‑Wiener deconvolution to restore edge detail for the final PDF.
 * 3. When implementing an automated pipeline that converts SVG assets to PNG, adds a subtle blur for UI background effects, and then runs deconvolution to verify that the blur parameters can be accurately reversed for quality‑control testing.
 * 4. When building a web‑based image editor that lets users apply a Gaussian blur to vector graphics and immediately see the effect of a deconvolution filter using identical kernel settings to understand the limits of image restoration.
 * 5. When generating test data for computer‑vision algorithms by blurring SVG illustrations with sigma 0.5 and then deconvolving them to evaluate the performance of edge‑detection models on both degraded and restored raster images.
 */