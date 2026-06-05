using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the TIFF image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to TiffImage for TIFF-specific operations
                TiffImage tiffImage = (TiffImage)image;

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                tiffImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1);

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
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
 * 1. When converting high‑resolution scanned TIFF documents to web‑friendly PNGs while reducing file size with 1‑bit Floyd‑Steinberg dithering and smoothing edges using a Gaussian blur.
 * 2. When preparing archival TIFF images for printing on low‑resolution printers by applying dithering and blur before saving as PNG to ensure consistent tonal output.
 * 3. When building a C# batch‑processing tool that automatically cleans up noisy TIFF scans by dithering and applying a Gaussian blur, then stores the results as PNG for downstream workflows.
 * 4. When developing a .NET application that needs to display TIFF maps on a UI, and the developer wants to reduce color depth with Floyd‑Steinberg dithering and soften details with Gaussian blur before converting to PNG.
 * 5. When creating a server‑side image pipeline in ASP.NET that receives TIFF uploads, applies dithering and blur to improve visual quality, and returns the processed image as a PNG response.
 */